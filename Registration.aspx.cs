using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {

        //initialize the Data Entity Data context
        CommunityAssistEntities ce = new CommunityAssistEntities();

        PassCodeGenerator pg = new PassCodeGenerator();
        int passcode = pg.GetPassCode();

        PasswordHash ph = new PasswordHash();
        //initialize the person class, set the values
        //and add to People (a class that stores persons)
        Person p = new Person();
        p.PersonFirstName = txtFirstName.Text;
        p.PersonLastName = txtLastName.Text;
        p.PersonUsername = txtEmail.Text;
        p.PersonPlainPassword = txtConfirm.Text;
        p.Personpasskey = passcode;
        p.PersonPlainPassword = txtPassword.Text;
        p.PersonUserPassword = ph.HashIt(txtPassword.Text, passcode.ToString());
        ce.People.Add(p);

        //same for address
        PersonAddress pa = new PersonAddress();
        pa.Street = txtAddress.Text;
        pa.Person = p;
        pa.City = txtCity.Text;
        pa.State = txtState.Text;
        pa.Zip = txtZip.Text;
        ce.PersonAddresses.Add(pa);
        
        //same for contact
        PersonContact pc = new PersonContact();
        pc.ContactInfo= txtPhone.Text;

        //write to database
        ce.SaveChanges();

        Response.Redirect("Default.aspx");
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}