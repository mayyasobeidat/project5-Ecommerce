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
    public partial class register : System.Web.UI.Page
    {

        public void uploadToDatabase(string srcP)
        {

            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source = DESKTOP-HDOBIGI\\SQLEXPRESS01; database=goalproject; integrated security=SSPI");
                // writing sql query  
                string name = TextBox1.Text + " " + TextBox4.Text;
                SqlCommand cm = new SqlCommand($"insert into users  ( name, email, password, imgSrc)values('{name}',   '{TextBox2.Text}'   ,    '{TextBox3.Text}',  'Images/ {Path.GetFileName(FileUpload1.FileName)}')", con);
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
                //Console.WriteLine("OOPs, something went wrong." + A);
                Label1.Text = "OOPs, something went wrong." + A;
            }
            // Closing the connection  
            finally
            {
            con.Close();
                Response.Redirect("login.aspx");
            }
        }






        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadFile(object sender, EventArgs e)
        {




            try
            {
                string folderPath = Server.MapPath("~/Images/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath);
                }

                //Save the File to the Directory (Folder).
                string fullPath = folderPath + Path.GetFileName(FileUpload1.FileName);
                string srcPath = "/Images/" + Path.GetFileName(FileUpload1.FileName);

                FileUpload1.SaveAs(fullPath);
                //Image1.ImageUrl = srcPath;


                uploadToDatabase(srcPath);


            }
            catch (SqlException q)
            {
                Response.Write(q.Message);
            }

        }

    }
}