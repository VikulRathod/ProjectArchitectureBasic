-- create database VHaaShMVCDB
go
use VHaaShMVCDB
GO
/****** Object:  Table [dbo].[tblAcademicDetails]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAcademicDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[DeptId] [int] NULL,
	[DocumentOne] [varchar](max) NULL,
	[DocumentTwo] [varchar](max) NULL,
	[DocumentThree] [varchar](max) NULL,
	[DocumentFour] [varchar](max) NULL,
	[DocumentFive] [varchar](max) NULL,
 CONSTRAINT [PK_tblAcademicDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblActiveUsers]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblActiveUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[LoginDateTime] [smalldatetime] NULL,
	[LogoutDateTime] [smalldatetime] NULL,
	[IsActiveSession] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCompany]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCompany](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
	[Address] [varchar](max) NULL,
	[Email] [varchar](100) NULL,
	[Contact] [varchar](50) NULL,
 CONSTRAINT [PK_tblCompany] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDepartment]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [varchar](50) NULL,
 CONSTRAINT [PK_tblDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDesignation]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDesignation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_tblDesignation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEligibility]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEligibility](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblEligibility] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGender]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [varchar](50) NULL,
 CONSTRAINT [PK_tblGender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblJobDescription]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblJobDescription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[RoundId] [int] NULL,
	[SkillSetId] [int] NULL,
	[PackageId] [int] NULL,
	[DeptId] [int] NULL,
	[JobTitleId] [int] NULL,
	[JobDescription] [nvarchar](max) NULL,
	[EligibilityId] [int] NULL,
	[DesignationId] [int] NULL,
	[ScheduleDateTime] [datetime] NULL,
	[Location] [varchar](50) NULL,
	[Comments] [varchar](max) NULL,
 CONSTRAINT [PK_tblJobDescription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblJobTitle]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblJobTitle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
 CONSTRAINT [PK_tblJobTitle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPackage]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPackage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_tblPackage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblResetPasswordRequests]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblResetPasswordRequests](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [int] NULL,
	[ResetRequestDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRoles]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSelectionProcess]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSelectionProcess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[DepartmentId] [int] NULL,
	[JobDescriptionId] [int] NULL,
	[StudentId] [int] NULL,
	[IsSelected] [bit] NULL,
	[RoundOne] [bit] NULL,
	[RoundTwo] [bit] NULL,
	[RoundThree] [bit] NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblSelectionProcess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSkillSet]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSkillSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
 CONSTRAINT [PK_tblSkillSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudent]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EnrollmentNo] [nvarchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[GenderId] [int] NULL,
	[DOB] [datetime] NULL,
	[ContactNo] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[AddressOne] [varchar](max) NULL,
	[AddressTwo] [varchar](max) NULL,
	[State] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
	[AcademicDetailsId] [int] NULL,
 CONSTRAINT [PK_tblStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserAddress]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserAddress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[LineNumber1] [varchar](100) NULL,
	[LineNumber2] [varchar](100) NULL,
	[Village] [varchar](100) NULL,
	[Taluka] [varchar](100) NULL,
	[District] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[PinCode] [varchar](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserInfo]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[HighestQualification] [varchar](100) NULL,
	[Occupation] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserRoles]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](200) NULL,
	[Email] [nvarchar](100) NULL,
	[RetryAttempts] [int] NULL,
	[IsLocked] [bit] NULL,
	[LockedDateTime] [datetime] NULL,
	[Mobile] [varchar](10) NULL,
	[IsActive] [bit] NULL,
	[IsConfirmedMobile] [bit] NULL,
	[IsConfirmedEmail] [bit] NULL,
	[RegistrationOtp] [varchar](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[test]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test](
	[Id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spActivateRegisteredUser]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spActivateRegisteredUser]
@Mobile nvarchar(10),
@Password nvarchar(50),
@Email varchar(100),
@Otp varchar(6)
as  
Begin  
 Declare @Count int  
 Declare @ReturnCode int  
   
 Select @Count = COUNT(UserName)   
 from tblUsers where Mobile = @Mobile  
 If @Count > 0  
 Begin  
  declare @IsMobileConfirmed bit, @IsEmailConfirmed bit
  exec usp_ConfirmMobile @Mobile, @Otp, @IsMobileConfirmed output
  exec usp_ConfirmEmail @Email, @Otp, @IsEmailConfirmed output

  if @IsEmailConfirmed = 1 or @IsMobileConfirmed = 1
	begin
		Set @ReturnCode = 1
		update tblusers set IsActive = 1, Password = @Password where Mobile = @Mobile  
	end 
   else
	begin
		Set @ReturnCode = -1
	end
 End  
 Else  
 Begin  
  Set @ReturnCode = -1  
 End  
 Select @ReturnCode as ReturnValue  
End  

GO
/****** Object:  StoredProcedure [dbo].[spAuthenticateUser]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spAuthenticateUser]
@UserName nvarchar(100),
@Password nvarchar(200)
as
Begin
 Declare @AccountLocked bit
 Declare @Count int
 Declare @RetryCount int
 
 Select @AccountLocked = IsLocked
 from tblUsers where UserName = @UserName
  
 --If the account is already locked
 if(@AccountLocked = 1)
 Begin
  Select 1 as AccountLocked, 0 as Authenticated, 0 as RetryAttempts
 End
 Else
 Begin
  -- Check if the username and password match
  Select @Count = COUNT(UserName) from tblUsers
  where [UserName] = @UserName and [Password] = @Password
  
  if not exists (select UserName from tblUsers where Username = @Username)
  Begin
  Select 0 as AccountLocked, 0 as Authenticated, 0 as RetryAttempts
  end
  else
  begin
  -- If match found
  if(@Count = 1)
  Begin
   -- Reset RetryAttempts 
   Update tblUsers set RetryAttempts = 0
   where UserName = @UserName
       
   Select 0 as AccountLocked, 1 as Authenticated, 0 as RetryAttempts
  End
  Else
  Begin
   -- If a match is not found
   Select @RetryCount = IsNULL(RetryAttempts, 0)
   from tblUsers
   where UserName = @UserName
   
   Set @RetryCount = @RetryCount + 1
   
   if(@RetryCount <= 3)
   Begin
    -- If re-try attempts are not completed
    Update tblUsers set RetryAttempts = @RetryCount
    where UserName = @UserName 
    
    Select 0 as AccountLocked, 0 as Authenticated, @RetryCount as RetryAttempts
   End
   Else
   Begin
    -- If re-try attempts are completed
    Update tblUsers set RetryAttempts = @RetryCount,
    IsLocked = 1, LockedDateTime = GETDATE()
    where UserName = @UserName

    Select 1 as AccountLocked, 0 as Authenticated, 0 as RetryAttempts
   End
  End
 End
 end
End


GO
/****** Object:  StoredProcedure [dbo].[spChangePassword]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[spChangePassword]
@GUID uniqueidentifier,
@Password nvarchar(100)
as
Begin
 Declare @UserId int
 
 Select @UserId = UserId 
 from tblResetPasswordRequests
 where Id= @GUID
 
 if(@UserId is null)
 Begin
  -- If UserId does not exist
  Select 0 as IsPasswordChanged
 End
 Else
 Begin
  -- If UserId exists, Update with new password
  Update tblUsers set
  [Password] = @Password
  where Id = @UserId
  
  -- Delete the password reset request row 
  Delete from tblResetPasswordRequests
  where Id = @GUID
  
  Select 1 as IsPasswordChanged
 End
End


GO
/****** Object:  StoredProcedure [dbo].[spChangePasswordUsingCurrentPassword]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[spChangePasswordUsingCurrentPassword]
@UserName nvarchar(100),
@CurrentPassword nvarchar(100),
@NewPassword nvarchar(100)
as
Begin
 if(Exists(Select Id from tblUsers 
     where UserName = @UserName
     and [Password] = @CurrentPassword))
 Begin
  Update tblUsers
  Set [Password] = @NewPassword
  where UserName = @UserName
  
  Select 1 as IsPasswordChanged
 End
 Else
 Begin
  Select 0 as IsPasswordChanged
 End
End 


GO
/****** Object:  StoredProcedure [dbo].[spGetAllLocakedUserAccounts]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spGetAllLocakedUserAccounts]
as
Begin
 Select UserName, Email, LockedDateTime,
 DATEDIFF(hour, LockedDateTime, GETDATE()) as HoursElapsed
 from tblUsers
 where IsLocked = 1
End 


GO
/****** Object:  StoredProcedure [dbo].[spIsPasswordResetLinkValid]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[spIsPasswordResetLinkValid] 
@GUID uniqueidentifier
as
Begin
 Declare @UserId int
 
 If(Exists(Select UserId from tblResetPasswordRequests where Id = @GUID))
 Begin
  Select 1 as IsValidPasswordResetLink
 End
 Else
 Begin
  Select 0 as IsValidPasswordResetLink
 End
End



GO
/****** Object:  StoredProcedure [dbo].[spRegisterUser]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spRegisterUser]  
@FirstName nvarchar(100),  
@LastName nvarchar (200),  
@Mobile nvarchar(10),
@Email varchar(100),
@Otp varchar(6)
as  
Begin  
 Declare @Count int  
 Declare @ReturnCode int  
   
 Select @Count = COUNT(UserName)   
 from tblUsers where Mobile = @Mobile  
 If @Count > 0  
 Begin  
  Set @ReturnCode = -1  
 End  
 Else  
 Begin  
  Set @ReturnCode = 1  
  --Change: Column list specified while inserting
  Insert into tblUsers([UserName], Mobile, Email, RegistrationOtp) 
  values  (@Mobile, @Mobile, @Email, @Otp)  
  insert into tblUserInfo (UserId, FirstName, LastName) values(scope_identity(), @FirstName, @LastName)
 End  
 Select @ReturnCode as ReturnValue  
End  


GO
/****** Object:  StoredProcedure [dbo].[spResetPassword]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spResetPassword]
@UserName nvarchar(100)
as
Begin
 Declare @UserId int
 Declare @Email nvarchar(100)
 
 Select @UserId = Id, @Email = Email 
 from tblUsers
 where UserName = @UserName
 
 if(@UserId IS NOT NULL)
 Begin
  --If username exists
  Declare @GUID UniqueIdentifier
  Set @GUID = NEWID()
  
  Insert into tblResetPasswordRequests
  (Id, UserId, ResetRequestDateTime)
  Values(@GUID, @UserId, GETDATE())
  
  Select 1 as ReturnCode, @GUID as UniqueId, @Email as Email
 End
 Else
 Begin
  --If username does not exist
  SELECT 0 as ReturnCode, NULL as UniqueId, NULL as Email
 End
End


GO
/****** Object:  StoredProcedure [dbo].[usp_ChangePasswordOnFirstLogin]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_ChangePasswordOnFirstLogin]
@Username varchar(10),
@CurrentPassword varchar(200),
@NewPassword varchar(200)
as
begin
if exists (select Username from tblUsers where UserName = @Username)
	begin
		update tblUsers set Password = @NewPassword where UserName = @Username
		select 1 as ReturnValue
	end
else
	begin
	select -1 as ReturnValue
	end
end
GO
/****** Object:  StoredProcedure [dbo].[usp_ConfirmEmail]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_ConfirmEmail]
@Email varchar(10), @Otp varchar(6), @IsSuccess bit out
as
begin
if exists (select Email, RegistrationOtp from tblUsers where Email = @Email and RegistrationOtp = @Otp)
	begin
		update tblUsers set IsConfirmedEmail = 1 where Email = @Email and RegistrationOtp = @Otp
		set @IsSuccess = 1
	end
else
	begin
	set @IsSuccess = 0
	end
end


GO
/****** Object:  StoredProcedure [dbo].[usp_ConfirmMobile]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_ConfirmMobile]
@Mobile varchar(10), @Otp varchar(6), @IsSuccess bit out
as
begin
if exists (select Mobile, RegistrationOtp from tblUsers where Mobile = @Mobile and RegistrationOtp = @Otp)
	begin
		update tblUsers set IsConfirmedMobile = 1 where Mobile = @Mobile and RegistrationOtp = @Otp
		set @IsSuccess = 1
	end
else
	begin
	set @IsSuccess = 0
	end
end

GO
/****** Object:  StoredProcedure [dbo].[usp_GetOtpFromDatabase]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_GetOtpFromDatabase]
@Mobile varchar(10), @Email varchar(100),@Otp varchar(6) out
as
begin
   if exists (select Mobile, Email from tblUsers where Email = @Email and Mobile = @Mobile)
	begin
		select @otp = RegistrationOtp from tblUsers where Email = @Email and Mobile = @Mobile
	end
end

GO
/****** Object:  StoredProcedure [dbo].[usp_SaveOtpInDatabase]    Script Date: 3/22/2021 12:12:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_SaveOtpInDatabase]
@Mobile varchar(10), @Email varchar(100),@Otp varchar(6)
as
begin
   if exists (select Mobile, Email from tblUsers where Email = @Email and Mobile = @Mobile)
	begin
		update tblusers set RegistrationOtp = @Otp where Email = @Email and Mobile = @Mobile
	end
end


GO
ALTER DATABASE [VHaaShMVCDB] SET  READ_WRITE 
GO
