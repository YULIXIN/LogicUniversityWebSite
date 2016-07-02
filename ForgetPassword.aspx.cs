using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using LogicUniversity;

public partial class ForgetPassword : System.Web.UI.Page
{
    emailSender.emailSender client = new emailSender.emailSender();
    LogicUniversityEntities3 ent = new LogicUniversityEntities3();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        string address = tbEmailAddress.Text.Trim();
        bool found = false;
        foreach (Staff u in ent.Staffs.ToList())
        {
            if (u.Email.Trim().Equals(address))
            {
                lbError.Text = "";
                //Response.Write(user.Name);
                //client.sendEmail(address, "password of " + u.Name, "your username is " + u.Name + "\nyour password is : " + u.Password);
                client.sendEmail(address, "password of " + u.Name, "your username is : " + u.Name + "\nyour password is : " + u.Password);
                found = true;
                lbEmailSent.Text = "Email has been sent to your email. Please go to your email";
                break;
            }
        }
        if (!found)
        {
            lbError.Text = "No User has this email address";
            lbEmailSent.Text = "";
        }

    }
}