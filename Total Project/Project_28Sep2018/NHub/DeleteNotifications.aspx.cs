using NHubDAL.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NHub
{
    public partial class DeleteNotifications : System.Web.UI.Page
    {
        int id;
        DALnotifications obj = new DALnotifications();
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            String name="";
            
            List<ClassEvents> CE = obj.GetOneEventdata(id);
            foreach (ClassEvents Ev in CE) name = Ev.Ename;
            Label1.Text = "Are you sure you want to delete" + name;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notifications");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            obj.DeleteEvent(id);
            Response.Redirect("Notifications");
        }
    }
}