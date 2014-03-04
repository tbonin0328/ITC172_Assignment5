using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GrantApplyPage : System.Web.UI.Page
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
        CommunityAssistEntities ce = new CommunityAssistEntities();
        int personkey = (int)Session["personKey"];
        if (personkey != 0)
        {
            try
            {
                ServiceGrant sg = new ServiceGrant();

                sg.GrantNeedExplanation = txtExplain.Text;
                sg.PersonKey = personkey;
                sg.GrantDate = DateTime.Now;
                sg.GrantAmount = Decimal.Parse(txtAmount.Text);
                sg.ServiceKey.Equals(ddServices.SelectedValue);

                ce.ServiceGrants.Add(sg);
                ce.SaveChanges();

                Response.Redirect("GrantSummary.aspx");
            }

            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }
        else
        {
            lblResult.Text = "Not working. Session personkey = " + personkey;
        }
    
    }
}