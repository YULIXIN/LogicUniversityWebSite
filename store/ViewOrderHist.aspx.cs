using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class store_ViewOrderHist : System.Web.UI.Page
{
    ManagerClerk mc = new ManagerClerk();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");

        else if (!((Staff)Session["user"]).Role.ToLower().Equals("clerk"))
        {
            Response.Redirect("~/store/Default.aspx");
        }
        
        if (!IsPostBack)
        {
            ListView1.DataSource = updateOrderView();
            ListView1.DataBind();
        }
    }

    private List<PurchaseOrder> updateOrderView()
    {
        //if (Request.QueryString["state"] != null)
        //{
        //    string[] states = { "Approved", "Pending", "Delivered", "Canceled" };
        //    if (states.Contains(Request.QueryString["state"]))
        //        ddlStatus.Text = Request.QueryString["state"];
        //}
        string strStatus = ddlStatus.Text;

        List<PurchaseOrder> poList = mc.getOrdersByStatus(strStatus).OrderByDescending(x => x.Submission_Date).ToList();
        Session["orders"] = poList;
        return poList;
    }


    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strStatus = ddlStatus.Text;

        List<PurchaseOrder> poList = mc.getOrdersByStatus(strStatus).OrderByDescending(x=>x.Submission_Date).ToList();
        Session["orders"] = poList;
        ListView1.DataSource = poList;
        ListView1.DataBind();

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/store/ViewOrderHist.aspx?state=" + ddlStatus.Text);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<PurchaseOrder> orders = (List<PurchaseOrder>)Session["orders"];
        Button btn = (Button)sender;
        GridView gv = (GridView)btn.FindControl("GridView1");
        HiddenField hb = (HiddenField)btn.FindControl("hiddenOrderID");
        string poNo = hb.Value;
        PurchaseOrder order = orders.FirstOrDefault(x => x.PurchaseOrder_ID.Equals(poNo));
        order.Delivery_Date = DateTime.Now;
        order.Status = "Delivered";

        foreach (GridViewRow row in gv.Rows)
        {
            HiddenField hItemID = (HiddenField)row.FindControl("hiddenItemID");
            string itemID = hItemID.Value;
            TextBox tbQty = (TextBox)row.FindControl("tbQty");
            int qty = Convert.ToInt32(tbQty.Text);
            order.PurchaseOrder_Details.FirstOrDefault(x => x.Item_ID.Equals(itemID)).Quantity = qty;
        }

        //saveChanges
        mc.confirmDelivery(order);
        Session["orders"] = null;
        //Refresh
        Response.Redirect("~/store/ViewOrderHist.aspx?state=" + ddlStatus.Text);
    }


    protected void btnReorder_Click(object sender, EventArgs e)
    {
        //create new order
        PurchaseOrder po = new PurchaseOrder();
        po.Status = "Pending";
        po.Submission_Date = DateTime.Now;

        //get order supplier

        List<PurchaseOrder> orders = (List<PurchaseOrder>)Session["orders"];
        Button btn = (Button)sender;
        GridView gv = (GridView)btn.FindControl("GridView1");
        HiddenField hb = (HiddenField)btn.FindControl("hiddenOrderID");
        string poNo = hb.Value;
        PurchaseOrder order = orders.FirstOrDefault(x => x.PurchaseOrder_ID.Equals(poNo));

        po.Supplier = order.Supplier;
        string newPoNo = POnumberGenerator.PO;
        po.PurchaseOrder_ID = newPoNo;

        foreach (GridViewRow row in gv.Rows)
        {
            HiddenField hItemID = (HiddenField)row.FindControl("hiddenItemID");
            string itemID = hItemID.Value;
            TextBox tbQty = (TextBox)row.FindControl("tbQty");
            int qty = Convert.ToInt32(tbQty.Text);

            PurchaseOrder_Details pod = new PurchaseOrder_Details();
            pod.Item_ID = itemID;
            pod.Quantity = qty;
            pod.PurchaseOrder_ID = newPoNo;
            po.PurchaseOrder_Details.Add(pod);
        }
        //saveChanges
        mc.placeOrder(po);
        Session["orders"] = null;
        //Refresh
        Response.Redirect("~/store/ViewOrderHist.aspx?state=" + ddlStatus.Text);
    }

    protected void btnCancelOrder_Click(object sender, EventArgs e)
    {
        List<PurchaseOrder> orders = (List<PurchaseOrder>)Session["orders"];
        Button btn = (Button)sender;
        GridView gv = (GridView)btn.FindControl("GridView1");
        HiddenField hb = (HiddenField)btn.FindControl("hiddenOrderID");
        string poNo = hb.Value;
        PurchaseOrder order = orders.FirstOrDefault(x => x.PurchaseOrder_ID.Equals(poNo));
        order.Status = "Canceled";

        //saveChanges
        mc.updateOrder();
        Session["orders"] = null;
        //Refresh
        Response.Redirect("~/store/ViewOrderHist.aspx?state=" + ddlStatus.Text);
    }

