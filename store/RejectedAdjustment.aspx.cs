using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class store_RejectedAdjustment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else if (!((Staff)Session["user"]).Role.Contains("Clerk"))
        {
            Response.Redirect("~/store/Default.aspx");
        }
        currentDate.Text = DateTime.Now.ToString();
    }

    protected void UpdateBtn_Click(object sender, EventArgs e)
    {
        string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
        Response.Redirect("~/store/CreateAdjustment.aspx?show=Rejected");
    }
}