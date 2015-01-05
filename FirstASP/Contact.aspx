<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <asp:Panel ID="pnlContact" runat="server" HorizontalAlign="Center">
    
            <div id="imgAbbi" runat="server" >
                <img src="Images/abigail.JPG" alt="cat graphic" />
            </div>

        </asp:Panel>   
    
                <br />
                <br />

        <div id="feedbackText" runat="server" style="margin-left:100px; margin-right:100px; font-weight:bold" >
            <p>Your feedback is important to us!</p>
        </div>

                <br />
 
        <div id="contactText" runat="server" style="margin-left:100px; margin-right:100px" >
           
            <p>Do you have product questions, comments, suggestions or concerns to share with us?</p> 
            <p>Please email us at CustomerService@seveniggies.com, or you can call us at 800-555-1234.</p>
            <p>Customer Service Center hours: Monday through Friday, 8 a.m. to midnight EST</p>

        </div>


</asp:Content>

