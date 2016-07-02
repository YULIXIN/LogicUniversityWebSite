using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class department_ViewRequest : System.Web.UI.Page
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
        if (Request.QueryString["rID"] == null)
        {
            Response.Redirect("~/department/ModifyRequest.aspx");
        }
        if (!IsPostBack)
        {
            try { 
                int rID = Convert.ToInt32(Request.QueryString["rID"]);
                Requisition req = me.getRequisitionByID(rID);
                switch (req.Status.ToLower())
                {
                    case "pending":
                        btnEdit.Text = "Edit";
                        btnDelete.Visible = true;
                        break;
                    case "rejected":
                        btnEdit.Text = "Reuse";
                        break;
                    case "approved":
                        btnEdit.Text = "Reuse";
                        break;
                    case "canceled":
                        btnEdit.Text = "Reuse";
                        break;
                    case "retrieved":
                        btnEdit.Text = "Reuse";
                        break;
                    default:
                        throw new LogicUniversity.BLL.BLLExceptions.IllegalStatusException();
                }
                if (null == req) {
                    Response.Redirect("~/department/ModifyRequest.aspx");
                    return;
                }
                    
                lbDate.Text = req.Requested_Date.ToString("dd-MMM-yyyy");
                lbStatus.Text = req.Status;

                gridview.DataSource = req.Requisition_Details;
                gridview.DataBind();
                Session["MYrequisition"] = req;
               
            }
            catch (Exception ex)
            {
                Response.Write("Don't have this requisition");
                Response.Flush();
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                return;
            }
            
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if ("Reuse".Equals(btnEdit.Text))
        {
            Requisition rep = (Requisition)Session["MYrequisition"];
            Dictionary<string, int> cart = new Dictionary<string, int>();

            foreach (Requisition_Details rd in rep.Requisition_Details)
            {
                cart.Add(rd.Item.Item_Name, rd.Requested_Qty);
            }
            Session["shoppingCart"] = cart;
            Response.Redirect("~/department/EditRequest.aspx");
            return;
        }
        
        Session["requisition"] = Session["MYrequisition"];
        Session["MYrequisition"] = null;
        Response.Redirect("~/department/EditRequest2.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int rID = Convert.ToInt32(Request.QueryString["rID"]);
        me.cancelRequition(rID);
        Response.Redirect("~/department/ModifyRequest.aspx");
    }
}