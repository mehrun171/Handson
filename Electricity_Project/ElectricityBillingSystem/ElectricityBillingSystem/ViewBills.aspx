<%@ Page Title="View Bills" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="ViewBills.aspx.cs" Inherits="ElectricityBillingSystem.ViewBills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Retrieve Recent Bills</h2>

    <asp:Label ID="lblCount" runat="server" Text="Enter number of bills to retrieve:" AssociatedControlID="txtCount" />
    <br />
    <asp:TextBox ID="txtCount" runat="server" />
    <asp:RequiredFieldValidator ID="rfvCount" runat="server" ControlToValidate="txtCount"
        ErrorMessage="Please enter a number" ForeColor="Red" Display="Dynamic" />
    <asp:RangeValidator ID="rvCount" runat="server" ControlToValidate="txtCount"
        MinimumValue="1" MaximumValue="100" Type="Integer"
        ErrorMessage="Enter a number between 1 and 100" ForeColor="Red" Display="Dynamic" />
    <br /><br />

    <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve Bills" OnClick="btnRetrieve_Click" />
    <br /><br />

    <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="False" CssClass="grid" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Width="818px">
        <Columns>
            <asp:BoundField DataField="consumer_number" HeaderText="Consumer No" />
            <asp:BoundField DataField="consumer_name" HeaderText="Name" />
            <asp:BoundField DataField="units_consumed" HeaderText="Units" />
            <asp:BoundField DataField="bill_amount" HeaderText="Amount" DataFormatString="{0:C}" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        
    </asp:GridView>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
</asp:Content>
