<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel ID="pnlAbout" runat="server" HorizontalAlign="Center">
    
        <div id="imgMisty" runat="server" >
            <img src="Images/misty.JPG" alt="dog graphic" />
        </div>

     </asp:Panel>   
    
            <br />
            <br />

    <div id="missionText" runat="server" style="margin-left:100px; margin-right:100px; font-weight:bold" >
        <p>Our mission is to help you find what you need quickly and affordably, so you can spend more time loving your pets!</p>
    </div>

            <br />
            <br />

    <div id="aboutText" runat="server" style="margin-left:100px; margin-right:100px" >
        <p>Since our beginning 10 weeks ago, we’ve been dedicated to making life easier for pet parents.</p> 
        <p>It all started with an ASP.net class at NEIT. Today, our site has a complete line of all natural pet supplies.</p> 
        <p>Within our website, we provide pet parents a place to purchase the very best products for their pets.</p>
    </div>


    
</asp:Content>

