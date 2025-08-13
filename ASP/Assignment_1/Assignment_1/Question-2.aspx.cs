using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class Question_2 : System.Web.UI.Page
    {
        Dictionary<string, (string imageUrl, string price)> products = new Dictionary<string, (string, string)>
        {
            { "Iphone", ("~/Images/iphone.png", "₹145,000") },
            { "Samsung S25 Ultra", ("~/Images/samsung.png", "₹165,000") },
            { "Oneplus", ("~/Images/oneplus.jpg", "₹49,500") },
            { "Oppo", ("~/Images/oppo.jpg", "₹42,000") },
            { "Vivo", ("~/Images/vivo.jpg", "₹38,500") },
            { "Realme", ("~/Images/realme.jpg", "₹34,000") }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.DataSource = products.Keys;
                ddlProducts.DataBind();
                ddlProducts.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Product --", ""));
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (products.ContainsKey(selected))
            {
                imgProduct.ImageUrl = products[selected].imageUrl;
                lblPrice.Text = ""; 
            }
            else
            {
                imgProduct.ImageUrl = "";
                lblPrice.Text = "";
            }
        }

        protected void btnGetProPrice_Click(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (products.ContainsKey(selected))
            {
                lblPrice.Text = "Price of This Mobile: " + products[selected].price;
            }
            else
            {
                lblPrice.Text = "Please select a product.";
            }
        }
    }
}