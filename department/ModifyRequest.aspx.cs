using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class department_ModifyRequest : System.Web.UI.Page
{
    ManagerEmployee me = new ManagerEmployee();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else if (!(((Staff)Session["user"]).Role.Contains("Department") || ((Staff)Session["user"]).Role.Contains("Employee")))
        {
            Response.Redirect("~/department/Default.aspx");
        }

         if (!IsPostBack)
        {
            List<Requisition> rlist = me.getRequisitionList(((Staff)Session["user"]).Employee_ID).OrderByDescending(x=>x.Requested_Date).ToList();
            Session["request"] = rlist;

            if (rlist.Count == 0)
            {
                Label1.Visible = true;
            }
            else
            {
                gridView.DataSource = rlist;
                gridView.DataBind();
                
            }
        }
    }

    protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            string ID = e.CommandArgument.ToString();
            //Get the data value and bind into textbox..
            Response.Redirect("~/department/ViewRequest.aspx?rID=" + ID);
        }
    }
}