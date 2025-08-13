using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                txtmsg.Text = "Validation Success";
                txtmsg.ForeColor = System.Drawing.Color.Green;
            }

            else
            {
                txtmsg.Text = "Validation failed. Please check your input.";
                txtmsg.ForeColor = System.Drawing.Color.Red;
            }
            

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string name = TxtName.Text.Trim();
            string familyName = TxtFamilyName.Text.Trim();
            args.IsValid = name != familyName;
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string address = TxtAddress.Text;
            args.IsValid = address.Length >= 2;
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string city = TxtCity.Text.Trim();
            args.IsValid = city.Length >= 2;
        }

        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string zip = TxtZipcode.Text.Trim();
            args.IsValid = zip.Length == 5 && IsAllDigits(zip);
        }
        private bool IsAllDigits(string input)
        {
            foreach (char c in input)
                if (!char.IsDigit(c)) return false;
            return true;
        }

        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string phone = TxtPhone.Text.Trim();
            args.IsValid = IsValidPhone(phone);
        }
        private bool IsValidPhone(string phone)
        {
            if (phone.Contains("-"))
            {
                string[] parts = phone.Split('-');
                if (parts.Length == 2)
                {
                    string prefix = parts[0];
                    string number = parts[1];
                    return (prefix.Length == 2 || prefix.Length == 3)
                        && number.Length == 7
                        && IsAllDigits(prefix)
                        && IsAllDigits(number);
                }
            }
            return false;
        }

        protected void CustomValidator6_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string email = TxtEmail.Text.Trim();
            int at = email.IndexOf('@');
            int dot = email.LastIndexOf('.');
            args.IsValid = at > 0 && dot > at + 1 && dot < email.Length - 1;
        }
    }
}