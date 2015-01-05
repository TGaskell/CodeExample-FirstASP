<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Orders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="OrderID" DataSourceID="sdsOrdersGrid">

            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="OrderID" />
                <asp:HyperLinkField DataTextField="UserEmail" DataNavigateUrlFields="OrderID" 
                    DataNavigateUrlFormatString="~/Order.aspx?id={0}" HeaderText="Email" 
                    SortExpression="UserEmail" />
                <asp:BoundField DataField="StatusName" HeaderText="Status" 
                    SortExpression="StatusName" />
                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" 
                    SortExpression="OrderDate" />
                <asp:BoundField DataField="OrderZip" HeaderText="Zip" 
                    SortExpression="OrderZip" />
                <asp:BoundField DataField="OrderLastUpdate" HeaderText="Last Update" 
                    SortExpression="OrderLastUpdate" />
            </Columns>

        </asp:GridView>

        <!-- SQL datasource connection -->
        <asp:SqlDataSource ID="sdsOrdersGrid" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SE256_cs %>" 
        SelectCommand="spGetOrdersGrid" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>

    </asp:Panel>

</asp:Content>

