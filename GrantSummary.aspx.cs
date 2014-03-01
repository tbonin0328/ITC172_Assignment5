using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GrantSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["personKey"] != null)
        {
            GetGrantInfo();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private void GetGrantInfo()
    {
        CommunityAssistEntities ce = new CommunityAssistEntities();
        int pk = (int)Session["personKey"];
        var grant = from g in ce.ServiceGrants
                       where g.PersonKey == pk
                       select new
                       {
                           g.GrantDate,
                           g.GrantAmount,
                           g.GrantNeedExplanation
                       };

        GridView1.DataSource = grant.ToList();
        GridView1.DataBind();
    }
}