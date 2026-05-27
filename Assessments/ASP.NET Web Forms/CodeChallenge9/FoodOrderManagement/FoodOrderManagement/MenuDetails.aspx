<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="MenuDetails.aspx.cs"
    Inherits="FoodOrderManagement.MenuDetails" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<h2>Menu Details</h2>

<asp:DetailsView ID="dvMenu"
    runat="server"
    AutoGenerateRows="true">
</asp:DetailsView>

</asp:Content>