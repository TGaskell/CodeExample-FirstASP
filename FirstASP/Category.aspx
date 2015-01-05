<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvName" 
        runat="server"
        ControlToValidate="txtName" 
        ErrorMessage="Name is a required field">
    </asp:RequiredFieldValidator><br />

    <asp:Label ID="lblDesc" runat="server" Text="Desc"></asp:Label>
    <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvDesc" 
        runat="server"
        ControlToValidate="txtDesc" 
        ErrorMessage="Description is a required field">
    </asp:RequiredFieldValidator><br />

    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    
    <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active" /><br />
    
    <asp:Button ID="btnUpdate" runat="server" Text="Update" />
    
    <asp:Button ID="btnCancel" runat="server" Text="Cancel"
        CausesValidation="false" onclick="btnCancel_Click" />

</asp:Content>

