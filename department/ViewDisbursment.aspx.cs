using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class department_ViewDisbursment : System.Web.UI.Page
{
    ManagerClerk mc = new ManagerClerk();
    ManagerEmployee me = new ManagerEmployee();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else
        {
            Staff user = (Staff)Session["user"];

            if (!user.Role.Contains("Department Representative"))
            {
                Response.Redirect("~/department/Default.aspx");
            }
            else
            {
                lbCP.Text = user.Department.Collection_Point.Name;
                lbDDate.Text = user.Department.Collection_Point.DeliveryPeriod;

                gridView.DataSource = mc.getDisbursementListOfThisWeek(user.Department).ToList();
                gridView.DataBind();
            }
        }
    }
}