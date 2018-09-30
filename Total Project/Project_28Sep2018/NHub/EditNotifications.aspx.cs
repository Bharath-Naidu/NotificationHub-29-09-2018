using NHubDAL.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NHub
{
    public partial class EditNotifications : System.Web.UI.Page
    {
        int id;
        DALnotifications obj = new DALnotifications();
        protected void Page_Load(object sender, EventArgs e)
        {

            id=Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                List<ClassSources> Souid = obj.GetSourceData();
                List<ClassEvents> Edetails = obj.GetOneEventdata(id);
                foreach (ClassSources cs in Souid)
                {
                    SourceName.Items.Add(new ListItem(cs.SName, cs.Sid.ToString()));
                }
                foreach (ClassEvents c in Edetails)
                    TextBox1.Text = c.Ename;
                int[] channels = obj.GetChannelsAndEventData(id);

                try
                {
                    if (1 == channels[0])
                        CheckBoxIntranet.Checked = true;
                    if (2 == channels[1])
                        CheckBoxEmails.Checked = true;
                    if (3 == channels[2])
                        CheckboxUnabot.Checked = true;
                    if (4 == channels[3])
                       CheckboxSMS.Checked = true;
                }
                catch (Exception)
                {

                }
            }
        }

        protected void ButtonADDEvent_Click(object sender, EventArgs e)
        {
            obj.DeleteChannels(id);
            List<ClassChannels> ListofChannels = obj.GetChannelsData();
            if (CheckBoxIntranet.Checked == true)
                obj.UpdateChannels(id, ListofChannels[0].Cid);
            if (CheckBoxEmails.Checked == true)
                obj.UpdateChannels(id, ListofChannels[1].Cid);
            if (CheckboxUnabot.Checked == true)
                obj.UpdateChannels(id, ListofChannels[2].Cid);
            if (CheckboxSMS.Checked == true)
                obj.UpdateChannels(id, ListofChannels[3].Cid);
            obj.UpdateEvent(id,TextBox1.Text, Convert.ToInt32(SourceName.SelectedItem.Value), false);
            

            Response.Redirect("Notifications");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notifications");
        }
    }
}