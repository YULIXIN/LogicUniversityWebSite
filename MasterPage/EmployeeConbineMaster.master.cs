using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class MasterPage_EmployeeConbineMaster : System.Web.UI.MasterPage
{
    ManagerEmployee me = new ManagerEmployee();
    protected void Page_Load(object sender, EventArgs e)
    {
        HeadMenu.Visible = false;
        EmployeeMenu.Visible = false;
        RepresentativeMenu.Visible = false;
        divDelegate.Visible = false;

        if (null == Session["user"])
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            Staff clerk = (Staff)Session["user"];
            switch (clerk.Role.Trim())
            {
                case "Employee":
                    if (me.checkDelegate(clerk.Employee_ID))
                        divDelegate.Visible = true;
                    else
                        EmployeeMenu.Visible = true;

                    break;
                case "Department Representative":
                    RepresentativeMenu.Visible = true;
                    break;

                case "Department Head":
                    HeadMenu.Visible = true;
                    break;

            }
        }
    }
}
