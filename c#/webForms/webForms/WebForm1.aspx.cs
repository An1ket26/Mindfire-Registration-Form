using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
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
            if (!IsPostBack)
            {
                DataListBind();
                BindGrid();
                Response.Write("First time");
            }
            else
                Response.Write("PostBacks"); 
            
           
        }
        protected void Page_Start(object sender, EventArgs e)
        {

        }
        protected void Page_PreInit(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_InitComplete(object sender, EventArgs e)
        {

        }
        protected override void OnPreLoad(EventArgs e)
        {

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {

        }
        protected override void OnSaveStateComplete(EventArgs e)
        {
            
        }
        protected void Page_UnLoad(object sender, EventArgs e)
        {

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
            
            using(var dbContext = new TestDBEntities())
            {
               DataList1.DataSource = dbContext.GetDetailsById(id).ToList();
               DataList1.DataBind();
            }
        }
        protected void DataList1_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            

            DataList1.EditItemIndex = e.Item.ItemIndex;
            if(e.CommandName=="Edit")
                Add_To_DataList(sender, e);
        }
        protected void Datalist1_UpdateCommand(object sender, DataListCommandEventArgs e)
        {
            
            string Fname = (e.Item.FindControl("FirstNameTxt") as TextBox).Text;
            
            string Lname = (e.Item.FindControl("LastNameTxt") as TextBox).Text;
            LogRecord(Fname + Lname);
            using(var dbContext = new TestDBEntities())
            {
                var id = int.Parse(Tb4.Text);
                var items = dbContext.UserDetails.Where(i=>i.UserID==id);
                foreach(var item in items)
                {
                    item.FirstName = Fname;
                    item.LastName = Lname;
                }
                dbContext.SaveChanges();
            }
            Add_To_DataList(sender, e);
        }
        protected void Datalist1_CancelCommand(object sender, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = -1;
            Add_To_DataList(sender, e);
        }


        protected void BindGrid()
        {
            using (var dbContext = new TestDBEntities())
            {
                GridView1.DataSource = dbContext.UserDetails.ToList();
                GridView1.DataBind();
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string Fname = (row.FindControl("txtFName") as TextBox).Text;
            string Lname = (row.FindControl("txtLName") as TextBox).Text;
            LogRecord("Grid Changes = " + Fname + " " + Lname+" "+userId);
            using (var dbContext = new TestDBEntities())
            {
                var items = dbContext.UserDetails.Where(i => i.UserID == userId);
                foreach (var item in items)
                {
                    item.FirstName = Fname;
                    item.LastName = Lname;
                }
                dbContext.SaveChanges();
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void GridInsert(object sender, EventArgs e)
        {
            using(var dbContext = new TestDBEntities())
            {
                UserDetails obj= new UserDetails();
                obj.FirstName = txtFNameInsert.Text;
                obj.LastName = txtLNameInsert.Text;
                dbContext.UserDetails.Add(obj);
                dbContext.SaveChanges();
            }
            txtFNameInsert.Text="";
            txtLNameInsert.Text= "";
            this.BindGrid();
        }
         protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int userId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            using(var dbContext = new TestDBEntities()) 
            {
                UserDetails obj = new UserDetails();
                obj=dbContext.UserDetails.Where(i=>i.UserID==userId).Single();
                dbContext.UserDetails.Remove(obj);
                dbContext.SaveChanges();
            }
            this.BindGrid();
        }

        protected void DataListBind()
        {
            using (var dbContext = new TestDBEntities())
            {
                DataList2.DataSource = dbContext.UserDetails.ToList();
                DataList2.DataBind();
            }
        }
        protected void DataList2_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            DataList2.EditItemIndex = e.Item.ItemIndex;
            if (e.CommandName == "Edit")
                DataListBind();
        }
        protected void Datalist2_UpdateCommand(object sender, DataListCommandEventArgs e)
        {
            int id = Convert.ToInt32(DataList2.DataKeys[e.Item.ItemIndex]);
            LogRecord(id.ToString());
            string Fname = (e.Item.FindControl("FirstNameTxt1") as TextBox).Text;
            string Lname = (e.Item.FindControl("LastNameTxt1") as TextBox).Text;
            //LogRecord(Fname + Lname);
            using (var dbContext = new TestDBEntities())
            {
                var items = dbContext.UserDetails.Where(i => i.UserID == id);
                foreach (var item in items)
                {
                    item.FirstName = Fname;
                    item.LastName = Lname;
                }
                dbContext.SaveChanges();
            }
            DataList2.EditItemIndex = -1;
            this.DataListBind();
        }
        
        protected void Datalist2_CancelCommand(object sender, DataListCommandEventArgs e)
        {
            DataList2.EditItemIndex = -1;
            this.DataListBind();
        }
        protected void Datalist2_DeleteCommand(object sender, DataListCommandEventArgs e)
        {
            int id = Convert.ToInt32(DataList2.DataKeys[e.Item.ItemIndex]);
            using(var dbContext = new TestDBEntities())
            {
                UserDetails obj=new UserDetails();
                obj = dbContext.UserDetails.Where(i => i.UserID == id).Single();
                dbContext.UserDetails.Remove(obj);
                dbContext.SaveChanges();
            }
            DataList2.EditItemIndex = -1;
            this.DataListBind();
        }

    }
}