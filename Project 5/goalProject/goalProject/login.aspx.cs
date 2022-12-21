using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace goalProject
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source= DESKTOP-HDOBIGI\\SQLEXPRESS01; database=goalProject; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand("Select * from users", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    string Email = Convert.ToString(sdr[2]);
                    string Password = Convert.ToString(sdr[3]);
                    if (TextBox1.Text == Email  && TextBox2.Text == Password )
                    {
                        
                        if (Convert.ToInt32(sdr[4]) == 1)
                        {
                            Label1.Text = "user is admin";
                            Response.Redirect("dashboard.aspx");

                        }
                        else
                        {
                            Label1.Text = "user in not admin";
                            
                        }
                        Session["userId"] = sdr[0];
                        Session["name"] = sdr[1];
                        Session["email"] = sdr[2];
                        Session["isAdmin"] = Convert.ToBoolean(sdr[4]) ;
                        Response.Redirect("homePage.aspx");
                        break;
                    }
                    else
                    {
                        Label1.Text = "user is not registerd";
                        
                    }


                   // Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"]); // Displaying Record  
                    //Label1.Text = sdr["id"] + " " + sdr["name"] + " " + sdr["email"];
                }
            }
            catch (Exception S)
            {
                //Console.WriteLine("OOPs, something went wrong.\n" + S);
                Label1.Text = "OOPs, something went wrong.\n" + S;
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }
}