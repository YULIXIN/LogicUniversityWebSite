using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;
using System.Globalization;

public partial class department_Delegate : System.Web.UI.Page
{
    ManagerHead mh = new ManagerHead();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else
        {
            Staff user = (Staff)Session["user"];
            if (!(user.Role.Contains("Department Head")) && !user.Role.Contains("Department Representative"))
            {
                Response.Redirect("~/department/Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    var currentDele = mh.getCurrentDelegate(user.Department_ID);
                    lbCDP.Text = currentDele.Staff.Name;

                    var allEmp = mh.getEmployeeListForDelegate(user.Department_ID);

                    datepicker.Value = currentDele.Start_Date.ToString("yyyy-MM-dd");
                    datepicker2.Value = currentDele.End_Date.ToString("yyyy-MM-dd");
                    //datepicker.SelectedDate = currentDele.Start_Date;
                    //datepicker2.SelectedDate = currentDele.End_Date;
                }

                if (lbCDP.Text.Equals("Nobody"))
                {
                    showAll.Visible = false;
                }
                else
                {
                    showAll.Visible = true;
                }
            }

        }

    }
    protected void btnChangeDate_Click(object sender, EventArgs e)
    {
        if (datepicker.Value.CompareTo(datepicker2.Value) > 0)
        {
            lbError.Text = "begin date cannot be after end date";
            return;
        }
        lbError.Text = "";
        Staff user = (Staff)Session["user"];
        var dele = mh.getCurrentDelegate(user.Department_ID);
        mh.changeDelegate(dele.Delegate_ID, Convert.ToDateTime(datepicker.Value), Convert.ToDateTime(datepicker2.Value));
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Delegate period Changed');</script>");

    }
    protected void btnCancelDelegate_Click(object sender, EventArgs e)
    {
        Staff user = (Staff)Session["user"];
        var dele = mh.getCurrentDelegate(user.Department_ID);

        mh.cancelDelegate(dele.Delegate_ID);
        Response.Redirect("~/department/NewDelegate.aspx");
    }

}