using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["personKey"] != null)
        {
            GetPersonInfo();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private void GetPersonInfo()
    {
        CommunityAssistEntities ce = new CommunityAssistEntities();
        int pk = (int)Session["personKey"];
        var customer = from c in ce.People
                       where c.PersonKey == pk
                       select new
                       {
                           c.PersonLastName,
                           c.PersonFirstName,
                           c.PersonUsername
                       };

        GridView1.DataSource = customer.ToList();
        GridView1.DataBind();
    }

    protected void btnDonate_Click(object sender, EventArgs e)
    {
        Response.Redirect("DonationPage.aspx");
    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        Response.Redirect("GrantApplyPage.aspx");
    }
}