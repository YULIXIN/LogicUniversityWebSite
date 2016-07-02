using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class store_StockManagement : System.Web.UI.Page
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
            Label1.Text = "";
            List<Inventory> sessionList = (List<Inventory>)Session["stockList"];
            if (sessionList == null)
            {
                List<Inventory> list = mc.checkLowStock1();

                if (list.Count() > 0)
                {
                    Label1.Text = "Low Stock List";
                    GridView1.DataSource = list;
                    GridView1.DataBind();
                }
            }
            else
            {
                if (sessionList.Count() > 0)
                {
                    Label1.Text = "Stock List";
                    GridView1.DataSource = sessionList;
                    GridView1.DataBind();
                }
            }

        }
        
    }
  

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("View"))
        {
            string ID = e.CommandArgument.ToString();
            Session["stockDetailItem"] = ID;

            Label1.Text = Session["stockDetailItem"].ToString();
            Response.Redirect("StockDetails.aspx");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strName = tbSearch.Text;
        List<Inventory> list = mc.getInventoriesByName(strName);
        Session["stockList"] = list;
        if (list.Count() > 0)
        {
            Label1.Text = "Stock List";
            GridView1.DataSource = list;
            GridView1.DataBind();
            //GridView1.Visible = true;
        }
        else
        {
            Label1.Text = "No item found";
            //GridView1.Visible = false;
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["stockList"] = null;
        Response.Redirect(Request.RawUrl);
    }
}