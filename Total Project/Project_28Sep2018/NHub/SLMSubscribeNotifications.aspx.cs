using NHubDAL.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NHub
{
    public partial class SLMSubscribeNotifications : System.Web.UI.Page
    {
        int id;
        DALnotifications obj = new DALnotifications();
        protected void Page_Load(object sender, EventArgs e)
        {

            id = Convert.ToInt32(Request.QueryString["id"]);
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

                for (int i = 0; i < channels.Length; i++)
                {
                    int flag = 0;
                    switch (channels[i])
                    {

                        case 1: CheckBoxIntranet.Checked = true; flag = 1; break;
                        case 2: CheckBoxEmails.Checked = true; flag = 1; break;
                        case 3: CheckboxUnabot.Checked = true; flag = 1; break;
                        case 4: CheckboxSMS.Checked = true; flag = 1; break;

                    }
                    //if(i+1!=channels[i])
                    //    switch (channels[i])
                    //    {

                    //        case 1: CheckBoxIntranet.Enabled = false; break;
                    //        case 2: CheckBoxEmails.Enabled = false;  break;
                    //        case 3: CheckboxUnabot.Enabled = false;  break;
                    //        case 4: CheckboxSMS.Enabled = false;  break;

                    //    }
                }

                //List<Users> ListOfUsers = new List<Users>();
                //ListOfUsers = obj.GetUsers();
                ////int i = 1;
                //foreach (Users OneUser in ListOfUsers)
                //{
                //    ListBox1.Items.Add(new ListItem(OneUser.Username));
                //}
                
                    
            }
               
        }
    

        protected void ButtonADDEvent_Click(object sender, EventArgs e)
        {
        
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {

        }

        protected void Submit(object sender, EventArgs e)
        {
            
        }

        protected void SourceName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach (ListItem item in lstFruits.Items)
            {
                if (item.Selected)
                {
                    message += item.Text + " " + item.Value + "\\n";
                }
            }
        }
    }
}