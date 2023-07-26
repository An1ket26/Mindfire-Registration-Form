using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace webForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Cookies["Name"].Expires = DateTime.Now.AddDays(-1);
            //DataTable table = new DataTable();
            //table.Columns.Add("Name");
            //table.Rows.Add("Aniket");
            //DataList1.DataSource = table;
            //DataList1.DataBind();

        }
        protected void TextBxChange(object sender, EventArgs e)
        {
            LogRecord("Textbox changed");
            LogRecord(TextBox1.Text);
            String text=TextBox1.Text;
            HttpCookie cookies = new HttpCookie("Name");
            cookies.Value = text;
            Response.Cookies.Add(cookies);

            Session["Name"] = text;
          

            //Response.Cookies["Name"]["Text"] =text;

        }

        protected void Submit_Click1(object sender, EventArgs e)
        {
            
            var text=TextBox1.Text;
            Label1.Text = text;

        }

        protected void FormCalendar_SelectionChanged(object sender, EventArgs e)
        {
            Label2.Text = FormCalendar.SelectedDate.ToString("dd/MM/yyyy");
        }
        protected void FileUploadButton(object sender, EventArgs e)
        {
            
            LogRecord("File Coming");
            LogRecord(File1.PostedFile.ToString());
            if(File1.PostedFile!=null && (File1.PostedFile.ContentLength>0))
            {
                int count = 0;
                foreach(HttpPostedFile postFile in File1.PostedFiles)
                {
                    string fileName = System.IO.Path.GetFileName(postFile.FileName);
                    LogRecord(fileName);
                    string saveLocation = Server.MapPath("upload") + "\\" + fileName;
                    try
                    {
                        postFile.SaveAs(saveLocation);
                        count++;
                    }
                    catch (Exception ex)
                    {
                        Label3.Text = "Error :" + ex.Message;
                    }
                }
                if(count>0)
                {
                    Label3.Text = count + " Files uploaded successfully";
                }
            }
            else
            {
                Label3.Text = "Please select a file to upload.";
            }
        }
        public static void LogRecord(string message)
        {
            Console.WriteLine(message);
            string pathName = Path.Combine("D:\\Projects\\Assignments\\test\\test2.txt");
            if (File.Exists(pathName))
            {
                File.AppendAllText(pathName, message + Environment.NewLine);
            }
            else
            {
                File.WriteAllText(pathName, message + Environment.NewLine);
            }
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            string filePath = "D:\\Projects\\Assignments\\test\\test2.txt";
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", " attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length",fileInfo.Length.ToString());
                Response.ContentType="text/plain";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                Response.End();
            }
        }
        protected void Add_List_Click(object sender, EventArgs e)
        {
            string txt = Tb3.Text;
            DropDownList1.Items.Add(txt);
            Tb3.Text="";
            
        }
        protected void Add_To_DataList(object sender,EventArgs e) 
        {
            var id = int.Parse(Tb4.Text);
            DataTable dt = new DataTable();
            dt.Columns.Add("UserID1");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            using(var dbContext = new TestDBEntities())
            {
                var items = dbContext.GetDetailsById(id);
                foreach (var item in items)
                {
                    dt.Rows.Add(item.UserID.ToString(),item.FirstName,item.LastName);
                }
            }
            DataList1.DataSource = dt;
            DataList1.DataBind(); 
        }
       
    }
}