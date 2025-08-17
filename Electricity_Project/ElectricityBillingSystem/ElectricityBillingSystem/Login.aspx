<%@ Page Title="Login" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ElectricityBillingSystem.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .login-box {
            width: 300px;
            margin: 40px auto;
            padding: 20px;
            background-color: #f4f4f4;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
    </style>

    <div class="login-box">
        <asp:Label ID="Label1" runat="server" Text="Enter your Username:" AssociatedControlID="txtUsername" />
        <br />
        <asp:TextBox ID="txtUsername" runat="server" />
        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
            ErrorMessage="Username is required" ForeColor="Red" Display="Dynamic" />
        <br /><br />

        <asp:Label ID="Label2" runat="server" Text="Enter your Password:" AssociatedControlID="txtPassword" />
        <br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
            ErrorMessage="Password is required" ForeColor="Red" Display="Dynamic" />
        <br /><br />

        <asp:Button ID="btnLogin" runat="server" Text="Login" BackColor="#00CCFF" ForeColor="Black" OnClick="btnLogin_Click" />
        <br /><br />

        <asp:Label ID="lblError" runat="server" ForeColor="Red" />
    </div>
</asp:Content>
