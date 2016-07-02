using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class department_ChangeRep : System.Web.UI.Page
{
    //ManagerClerk mc = new ManagerClerk();
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
            else
            {
                if (!IsPostBack)
                {
                    lbCurrentRep.Text = mh.getCurrentRepresentative(user.Department_ID).Name;
                    var allEmp = mh.getEmployeeListForRepresentative(user.Department_ID);

                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataValueField = "Employee_ID";
                    DropDownList1.DataSource = allEmp;

                    
                }
                var currentRep = mh.getCurrentRepresentative(user.Department_ID);
                DropDownList1.DataBind();
            }
        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        mh.changeRepresentativeTo(Convert.ToInt32(DropDownList1.SelectedValue));
        lbCurrentRep.Text = DropDownList1.SelectedItem.Text;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Representative Changed to " + DropDownList1.SelectedItem.Text + "')</script>");
        //Response.Redirect(Request.RawUrl);
    }
}