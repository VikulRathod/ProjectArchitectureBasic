<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="Register.aspx.cs" 
    Inherits="VHaaSh.ASP.Client.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial">
            <table style="border: 1px solid black">
                <tr>
                    <td colspan="2">
                        <b>User Registration</b>
                    </td>
                </tr>
                <tr>
                    <td>User Name
                    </td>
                    <td>:<asp:TextBox ID="txtUserName" runat="server">
                    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorusername"
                            runat="server" ErrorMessage="User Name required" Text="*"
                            ControlToValidate="txtUserName" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password
                    </td>
                    <td>:<asp:TextBox ID="txtPassword" TextMode="Password" runat="server">
                    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword"
                            runat="server" ErrorMessage="Password required" Text="*"
                            ControlToValidate="txtPassword" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Confirm Password
                    </td>
                    <td>:<asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server">
                    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword"
                            runat="server" ErrorMessage="Confirm Password required" Text="*"
                            ControlToValidate="txtConfirmPassword" ForeColor="Red"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                            ErrorMessage="Password and Confirm Password must match"
                            ControlToValidate="txtConfirmPassword" ForeColor="Red"
                            ControlToCompare="txtPassword" Display="Dynamic"
                            Type="String" Operator="Equal" Text="*">
                        </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email
                    </td>
                    <td>:<asp:TextBox ID="txtEmail" runat="server">
                    </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail"
                            runat="server" ErrorMessage="Email required" Text="*"
                            ControlToValidate="txtEmail" ForeColor="Red"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail"
                            runat="server" ErrorMessage="Invalid Email" ControlToValidate="txtEmail"
                            ForeColor="Red" Display="Dynamic" Text="*"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" Text="Register"
                            OnClick="btnRegister_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
