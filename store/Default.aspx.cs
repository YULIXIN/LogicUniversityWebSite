using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using LogicUniversity.BLL;
using LogicUniversity;

public partial class _Default : System.Web.UI.Page
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
                case "Clerk":
                    Response.Redirect("~/store/StockManagement.aspx");
                    break;
                case "Supervisor":
                    Response.Redirect("~/store/ProcessOrder.aspx");
                    break;

                case "Manager":
                    Response.Redirect("~/store/ProcessAdjustment2.aspx");
                    break;

                default:
                    Response.Redirect("~/login.aspx");
                    break;
            }
        }
    }

}