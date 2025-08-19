using System;
using System.Web.UI;

namespace ElectricityBillingSystem
{
    public partial class CalculateBill : System.Web.UI.Page
    {
        ElectricityBoard board = new ElectricityBoard();
        BillValidator validator = new BillValidator();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
                lblBillAmount.Text = "";
                lblSummary.Text = "";
            }

            Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string consumerNo = txtConsumerNo.Text;
                string consumerName = txtConsumerName.Text;

                if (!int.TryParse(txtUnits.Text, out int units))
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

                ElectricityBill bill = new ElectricityBill
                {
                    ConsumerNumber = consumerNo,
                    ConsumerName = consumerName,
                    UnitsConsumed = units
                };

                board.CalculateBill(bill);

                lblBillAmount.Text = "Bill Amount: ₹" + bill.BillAmount.ToString("F2");
                lblSummary.Text = $"Consumer: {bill.ConsumerName}<br />" +
                                  $"Units: {bill.UnitsConsumed}<br />" +
                                  $"Amount: ₹{bill.BillAmount:F2}<br />" +
                                  $"Date: {DateTime.Now:dd-MMM-yyyy}";
                lblMessage.Text = "Bill calculated successfully.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtConsumerNo.Text = "";
            txtConsumerName.Text = "";
            txtUnits.Text = "";
            lblBillAmount.Text = "";
            lblSummary.Text = "";
            lblMessage.Text = "";
        }
    }
}
