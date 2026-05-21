using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProduct.SelectedItem.Text == "Laptop")
            {
                imgProduct.ImageUrl = "~/Images/laptop.jpg";
            }

            else if (ddlProduct.SelectedItem.Text == "Mobile")
            {
                imgProduct.ImageUrl = "~/Images/mobile.jpg";
            }

            else if (ddlProduct.SelectedItem.Text == "Headphone")
            {
                imgProduct.ImageUrl = "~/Images/headphone.jpg";
            }

            else if (ddlProduct.SelectedItem.Text == "Watch")
            {
                imgProduct.ImageUrl = "~/Images/watch.jpg";
            }

            else
            {
                imgProduct.ImageUrl = "";
            }
        }

        protected void btnPrice_Click(object sender, EventArgs e)
        {
            if (ddlProduct.SelectedItem.Text == "Laptop")
            {
                lblPrice.Text = "Price : Rs. 55000";
            }

            else if (ddlProduct.SelectedItem.Text == "Mobile")
            {
                lblPrice.Text = "Price : Rs. 25000";
            }

            else if (ddlProduct.SelectedItem.Text == "Headphone")
            {
                lblPrice.Text = "Price : Rs. 3000";
            }

            else if (ddlProduct.SelectedItem.Text == "Watch")
            {
                lblPrice.Text = "Price : Rs. 5000";
            }

            else
            {
                lblPrice.Text = "Select Product";
            }
        }
    }
}