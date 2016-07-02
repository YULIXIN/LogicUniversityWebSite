using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class store_ViewAdjustmentHis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");

        string role = ((Staff)Session["user"]).Role.ToLower();
        if (!(role.Equals("clerk")))
        {
            Response.Redirect("~/store/Default.aspx");
        }
        ManagerClerk mC = new ManagerClerk();
        List<Adjustment_Details> list = mC.getAdjustmentList().OrderByDescending(x=>x.Adjustment_ID).ToList();
        GridView1.DataSource = list;
        GridView1.DataBind();
    }

}