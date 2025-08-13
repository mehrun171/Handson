<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question-2.aspx.cs" Inherits="Assignment_1.Question_2" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Viewer</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Select a Product:</h2>

        <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" Width="259px" />
        <br /><br />

        <asp:Image ID="imgProduct" runat="server" Width="258px" Height="301px" />
        <br /><br />

        <asp:Button ID="btnGetPrice" runat="server" Text="Get This Product Price" OnClick="btnGetProPrice_Click" BackColor="#33CCFF" BorderColor="#000066" BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" Width="257px" />
        <br /><br />

        <asp:Label ID="lblPrice" runat="server" Font-Bold="true" ForeColor="Purple" />
    </form>
</body>
</html>

