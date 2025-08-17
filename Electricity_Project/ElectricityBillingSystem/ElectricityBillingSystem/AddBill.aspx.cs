using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBillingSystem
{
    public partial class AddBill : System.Web.UI.Page
    {
        ElectricityBill bill = new ElectricityBill();
        ElectricityBoard board = new ElectricityBoard();
        BillValidator validator = new BillValidator();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
                lblBillAmount.Text = "";
            }
            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                ElectricityBill bill = new ElectricityBill();
                bill.ConsumerNumber = txtConsumerNo.Text.Trim();
                bill.ConsumerName = txtConsumerName.Text.Trim();

                if (!int.TryParse(txtUnits.Text.Trim(), out int units))
                {
                    lblMessage.Text = "Units must be a valid number.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string validationMsg = validator.ValidateUnitsConsumed(units);
                if (validationMsg != null)
                {
                    lblMessage.Text = validationMsg;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                bill.UnitsConsumed = units;
                board.CalculateBill(bill);

                lblBillAmount.Text = "Bill Amount: ₹" + bill.BillAmount.ToString("F2");
                lblSummary.Text = $"Consumer: {bill.ConsumerName}<br />" +
                                  $"Units: {bill.UnitsConsumed}<br />" +
                                  $"Amount: ₹{bill.BillAmount:F2}<br />" +
                                  $"Date: {DateTime.Now:dd-MMM-yyyy}";
                lblMessage.Text = "Bill calculated successfully.";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                ViewState["Bill"] = bill;
                btnSubmit.Enabled = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        /*protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string consumerNo = txtConsumerNo.Text.Trim();
            string consumerName = txtConsumerName.Text.Trim();
            int units = int.Parse(txtUnits.Text.Trim());

            // Safely parse the bill amount
            string rawAmount = lblBillAmount.Text.Replace("₹", "").Replace(",", "").Trim();
            decimal amount;
            if (!decimal.TryParse(rawAmount, out amount))
            {
                lblMessage.Text = "❌ Invalid bill amount format.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO ElectricityBill 
                             (ConsumerNo, ConsumerName, UnitsConsumed, BillAmount, BillDate) 
                             VALUES (@ConsumerNo, @ConsumerName, @UnitsConsumed, @BillAmount, @BillDate)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ConsumerNo", consumerNo);
                        cmd.Parameters.AddWithValue("@ConsumerName", consumerName);
                        cmd.Parameters.AddWithValue("@UnitsConsumed", units);
                        cmd.Parameters.AddWithValue("@BillAmount", amount);
                        cmd.Parameters.AddWithValue("@BillDate", DateTime.Now);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "✅ Bill submitted successfully!";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            btnSubmit.Enabled = false;
                        }
                        else
                        {
                            lblMessage.Text = "❌ Failed to submit bill.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"❌ Error: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }*/
       
protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Step 1: Gather and validate inputs
        string consumerNo = txtConsumerNo.Text.Trim();
        string consumerName = txtConsumerName.Text.Trim();
        int units;

        if (!int.TryParse(txtUnits.Text.Trim(), out units))
        {
            lblMessage.Text = "❌ Invalid units entered.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }

        // Step 2: Extract and parse bill amount safely
        string rawText = lblBillAmount.Text;
        string numericPart = Regex.Match(rawText, @"\d+[\d,]*\.?\d*").Value.Replace(",", "").Replace(" ", "");

        decimal amount;
        if (!decimal.TryParse(numericPart, NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
        {
            lblMessage.Text = $"❌ Could not parse bill amount from: '{rawText}'";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }

            // Step 3: Insert into database
            string connectionString = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;

            try
            {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ElectricityBill 
                             (consumer_number, consumer_name, units_consumed, bill_amount) 
                             VALUES (@ConsumerNo, @ConsumerName, @UnitsConsumed, @BillAmount)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ConsumerNo", consumerNo);
                    cmd.Parameters.AddWithValue("@ConsumerName", consumerName);
                    cmd.Parameters.AddWithValue("@UnitsConsumed", units);
                    cmd.Parameters.AddWithValue("@BillAmount", amount);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "✅ Bill submitted successfully!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        btnSubmit.Enabled = false;
                    }
                    else
                    {
                        lblMessage.Text = "❌ Failed to submit bill.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = $"❌ Error: {ex.Message}";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }



}
}