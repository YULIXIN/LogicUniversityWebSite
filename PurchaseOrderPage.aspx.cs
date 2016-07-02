using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class PurchageOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LogicUniversityEntities3 ent = entitySingleton.Entity;
        string poNO = Request.QueryString["po"];
        if (null == poNO)
        {
            isShow(false);
        }
        else
        {
            PurchaseOrder po = ent.PurchaseOrders.FirstOrDefault(x => x.PurchaseOrder_ID.Equals(poNO));

            if (null == po)
            {
                isShow(false);
            }
            else
            {
                isShow(true);
                Label1.Text = po.Supplier.Name;
                Label2.Text = ((DateTime)po.Submission_Date).AddDays(7).ToString("dd-MMM-yyyy");
                GridView1.DataSource = po.PurchaseOrder_Details;
                GridView1.DataBind();
            }
        }
     }

     private void isShow(bool flag)
    {

        divMain.Visible = flag;
        divError.Visible = !flag;
    }  
    
}