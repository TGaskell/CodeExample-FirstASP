<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblEmail" runat="server" Text="Enter Email:"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rvfEmail" 
        runat="server"
        ControlToValidate="txtEmail" 
        ErrorMessage="Email is a required field">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revEmail" runat="server" 
        ErrorMessage="Email not in proper format" 
        ControlToValidate="txtEmail" 
        ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+">
    </asp:RegularExpressionValidator><br />
    
    <asp:Label ID="lblConfirmEmail" runat="server" Text="Confirm Email:"></asp:Label>
    <asp:TextBox ID="txtConfirmEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rvfConfirmEmail" 
        runat="server"
        ControlToValidate="txtConfirmEmail" 
        ErrorMessage="Confirm Email is a required field">
    </asp:RequiredFieldValidator>
    <asp:CompareValidator 
     ID="cvConfirmEmail" runat="server" 
     ControlToValidate="txtConfirmEmail"
     Operator="Equal"
     ControlToCompare="txtEmail" 
     ErrorMessage="Email does not match">
    </asp:CompareValidator><br />

    <asp:Label ID="lblPassword" runat="server" Text="Enter New Password:"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvPassword" 
        runat="server"
        ControlToValidate="txtPassword" 
        ErrorMessage="Password is a required field">
    </asp:RequiredFieldValidator><br />
    
    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvConfirmPassword" 
        runat="server"
        ControlToValidate="txtConfirmPassword" 
        ErrorMessage="Confirm Password is a required field">
    </asp:RequiredFieldValidator>
    <asp:CompareValidator 
     ID="cvConfirmPassword" runat="server" 
     ControlToValidate="txtConfirmPassword"
     Operator="Equal"
     ControlToCompare="txtPassword" 
     ErrorMessage="Password does not match">
    </asp:CompareValidator><br />

    <asp:LinkButton ID="lbtnResetPassword" runat="server">Reset Password</asp:LinkButton>
    
    <asp:LinkButton ID="lbtnCancel" runat="server" 
        CausesValidation="false" onclick="lbtnCancel_Click">Cancel</asp:LinkButton>

</asp:Content>

