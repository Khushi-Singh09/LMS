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
    public partial class Course_1_Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            // Check if the Confirm Email ID matches the Email ID
            if (TextBox8.Text != TextBox4.Text)
            {
                // Display an error message
                ErrorMessageLabel.Text = "Email ID does not match Confirm Email ID.";
                ErrorMessageLabel.Visible = true;
                return; // Exit the event handler
            }
            else
            {
                ErrorMessageLabel.Visible = false;
            }
            try
            {
                // Create a new SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a parameterized SQL query to insert the form data into the Course3 table
                    string query = "INSERT INTO Course_1 (FirstName, LastName, DateOfBirth, ContactNo, Email,  State, City, Pincode) " +
                        "VALUES (@FirstName, @LastName, @DateOfBirth, @ContactNo, @Email,  @State, @City, @Pincode)";

                    // Create a new SqlCommand using the query and the SqlConnection
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Set the parameter values with the form data
                        command.Parameters.AddWithValue("@FirstName", TextBox1.Text);
                        command.Parameters.AddWithValue("@LastName", TextBox5.Text);
                        command.Parameters.AddWithValue("@DateOfBirth", TextBox2.Text);
                        command.Parameters.AddWithValue("@ContactNo", TextBox3.Text);
                        command.Parameters.AddWithValue("@Email", TextBox8.Text);
                        command.Parameters.AddWithValue("@State", DropDownList1.SelectedItem.Value);
                        command.Parameters.AddWithValue("@City", TextBox6.Text);
                        command.Parameters.AddWithValue("@Pincode", TextBox7.Text);


                        // Open the SqlConnection
                        connection.Open();

                        // Execute the query
                        command.ExecuteNonQuery();

                        // Close the SqlConnection
                        connection.Close();

                    }
                    Response.Write("<script>alert('Registration Completed.');</script>");
                    Response.Redirect("Complete_Reg.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


            // Clear the form fields after successful submission
            TextBox1.Text = "";
            TextBox5.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox8.Text = "";
            TextBox4.Text = "";
            DropDownList1.SelectedIndex = 0;
            TextBox6.Text = "";
            TextBox7.Text = "";
        }
    }
}