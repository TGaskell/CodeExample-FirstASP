<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Width="95%">
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ProductID" DataSourceID="sdsProductsGrid">

            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" 
                    SortExpression="CategoryName" />
                <asp:HyperLinkField DataTextField="ProductName" DataNavigateUrlFields="ProductID" 
                    DataNavigateUrlFormatString="~/Product.aspx?id={0}" HeaderText="Product Name" 
                    SortExpression="ProductName" />
                <asp:BoundField DataField="ProductSKU" HeaderText="Product SKU" 
                    SortExpression="ProductSKU" />
                <asp:BoundField DataField="ProductCost" HeaderText="Product Cost" 
                    SortExpression="ProductCost" />
                <asp:CheckBoxField DataField="ProductIsActive" HeaderText="Active" 
                    SortExpression="ProductIsActive" />
            </Columns>

        </asp:GridView>

        
        <!-- SQL datasource connection -->
        <asp:SqlDataSource ID="sdsProductsGrid" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SE256_cs %>" 
        SelectCommand="spGetProductsGrid" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>

    </asp:Panel>

</asp:Content>

