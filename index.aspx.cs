using Gamma1;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gamma1
{
    public partial class index : System.Web.UI.Page
    {
        public bool LoginFailed { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // If it's a postback, the script registration is not needed
                UpdateClientScript();
            }

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            string email = l_email.Text.Trim();
            string password = l_password.Text.Trim();
            bool isAdmin = RadioButtonAdmin.Checked;
            bool isUser = RadioButtonUser.Checked;

            // Check if any field is left empty
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Error.Text = "Email and Password cannot be left empty";
                LoginFailed = true;
                UpdateClientScript();
                return;
            }
            if (!isAdmin && !isUser)
            {
                Error.Text = "Please select User type (User/Admin)";
                LoginFailed = true;
                UpdateClientScript();
                return;
            }

            // Check email format
            if (!IsValidEmail(email))
            {
                Error.Text = "Enter a valid email address";
                LoginFailed = true;
                UpdateClientScript();
                return;
            }

            // Check if neither radio button is selected
            

            string connectionString = "Data Source=(LocalDB)\\LocalDbDemo;Initial Catalog=WeddingSolutions;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query;

                    if (isAdmin)
                    {
                        // Query for admin login
                        query = "SELECT COUNT(1) FROM [Admin] WHERE Email=@Email AND Password=@Password";
                    }
                    else
                    {
                        // Query for user login
                        query = "SELECT COUNT(1) FROM [User] WHERE Email=@Email AND Password=@Password";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        // Login successful
                        Session["Email"] = email;

                        if (isAdmin)
                        {
                            LoginFailed = false;
                            Response.Redirect("Admin/a_index.aspx"); // Redirect to Admin page

                        }
                        else
                        {
                            Response.Redirect("HomePage.aspx"); // Redirect to User home page
                        }
                    }
                    else
                    {
                        LoginFailed = true;
                        // Login failed
                        Error.Text = "Login Failed";
                    }
                    UpdateClientScript();

                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Response.Write("Error occurred: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void UpdateClientScript()
        {
            string script = $"<script>var loginFailed = {LoginFailed.ToString().ToLower()};</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "LoginFlagScript", script);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


    }
}
