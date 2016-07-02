using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class department_ViewPendingRequests : System.Web.UI.Page
{
    ManagerEmployee me = new ManagerEmployee();
    ManagerHead mh = new ManagerHead();
    protected void Page_Load(object sender, EventArgs e)
    {
        Staff user = null;
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else {
            user = (Staff)Session["user"];
            if (!(user.Role.Contains("Head") || me.checkDelegate(user.Employee_ID)))
            {
                Response.Redirect("~/department/Default.aspx");
            }
        } 


        if (!IsPostBack)
        {
            var v = me.getAllPendingRequisition(user.Department);

            ListView1.DataSource = v;
            ListView1.DataBind();
        }
    }
    protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Approve"))
        {
            string ID = e.CommandArgument.ToString();
            mh.processPendingRequisition(Convert.ToInt32(ID), "Approved", "");
            Requisition req = mh.getRequisitionByID(Convert.ToInt32(ID));
            try
            {
                emailSender.emailSender Esender = new emailSender.emailSender();

                Esender.sendEmail(req.Staff.Email, "Your Request has been Approved", "Please login to see detail http://10.10.1.162/LogicUniversityWebSite/");
            }
            catch (Exception ex)
            {

            }
            Response.Redirect(Request.RawUrl);
        }

        if (e.CommandName.Equals("Reject"))
        {
            string ID = e.CommandArgument.ToString();
            TextBox tb = e.Item.FindControl("tbReason") as TextBox;
            mh.processPendingRequisition(Convert.ToInt32(ID), "Rejected", tb.Text);
            
            Requisition req = mh.getRequisitionByID(Convert.ToInt32(ID));
            try
            {
                emailSender.emailSender Esender = new emailSender.emailSender();
                Esender.sendEmail(req.Staff.Email, "Your Request has been Rejected", "Please login to see detail http://10.10.1.162/LogicUniversityWebSite/");
            }
            catch (Exception ex)
            {

            }
            Response.Redirect(Request.RawUrl);
        }
    }
}