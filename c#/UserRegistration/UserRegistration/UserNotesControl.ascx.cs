using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistration
{

    
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        
        public int ObjectID { get; set; }
        public string ObjectType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Auth.CheckIsAdmin())
            {
                isPrivateDiv.Attributes.Add("style", "display:inline");
            }
            else
            {
                isPrivateDiv.Attributes.Add("style", "display:none");
            }

        }
        //protected void GridBind()
        //{
        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("Id");
        //    dataTable.Columns.Add("Notes");
        //    dataTable.Columns.Add("IsPrivate");
        //    string isAdmin = "NO";
        //    if (Auth.CheckIsAdmin())
        //    {
        //        isAdmin = "YES";
        //    }
        //    if(isAdmin == "NO")
        //    {
        //        using(var dbContext = new UserEntities())
        //        {
        //            var items = dbContext.UserNotes.Where(i => i.ObjectId == ObjectID).Where(i => i.ObjectType == ObjectType && i.IsPrivate==isAdmin);
        //            foreach(var item in items)
        //            {
        //                dataTable.Rows.Add(item.NoteId, item.Notes.Trim(),item.IsPrivate.Trim());
        //            }
        //        }
        //    }
        //    else
        //    {
        //        using (var dbContext = new UserEntities())
        //        {
        //            var items = dbContext.UserNotes.Where(i => i.ObjectId == ObjectID).Where(i => i.ObjectType == ObjectType);
        //            foreach (var item in items)
        //            {
        //                dataTable.Rows.Add(item.NoteId, item.Notes.Trim(), item.IsPrivate.Trim());
        //            }
        //        }
        //    }

        //    GridView2.DataSource = dataTable;
        //    GridView2.DataBind();
        //}
        //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView2.EditIndex = e.NewEditIndex;
        //    this.GridBind();
        //}
        //protected void OnRowCancelingEdit(object sender, EventArgs e)
        //{
        //    GridView2.EditIndex = -1;
        //    this.GridBind();
        //}
        //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string item = e.Row.Cells[0].Text;
        //        foreach (Button button in e.Row.Cells[3].Controls.OfType<Button>())
        //        {
        //            if (button.CommandName == "Delete")
        //            {
        //                button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
        //            }
        //        }
        //    }
        //}
        //protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    var id = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
        //    using (var dbContext = new UserEntities())
        //    {
        //        UserNotes obj = dbContext.UserNotes.Where(i => i.NoteId ==id).Single();
        //        dbContext.UserNotes.Remove(obj);
        //        dbContext.SaveChanges();
        //    }
        //    this.GridBind();
        //}
        //protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    var noteId = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Values[0]);
        //    using(var dbContext = new UserEntities())
        //    {
        //        UserNotes obj = dbContext.UserNotes.Where(i=>i.NoteId == noteId).FirstOrDefault();
        //        var x= (GridView2.Rows[e.RowIndex].FindControl("txtNote") as TextBox).Text;
        //        obj.Notes = (GridView2.Rows[e.RowIndex].FindControl("txtNote") as TextBox).Text;
        //        dbContext.SaveChanges();
        //    }
        //    GridView2.EditIndex = -1;
        //    this.GridBind();
        //}

        //protected void AddNote(object sender, EventArgs e)
        //{
        //    if(txtAddnote.Text.Length==0)
        //    {
        //        noteErrorSpan.CssClass = noteErrorSpan.CssClass.Replace("note-error-hide", "note-error-show");
        //        return;
        //    }
        //    noteErrorSpan.CssClass = noteErrorSpan.CssClass.Replace("note-error-show", "note-error-hide");
        //    var isPrivate = isPrivateChkbox.Checked ? "YES" : "NO";
        //    using (var dbContext = new UserEntities())
        //    {
        //        UserNotes obj = new UserNotes();
        //        obj.Notes = txtAddnote.Text;
        //        obj.ObjectId = ObjectID;
        //        obj.ObjectType = ObjectType;
        //        obj.IsPrivate = isPrivate;
        //        dbContext.UserNotes.Add(obj);
        //        dbContext.SaveChanges();
        //    }
        //    this.GridBind();
        //    txtAddnote.Text="";
        //}
        
    }
}