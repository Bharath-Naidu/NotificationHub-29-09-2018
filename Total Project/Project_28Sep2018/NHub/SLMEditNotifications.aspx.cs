using NHubDAL.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NHub
{
    public partial class SLMEditNotifications : System.Web.UI.Page
    {
        DALnotifications obj = new DALnotifications();
        List<ClassEvents> Edetails = new List<ClassEvents>();
        List<Services> Souid = new List<Services>();
        SubscribeDetails SD = new SubscribeDetails();
       
        int[] channels;
        int id;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                SD = obj.GetSubscribedData(id);
                Edetails = obj.GetOneEventdata(id);
                foreach (ClassEvents c in Edetails)
                    TextBox1.Text = c.Ename;
                TextBox1.Enabled = false;
                channels = obj.GetChannelsFromSubscribedList(SD.id);
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

                for (int i = 1; i <= 4; i++)
                {
                    if (Find(i))
                    {
                        switch (i)
                        {
                            case 1: CheckBoxIntranet.Enabled = false; break;
                            case 2: CheckBoxEmails.Enabled = false; break;
                            case 3: CheckboxUnabot.Enabled = false; break;
                            case 4: CheckboxSMS.Enabled = false; break;
                        }
                    }
                }
                Souid = obj.getServices();
                String name = "";
                foreach (Services cs in Souid)
                {
                    SourceName.Items.Add(new ListItem(cs.SerName, cs.Serid.ToString()));
                    if (SD.ServiceLineid == cs.Serid)
                        name = cs.SerName;
                }
                SourceName.Items.FindByText(name).Selected = true;
                List<SubscribedUsers> UserList = new List<SubscribedUsers>();
                UserList = obj.GetSubscribedUsersList(SD.id);
                List<Users> ListOfUsers = new List<Users>();
                ListOfUsers = obj.GetUsers();
                foreach (SubscribedUsers OneUser in UserList)
                {
                    foreach (Users PresentUser in ListOfUsers)
                    {
                        if (PresentUser.UserId.Equals(OneUser.UserId))
                        {
                            ListBox1.Items.Add(new ListItem(PresentUser.Username));
                        }
                    }
                }
            }

        }
        bool Find(int value)
        {
            for (int i = 0; i < channels.Length; i++)
            {
                if (channels[i] == value)
                    return false;
            }
            return true;
        }
        protected void ButtonADDEvent_Click(object sender, EventArgs e)
        {
            SD = obj.GetSubscribedData(id);
            obj.UpdatesEvents(SD.id);
            String currentUser = Context.User.Identity.Name;
            String Userid = "";
            int SLMid = 0;
            List<Users> ListOfUsers = new List<Users>();
            ListOfUsers = obj.GetUsers();
            bool Confidencal = false, Manadantry = false;
            if (CYes.Checked == true && CNo.Checked == false)
                Confidencal = true;
            if (MYes.Checked == true && MNo.Checked == false)
                Manadantry = true;
            foreach (Users OneUser in ListOfUsers)
            {
                if (OneUser.Username == currentUser)
                    Userid = OneUser.UserId;
            }
            List<ServiceLineManagers> SLM = obj.getServiceLineManagers(Userid);
            foreach (ServiceLineManagers manager in SLM)
            {
                if (manager.Uid == Userid)
                    SLMid = manager.SLMid;
            }
            obj.UpdateSubscribedList(SD.id,id, Convert.ToInt32(SourceName.SelectedItem.Value), SLMid, Confidencal, Manadantry);
            int ESS = SD.id;
            List<ClassChannels> ListofChannels = obj.GetChannelsData();
            if (CheckBoxIntranet.Checked == true)
                obj.SubscribeChannels(ESS, ListofChannels[0].Cid);
            if (CheckBoxEmails.Checked == true)
                obj.SubscribeChannels(ESS, ListofChannels[1].Cid);
            if (CheckboxUnabot.Checked == true)
                obj.SubscribeChannels(ESS, ListofChannels[2].Cid);
            if (CheckboxSMS.Checked == true)
                obj.SubscribeChannels(ESS, ListofChannels[3].Cid);

            string[] uname = new string[10];
            int count = 0;
            int c = ListBox2.Items.Count;
            foreach (ListItem item in ListBox2.Items)
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