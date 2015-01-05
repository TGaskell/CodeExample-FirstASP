<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Users" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Width="95%">
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="UserID" DataSourceID="sdsUsersGrid" >

            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="User ID"  
                    SortExpression="UserID" />
                <asp:HyperLinkField DataTextField="FullName" DataNavigateUrlFields="UserID" 
                    DataNavigateUrlFormatString="~/User.aspx?id={0}" HeaderText="User Name" 
                    SortExpression="FullName" />
               <asp:BoundField DataField="UserCity" HeaderText="City" 
                    SortExpression="UserCity" />
                <asp:BoundField DataField="StateName" HeaderText="State" 
                    SortExpression="StateName" />
                <asp:BoundField DataField="UserEmail" HeaderText="Email" 
                    SortExpression="UserEmail" />
                <asp:BoundField DataField="UserRole" HeaderText="User Role" 
                    SortExpression="UserRole" />
                <asp:CheckBoxField DataField="UserIsActive" HeaderText="Active" 
                    SortExpression="UserIsActive" />
                
            </Columns>

        </asp:GridView>

        <!-- SQL datasource connection -->
        <asp:SqlDataSource ID="sdsUsersGrid" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SE256_cs %>" 
        SelectCommand="spGetUsersGrid" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>

    </asp:Panel>

</asp:Content>

