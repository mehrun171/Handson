<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment_1.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
    <script type="text/javascript">

        function validateNameDiff(sender, args) {
            var name = document.getElementById('<%= TxtName.ClientID %>').value.trim();
            var familyName = args.Value.trim();
            args.IsValid = name !== familyName;
            if (!args.IsValid) {
                alert("Name and Family name should be different");
            }
        }

        function validateAddress(sender, args) {
            args.IsValid = args.Value.length >= 2;
            if (!args.IsValid) {
                alert("Address should be more than 2 char");
            }
        }

        function validateCity(sender, args) {
            args.IsValid = args.Value.length >= 2;
            if (!args.IsValid) {
                alert("City must be more than two char");
            }
        }

        function validateZip(sender, args) {
            var zip = args.Value;
            args.IsValid = zip.length === 5 && /^\d{5}$/.test(zip);
            if (!args.IsValid) {
                alert("Zip Code must be exactly 5 digits.");
            }
        }

        function validatePhone(sender, args) {
            var phone = args.Value.trim();
            var parts = phone.split('-');
            if (parts.length === 2) {
                var prefix = parts[0];
                var number = parts[1];
                args.IsValid = (prefix.length === 2 || prefix.length === 3)
                    && number.length === 7
                    && /^\d+$/.test(prefix)
                    && /^\d+$/.test(number);
            } else {
                args.IsValid = false;
            }
            if (!args.IsValid) {
                alert("phone according to the format XX-XXXXXXX or XXX-XXXXXXX");
            }
        }

        function validateEmail(sender, args) {
            var email = args.Value.trim();
            var at = email.indexOf('@');
            var dot = email.lastIndexOf('.');
            args.IsValid = at > 0 && dot > at + 1 && dot < email.length - 1;
            if (!args.IsValid) {
                alert("Invalid Email");
            }
        }

       
    </script>
<body>
    <h3>Enter Your Details:</h3>
    <form id="form1" runat="server">
    <p>
        &nbsp;&nbsp;</p>
        <div style="height: 472px">

            <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="TxtName" runat="server" style="margin-left: 85px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtName" Display="Dynamic" ErrorMessage="* Required Name" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /> <br />
            <asp:Label ID="Label2" runat="server" Text="Family Name:"></asp:Label>
            <asp:TextBox ID="TxtFamilyName" runat="server" style="margin-left: 35px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtFamilyname" Display="Dynamic" ErrorMessage="* Required Different FamilyName that of Name" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidatorFamilyname" runat="server" ControlToValidate="TxtFamilyName" Display="Dynamic" ErrorMessage="Name differet of family name" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" ClientValidationFunction="validateNameDiff"></asp:CustomValidator>
            <br /> <br />
            <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="TxtAddress" runat="server" style="margin-left: 70px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtAddress" Display="Dynamic" ErrorMessage="* Required Address at least 2 letters" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="TxtAddress" Display="Dynamic" ErrorMessage="address at least 2 letters," ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate" ClientValidationFunction="validateAddress"></asp:CustomValidator>
            <br /> <br />
            <asp:Label ID="Label4" runat="server" Text="City:"></asp:Label>
            <asp:TextBox ID="TxtCity" runat="server" style="margin-left: 95px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtCity" Display="Dynamic" ErrorMessage="* Required City at least 2 letters" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="TxtCity" Display="Dynamic" ErrorMessage="city at least 2 letters," ForeColor="Red" OnServerValidate="CustomValidator3_ServerValidate" ClientValidationFunction="validateCity"></asp:CustomValidator>
            <br /> <br />
            <asp:Label ID="Label5" runat="server" Text="Zip Code:"></asp:Label>
            <asp:TextBox ID="TxtZipcode" runat="server" style="margin-left: 64px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtZipcode" Display="Dynamic" ErrorMessage="*Required Zip Code 5 digits" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="TxtZipcode" Display="Dynamic" ErrorMessage="zip-code 5 digits" ForeColor="Red" OnServerValidate="CustomValidator4_ServerValidate" ClientValidationFunction="validateZip"></asp:CustomValidator>
            <br /> <br />
            <asp:Label ID="Label6" runat="server" Text="Phone:"></asp:Label>
            <asp:TextBox ID="TxtPhone" runat="server" style="margin-left: 85px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtPhone" Display="Dynamic" ErrorMessage="* phone according to the format XX-XXXXXXX or XXX-XXXXXXX," ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="TxtPhone" Display="Dynamic" ErrorMessage="phone according to the format XX-XXXXXXX or XXX-XXXXXXX" ForeColor="Red" OnServerValidate="CustomValidator5_ServerValidate" ClientValidationFunction="validatePhone"></asp:CustomValidator>
            <br /> <br />
            <asp:Label ID="Label7" runat="server" Text="E-mail:"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server" style="margin-left: 82px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtEmail" Display="Dynamic" ErrorMessage="* Required " ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator6" runat="server" ControlToValidate="TxtEmail" Display="Dynamic" ErrorMessage="enter valid email" ForeColor="Red" OnServerValidate="CustomValidator6_ServerValidate" ClientValidationFunction="validateEmail"></asp:CustomValidator>
            <br /> <br />
            <asp:Button ID="btnCheck" runat="server" Text="Check"
    OnClick="btnCheck_Click"
    OnClientClick="return validateAllFields();" />

            <br />
        <asp:Label ID="txtmsg" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
