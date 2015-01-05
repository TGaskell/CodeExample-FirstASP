<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvName" 
        runat="server"
        ControlToValidate="txtName" 
        ErrorMessage="Name is a required field">
    </asp:RequiredFieldValidator><br />
    
    <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvDescription" 
        runat="server"
        ControlToValidate="txtDescription" 
        ErrorMessage="Description is a required field">
    </asp:RequiredFieldValidator><br />
    
    <asp:Label ID="lblSKU" runat="server" Text="SKU"></asp:Label>
    <asp:TextBox ID="txtSKU" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvSKU" 
        runat="server"
        ControlToValidate="txtSKU" 
        ErrorMessage="SKU is a required field">
    </asp:RequiredFieldValidator><br />
    
    <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
    <asp:DropDownList ID="ddlCategory" runat="server" OnPreRender="ddlCategory_PreRender" 
            OnSelectedIndexChanged="ddlCategory_OnSelectedIndexChange"
            DataSourceID="sdsCategory" DataTextField="CategoryName" DataValueField="CategoryID">
    </asp:DropDownList>
    <asp:RequiredFieldValidator
        ID="rfvCategory" 
        runat="server"
        ControlToValidate="ddlCategory"
        InitialValue="Choose Category" 
        ErrorMessage="Category is a required field">
    </asp:RequiredFieldValidator><br />
    
    <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active" /><br />
    
    <asp:Button ID="btnUpdate" runat="server" Text="Update" 
        onclick="btnUpdate_Click" />
    
    <asp:Button ID="btnCancel" runat="server" Text="Cancel"
        CausesValidation="false" onclick="btnCancel_Click" />

    <br />
    <br />

    <asp:Button ID="btnAddCart" runat="server" Text="Add to Cart"
        CausesValidation="false" onclick="btnAddCart_Click" />
    
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    <!-- SQL datasource connection -->
    <asp:SqlDataSource ID="sdsCategory" runat="server" 
    ConnectionString="<%$ ConnectionStrings:SE256_cs %>" 
    SelectCommand="spGetActiveCategoriesDDL" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


</asp:Content>

