<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvFirstName" 
        runat="server"
        ControlToValidate="txtFirstName" 
        ErrorMessage="First Name is a required field">
    </asp:RequiredFieldValidator><br />

    <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvLastName" 
        runat="server"
        ControlToValidate="txtLastName" 
        ErrorMessage="Last Name is a required field">
    </asp:RequiredFieldValidator><br />

    <asp:Label ID="lblAddress1" runat="server" Text="Address1"></asp:Label>
    <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvAddress1" 
        runat="server"
        ControlToValidate="txtAddress1" 
        ErrorMessage="Address1 is a required field">
    </asp:RequiredFieldValidator><br />
    
    <asp:Label ID="lblAddress2" runat="server" Text="Address2"></asp:Label>
    <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox><br />
    
    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvCity" 
        runat="server"
        ControlToValidate="txtCity" 
        ErrorMessage="City is a required field">
    </asp:RequiredFieldValidator><br />
    
    <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
    <asp:DropDownList ID="ddlState" runat="server" OnPreRender="ddlState_PreRender" 
        DataSourceID="sdsStates" DataTextField="StateName" DataValueField="StateID">
    </asp:DropDownList>
    <asp:RequiredFieldValidator
        ID="rfvState" 
        runat="server"
        ControlToValidate="ddlState"
        InitialValue="Choose State" 
        ErrorMessage="State is a required field">
    </asp:RequiredFieldValidator><br />
    
    <asp:Label ID="lblZip" runat="server" Text="Zip"></asp:Label>
    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvZip" 
        runat="server"
        ControlToValidate="txtZip" 
        ErrorMessage="Zip is a required field">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator 
         ID="revZip" 
         runat="server" ControlToValidate="txtZip" 
         ValidationExpression="\d{5}"
         ErrorMessage="Must be a five-digit U.S. zip code.">
    </asp:RegularExpressionValidator><br />
    
    <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvUserName" 
        runat="server"
        ControlToValidate="txtUserName" 
        ErrorMessage="User Name is a required field">
    </asp:RequiredFieldValidator><br />
    
    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvPassword" 
        runat="server"
        ControlToValidate="txtPassword" 
        ErrorMessage="Password is a required field">
    </asp:RequiredFieldValidator><br />
    
    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
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
    
    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvEmail" 
        runat="server"
        ControlToValidate="txtEmail" 
        ErrorMessage="Email is a required field">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revEmail" runat="server" 
        ErrorMessage="Email not in proper format" 
        ControlToValidate="txtEmail" 
        ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+">
    </asp:RegularExpressionValidator><br />
    
    <asp:Label ID="lblConfirmEmail" runat="server" Text="Confirm Email"></asp:Label>
    <asp:TextBox ID="txtConfirmEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvConfirmEmail" 
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
    
    <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator
        ID="rfvPhone" 
        runat="server"
        ControlToValidate="txtPhone" 
        ErrorMessage="Phone is a required field">
    </asp:RequiredFieldValidator><br />

    <asp:TextBox ID="txtUserRole" runat="server"></asp:TextBox><br />

    <asp:RadioButtonList ID="rblIsActive" runat="server">
        <asp:ListItem Text="Yes" Value="True" />
        <asp:ListItem Text="No" Value="False" />
    </asp:RadioButtonList>
    <br />
    
    <asp:LinkButton ID="lbtnAddUpdate" runat="server" 
        onclick="lbtnAddUpdate_Click"></asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lbtnCancel" runat="server" CausesValidation="false"
         onclick="lbtnCancel_Click">Cancel</asp:LinkButton>  
    
    <!-- SQL datasource connection -->
    <asp:SqlDataSource ID="sdsStates" runat="server" 
    ConnectionString="<%$ ConnectionStrings:SE256_cs %>" 
    SelectCommand="spGetStatesDDL" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
   
   </asp:Content>