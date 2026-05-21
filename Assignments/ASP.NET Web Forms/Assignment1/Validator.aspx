<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Form</title>

    <style>

        table
        {
            margin-top:50px;
        }

        td
        {
            padding:8px;
        }

        .txt
        {
            width:200px;
            height:25px;
        }

        .err
        {
            color:red;
        }

    </style>

</head>

<body>

    <form id="form1" runat="server">

        <div align="center">

            <h2>Validation Form</h2>

            <table>

                <tr>
                    <td>Name</td>

                    <td>
                        <asp:TextBox ID="txtName"
                            runat="server"
                            CssClass="txt">
                        </asp:TextBox>
                    </td>

                    <td>

                        <asp:RequiredFieldValidator ID="rfvName"
                            runat="server"
                            ControlToValidate="txtName"
                            ErrorMessage="Enter Name"
                            CssClass="err">
                        </asp:RequiredFieldValidator>

                    </td>
                </tr>

                <tr>
                    <td>Family Name</td>

                    <td>
                        <asp:TextBox ID="txtFamily"
                            runat="server"
                            CssClass="txt">
                        </asp:TextBox>
                    </td>

                    <td>

                        <asp:RequiredFieldValidator ID="rfvFamily"
                            runat="server"
                            ControlToValidate="txtFamily"
                            ErrorMessage="Enter Family Name"
                            CssClass="err">
                        </asp:RequiredFieldValidator>

                        <br />

                        <asp:CompareValidator ID="cvFamily"
                            runat="server"
                            ControlToValidate="txtFamily"
                            ControlToCompare="txtName"
                            Operator="NotEqual"
                            ErrorMessage="Name and Family Name should differ"
                            CssClass="err">
                        </asp:CompareValidator>

                    </td>
                </tr>

                <tr>
                    <td>Address</td>

                    <td>
                        <asp:TextBox ID="txtAddress"
                            runat="server"
                            CssClass="txt">
                        </asp:TextBox>
                    </td>

                    <td>

                        <asp:RequiredFieldValidator ID="rfvAddress"
                            runat="server"
                            ControlToValidate="txtAddress"
                            ErrorMessage="Enter Address"
                            CssClass="err">
                        </asp:RequiredFieldValidator>

                        <br />

                        <asp:RegularExpressionValidator ID="revAddress"
                            runat="server"
                            ControlToValidate="txtAddress"
                            ValidationExpression=".{2,}"
                            ErrorMessage="Minimum 2 letters"
                            CssClass="err">
                        </asp:RegularExpressionValidator>

                    </td>
                </tr>

                <tr>
                    <td>City</td>

                    <td>
                        <asp:TextBox ID="txtCity"
                            runat="server"
                            CssClass="txt">
                        </asp:TextBox>
                    </td>

                    <td>

                        <asp:RequiredFieldValidator ID="rfvCity"
                            runat="server"
                            ControlToValidate="txtCity"
                            ErrorMessage="Enter City"
                            CssClass="err">
                        </asp:RequiredFieldValidator>

                        <br />

                        <asp:RegularExpressionValidator ID="revCity"
                            runat="server"
                            ControlToValidate="txtCity"
                            ValidationExpression=".{2,}"
                            ErrorMessage="Minimum 2 letters"
                            CssClass="err">
                        </asp:RegularExpressionValidator>

                    </td>
                </tr>

                <tr>
                    <td>Zip Code</td>

                    <td>
                        <asp:TextBox ID="txtZip"
                            runat="server"
                            CssClass="txt">
                        </asp:TextBox>
                    </td>

                    <td>

                        <asp:RequiredFieldValidator ID="rfvZip"
                            runat="server"
                            ControlToValidate="txtZip"
                            ErrorMessage="Enter Zip"
                            CssClass="err">
                        </asp:RequiredFieldValidator>

                        <br />

                        <asp:RangeValidator ID="rvZip"
                            runat="server"
                            ControlToValidate="txtZip"
                            MinimumValue="10000"
                            MaximumValue="99999"
                            Type="Integer"
                            ErrorMessage="Zip must be 5 digits"
                            CssClass="err">
                        </asp:RangeValidator>

                    </td>
                </tr>

                <tr>
                    <td>Phone</td>

                    <td>
                        <asp:TextBox ID="txtPhone"
                            runat="server"
                            CssClass="txt">
                        </asp:TextBox>
                    </td>

                    <td>

                        <asp:RequiredFieldValidator ID="rfvPhone"
                            runat="server"
                            ControlToValidate="txtPhone"
                            ErrorMessage="Enter Phone"
                            CssClass="err">
                        </asp:RequiredFieldValidator>

                        <br />

                        <asp:RegularExpressionValidator ID="revPhone"
                            runat="server"
                            ControlToValidate="txtPhone"
                            ValidationExpression="(\d{2}-\d{7})|(\d{3}-\d{7})"
                            ErrorMessage="Format XX-XXXXXXX or XXX-XXXXXXX"
                            CssClass="err">
                        </asp:RegularExpressionValidator>

                    </td>
                </tr>

                <tr>
                    <td>Email</td>

                    <td>
                        <asp:TextBox ID="txtEmail"
                            runat="server"
                            CssClass="txt">
                        </asp:TextBox>
                    </td>

                    <td>

                        <asp:RequiredFieldValidator ID="rfvEmail"
                            runat="server"
                            ControlToValidate="txtEmail"
                            ErrorMessage="Enter Email"
                            CssClass="err">
                        </asp:RequiredFieldValidator>

                        <br />

                        <asp:RegularExpressionValidator ID="revEmail"
                            runat="server"
                            ControlToValidate="txtEmail"
                            ValidationExpression="\w+([-.+']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage="Invalid Email"
                            CssClass="err">
                        </asp:RegularExpressionValidator>

                    </td>
                </tr>

                <tr>

                    <td colspan="2" align="center">

                        <asp:Button ID="btnCheck"
                            runat="server"
                            Text="Check"
                            PostBackUrl="~/Welcome.aspx" />

                    </td>

                </tr>

                <tr>

                    <td colspan="3">

                        <asp:ValidationSummary ID="ValidationSummary1"
                            runat="server"
                            HeaderText="Correct the following:"
                            ShowMessageBox="true"
                            ShowSummary="true"
                            CssClass="err" />

                    </td>

                </tr>

            </table>

        </div>

    </form>

</body>
</html>