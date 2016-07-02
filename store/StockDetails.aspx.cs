using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;
public partial class store_StockDetails : System.Web.UI.Page
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
            //Label1.Text = "a" + Session["stockDetailItem"].ToString() + "b";
            String strItemID = Session["stockDetailItem"].ToString();
            Item selectItem = mc.getItemByID(strItemID);
            Label1.Text = "Stock Card - " + selectItem.Item_Name;
            Label2.Text = selectItem.BinNo;
            Label3.Text = selectItem.UnitOfMeasurement;

            List<Stock_Card> stockList = mc.getStockCardByItem(selectItem).OrderByDescending(x=>x.Date).ToList();
            GridView1.DataSource = stockList;
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("StockManagement.aspx");
    }
}