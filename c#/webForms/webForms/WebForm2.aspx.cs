using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webForms
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void rbLBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbLBackColor.SelectedItem.Value.Equals("Red"))
            {
                TextBox6.BackColor = Color.Red;
            }
            else if (rbLBackColor.SelectedItem.Value.Equals("Green"))
            {
                TextBox6.BackColor = Color.Green;
            }
            else if (rbLBackColor.SelectedItem.Value.Equals("Blue"))
            {
                TextBox6.BackColor = Color.Blue;
            }
        }

        protected void rbLForeColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbLForeColor.SelectedItem.Value.Equals("Red"))
            {
                TextBox6.ForeColor = Color.Red;
            }
            else if (rbLForeColor.SelectedItem.Value.Equals("Green"))
            {
                TextBox6.ForeColor = Color.Green;
            }
            else if (rbLForeColor.SelectedItem.Value.Equals("Blue"))
            {
                TextBox6.ForeColor = Color.Blue;
            }
        }


        [System.Web.Services.WebMethod]
        public static string TestMethod(string msg)
        {
            return msg+" Aniket";
        }
    }
    
}