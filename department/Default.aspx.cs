using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;

public partial class department_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
                    Response.Redirect("~/department/SearchItem.aspx");
                    break;
                case "Department Representative":
                    Response.Redirect("~/department/SearchItem.aspx");
                    break;
                    
                case "Department Head":
                    Response.Redirect("~/department/SearchItem.aspx");
                    break;
                default:
                    Response.Redirect("~/login.aspx");
                    break;
            }
        }
    }
}