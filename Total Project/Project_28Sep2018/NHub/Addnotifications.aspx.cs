using NHubDAL.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NHub
{
    public partial class Addnotifications : System.Web.UI.Page
    {
        DALnotifications obj = new DALnotifications();
        List<ClassChannels> ListofChannels = new List<ClassChannels>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            List<ClassSources> Listofsourcse = new List<ClassSources>();
            
            Listofsourcse = obj.GetSourceData();
            ListofChannels = obj.GetChannelsData();
            SourceName.Items.Add("Please Select Source");
            
            foreach (ClassSources S in Listofsourcse)
            {
                
                SourceName.Items.Add(new ListItem(S.SName,S.Sid.ToString()));
            }
            CheckBoxIntranet.Text = ListofChannels[0].CName;
            CheckBoxEmails.Text= ListofChannels[1].CName;
            CheckboxUnabot.Text = ListofChannels[2].CName;
            CheckboxSMS.Text = ListofChannels[3].CName;
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notifications");
        }

        protected void ButtonADDEvent_Click(object sender, EventArgs e)
        {
            ListofChannels = obj.GetChannelsData();
            bool Manadantry = false;
            if (MYes.Checked == true && MNo.Checked == false)
                Manadantry = true;
            int Eid = obj.AddEvent(TextBox1.Text, Convert.ToInt32(SourceName.SelectedItem.Value), Manadantry);
            if (CheckBoxIntranet.Checked == true)
                obj.AddChannels(Eid, ListofChannels[0].Cid);
            if (CheckBoxEmails.Checked == true)
                obj.AddChannels(Eid, ListofChannels[1].Cid);
            if (CheckboxUnabot.Checked == true)
                obj.AddChannels(Eid, ListofChannels[2].Cid);
            if (CheckboxSMS.Checked == true)
                obj.AddChannels(Eid, ListofChannels[3].Cid);
            HyperLink EditLink = new HyperLink();
            HyperLink DeleteLink = new HyperLink();
            EditLink.Text = "Edit";
            DeleteLink.Text = "Delete";
            EditLink.NavigateUrl = "EditNotifications";

            Response.Redirect("Notifications");
        }
    }
}