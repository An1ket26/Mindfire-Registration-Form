using System;
using System.Collections.Generic;
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
            
        }
        public void TextBxChange(object sender, EventArgs e)
        {
            var text = TextBox1.Text;
            Label1.ToolTip = text;
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
                Response.AddHeader("Content-Dispostion", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length",fileInfo.Length.ToString());
                Response.ContentType="text/plain";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                Response.End();
            }
        }
    }
}