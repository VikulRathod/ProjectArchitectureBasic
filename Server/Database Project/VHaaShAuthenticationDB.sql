create database VHaaShAuthenticationDB

go

use VHaaShAuthenticationDB

go

Create table tblUser
(
 [Id] int identity primary key,
 [UserName] nvarchar(100),
 [Password] nvarchar(200),
 [Email] nvarchar(100), 
 [RegisteredDateTime] datetime,
 [ModifiedDateTime] datetime,
 [DeletedDateTime] datetime,
 [IsActive] bit,
 [RetryAttempts] int,
 [IsLocked] bit,
 [LockedDateTime] datetime,
) 

go

CREATE proc usp_RegisterUser  
@UserName nvarchar(100),  
@Password nvarchar (200),  
@Email nvarchar (200),
@ReturnCode int out
as  
Begin  
 Declare @Count int   
   
 Select @Count = COUNT(UserName)   
 from tblUser where UserName = @UserName and Email = @Email
	 If @Count > 0  
	 Begin  
	  Set @ReturnCode = -1  
	 End  
 Else  
	 Begin  
	  Set @ReturnCode = 1  
	  Insert into tblUser([UserName], [Password], [Email], [RegisteredDateTime], [IsActive]) 
	  values  (@UserName, @Password, @Email, GETDATE(), 1)  
	 End  
 Select @ReturnCode as ReturnValue  
End  

go

create proc usp_AuthenticateUser
@UserName nvarchar(100),
@Password nvarchar(200),
@AccountLocked bit out,
@Authenticated bit out,
@RetryCount int out
as
Begin
 Declare @Count int
 
 Select @AccountLocked = IsLocked
 from tblUser where UserName = @UserName
 
if @AccountLocked is null 
	Begin
		  set @AccountLocked = 0
		  set @Authenticated = 0
		  set @RetryCount = 0
	End
else if(@AccountLocked = 1)
	 Begin
		  set @AccountLocked = 1
		  set @Authenticated = 0
		  set @RetryCount = 0
	 End
Else
 Begin
  Select @Count = COUNT(UserName) from tblUser
  where [UserName] = @UserName and [Password] = @Password
  
  if(@Count = 1)
  Begin 
   Update tblUser set RetryAttempts = 0
   where UserName = @UserName
       
	  set @AccountLocked = 0
	  set @Authenticated = 1
	  set @RetryCount = 0
  End
  Else
  Begin
	   Select @RetryCount = IsNULL(RetryAttempts, 0)
	   from tblUser
	   where UserName = @UserName   
	   Set @RetryCount = @RetryCount + 1
   
   if(@RetryCount <= 3)
	   Begin
			Update tblUser set RetryAttempts = @RetryCount
			where UserName = @UserName 
    
			set @AccountLocked = 0
			set @Authenticated = 1
			set @RetryCount = @RetryCount
	   End
   Else
	   Begin
			Update tblUser set RetryAttempts = @RetryCount,
			IsLocked = 1, LockedDateTime = GETDATE()
			where UserName = @UserName

			set @AccountLocked = 1
			set @Authenticated = 1
			set @RetryCount = 0
	   End
  End
 End
End

go
Create table tblResetPasswordRequests
(
 Id UniqueIdentifier Primary key,
 UserId int Foreign key references tblUser(Id),
 ResetRequestDateTime DateTime
)

go

create proc usp_ResetPassword
@UserName nvarchar(100), @ReturnCode int out, 
@UniqueId UniqueIdentifier out, @Email nvarchar(100) out
as
Begin
 Declare @UserId int
 
 Select @UserId = Id, @Email = Email 
 from tblUser
 where UserName = @UserName
 
 if(@UserId IS NOT NULL)
 Begin
	  Declare @GUID UniqueIdentifier
	  Set @GUID = NEWID()
  
	  Insert into tblResetPasswordRequests
	  (Id, UserId, ResetRequestDateTime)
	  Values(@GUID, @UserId, GETDATE())
  
		set @ReturnCode = 1
		set @UniqueId = @GUID
 End
 Else
 Begin
		set @ReturnCode = 0
		set @UniqueId = null
		set @Email = null
 End
End

go

Create Proc usp_IsPasswordResetLinkValid 
@GUID uniqueidentifier, 
@IsValidPasswordResetLink bit out
as
Begin
 Declare @UserId int
 
 If(Exists(Select UserId from tblResetPasswordRequests where Id = @GUID))
 Begin
  set @IsValidPasswordResetLink = 1
 End
 Else
 Begin
  set @IsValidPasswordResetLink = 0
 End
End


go

Create Proc usp_ChangePassword
@GUID uniqueidentifier,
@Password nvarchar(100),
@IsPasswordChanged bit out
as
Begin
 Declare @UserId int
 
 Select @UserId = UserId 
 from tblResetPasswordRequests
 where Id= @GUID
 
 if(@UserId is null)
	 Begin
		set @IsPasswordChanged = 0
	 End
 Else
 Begin
	  Update tblUser set
	  [Password] = @Password, [ModifiedDateTime] = GETDATE() 
	  where Id = @UserId
  
	  Delete from tblResetPasswordRequests
	  where Id = @GUID
  
	  set @IsPasswordChanged = 1
 End
End

go

Create Proc usp_ChangePasswordUsingCurrentPassword
@UserName nvarchar(100),
@CurrentPassword nvarchar(100),
@NewPassword nvarchar(100),
@IsPasswordChanged bit out
as
Begin
 if(Exists(Select Id from tblUser 
     where UserName = @UserName
     and [Password] = @CurrentPassword))
 Begin
  Update tblUser
  Set [Password] = @NewPassword, [ModifiedDateTime] = GETDATE()
  where UserName = @UserName
  
  set @IsPasswordChanged = 1
 End
 Else
 Begin
  set @IsPasswordChanged = 0
 End
End 

go

Create proc usp_GetAllLocakedUserAccounts
as
Begin
	 Select UserName, Email, LockedDateTime,
	 DATEDIFF(hour, LockedDateTime, GETDATE()) as HoursElapsed
	 from tblUser
	 where IsLocked = 1 and IsActive = 1
End 
