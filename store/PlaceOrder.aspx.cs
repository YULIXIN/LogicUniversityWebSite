using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class store_ProcessOrder : System.Web.UI.Page
{
    ManagerClerk mc = new ManagerClerk();
    ManagerEmployee me = new ManagerEmployee();
    List<ItemQuantity> griddata;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        Response.Redirect("~/login.aspx");
        else if (!((Staff)Session["user"]).Role.Contains("Clerk"))
        {
            Response.Redirect("~/store/Default.aspx");
        }
        else
        {
            if (Session["shoppingCart"] == null)
            {
                Session["shoppingCart"] = new Dictionary<string, int>();
            }

            Dictionary<string, int> cart = (Dictionary<string, int>)Session["shoppingCart"];
            List<OrderInventory> cartObjs = ToCartObjects(cart);

            //update shopping cart dropdown view


            if (cart.Count <= 0)
            {
                emptyDiv.Visible = true;
                notEmptyDiv.Visible = false;
            }
            else
            {
                emptyDiv.Visible = false;
                notEmptyDiv.Visible = true;
            }

            if (!IsPostBack)
            {
                gvCart.DataSource = cartObjs;
                gvCart.DataBind();
                ddlSupplier.DataSource = mc.getAllSupplies();
                ddlSupplier.DataBind();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Session["shoppingCart"] == null)
        {
            Session["shoppingCart"] = new Dictionary<string, int>();
        }
        Dictionary<string, int> cart = (Dictionary<string, int>)Session["shoppingCart"];

        for (int i = 0; i < gridView.Rows.Count; i++)
        {

            GridViewRow row = gridView.Rows[i];
            CheckBox chkRow = (row.Cells[0].FindControl("ckRow") as CheckBox);
            if (chkRow.Checked)
            {

                string rowItemName = row.Cells[2].Text;
                int qty = Convert.ToInt32((row.Cells[3].FindControl("tbQty") as TextBox).Text);
                if (cart.Keys.Contains(rowItemName))
                {
                    cart[rowItemName] += qty;
                }
                else
                {
                    cart.Add(rowItemName, qty);
                }

            }
        }
        Response.Redirect(Request.RawUrl);
    }

    private List<OrderInventory> ToCartObjects(Dictionary<string, int> cart)
    {
        List<OrderInventory> cartObjs = new List<OrderInventory>();
        foreach (string key in cart.Keys)
        {
            OrderInventory cartObj = new OrderInventory();
            cartObj.Item_Name = key;
            cartObj.Qty = cart[key];
            cartObjs.Add(cartObj);
        }
        return cartObjs;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<OrderInventory> oiList = new List<OrderInventory>();
        List<Item> items = me.SearchByName(tbKeyword.Text.Trim());
        foreach (Item i in items)
        {
            OrderInventory oi = new OrderInventory();
            var inventory = i.Inventories.FirstOrDefault();
            oi.Balance = inventory.Balance;
            oi.Item_ID = inventory.Item_ID;
            oi.Item_Name = inventory.Item.Item_Name;
            //default order quantity is reorder level
            oi.Qty = i.ReOrderLevel;
            oi.Unit = inventory.Item.UnitOfMeasurement;
            oiList.Add(oi);
        }
        gridView.DataSource = oiList;
        gridView.DataBind();
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        comfirmTable();
        if (gvCart.Rows.Count <= 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Order list cannot be empty')", true);
            return;
        }

        PurchaseOrder po = new PurchaseOrder();
        
        po.Status = "Pending";
        po.Submission_Date = DateTime.Now;
        //po.Supplier_ID = ddlSupplier.SelectedValue;
        po.Supplier = mc.getSupplierByID(ddlSupplier.SelectedValue);
        string poNo = POnumberGenerator.PO;
        po.PurchaseOrder_ID = poNo;
        Dictionary<string, int> cart = ((Dictionary<string, int>)Session["shoppingCart"]);
        foreach(string key in cart.Keys){
            PurchaseOrder_Details pod = new PurchaseOrder_Details();
            pod.Item = me.getItemByName(key);
            pod.Quantity = cart[key];
            pod.PurchaseOrder_ID = poNo;
            po.PurchaseOrder_Details.Add(pod);
        }
        mc.placeOrder(po);

        Session["shoppingCart"] = null;
        Response.Redirect(Request.RawUrl);
    }

    //synchronize table with shopping cart
    private void comfirmTable()
    {
        Dictionary<string, int> cart = new Dictionary<string, int>();
        foreach (GridViewRow row in gvCart.Rows)
        {
            string key = row.Cells[0].Text;
            int value = Convert.ToInt32(((TextBox)row.Cells[1].FindControl("tbQuantity")).Text);
            cart.Add(key, value);
        }
        Session["shoppingCart"] = cart;
    }
    protected void linkButtonRemove_Click(object sender, EventArgs e)
    {
        comfirmTable();
        LinkButton lb = (LinkButton)sender;
        HiddenField hd = (HiddenField)(lb.FindControl("HiddenFieldItemName"));
        Dictionary<string, int> cart = (Dictionary<string, int>)Session["shoppingCart"];
        cart.Remove(hd.Value);
        gvCart.DataSource = ToCartObjects(cart);
        gvCart.DataBind();
    }

}