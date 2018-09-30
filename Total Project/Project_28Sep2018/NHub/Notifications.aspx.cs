using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHubDAL.Notifications;
namespace NHub
{
    public partial class Notifications : System.Web.UI.Page
    {
        //int id;
        LinkButton[] LB;
        PlaceHolder[] PH;
        
        int NoOfSources;
        DALnotifications  Obj= new DALnotifications();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            List<ClassSources> ListOfSources = new List<ClassSources>();
            ListOfSources = Obj.GetSourceData();
            NoOfSources = ListOfSources.Count;
            List<ClassEvents> ListOfEvents = new List<ClassEvents>();

           LB = new LinkButton[NoOfSources];
           PH = new PlaceHolder[NoOfSources];
           
            if (!IsPostBack)
            {
                for (int count = 0; count < NoOfSources; count++)
                {
                    LB[count] = new LinkButton();
                    PH[count] = new PlaceHolder();
                    
                    LB[count].Text = ListOfSources[count].SName;
                    

                    LB[count].ID = ListOfSources[count].Sid.ToString();
                    PH[count].ID = ListOfSources[count].Sid.ToString();


                    ListOfEvents = Obj.GetEventsData(ListOfSources[count].Sid);
                    foreach (ClassEvents Event in ListOfEvents)
                    {
                        PH[count].Controls.Add(new LiteralControl("<br/>"));
                        PH[count].Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp"));
                        Label L = new Label();
                        HyperLink EditLink = new HyperLink();
                        HyperLink DeleteLink = new HyperLink();
                        L.Text = Event.Ename;
                        DeleteLink.Text = "Delete";
                        EditLink.Text = "Edit";
                        EditLink.ID = Event.Eid.ToString();
                        DeleteLink.ID= Event.Eid.ToString();
                        EditLink.NavigateUrl = "~/EditNotifications.aspx?id="+Event.Eid;
                        DeleteLink.NavigateUrl = "~/DeleteNotifications.aspx?id=" + Event.Eid;
                        PH[count].Controls.Add(L);
                        PH[count].Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp"));
                        PH[count].Controls.Add(EditLink);
                        PH[count].Controls.Add(new LiteralControl("&nbsp;"));
                        PH[count].Controls.Add(DeleteLink);
                    }
                    //LB[count].Command += LinkButtonClick;
                    NotificationsBody.Controls.Add(LB[count]);
                    NotificationsBody.Controls.Add(PH[count]);
                    NotificationsBody.Controls.Add(new LiteralControl("<br/>"));
                }
            }
            


            //foreach (ClassSources sou in ListOfSources)
            //{
            //    NotificationsBody.Controls.Add(new LiteralControl("<br />"));

            //    LinkButton Lk = new LinkButton();
            //    Lk.Text = sou.SName;
            //    Lk.ID = sou.Sid.ToString();
                
            //    PlaceHolder PH = new PlaceHolder();
            //    //PH.Visible = false;

            //    ListOfEvents = Obj.GetEventsData(sou.Sid);
            //    foreach (ClassEvents Event in ListOfEvents)
            //    {
            //        Label L = new Label();
            //        L.Text = Event.Ename;
            //        PH.Controls.Add(new LiteralControl("<br/>"));
            //        PH.Controls.Add(L);
                   
            //    }
            //    //GetEvents();
            //    Lk.Command += new CommandEventHandler(this.LinkButtonClick);
            //    //NotificationsBody.Controls.Add(GetEvents);
            //    //NotificationsBody.Controls.Add(new LiteralControl("<br/>"));
            //    NotificationsBody.Controls.Add(Lk);
            //    NotificationsBody.Controls.Add(PH);
                
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Addnotifications");
        }
    }
}