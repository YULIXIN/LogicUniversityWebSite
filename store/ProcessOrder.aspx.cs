using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;
using System.Net;
using System.Text;


public partial class store_ProcessOrder : System.Web.UI.Page
{
    ManagerSupervisor ms = new ManagerSupervisor();
    ManagerClerk mc = new ManagerClerk();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else if (!((Staff)Session["user"]).Role.Contains("Supervisor"))
        {
            Response.Redirect("~/store/Default.aspx");
        }

        if (!IsPostBack)
        {
            ListView1.DataSource = mc.getOrdersByStatus("Pending").OrderBy(x=>x.Submission_Date).ToList();
            ListView1.DataBind();
        }
    }

    private string emailBody(PurchaseOrder po)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(WebUtility.HtmlEncode("<h1>Loginc University</h1>"));
        return builder.ToString();

    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Approve"))
        {
            string ID = e.CommandArgument.ToString();
            PurchaseOrder po = ms.getOrderByPO(ID);
            po.Status = "Approved";
            ms.approveOrder();
            try
            {
                //sent email
                emailSender.emailSender Esender = new emailSender.emailSender();
                Esender.sendEmail(po.Supplier.Email, "Purchase Order from Logic University", "Please visit this page to see the detail http://10.10.1.162/LogicUniversityWebSite/PurchaseOrderPage?po=" + po.PurchaseOrder_ID);
            }
            catch (Exception ex)
            {

            }
                //Refresh
            Response.Redirect(Request.RawUrl);
        }

        if (e.CommandName.Equals("Reject"))
        {
            string ID = e.CommandArgument.ToString();
            TextBox tb = e.Item.FindControl("tbReason") as TextBox;
            PurchaseOrder po = ms.getOrderByPO(ID);
            po.Status = "Rejected";
            po.Reason = tb.Text;
            ms.approveOrder();
            Response.Redirect(Request.RawUrl);
        }
    }
}