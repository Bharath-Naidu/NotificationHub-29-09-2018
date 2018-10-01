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
        //int ServiceId;
        DALnotifications obj = new DALnotifications();
        List<Services> Souid=new List<Services>();
        List<ClassEvents> Edetails=new List<ClassEvents>();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                Souid = obj.getServices();
                Edetails = obj.GetOneEventdata(id);
                foreach (Services cs in Souid)
                {
                    SourceName.Items.Add(new ListItem(cs.SerName, cs.Serid.ToString()));
                    //ServiceId = Convert.ToInt32(cs.Serid.ToString());
                }
                foreach (ClassEvents c in Edetails)
                    TextBox1.Text = c.Ename;
                TextBox1.Enabled = false;
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

                // ListOfUsers = new List<Users>();
                List<Users> ListOfUsers = new List<Users>();
                ListOfUsers = obj.GetUsers();
                //int i = 1;
                foreach (Users OneUser in ListOfUsers)
                {
                    
                    ListBox1.Items.Add(new ListItem(OneUser.Username));
                }


            }
               
        }
    

        protected void ButtonADDEvent_Click(object sender, EventArgs e)
        {
            String currentUser=Context.User.Identity.Name;
            String Userid="";
            int SLMid=0;
            List<Users> ListOfUsers = new List<Users>();
            ListOfUsers = obj.GetUsers();
            foreach (Users OneUser in ListOfUsers)
            {
                if (OneUser.Username == currentUser)
                    Userid = OneUser.UserId;
            }
            List<ServiceLineManagers> SLM = obj.getServiceLineManagers(Userid);
            foreach(ServiceLineManagers manager in SLM)
            {
                if(manager.Uid==Userid)
                SLMid = manager.SLMid;    
            }
            int ESS=obj.SubscribeEvent(id, Convert.ToInt32(SourceName.SelectedItem.Value), SLMid,false,false);
            List<ClassChannels> ListofChannels = obj.GetChannelsData();
            if (CheckBoxIntranet.Checked == true)
                obj.SubscribeChannels(ESS, ListofChannels[0].Cid);
            if (CheckBoxEmails.Checked == true)
                obj.SubscribeChannels(ESS, ListofChannels[1].Cid);
            if (CheckboxUnabot.Checked == true)
                obj.SubscribeChannels(ESS, ListofChannels[2].Cid);
            if (CheckboxSMS.Checked == true)
                obj.SubscribeChannels(ESS, ListofChannels[3].Cid);

            string []uname=new string[10];
            int count = 0;
            int c = ListBox2.Items.Count;
            foreach(ListItem item in ListBox2.Items)
            {
                uname[count++] = item.Text;
            }
            
            List<Users> Totalusers = new List<Users>();
            Totalusers = obj.GetUsers();
            for (int loop = 0; loop < count; loop++)
            {
                foreach (Users OneUser in Totalusers)
                {
                    String ss = uname[loop];
                    if (OneUser.Username.Equals(uname[loop]))
                    {
                        String s = OneUser.Username;
                        obj.SubscribeUsers(OneUser.UserId, ESS);
                    }
                }
            }


            Response.Redirect("SLMNotifications");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SLMNotifications");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            String Uname = ListBox1.SelectedItem.ToString();
            String Uid = ListBox1.SelectedValue;
            ListBox2.Items.Add(Uname);
            ListBox1.Items.Remove(Uid);
        }
    }
}