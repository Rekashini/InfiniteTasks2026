<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Assignment1.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Application</title>

    <style>
        body{
            background-color:powderblue;
        }

        table
        {
            margin-top:50px;
        }

        td
        {
            padding:10px;
        }

        .imgstyle
        {
            width:200px;
            height:200px;
        }

    </style>

</head>

<body>

    <form id="form1" runat="server">

        <div align="center">

            <h2>Product Details</h2>

            <table>

                <tr>

                    <td>Select Product</td>

                    <td>

                        <asp:DropDownList ID="ddlProduct"
                            runat="server"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">

                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Laptop</asp:ListItem>
                            <asp:ListItem>Mobile</asp:ListItem>
                            <asp:ListItem>Headphone</asp:ListItem>
                            <asp:ListItem>Watch</asp:ListItem>

                        </asp:DropDownList>

                    </td>

                </tr>

                <tr>

                    <td>Product Image</td>

                    <td>

                        <asp:Image ID="imgProduct"
                            runat="server"
                            CssClass="imgstyle" />

                    </td>

                </tr>

                <tr>

                    <td colspan="2" align="center">

                        <asp:Button ID="btnPrice"
                            runat="server"
                            Text="Get Price"
                            OnClick="btnPrice_Click" />

                    </td>

                </tr>

                <tr>

                    <td>Price</td>

                    <td>

                        <asp:Label ID="lblPrice"
                            runat="server"
                            Font-Bold="true"
                            ForeColor="Blue">
                        </asp:Label>

                    </td>

                </tr>

            </table>

        </div>

    </form>

</body>
</html>