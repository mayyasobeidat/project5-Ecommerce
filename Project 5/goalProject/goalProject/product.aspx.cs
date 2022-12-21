using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace goalProject
{
    public partial class product : System.Web.UI.Page
    {

        int product_id;
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con = null;
            SqlConnection con2 = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=  DESKTOP-HDOBIGI\\SQLEXPRESS01; database=goalProject; integrated security=SSPI");
                con2 = new SqlConnection("data source=  DESKTOP-HDOBIGI\\SQLEXPRESS01; database=goalProject; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand($"Select * from product where id = {Request.QueryString["id"]}", con);
                SqlCommand cm2 = new SqlCommand($"Select * from reviews where product_id ='{Request.QueryString["id"]}'", con2);
                // Opening Connection  
                con.Open();
                con2.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                while (sdr.Read())
                {
                    product_id = Convert.ToInt32(sdr[0]);

                    productimg.InnerHtml = $"<img class='imgPro' src='{sdr[5]}' />";
                    //productContainer.InnerHtml = $"<div><img src='{sdr[5]}' /> <span>{sdr[1]}</span> <span>{sdr[2]}</span> <span>{sdr[3]}</span> <span>{sdr[4]}</span> <span>{sdr[6]}</span> <span>{sdr[7]}</span>  </div>";
                    titleProduct.InnerHtml = $"{sdr[1]}";
                    titleProduct2.InnerHtml = $"{sdr[1]}";
                    descriPtionProduct.InnerHtml = $"{sdr[2]}";
                    categoryName.InnerHtml = $"{sdr[3]}";
                    price.InnerHtml = $"{sdr[4]}";
                    double x = Convert.ToDouble(sdr[4]);
                    double y = Convert.ToDouble(sdr[6]);
                    double newPrice = x - (x * y);
                    priceDiscount.InnerHtml = Convert.ToString(newPrice);
                    countInStock.InnerHtml = $"{sdr[7]}";
                    //TextBox1.Text = sdr[1].ToString();
                    //TextBox2.Text = sdr[2].ToString();
                    //TextBox3.Text = sdr[3].ToString();
                    //TextBox4.Text = sdr[4].ToString();
                    //TextBox6.Text = sdr[6].ToString();
                    //TextBox7.Text = sdr[7].ToString();

                    //Console.WriteLine(sdr["id"] + " " + sdr["name"] + " " + sdr["email"]); // Displaying Record  
                    //Label1.Text = sdr["id"] + " " + sdr["name"] + " " + sdr["email"];
                }
                SqlDataReader sdr2 = cm2.ExecuteReader();
                while (sdr2.Read())
                {
                    innerMessage.InnerHtml += $"<div><p style='color:#F24726;'>{sdr2[1]}</p><p>{sdr2[3]}</p></div><hr/>";
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
            }



        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                SqlConnection con = null;
                SqlConnection con1 = null;
                SqlConnection con2 = null;
                try
                {
                    // Creating Connection  
                    con = new SqlConnection("data source = DESKTOP-HDOBIGI\\SQLEXPRESS01; database=goalProject; integrated security=SSPI");
                    con1 = new SqlConnection("data source = DESKTOP-HDOBIGI\\SQLEXPRESS01; database=goalProject; integrated security=SSPI");
                    con2 = new SqlConnection("data source = DESKTOP-HDOBIGI\\SQLEXPRESS01; database=goalProject; integrated security=SSPI");


                    // writing sql query  
                    SqlCommand cm1 = new SqlCommand($"select * from cart", con1);
                    SqlCommand cm = new SqlCommand($"insert into cart  (product_id, user_id)values('{Request.QueryString["id"]}',   '{Convert.ToInt32(Session["userId"])}'   )", con);
                    SqlCommand cm2 = new SqlCommand($"update cart set qty = qty + 1 where product_id = {Request.QueryString["id"]} AND user_id = {Session["userId"]}", con2);

                    // Opening Connection  
                    con.Open();
                    con1.Open();
                    con2.Open();
                    SqlDataReader sdr1 = cm1.ExecuteReader();
                    // Iterating Data
                    bool there = false;
                    while (sdr1.Read())
                    {

                        if (Convert.ToInt32(sdr1[1]) == Convert.ToInt32(Request.QueryString["id"]) && Convert.ToInt32(sdr1[3]) == Convert.ToInt32(Session["userId"]))
                        {
                            there = true;


                        }



                    }
                    if (there)
                    {
                        cm2.ExecuteNonQuery();
                    }
                    else
                    {
                        // Executing the SQL query  
                        cm.ExecuteNonQuery();
                    }

                    // Displaying a message  
                    Console.WriteLine("Record Inserted Successfully");
                    //Label1.Text = "Record Inserted Successfully";
                }
                catch (Exception A)
                {
                    // Label1.Attributes.Add("style", "display:inline-block");
                    //Console.WriteLine("OOPs, something went wrong." + A);
                    Label1.Text = "OOPs, something went wrong." + A;
                }
                // Closing the connection  
                finally
                {
                    con.Close();
                    con1.Close();
                    con2.Close();
                }

            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                SqlConnection con = null;
                try
                {
                    // Creating Connection  
                    con = new SqlConnection("data source = DESKTOP-HDOBIGI\\SQLEXPRESS01; database=goalProject; integrated security=SSPI");
                    // writing sql query  

                    SqlCommand cm = new SqlCommand($"insert into reviews  ( user_name, product_id, comment)values('{Session["name"]}',   {Convert.ToInt32(Request.QueryString["id"])}   ,    '{TextBox1.Text}')", con);
                    // Opening Connection  
                    con.Open();
                    // Executing the SQL query  
                    cm.ExecuteNonQuery();
                    // Displaying a message  
                    Console.WriteLine("Record Inserted Successfully");
                    //Label1.Text = "Record Inserted Successfully";
                }
                catch (Exception A)
                {
                    //Label1.Attributes.Add("style", "display:inline-block");
                    Console.WriteLine("OOPs, something went wrong." + A);
                    // Label1.Text = "OOPs, something went wrong." + A;
                }
                // Closing the connection  
                finally
                {
                    con.Close();
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }


    }
}