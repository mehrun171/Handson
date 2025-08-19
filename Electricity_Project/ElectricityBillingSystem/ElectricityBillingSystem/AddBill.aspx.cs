using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityBillingSystem
{
    public partial class AddBill : System.Web.UI.Page
    {
        ElectricityBoard board = new ElectricityBoard();
        BillValidator validator = new BillValidator();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
                lblBillAmount.Text = "";
                pnlBillEntry.Visible = false;
                btnSubmit.Enabled = false;
            }

            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnStartEntry_Click(object sender, EventArgs e)
        {
            int totalBills;
            if (!int.TryParse(txtBillCount.Text.Trim(), out totalBills) || totalBills < 1 || totalBills > 100)
            {
                lblMessage.Text = "Enter a valid number between 1 and 100.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            ViewState["TotalBills"] = totalBills;
            hfCurrentCount.Value = "0";
            pnlBillEntry.Visible = true;
            btnSubmit.Enabled = true;
            lblMessage.Text = $"Entering bill 1 of {totalBills}";
            lblMessage.ForeColor = System.Drawing.Color.Blue;
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                ElectricityBill bill = new ElectricityBill();
                bill.ConsumerNumber = txtConsumerNo.Text;
                bill.ConsumerName = txtConsumerName.Text;

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string consumerNo = txtConsumerNo.Text;
            string consumerName = txtConsumerName.Text;
            int units;

            if (!int.TryParse(txtUnits.Text.Trim(), out units))
            {
                lblMessage.Text = "Invalid units entered.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string rawText = lblBillAmount.Text;
            string numericPart = Regex.Match(rawText, @"\d+[\d,]*\.?\d*").Value.Replace(",", "").Replace(" ", "");

            decimal amount;
            if (!decimal.TryParse(numericPart, NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
            {
                lblMessage.Text = $"Could not parse bill amount from: '{rawText}'";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

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
                            int current = int.Parse(hfCurrentCount.Value);
                            int total = (int)ViewState["TotalBills"];
                            current++;

                            if (current < total)
                            {
                                hfCurrentCount.Value = current.ToString();
                                lblMessage.Text = $"Bill {current} submitted. Enter bill {current + 1} of {total}.";
                                lblMessage.ForeColor = System.Drawing.Color.Green;
                                ClearForm();
                            }
                            else
                            {
                                lblMessage.Text = $"All {total} bills submitted successfully!";
                                lblMessage.ForeColor = System.Drawing.Color.DarkGreen;
                                pnlBillEntry.Visible = false;
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Failed to submit bill.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearForm()
        {
            txtConsumerNo.Text = "";
            txtConsumerName.Text = "";
            txtUnits.Text = "";
            lblBillAmount.Text = "";
            lblSummary.Text = "";
            btnSubmit.Enabled = true;
        }
    }
}
