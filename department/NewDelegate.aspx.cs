using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.BLL;
using LogicUniversity;
using System.Globalization;

public partial class department_NewDelegate : System.Web.UI.Page
{
    ManagerHead mh = new ManagerHead();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else
        {
            Staff user = (Staff)Session["user"];
            if (!(user.Role.Contains("Department Head")))
            {
                Response.Redirect("~/department/Default.aspx");
            }
            if (!mh.getCurrentDelegate(user.Department_ID).Staff.Name.Equals("Nobody"))
            {
                divDelegated.Visible = true;
                divNotDegated.Visible = false;
            }else{
                divDelegated.Visible = false;
                divNotDegated.Visible = true;
            }

            if (!IsPostBack)
            {
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Employee_ID";
                DropDownList1.DataSource = mh.getEmployeeListForDelegate(user.Department_ID);
                DropDownList1.DataBind();
                DropDownList1.SelectedValue = "0";
            }

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string pattern = "yyyy-MM-dd";
        DateTime parsedDate1;
        bool dateCorrect = false;
        if (DateTime.TryParseExact(datepicker.Value, pattern, null, DateTimeStyles.None, out parsedDate1))
        {
            DateTime parsedDate2;
            if (DateTime.TryParseExact(datepicker2.Value, pattern, null, DateTimeStyles.None, out parsedDate2))
            {
                dateCorrect = true;
                int newDeleID = Convert.ToInt32(DropDownList1.SelectedValue);
                mh.AppointDelegate(newDeleID, parsedDate1, parsedDate2);
                Response.Redirect("~/department/Delegate.aspx");
            }
        }
        if (!dateCorrect)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Date format is incorrect');</script>"); 
        }
    }
}