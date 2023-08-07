using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserRegistration
{
    public partial class UserDetails : Auth
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            DataTable datatable=new DataTable();
            datatable.Columns.Add("Id");
            datatable.Columns.Add("FirstName");
            datatable.Columns.Add("LastName");
            datatable.Columns.Add("Email");
            datatable.Columns.Add("Dob");
            datatable.Columns.Add("Gender");
            datatable.Columns.Add("PresentAddrL1");
            datatable.Columns.Add("PresentAddrL2");
            datatable.Columns.Add("PresentPcode");
            datatable.Columns.Add("PresentCountry");
            datatable.Columns.Add("PresentState");
            datatable.Columns.Add("PresentCity");
            datatable.Columns.Add("PermanentAddrL1");
            datatable.Columns.Add("PermanentAddrL2");
            datatable.Columns.Add("PermanentPcode");
            datatable.Columns.Add("PermanentCountry");
            datatable.Columns.Add("PermanentState");
            datatable.Columns.Add("PermanentCity");
            datatable.Columns.Add("Hobby");
            datatable.Columns.Add("IsSubscribed");
            datatable.Columns.Add("Roles");

            using (var dbContext = new UserEntities())
            {
                var items = dbContext.User;
                foreach(var item in items)
                {
                    string presentCountryName =dbContext.Country.
                        Where(i=>i.CountryId==item.PresentCountryId).
                        Select(i=>i.CountryName).Single().ToString();
                    string permanentCountryName = dbContext.Country.Where(i => i.CountryId == item.PermanentCountryId).
                        Select(i => i.CountryName).Single().ToString();
                    string presentStateName = dbContext.State.Where(i => i.StateId == item.PresentStateId).
                        Select(i => i.StateName).Single().ToString();
                    string permanentStateName = dbContext.State.Where(i => i.StateId == item.PermanentStateId).
                        Select(i => i.StateName).Single().ToString();
                    var hobbies = dbContext.Hobby.Where(i => i.UserId == item.UserId);
                    string hobby = "";
                    foreach(var hob in hobbies)
                    {
                        hobby += hob.HobbyName.Trim()+",";
                    }
                    if(hobby.Length>0)
                        hobby = hobby.Substring(0,hobby.Length-1).Trim();
                    string Roles = "";
                    var roleIds = dbContext.UserRole.
                        Where(i=>i.UserId == item.UserId).
                        Select(i=>i.RoleId);
                    foreach(var roleid in roleIds)
                    {
                        Roles+=dbContext.Role.
                            Where(i => i.RoleId == roleid).
                            Select(i => i.RoleName).Single().ToString().Trim()+",";
                    }
                    if(Roles.Length>0)
                        Roles = Roles.Substring(0, Roles.Length - 1).Trim();
                    datatable.Rows.Add(item.UserId, item.Firstname.Trim(), item.LastName.Trim(), item.Email.Trim(),
                        item.Dob, item.Gender, item.PresentAddressLine1.Trim(), item.PresentAddressLine2.Trim(),
                        item.PresentPostalCode.Trim(), presentCountryName, presentStateName,
                        item.PresentCity.Trim(),item.PermanentAddressLine1.Trim(), item.PermanentAddressLine2.Trim(),
                        item.PermanentPostalCode.Trim(),permanentCountryName, permanentStateName,
                        item.PermanentCity.Trim(), hobby,item.IsSubscribed.Trim(), Roles);
                }
                GridView1.DataSource = datatable;
                GridView1.DataBind();
            }
        }
        protected void OnRowEditing(object sender,GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            int userId = Convert.ToInt32(GridView1.DataKeys[GridView1.EditIndex].Values[0]);
            Response.Redirect("UserDetails?UserId="+userId+"&tab=detailsLink");
            BindGrid();
        }

        protected void OnRowCancelingEdit(object sender,EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void OnRowDeleting(object sender,GridViewDeleteEventArgs e)
        {
            int deleteId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            using(var dbContext = new UserEntities())
            {
                var hobbies = dbContext.Hobby.Where(i => i.UserId == deleteId);
                foreach(var hobby in hobbies)
                {
                    dbContext.Hobby.Remove(hobby); 
                } 
                dbContext.SaveChanges();
                var userRoles = dbContext.UserRole.Where(i=>i.UserId == deleteId);
                foreach(var role in userRoles)
                {
                    dbContext.UserRole.Remove(role);
                }
                dbContext.SaveChanges();
                var notes = dbContext.UserNotes.Where(i=>i.ObjectId==deleteId && i.ObjectType=="User");
                foreach(var note in notes)
                {
                    dbContext.UserNotes.Remove(note); 
                }
                dbContext.SaveChanges();
                var files = dbContext.UserFiles.Where(i => i.userId == deleteId);
                foreach(var file in files)
                {
                    dbContext.UserFiles.Remove(file);
                }
                User obj = new User();
                obj=dbContext.User.Where(i=>i.UserId== deleteId).FirstOrDefault();
                dbContext.User.Remove(obj);
                dbContext.SaveChanges();
            }
            this.BindGrid();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[7].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }
        protected void OnRowUpdating(object sender,GridViewUpdateEventArgs e)
        {
            int updateId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            using(var dbContext = new UserEntities())
            {
                User obj=dbContext.User.Where(i=>i.UserId== updateId).FirstOrDefault();
                obj.Firstname = (GridView1.Rows[e.RowIndex].FindControl("txtFirstname") as TextBox).Text;
                obj.LastName = (GridView1.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text;
                obj.Email = (GridView1.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text;
                obj.Dob= (GridView1.Rows[e.RowIndex].FindControl("txtDob") as TextBox).Text;
                obj.Gender= (GridView1.Rows[e.RowIndex].FindControl("txtGender") as DropDownList).SelectedValue;
                
                dbContext.SaveChanges();
                int userId = obj.UserId;

               

                foreach (ListItem item in (GridView1.Rows[GridView1.EditIndex].FindControl("txtRoles") as CheckBoxList).Items)
                {
                    if (item.Selected)
                    {
                        string roleName = item.Text;
                        
                        int roleId = dbContext.Role.Where(i => i.RoleName == roleName).Select(i => i.RoleId).Single();
                        if(dbContext.UserRole.Where(i=>i.UserId==userId && i.RoleId==roleId).Any())
                        {
                            continue;
                        }
                        UserRole ur = new UserRole();
                        ur.UserId = userId;
                        ur.RoleId = roleId;
                        dbContext.UserRole.Add(ur);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        string roleName = item.Text;
                        int roleId = dbContext.Role.Where(i => i.RoleName == roleName).Select(i => i.RoleId).Single();
                        if (dbContext.UserRole.Where(i => i.UserId == userId && i.RoleId == roleId).Any())
                        {
                            UserRole usr = dbContext.UserRole.Where(i => i.UserId == userId && i.RoleId == roleId).Single();
                            dbContext.UserRole.Remove(usr);
                            dbContext.SaveChanges();
                        }
                    }
                }
                
                
            }
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void AddUser(object sender,EventArgs e)
        {
            Response.Redirect("userdetails");
        }
        protected void Logout(object sender,EventArgs e)
        {
            Response.Cookies["UserId"].Expires=DateTime.Now.AddDays(-30);
            Response.Cookies["IsAdmin"].Expires=DateTime.Now.AddDays(-30);
            Response.Redirect("loginpage");
        }
    }
}