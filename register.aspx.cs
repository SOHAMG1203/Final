using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gamma1
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string tempPassword = Request.Form[r_password.UniqueID];
                string tempConfirmPassword = Request.Form[r_cpassword.UniqueID];

                if (r_password != null)
                {
                    r_password.Attributes.Add("value", tempPassword);
                }

                if (r_cpassword != null)
                {
                    r_cpassword.Attributes.Add("value", tempConfirmPassword);
                }
            }


        }

        protected void registerbtn_Click(object sender, EventArgs e)
        {
            string email = r_email.Text.Trim();
            string password = r_password.Text.Trim();
            string confirmPassword = r_cpassword.Text.Trim();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                Error.Text = "All fields are required.";
                return;
            }

            if (!IsValidEmail(email))
            {
                Error.Text = "Invalid email format.";
                return;
            }

            if (password != confirmPassword)
            {
                Error.Text = "Passwords do not match.";
                return;
            }
            string securityQuestion = ddlSecurityQuestion.SelectedValue;
            if (string.IsNullOrEmpty(securityQuestion) || securityQuestion == "")
            {
                Error.Text = "Please select a security question.";
                return;
            }

            string securityAnswer = txtSecurityAnswer.Text.Trim();
            string customQuestion = securityQuestion == "Custom" ? txtCustomQuestion.Text.Trim() : "";

            if (string.IsNullOrEmpty(securityAnswer) || (securityQuestion == "Custom" && string.IsNullOrEmpty(customQuestion)))
            {
                Error.Text = "Security question and answer are required.";
                return;
            }

            string connectionString = "Data Source=(LocalDB)\\LocalDbDemo;Initial Catalog=WeddingSolutions;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO [User] (Email,Password) VALUES(@Value1,@Value2)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Value1", email);
                    cmd.Parameters.AddWithValue("@Value2", password);

                    cmd.ExecuteNonQuery();

                    Error.Text = "Registered Successfully!!";


                }
                catch (Exception ex)
                {
                    Response.Write("Exception occured : " + ex);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (Error.Text == "Registered Successfully!!")
            {
                // Redirect to index.aspx with a parameter to show the login box
                Response.Redirect("index.aspx?registered=true&showLogin=true");
            }

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
        protected void ddlSecurityQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCustomQuestion.Visible = ddlSecurityQuestion.SelectedValue == "Custom";

        }
    }
}

