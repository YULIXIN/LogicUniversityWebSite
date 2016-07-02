using LogicUniversity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_SupMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            login.Text = "Login";
            logout.Visible = false;
        }
        else
        {
            Staff clerk = (Staff)Session["user"];
            login.Text = clerk.Name;
            logout.Visible = true;
        }
    }
    protected void login_Onclick(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else if (((Staff)Session["user"]).Role.Contains("Department") || ((Staff)Session["user"]).Role.Contains("Employee"))
        {
            Response.Redirect("~/department/Default.aspx");
        }
        else
        {
            Response.Redirect("~/store/Default.aspx");
        }
    }
    protected void logout_Onclick(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/login.aspx");  
    }
}