protected void btnUpdate_Click(object sender, EventArgs e)
{
    List<PurchaseOrder> orders = (List<PurchaseOrder>)Session["orders"];
    Button btn = (Button)sender;
    GridView gv = (GridView)btn.FindControl("GridView1");
    HiddenField hb = (HiddenField)btn.FindControl("hiddenOrderID");
    string poNo = hb.Value;
    PurchaseOrder order = orders.FirstOrDefault(x => x.PurchaseOrder_ID.Equals(poNo));
    order.Delivery_Date = DateTime.Now;

    foreach (GridViewRow row in gv.Rows)
    {
        HiddenField hItemID = (HiddenField)row.FindControl("hiddenItemID");
        string itemID = hItemID.Value;
        TextBox tbQty = (TextBox)row.FindControl("tbQty");
        int qty = Convert.ToInt32(tbQty.Text);
        order.PurchaseOrder_Details.FirstOrDefault(x => x.Item_ID.Equals(itemID)).Quantity = qty;

    }
    //saveChanges
    mc.updateOrder();
    Session["orders"] = null;
    //Refresh
    Response.Redirect("~/store/ViewOrderHist.aspx?state=" + ddlStatus.Text);
}

protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
{
    Button btnSub = (Button)e.Item.FindControl("btnSubmit");
    btnSub.Visible = false;
    Button btnUpd = (Button)e.Item.FindControl("btnUpdate");
    btnUpd.Visible = false;
    Button btnCancelEdit = (Button)e.Item.FindControl("btnCancel");
    btnCancelEdit.Visible = false;
    Button btnReorder = (Button)e.Item.FindControl("btnReorder");
    btnReorder.Visible = false;
    Button btnCancelOrder = (Button)e.Item.FindControl("btnCancelOrder");
    btnCancelOrder.Visible = false;

    switch (ddlStatus.Text)
    {
        case "Pending":
            btnUpd.Visible = true;
            btnCancelOrder.Visible = true;

            break;
        case "Approved":
            btnSub.Visible = true;
            btnCancelEdit.Visible = true;
            break;
        case "Canceled":
            btnReorder.Visible = true;
            btnCancelEdit.Visible = true;
            break;
        case "Delivered":
            btnReorder.Visible = true;
            btnCancelEdit.Visible = true;
            break;
        case "Rejected":
            
            btnReorder.Visible = true;
            btnCancelEdit.Visible = true;
            break;
    }
 
    //Show total price
    Label lbPono = (Label)e.Item.FindControl("lbPO");
    Label lbPriceOrder = (Label)e.Item.FindControl("lbOrderPrice");
    lbPriceOrder.Text = "Total Price: S$" + mc.totalPriceOrder(lbPono.Text).ToString();

} 
}