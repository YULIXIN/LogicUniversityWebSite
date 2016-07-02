using LogicUniversity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_ClerkConbineMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clerkDiv.Visible = false;
        supervisorDiv.Visible = false;
        managerDiv.Visible = false;
        if (null == Session["user"])
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            Staff clerk = (Staff)Session["user"];
            switch (clerk.Role.Trim())
            {
                case "Clerk":
                    clerkDiv.Visible = true;
                    break;
                case "Supervisor":
                    supervisorDiv.Visible = true;
                    break;

                case "Manager":
                    managerDiv.Visible = true;
                    break;

            }
        }
    }
}
