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
                {
                    TextBox1.Text = c.Ename;
                }
                int[] channels = obj.GetChannelsAndEventData(id);


                for (int i = 0; i < channels.Length; i++)
                {
                    switch (channels[i])
                    {

                        case 1: CheckBoxIntranet.Checked = true; break;
                        case 2: CheckBoxEmails.Checked = true; break;
                        case 3: CheckboxUnabot.Checked = true; break;
                        case 4: CheckboxSMS.Checked = true; break;
                    }
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