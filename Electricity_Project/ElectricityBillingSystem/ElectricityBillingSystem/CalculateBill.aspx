<%@ Page Title="Calculate Bill" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="CalculateBill.aspx.cs" Inherits="ElectricityBillingSystem.CalculateBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="lblConsumerNo" runat="server" Text="Consumer Number"></asp:Label>
    <p>
        <asp:TextBox ID="txtConsumerNo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="BillGroup" ControlToValidate="txtConsumerNo"
            ErrorMessage="Consumer Number is required" ForeColor="Red" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Format must be EB followed by 5 digits"
            ControlToValidate="txtConsumerNo" ValidationExpression="^EB\d{5}$" ForeColor="Red" Display="Dynamic" />
    </p>

    <asp:Label ID="lblConsumerName" runat="server" Text="Consumer Name"></asp:Label>
    <p>
        <asp:TextBox ID="txtConsumerName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="BillGroup" ControlToValidate="txtConsumerName"
            ErrorMessage="Consumer Name is required" ForeColor="Red" Display="Dynamic" />
    </p>

    <asp:Label ID="lblUnits" runat="server" Text="Units Consumed"></asp:Label>
    <p>
        <asp:TextBox ID="txtUnits" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="BillGroup" ControlToValidate="txtUnits"
            ErrorMessage="Units Consumed is required" ForeColor="Red" Display="Dynamic" />
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtUnits"
            MinimumValue="0" MaximumValue="9999" Type="Integer"
            ErrorMessage="Units must be a positive number" ForeColor="Red" Display="Dynamic" />
    </p>

    <asp:Button ID="btnCalculate" runat="server" Text="Calculate Bill" ValidationGroup="BillGroup" OnClick="btnCalculate_Click" />
    <br /><br />

    <asp:Label ID="lblBillAmount" runat="server" Text="Bill Amount"></asp:Label>
    <br /><br />

    <asp:Label ID="lblSummary" runat="server"></asp:Label>
    <br /><br />

    <asp:Label ID="lblMessage" runat="server" Text="(for validation feedback)"></asp:Label>
    <br /><br />
    <asp:Button ID="btnReset" runat="server" Text="Reset Form" OnClick="btnReset_Click" />
<br /><br />
    <asp:Button ID="btnPrint" runat="server" Text="Print Bill" OnClientClick="window.print(); return false;" />

    <asp:ValidationSummary 
        ID="ValidationSummary1" 
        runat="server" 
        HeaderText="Please fix the following errors:"
        ForeColor="Red" 
        DisplayMode="BulletList" 
        ValidationGroup="BillGroup" />

</asp:Content>
