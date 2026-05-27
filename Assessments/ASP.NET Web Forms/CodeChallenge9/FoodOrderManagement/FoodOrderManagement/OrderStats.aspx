<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="OrderStats.aspx.cs"
    Inherits="FoodOrderManagement.OrderStats" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<h2>Order Statistics</h2>

<asp:Label ID="lblVisitors" runat="server"></asp:Label>

<br /><br />

<asp:Label ID="lblUsers" runat="server"></asp:Label>

<br /><br />

<asp:GridView ID="gvStats" runat="server" style="text-align: center" Width="371px"></asp:GridView>

</asp:Content>