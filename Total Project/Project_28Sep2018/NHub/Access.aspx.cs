using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NHub
{
    public partial class Access : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Table T = new Table();
            
            TableRow TR = new TableRow();
            TableCell TCone = new TableCell();
            TCone.Controls.Add(new LiteralControl("User Name"));
            TableCell TCtwo = new TableCell();
            TCtwo.Controls.Add(new LiteralControl("Role"));
            TableCell TCthree = new TableCell();
            TCthree.Controls.Add(new LiteralControl("Actions"));
            TR.Cells.Add(TCone);
            TR.Cells.Add(TCtwo);
            TR.Cells.Add(TCthree);
            T.Rows.Add(TR);
            PlaceHolder1.Controls.Add(T);
            //foreach ()
            //{
                
            //}
        }
    }
}