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

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            CommunityAssistEntities ce = new CommunityAssistEntities();
            ServiceGrant sg = new ServiceGrant();

            sg.GrantNeedExplanation = txtExplain.Text;
            sg.GrantDate = DateTime.Now;
            sg.GrantAmount = Decimal.Parse(txtAmount.Text);
            ce.ServiceGrants.Add(sg);

            Response.Redirect("GrantSummary.aspx");
        }

        catch (Exception ex)
        {
            lblResult.Text = ex.Message;
        }
    }
}