using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;


public partial class store_CreateAdjustment : System.Web.UI.Page
{
    ManagerClerk mC = new ManagerClerk();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else if (!((Staff)Session["user"]).Role.Contains("Clerk"))
        {
            Response.Redirect("~/store/Default.aspx");
        }

        if (!IsPostBack)
        {
            itemDropDown.DataSource = mC.getAllItems().ToList();
            itemDropDown.DataBind();
            Item firstItem = mC.getItemByID(itemDropDown.SelectedValue);
            lbUnit.Text = firstItem.UnitOfMeasurement;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList itemList = (DropDownList)sender;
        Item item = mC.getItemByID(itemDropDown.SelectedValue);
        lbUnit.Text = item.UnitOfMeasurement;
        quantity.Text = "";
        reason.Text = "";
        
    }
     protected void Add_Click(object sender, EventArgs e)
    {
           
        int quantityNum = 1;
        Int32.TryParse(quantity.Text, out quantityNum);
        Item i = mC.getItemByID(itemDropDown.SelectedValue);
        if (quantityNum + i.Inventories.FirstOrDefault().Balance < 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('No sufficient stock');</script>"); 
            return;
        }

        //int[] ids = mC.insertMainAdjust();
        //mC.insertDetailAdjust(ids[0], ids[1], item.SelectedValue, quantityNum, reason.Text);
        var adjs = mC.insertMainAdjustment();
        mC.insertDetailAdjust(adjs[0].Adjustment_ID, adjs[1].Adjustment_ID, itemDropDown.SelectedValue, quantityNum, reason.Text);
        //Response.Redirect(Request.RawUrl);
        searchResult.DataBind();
        searchResult.Visible = true;
        quantity.Text = "";
        reason.Text = "";

    }
}