using NHubDAL.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NHub
{
    public partial class SLMNotifications : System.Web.UI.Page
    {
        
            LinkButton[] LB;
            PlaceHolder[] PH;

            int NoOfSources;
            DALnotifications Obj = new DALnotifications();
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

                        Table T = new Table();

                        ListOfEvents = Obj.GetEventsData(ListOfSources[count].Sid);
                        foreach (ClassEvents Event in ListOfEvents)
                        {
                        TableRow TR = new TableRow();
                        TR.Width =100;
                            //PH[count].Controls.Add(new LiteralControl("<br/>"));
                           // PH[count].Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp"));
                            Label L = new Label();
                            HyperLink EditLink = new HyperLink();
                            HyperLink SubscribeLink = new HyperLink();
                        TableCell TC1 = new TableCell();
                        TableCell TC2 = new TableCell();
                        TableCell TC3 = new TableCell();
                        L.Text = Event.Ename;
                            SubscribeLink.Text = "Subscribe/Unsubscribe";
                            EditLink.Text = "Edit";
                            EditLink.ID = Event.Eid.ToString();
                            SubscribeLink.ID = Event.Eid.ToString();
                            EditLink.NavigateUrl = "~/SLMEditNotifications?id=" + Event.Eid;
                        SubscribeLink.NavigateUrl = "~/SLMSubscribeNotifications.aspx?id=" + Event.Eid;
                        TC1.ColumnSpan = 1;
                            TC1.Controls.Add(L);
                        TableCell TC4 = new TableCell();
                        Label SP = new Label();
                        SP.Text = "&nbsp;&nbsp;&nbsp;";
                        TC4.Controls.Add(SP);
                        TC2.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
                        TC2.Controls.Add(EditLink);
                            //PH[count].Controls.Add(new LiteralControl("&nbsp;"));
                            TC3.Controls.Add(SubscribeLink);
                        TR.Cells.Add(TC1);
                        TR.Cells.Add(TC2);
                        TR.Cells.Add(TC4);
                        TR.Cells.Add(TC3);
                        T.Rows.Add(TR);
                        }
                        PH[count].Controls.Add(T);
                        //LB[count].Command += LinkButtonClick;
                        SLMNotificationsBody.Controls.Add(LB[count]);
                        SLMNotificationsBody.Controls.Add(PH[count]);
                        SLMNotificationsBody.Controls.Add(new LiteralControl("<br/>"));
                    }
                }
            }
        }
}