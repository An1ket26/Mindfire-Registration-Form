using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace webForms
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridBind();
                LoadIdeas();
            }
            
        }

        protected void LoadIdeas()
        {
            using (var dbContext = new TestDBEntities())
            {
                var ideaList = dbContext.Ideas.Select(i => i.Name).ToList();
                foreach (var idea in ideaList)
                {
                    IdeaDrpdwn.Items.Add(idea);
                }
            }
        }
        protected void AddTask(object sender, EventArgs e)
        {
            string noteName =  txtLNameInsert.Text;
            using(var dbContext = new TestDBEntities())
            {
                Notes obj = new Notes();
                obj.Name = noteName;
                obj.IdeaId =dbContext.Ideas.Where(i=>i.Name==IdeaDrpdwn.Text).Select(i=>i.Id).Single();
                obj.Date = DateTime.Now;
                dbContext.Notes.Add(obj);
                dbContext.SaveChanges();
            }
            txtLNameInsert.Text = "";
            GridBind();
        }

        protected void GridBind()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Idea");
            dataTable.Columns.Add("Date");
            using(var dbContext = new TestDBEntities())
            {
                var items = dbContext.Notes.ToList();
                foreach(var item in items)
                {
                    var ideaname = dbContext.Ideas.Where(i => i.Id == item.IdeaId).Select(i => i.Name).Single().ToString();
                    dataTable.Rows.Add(item.Id, item.Name, ideaname, item.Date.ToString("dd-MM-yyyy"));
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
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            using (var dbContext = new TestDBEntities())
            {
                Notes obj = new Notes();
                obj = dbContext.Notes.Where(i => i.Id == id).Single();
                obj.Name = (GridView1.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text;
                dbContext.SaveChanges();
            }
            GridView1.EditIndex = -1;
            this.GridBind();

        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            using(var dbContext = new TestDBEntities())
            {
                Notes obj = new Notes();
                obj = dbContext.Notes.Where(i => i.Id == id).Single();
                dbContext.Notes.Remove(obj);
                dbContext.SaveChanges();
            }
            this.GridBind();
        }
    }
}