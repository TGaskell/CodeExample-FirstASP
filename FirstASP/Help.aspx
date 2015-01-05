<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <asp:Panel ID="pnlHelp" runat="server" HorizontalAlign="Center">
    
            <div id="imgBunny" runat="server" >
                <img src="Images/bunny.JPG" alt="cat graphic" />
            </div>

        </asp:Panel>   
    
                <br />
                <br />

        <div id="howToOrder" runat="server" style="margin-left:100px; margin-right:100px; font-weight:bold" >
            <h3>How do I place a new order?</h3>
        </div>
        <div id="contactText" runat="server" style="margin-left:100px; margin-right:100px" >
            <p>If you wish to place an order via the website, you can browse for products by selecting Products from the top navigation bar on virtually all web pages.
               Once you would like to purchase a specific product, you enter the quantity and add it to your shopping cart by clicking the "Add to Cart" button.
            </p>
            <p>You will then be taken to the shopping cart screen where you can continue shopping or click on "Proceed to Checkout." 
               During the Checkout process, you will simply need to enter your shipping address, credit card information (via a secure payment process) and confirm your order. And you're done-all set to receive your order within 2 business days!
            </p> 
        </div>

        <div id="Div1" runat="server" style="margin-left:100px; margin-right:100px; font-weight:bold" >
            <h3>Where can I get assistance?</h3>
        </div>
        <div id="Div2" runat="server" style="margin-left:100px; margin-right:100px" >
            <p>You may contact us at CustomerService@seveniggies.com, or you can call us at 800-555-1234.</p>
            <p>Customer Service Center hours: Monday through Friday, 8 a.m. to midnight EST</p>
        </div>

</asp:Content>

