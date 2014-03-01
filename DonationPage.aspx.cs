﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DonationPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            CommunityAssistEntities ce = new CommunityAssistEntities();
            Donation d = new Donation();

            d.DonationAmount = Decimal.Parse(txtAmount.Text);
            d.DonationDate = DateTime.Now;
            ce.Donations.Add(d);

            Response.Redirect("DonateSummary.aspx");
        }

        catch (Exception ex)
        {
            lblResult.Text = ex.Message;
        }
    }
}