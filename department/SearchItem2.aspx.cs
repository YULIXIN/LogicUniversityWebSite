using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class store_SearchItem : System.Web.UI.Page
{
    ManagerEmployee me = new ManagerEmployee();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            searchResult.Visible = false;
            searchResult1.Visible = false;
            if (Session["user"] == null)
                Response.Redirect("~/login.aspx");
            else if (!(((Staff)Session["user"]).Role.Contains("Department") || ((Staff)Session["user"]).Role.Contains("Employee")))
            {
                Response.Redirect("~/department/Default.aspx");
            }
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<Item> list = me.SearchByName(tbKeyword.Text.Trim());
        List<ItemQuantity> iqs = new List<ItemQuantity>();
        foreach (Item i in list)
        {
            ItemQuantity iq = new ItemQuantity();
            iq.Item_ID = i.Item_ID;
            iq.ItemName = i.Item_Name;
            iq.Unit = i.UnitOfMeasurement;
            iqs.Add(iq);
        }
        gridView.DataSource = iqs;
        gridView.DataBind();
        if (iqs.Count > 0)
            searchResult.Visible = true;
        searchResult1.Visible = true;
        
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Session["shoppingCart"] == null)
        {
            Session["shoppingCart"] = new Dictionary<string, int>();
        }
        Dictionary<string, int> cart = (Dictionary<string, int>)Session["shoppingCart"];
        for(int i=0; i<gridView.Rows.Count; i++)
        {
            GridViewRow row = gridView.Rows[i];
            CheckBox chkRow = (row.Cells[0].FindControl("ckRow") as CheckBox);
            if (chkRow.Checked)
            {
                string rowItemName= row.Cells[2].Text;
                int qty = Convert.ToInt32((row.Cells[3].FindControl("tbQty") as TextBox).Text);
                if (cart.Keys.Contains(rowItemName))
                {
                    cart[rowItemName] += qty;
                }else{
                    cart.Add(rowItemName, qty);
                }
            }
        }

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("~/department/EditRequest2.aspx");

    }
}