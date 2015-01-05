<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Categories" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="CategoryID" DataSourceID="sdsCategoriesGrid">

            <Columns>
                <asp:BoundField DataField="CategoryID" HeaderText="Category ID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="CategoryID" />
                <asp:HyperLinkField DataTextField="CategoryName" DataNavigateUrlFields="CategoryID" 
                    DataNavigateUrlFormatString="~/Category.aspx?id={0}" HeaderText="User Name" 
                    SortExpression="CategoryName" />
                <asp:BoundField DataField="CategoryDesc" HeaderText="Category Desc" 
                    SortExpression="CategoryDesc" />
                <asp:CheckBoxField DataField="CategoryIsActive" HeaderText="Active" 
                    SortExpression="CategoryIsActive" />
            </Columns>

        </asp:GridView>

        <!-- SQL datasource connection -->
        <asp:SqlDataSource ID="sdsCategoriesGrid" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SE256_cs %>" 
        SelectCommand="spGetCategoriesGrid" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>

    </asp:Panel>

</asp:Content>

