using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Web_App_IT_Courses
{
    public partial class Contact_Us : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Contact_Us(full_name,phone_number,email_id,state,city,pincode,Message) values(@full_name,@phone_number,@email_id,@state,@city,@pincode,@Message)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@phone_number", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@email_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Message", TextBox7.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Submitted');</script>");

                // Reset the textboxes and dropdownlist
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                DropDownList1.SelectedIndex = 0;
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
    }
}