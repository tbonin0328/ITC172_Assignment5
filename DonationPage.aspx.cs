using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DonationPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["personKey"] != null)
        {
            int personkey = (int)Session["personKey"];
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int personkey = (int)Session["personKey"];
        if (personkey != 0)
        {
            try
            {
                CommunityAssistEntities ce = new CommunityAssistEntities();
                Donation d = new Donation();

                d.DonationAmount = Decimal.Parse(txtAmount.Text);
                d.DonationDate = DateTime.Now;
                d.PersonKey = personkey;
                ce.Donations.Add(d);

                ce.SaveChanges();

                Response.Redirect("DonationSummary.aspx");
            }

            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }
    }
}