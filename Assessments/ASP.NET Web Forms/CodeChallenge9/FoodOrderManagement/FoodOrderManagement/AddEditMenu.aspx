<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="AddEditMenu.aspx.cs"
    Inherits="FoodOrderManagement.AddEditMenu" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Add / Edit Menu</h2>

<asp:ValidationSummary ID="ValidationSummary1"
    runat="server"
    ForeColor="Red" />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Item Name:
<asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>

<asp:RequiredFieldValidator
    ID="rfv1"
    runat="server"
    ControlToValidate="txtItemName"
    ErrorMessage="Enter Item Name"
    ForeColor="Red">
</asp:RequiredFieldValidator>

<br />
    <br />

Category:
<asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<br />

<br />Food Type:
<asp:DropDownList ID="ddlFoodType" runat="server">
    <asp:ListItem>Veg</asp:ListItem>
    <asp:ListItem>NonVeg</asp:ListItem>
</asp:DropDownList>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<br /><br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Price:
<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

<asp:RangeValidator
    ID="rv1"
    runat="server"
    ControlToValidate="txtPrice"
    MinimumValue="1"
    MaximumValue="1000"
    Type="Double"
    ErrorMessage="Price between 1 and 1000"
    ForeColor="Red">
</asp:RangeValidator>

<asp:CompareValidator
    ID="cv1"
    runat="server"
    ControlToValidate="txtPrice"
    Operator="DataTypeCheck"
    Type="Double"
    ErrorMessage="Enter valid price"
    ForeColor="Red">
</asp:CompareValidator>

<br /><br />

Quantity:
<asp:TextBox ID="txtQty" runat="server"></asp:TextBox>

<asp:RegularExpressionValidator
    ID="rev1"
    runat="server"
    ControlToValidate="txtQty"
    ValidationExpression="^[0-9]+$"
    ErrorMessage="Numbers only"
    ForeColor="Red">
</asp:RegularExpressionValidator>

<br /><br />

Available:
<asp:CheckBox ID="chkAvailable" runat="server" />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<br /><br />

<asp:Button ID="btnSave"
    runat="server"
    Text="Save"
    OnClick="btnSave_Click" />

</asp:Content>