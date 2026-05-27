<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="MenuList.aspx.cs"
    Inherits="FoodOrderManagement.MenuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Menu Items</h2>

    <asp:GridView ID="gvMenu"
        runat="server"
        AutoGenerateColumns="False">

        <Columns>

            <asp:BoundField DataField="MenuId" HeaderText="ID" />
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="Price" HeaderText="Price" />

            <asp:HyperLinkField HeaderText="View"
                Text="View"
                DataNavigateUrlFields="MenuId"
                DataNavigateUrlFormatString="MenuDetails.aspx?MenuId={0}" />

            <asp:HyperLinkField HeaderText="Edit"
                Text="Edit"
                DataNavigateUrlFields="MenuId"
                DataNavigateUrlFormatString="AddEditMenu.aspx?MenuId={0}" />

            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>

                    <asp:LinkButton ID="lnkDelete"
                        runat="server"
                        Text="Delete"
                        CommandArgument='<%# Eval("MenuId") %>'
                        OnClick="lnkDelete_Click">
                    </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>