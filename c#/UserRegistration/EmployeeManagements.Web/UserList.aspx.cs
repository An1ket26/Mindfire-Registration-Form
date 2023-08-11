using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeMangement.Business;
using EmployeMangement.Utils;
using UserRegistration;

namespace EmployeeManagements.Web
{
    public partial class UserList : Auth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindGrid();
                }
            }catch(Exception ex)
            {
                LogRecords.LogRecord(ex);
                ShowErrorModal();
            }
        }
        protected void BindGrid()
        {
            try
            {
                DataTable datatable = new DataTable();
                datatable.Columns.Add("Id");
                datatable.Columns.Add("ImageUrl");
                datatable.Columns.Add("FirstName");
                datatable.Columns.Add("LastName");
                datatable.Columns.Add("Email");
                datatable.Columns.Add("Dob");
                datatable.Columns.Add("Gender");
                datatable.Columns.Add("Roles");

                var items = UserBusiness.GetAllUser();
                foreach (var item in items)
                {
                    datatable.Rows.Add(item.UserId, "ImageDownloadHandler.ashx?ImageName="+item.Imagesrc.ToString()+"&UserId="+item.UserId.ToString(), item.Firstname, item.LastName, item.Email, item.Dob, item.Gender, item.UserRoles);
                }
                GridView1.DataSource = datatable;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                ShowErrorModal();
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.NewEditIndex;
                int userId = Convert.ToInt32(GridView1.DataKeys[GridView1.EditIndex].Values[0]);
                Response.Redirect("UserDetails?UserId=" + userId + "&tab=detailsLink");
                BindGrid();
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                ShowErrorModal();
            }
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            try
            {
                GridView1.EditIndex = -1;
                this.BindGrid();
            }catch(Exception ex)
            {
                LogRecords.LogRecord(ex);
                ShowErrorModal();
            }
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                
                int deleteId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                UserBusiness.DeleteUser(deleteId);
                this.BindGrid();
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                ShowErrorModal();
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string item = e.Row.Cells[0].Text;
                    foreach (ImageButton button in e.Row.Cells[7].Controls.OfType<ImageButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                ShowErrorModal();
            }
        }


        protected void AddUser(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("userdetails");
            }catch(Exception ex)
            {
                LogRecords.LogRecord((Exception)ex);
                ShowErrorModal();
            }
        }
        protected void Logout(object sender, EventArgs e)
        {
            try
            {
                ClearSession();
                Response.Redirect("loginpage");
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex);
                ShowErrorModal();
            }
        }

        protected void ShowErrorModal()
        {
            string message = "Something Went Wrong,Please Try Again!!";
            string script2 = $@"<script type=text/javascript>document.addEventListener(""DOMContentLoaded"", function(event) {{displayModal(`{message}`);}})</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script2);
        }

    }
}