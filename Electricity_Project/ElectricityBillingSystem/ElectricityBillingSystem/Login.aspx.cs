using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBillingSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Username and password are required.";
                return;
            }

            using (SqlConnection con = DBHandler.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM AdminLogin WHERE username=@username AND password=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                    Session["Admin"] = txtUsername.Text;
                    Response.Redirect("AddBill.aspx");
                }
                else
                {
                    lblError.Text = "Invalid login credentials.";
                }
            }
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = "Password field changed.";
        }
    }
}
