using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ElectricityBillingSystem
{
    public partial class ViewBills : System.Web.UI.Page
    {

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            int count;
            if (!int.TryParse(txtCount.Text, out count) || count < 1 || count > 100)
            {
                lblMessage.Text = "Invalid number entered.";
                gvBills.DataSource = null;
                gvBills.DataBind();
                return;
            }

            var connSetting = ConfigurationManager.ConnectionStrings["ElectricityBillDB"];
            if (connSetting == null)
            {
                lblMessage.Text = "Connection string not found.";
                return;
            }
            string connectionString = connSetting.ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT TOP (@Count) consumer_number, consumer_name, units_consumed, bill_amount
FROM ElectricityBill
ORDER BY bill_id DESC
";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Count", count);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        gvBills.DataSource = dt;
                        gvBills.DataBind();
                        lblMessage.Text = "";
                    }
                    else
                    {
                        gvBills.DataSource = null;
                        gvBills.DataBind();
                        lblMessage.Text = "No bills found.";
                    }
                }
            }
        }
    }
}
