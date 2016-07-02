using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;
using LoginUniversityWebSite;

public partial class store_ProcessAdjustment2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //from here
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else if (!((Staff)Session["user"]).Role.ToLower().Equals("manager"))
        {
            Response.Redirect("~/store/Default.aspx");
        }
        else
        {//to here
            if (!IsPostBack)
            {

                ManagerClerk mC = new ManagerClerk();

                List<AdjustItem> adjustItem = new List<AdjustItem>();

                //judge the user's role
                bool j;
                Staff user = (Staff)Session["user"];
                if (user.Role == "Supervisor") { j = true; }
                else { j = false; }

                List<Adjustment_Details> alList2 = mC.getAdjustmentDetailByStaffRole(j).OrderByDescending(x => x.Adjustment_ID).ToList();
                foreach (Adjustment_Details ad in alList2)
                {
                    if (ad.Status == "Pending")
                    {
                        AdjustItem adj = new AdjustItem();
                        adj.id = ad.AdjustmentDetails_ID;
                        adj.Item = ad.Item.Item_Name;
                        adj.Adjust_Qty = Convert.ToInt32(ad.Qty);
                        adj.Unit = ad.Item.UnitOfMeasurement;
                        adj.totalPrice = Convert.ToInt32((Convert.ToInt32(ad.Qty)) * (ad.Item.Price));
                        adj.reason = ad.Reject_Reason;
                        adj.subReason = ad.Reason;
                        adjustItem.Add(adj);
                    }
                }
                GridView1.DataSource = adjustItem;
                GridView1.DataBind();
            }
        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[2].Visible = false; // hides the first column
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Index = Convert.ToInt32((e.CommandArgument).ToString());
        // row contains current Clicked Gridview Row
        int adjustDetailId = Convert.ToInt32(GridView1.Rows[Index].Cells[0].Text);
        LogicUniversityEntities3 ent = new LogicUniversityEntities3();
        ManagerManager mM = new ManagerManager();
        switch (e.CommandName)
        {
            case "Approve":
                Adjustment_Details ad = mM.getAdjustmentDetailByID(adjustDetailId);
                //ad.Status = "Approved";
                mM.approveAdjustment(ad, ad.Reason);

                break;
            case "Reject":
                Adjustment_Details ad2 = mM.getAdjustmentDetailByID(adjustDetailId);
                TextBox t1 = (TextBox)this.GridView1.Rows[Index].Cells[5].FindControl("TextBox1");
                string tb = t1.Text;
                //ad2.Status = "Reject";
                ad2.Reject_Reason = tb;
                ad2.Status = "Rejected";
                mM.approveAdjustment(ad2); ;
                break;
        }
        Response.Redirect(Request.RawUrl);
    }
}