using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DonationSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["personKey"] != null)
        {
            GetDonationInfo();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private void GetDonationInfo()
    {
        CommunityAssistEntities ce = new CommunityAssistEntities();
        int pk = (int)Session["personKey"];
        var donation = from d in ce.Donations
                       where d.PersonKey == pk
                       select new
                       {
                           d.Person,
                           d.DonationDate,
                           d.DonationAmount
                       };

        GridView1.DataSource = donation.ToList();
        GridView1.DataBind();
    }
}