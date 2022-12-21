using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace goalProject
{
    public partial class cart : System.Web.UI.Page
    {
      

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["userId"] = null;
            Session["name"] = null;
            Session["email"] = null;
            Session["isAdmin"] = null;
            Response.Redirect("homePage.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                userName.Style.Add("display", "none");
                Button1.Style.Add("display", "none");
                cart1.Style.Add("display", "none");
            }
            else
            {
                register.Style.Add("display", "none");
                userName.Style.Add("display", "inline-block");
                userName.InnerHtml = Session["name"].ToString();
            }



            if (Session["name"] == null)
            {
                cart1.Style.Add("display", "none");
                dashboard.Style.Add("display", "none");
            }
            else
            {
                cart1.Style.Add("display", "inline-block");
                // userName.InnerHtml = Session["name"].ToString();
            }



            if (Session["name"] != null)
            {

                signin.Style.Add("display", "none");

            }
            else
            {
                signin.Style.Add("display", "inline-block");
            }

            if (Session["name"] == null)
            {

                Button1.Attributes.Add("style", "display:none");
            }
            else
            {
                Button1.Attributes.Add("style", "display:inline-block");
            }
            if (Session["isAdmin"] == null)
            {

                dashboard.Style.Add("display", "none");

            }
            else
            {
                dashboard.Style.Add("display", "inline-block");
                if (Convert.ToBoolean(Session["isAdmin"]))
                {
                    cart1.Style.Add("display", "none");
                    dashboard.InnerHtml = "dashboard";
                }
            }

            if (Session["name"] != null)
            {

                if (!IsPostBack)
                {
                    SqlConnection con = null;
                    SqlConnection con2 = null;
                    try
                    {
                        // Creating Connection  
                        con = new SqlConnection("data source= DESKTOP-HDOBIGI\\SQLEXPRESS01; database=goalProject; integrated security=SSPI");
                        // writing sql query  
                        SqlCommand cm = new SqlCommand($"select * from cart join product on cart.product_id = product.id join users on cart.user_id = users.id where cart.user_id = {Session["userId"]}", con);
                        // Opening Connection  
                        con.Open();
                        // Executing the SQL query  
                        SqlDataReader sdr = cm.ExecuteReader();
                        // Iterating Data  
                        while (sdr.Read())
                        {
                            //Button button = new Button();
                            //button.Click += new EventHandler(button_delete);
                            //button.ID = Convert.ToString(sdr[0]) ;


                            double x = Convert.ToDouble(sdr[9]);
                            double y = Convert.ToDouble(sdr[11]);
                            double newPrice = x - (x * y);

                            if (Convert.ToDecimal(sdr[11]) != 0)
                            {
                                cartContainer.InnerHtml += $"<div class='cartBox' ><img class='productIMG'  src='{sdr[10]}' /> <span class='details'>{sdr[6]}</span class='details'> <span class='details' style='text-decoration: line-through;'>{sdr[9]} $</span> <span class='details'>{newPrice} $</span> <a class='details' href='deleteCart.aspx?id={sdr[0]}'>delete</a><br/> </div>";
                            }
                            else
                            {
                                cartContainer.InnerHtml += $"<div class='cartBox' ><img class='productIMG'  src='{sdr[10]}' /> <span class='details'>{sdr[6]}</span class='details'> <span class='details' >{sdr[9]} $</span> <a class='details' href='deleteCart.aspx?id={sdr[0]}'>delete</a><br/> </div>";
                            }



                            con2 = new SqlConnection("data source= DESKTOP-HDOBIGI\\SQLEXPRESS01; database=goalProject ; integrated security= SSPI ");
                            SqlCommand comand2 = new SqlCommand($"select sum(product.price) from cart join product on cart.product_id = product.id join users on cart.user_id = users.id where cart.user_id = {Session["userId"]};", con2);
                            con2.Open();
                            SqlDataReader rdr2 = comand2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                totalPrice.InnerHtml = rdr2[0].ToString();
                            }

                        }
                    }
                    catch (Exception S)
                    {
                        Console.WriteLine("OOPs, something went wrong.\n" + S);
                        //Label1.Text = "OOPs, something went wrong.\n" + S;
                    }
                    // Closing the connection  
                    finally
                    {
                        con.Close();
                        con2.Close();
                    }

                }

            }
            else
            {
                Label12.InnerHtml="Please login first !!";
            }


        }
        protected void button_delete(object sender, EventArgs e)
        {
          
        }
    }
}