using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodOrderManagement
{
    public partial class AddEditMenu : System.Web.UI.Page
    {
        int menuId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Request.QueryString["MenuId"] != null)
            {
                menuId = Convert.ToInt32(Request.QueryString["MenuId"]);
            }

            if (!IsPostBack)
            {
                if (menuId > 0)
                {
                    LoadMenu();
                }
            }
        }

        void LoadMenu()
        {
            string cs = ConfigurationManager.ConnectionStrings["FoodDBCS"].ConnectionString;

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd =
                new SqlCommand("select * from MenuItems where MenuId=@id", con);

            cmd.Parameters.AddWithValue("@id", menuId);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtItemName.Text = dr["ItemName"].ToString();
                txtCategory.Text = dr["Category"].ToString();
                ddlFoodType.Text = dr["FoodType"].ToString();
                txtPrice.Text = dr["Price"].ToString();
                txtQty.Text = dr["AvailableQuantity"].ToString();
                chkAvailable.Checked =
                    Convert.ToBoolean(dr["IsAvailable"]);
            }

            con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["FoodDBCS"].ConnectionString;

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd;

            if (menuId > 0)
            {
                cmd = new SqlCommand(
                    "update MenuItems set ItemName=@name,Category=@cat,FoodType=@type,Price=@price,AvailableQuantity=@qty,IsAvailable=@avail where MenuId=@id", con);

                cmd.Parameters.AddWithValue("@id", menuId);
            }
            else
            {
                cmd = new SqlCommand(
                    "insert into MenuItems values(@name,@cat,@type,@price,@qty,@avail,@date)", con);

                cmd.Parameters.AddWithValue("@date", DateTime.Now);
            }

            cmd.Parameters.AddWithValue("@name", txtItemName.Text);
            cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
            cmd.Parameters.AddWithValue("@type", ddlFoodType.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@qty", txtQty.Text);
            cmd.Parameters.AddWithValue("@avail", chkAvailable.Checked);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("MenuList.aspx");
        }
    }
}