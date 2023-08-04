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
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
                    string presentCountryName =dbContext.Country.Where(i=>i.CountryId==item.PresentCountryId).Select(i=>i.CountryName).Single().ToString();
                    string permanentCountryName = dbContext.Country.Where(i => i.CountryId == item.PermanentCountryId).Select(i => i.CountryName).Single().ToString();
                    string presentStateName = dbContext.State.Where(i => i.StateId == item.PresentStateId).Select(i => i.StateName).Single().ToString();
                    string permanentStateName = dbContext.State.Where(i => i.StateId == item.PermanentStateId).Select(i => i.StateName).Single().ToString();
                    var hobbies = dbContext.Hobby.Where(i => i.UserId == item.UserId);
                    string hobby = "";
                    foreach(var hob in hobbies)
                    {
                        hobby += hob.HobbyName.Trim()+",";
                    }
                    if(hobby.Length>0)
                        hobby = hobby.Substring(0,hobby.Length-1).Trim();
                    string Roles = "";
                    var roleIds = dbContext.UserRole.Where(i=>i.UserId == item.UserId).Select(i=>i.RoleId);
                    foreach(var roleid in roleIds)
                    {
                        Roles+=dbContext.Role.Where(i => i.RoleId == roleid).Select(i => i.RoleName).Single().ToString().Trim()+",";
                    }
                    Roles = Roles.Substring(0, Roles.Length - 1).Trim();
                    datatable.Rows.Add(item.UserId, item.Firstname.Trim(), item.LastName.Trim(), item.Email.Trim(),
                        item.Dob, item.Gender, item.PresentAddressLine1.Trim(), item.PresentAddressLine2.Trim(),
                        item.PresentPostalCode.Trim(), presentCountryName, presentStateName, item.PresentCity.Trim(),
                        item.PermanentAddressLine1.Trim(), item.PermanentAddressLine2.Trim(), item.PermanentPostalCode.Trim(),
                        permanentCountryName, permanentStateName, item.PermanentCity.Trim(), hobby,item.IsSubscribed.Trim(), Roles);
                }
                GridView1.DataSource = datatable;
                GridView1.DataBind();
            }
        }
        protected void OnRowEditing(object sender,GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            int userId = Convert.ToInt32(GridView1.DataKeys[GridView1.EditIndex].Values[0]);
            Response.Redirect("UserDetails?UserId="+userId);
            //var presentCountry = (GridView1.Rows[GridView1.EditIndex].FindControl("lblPresentCountry") as Label).Text;
            //var permanentCountry = (GridView1.Rows[GridView1.EditIndex].FindControl("lblPermanentCountry") as Label).Text;
            //var presentState = (GridView1.Rows[GridView1.EditIndex].FindControl("lblPresentState") as Label).Text;
            //var permanentState = (GridView1.Rows[GridView1.EditIndex].FindControl("lblPermanentState") as Label).Text;
            //var isSub = (GridView1.Rows[GridView1.EditIndex].FindControl("lblIsSubscribed") as Label).Text;
            BindGrid();
            //using (var dbContext = new UserEntities())
            //{

                //var items = dbContext.Country.Select(i => i.CountryName);
                //foreach (var item in items)
                //{
                //    (GridView1.Rows[GridView1.EditIndex].FindControl("txtPresentCountry") as DropDownList).Items.Add(item.ToString());
                //    (GridView1.Rows[GridView1.EditIndex].FindControl("txtPermanentCountry") as DropDownList).Items.Add(item.ToString());
                //}
                //(GridView1.Rows[GridView1.EditIndex].FindControl("txtPresentCountry") as DropDownList).SelectedValue = presentCountry;
                //LoadStateByCountry(presentCountry, "txtPresentState");
                //(GridView1.Rows[GridView1.EditIndex].FindControl("txtPresentState") as DropDownList).SelectedValue = presentState;
                //(GridView1.Rows[GridView1.EditIndex].FindControl("txtPermanentCountry") as DropDownList).SelectedValue = permanentCountry;
                //LoadStateByCountry(permanentCountry, "txtPermanentState");
                //(GridView1.Rows[GridView1.EditIndex].FindControl("txtPermanentState") as DropDownList).SelectedValue = permanentState;
                //var RoleNames = dbContext.Role.Select(i => i.RoleName);
                //foreach(var roleName in  RoleNames)
                //{
                //    (GridView1.Rows[GridView1.EditIndex].FindControl("txtRoles") as CheckBoxList).Items.Add(roleName.Trim());
                //}
                //var roleIds = dbContext.UserRole.Where(i => i.UserId == userId).Select(i => i.RoleId);
                //foreach (var roleid in roleIds)
                //{
                //    string roleName = dbContext.Role.Where(i => i.RoleId == roleid).Select(i => i.RoleName).Single().ToString().Trim();
                //    foreach(ListItem item in (GridView1.Rows[GridView1.EditIndex].FindControl("txtRoles") as CheckBoxList).Items)
                //    {
                //        if(item.Text.Trim()==roleName)
                //        {
                //            item.Selected = true;
                //        }
                //    }
                //}
                
                //if(isSub.Trim()=="YES")
                //{
                //    (GridView1.Rows[GridView1.EditIndex].FindControl("txtIsSubscribed") as CheckBox).Checked=true;
                //}
            //}
        }

        protected void LoadStateByCountry(string country,string stateId)
        {
            using (var dbContext = new UserEntities())
            {
                int countryId = dbContext.Country.Where(i => i.CountryName == country).Select(i => i.CountryId).Single();
                var items = dbContext.State.Where(i => i.CountryId == countryId).Select(i => i.StateName);
                (GridView1.Rows[GridView1.EditIndex].FindControl(stateId) as DropDownList).Items.Clear();
                foreach (var item in items)
                {
                    (GridView1.Rows[GridView1.EditIndex].FindControl(stateId) as DropDownList).Items.Add(item.ToString());
                }
            }
        }

        protected void LoadState(object sender,EventArgs e)
        {
            string country = (GridView1.Rows[GridView1.EditIndex].FindControl("txtPresentCountry") as DropDownList).SelectedItem.Text;
            LoadStateByCountry(country,"txtPresentState");
        }
        protected void LoadState2(object sender, EventArgs e)
        {
            string country = (GridView1.Rows[GridView1.EditIndex].FindControl("txtPermanentCountry") as DropDownList).SelectedItem.Text;
            LoadStateByCountry(country, "txtPermanentState");

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
                User obj = new User();
                obj=dbContext.User.Where(i=>i.UserId== deleteId).FirstOrDefault();
                dbContext.User.Remove(obj);
                dbContext.SaveChanges();
            }
            this.BindGrid();
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
                //obj.PresentAddressLine1 = (GridView1.Rows[e.RowIndex].FindControl("txtPresentAddrL1") as TextBox).Text;
                //obj.PresentAddressLine2 = (GridView1.Rows[e.RowIndex].FindControl("txtPresentAddrL2") as TextBox).Text;
                //obj.PresentPostalCode = (GridView1.Rows[e.RowIndex].FindControl("txtPresentPcode") as TextBox).Text;
                //obj.PresentCity = (GridView1.Rows[e.RowIndex].FindControl("txtPresentCity") as TextBox).Text;

                //string presentCountry = (GridView1.Rows[GridView1.EditIndex].FindControl("txtPresentCountry") as DropDownList).SelectedValue;
                //obj.PresentCountryId = dbContext.Country.Where(i => i.CountryName == presentCountry).Select(i => i.CountryId).Single();
                //string presentState = (GridView1.Rows[GridView1.EditIndex].FindControl("txtPresentState") as DropDownList).SelectedValue;
                //obj.PresentStateId = dbContext.State.Where(i => i.StateName == presentState).Select(i => i.StateId).Single();


                //obj.PermanentAddressLine1 = (GridView1.Rows[e.RowIndex].FindControl("txtPermanentAddrL1") as TextBox).Text;
                //obj.PermanentAddressLine2 = (GridView1.Rows[e.RowIndex].FindControl("txtPermanentAddrL2") as TextBox).Text;
                //obj.PermanentPostalCode = (GridView1.Rows[e.RowIndex].FindControl("txtPermanentPcode") as TextBox).Text;
                //obj.PermanentCity = (GridView1.Rows[e.RowIndex].FindControl("txtPermanentCity") as TextBox).Text;

                //string permanentCountry = (GridView1.Rows[GridView1.EditIndex].FindControl("txtPermanentCountry") as DropDownList).SelectedValue;
                //obj.PermanentCountryId = dbContext.Country.Where(i => i.CountryName == permanentCountry).Select(i => i.CountryId).Single();
                //string permanentState = (GridView1.Rows[GridView1.EditIndex].FindControl("txtPermanentState") as DropDownList).SelectedValue;
                //obj.PermanentStateId = dbContext.State.Where(i => i.StateName == permanentState).Select(i => i.StateId).Single();

                //obj.IsSubscribed = (GridView1.Rows[GridView1.EditIndex].FindControl("txtIsSubscribed") as CheckBox).Checked ? "YES" : "NO";
                dbContext.SaveChanges();
                int userId = obj.UserId;

                //string Hobby = (GridView1.Rows[e.RowIndex].FindControl("txtHobby") as TextBox).Text;

                //foreach (string item in Hobby.Split(','))
                //{
                //    if (item != "")
                //    {
                //        if(dbContext.Hobby.Where(i=>i.UserId==userId && i.HobbyName==item).Any())
                //        {
                //            continue;
                //        }
                //        Hobby hobby = new Hobby();
                //        hobby.UserId = userId;
                //        hobby.HobbyName = item;
                //        dbContext.Hobby.Add(hobby);
                //        dbContext.SaveChanges();
                //    }
                //}

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
    }
}