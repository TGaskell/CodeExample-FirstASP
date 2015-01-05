<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" EnableViewState="True">
    
    <asp:Label ID="lblUserName" runat="server" Text="Enter User Name:"></asp:Label>
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rvfUserName" 
        runat="server"
        ControlToValidate="txtUserName" 
        ErrorMessage="User Name is a required field"> </asp:RequiredFieldValidator><br />
    
    <asp:Label ID="lblPassword" runat="server" Text="Enter Password:"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvPassword" 
        runat="server"
        ControlToValidate="txtPassword" 
        ErrorMessage="Password is a required field"> </asp:RequiredFieldValidator><br />

    <asp:LinkButton ID="lbtnForgotPassword" runat="server">Forgot Password</asp:LinkButton>
    <asp:LinkButton ID="lbtnLogin" runat="server" onclick="lbtnLogin_Click">Log In</asp:LinkButton>       
    <asp:LinkButton ID="lbtnCancel" runat="server" 
        CausesValidation="false" onclick="lbtnCancel_Click">Cancel</asp:LinkButton>
    
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

</asp:Content>

