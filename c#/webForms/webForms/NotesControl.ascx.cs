using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webForms
{
    public partial class NotesControl : System.Web.UI.UserControl
    {

        public int ObjectID { get; set; }
        public string ObjectType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ObjectId"] != null)
                {
                    this.ObjectID = int.Parse(Request.QueryString["ObjectId"]);
                    btnAdd.Enabled = true;
                    GridBind();
                }
            }
            if(IsPostBack)
                GridBind();

        }
        protected void GridBind()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Notes");

            using(var dbContext = new TestDBEntities())
            {
                var items = dbContext.NoteApp.Where(i => i.ObjectId == ObjectID).Where(i => i.ObjectType == ObjectType);
                foreach(var item in items)
                {
                    dataTable.Rows.Add(item.NoteId, item.Notes);
                }
            }
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.GridBind();
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.GridBind();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            using (var dbContext = new TestDBEntities())
            {
                NoteApp obj = dbContext.NoteApp.Where(i => i.NoteId ==id).Single();
                dbContext.NoteApp.Remove(obj);
                dbContext.SaveChanges();
            }
            this.GridBind();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            using(var dbContext = new TestDBEntities())
            {
                NoteApp obj = dbContext.NoteApp.Where(i=>i.NoteId==id).Single();
                obj.Notes = (GridView1.FindControl("txtNote") as TextBox).Text;
                dbContext.SaveChanges();
            }
            GridView1.EditIndex = -1;
            this.GridBind();
        }

        protected void AddNote(object sender, EventArgs e)
        {
            //Response.Write("came");
            
            using(var dbContext = new TestDBEntities())
            {
                NoteApp obj = new NoteApp();
                obj.Notes = txtAddnote.Text;
                obj.ObjectId = ObjectID;
                obj.ObjectType = ObjectType;
                dbContext.NoteApp.Add(obj);
                dbContext.SaveChanges();
            }
            this.GridBind(); 
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


    }
}