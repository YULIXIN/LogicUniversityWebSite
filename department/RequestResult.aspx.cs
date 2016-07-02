using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;

public partial class department_RequestResult : System.Web.UI.Page
{

    LogicUniversityEntities3 ent = new LogicUniversityEntities3();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else if (!(((Staff)Session["user"]).Role.Contains("Department") || ((Staff)Session["user"]).Role.Contains("Employee")))
        {
            Response.Redirect("~/department/Default.aspx");
        }
        if (!IsPostBack)
        {
            if (null != Session["shoppingResult"])
            {

                List<ItemQuantity> shoppingResult = (List<ItemQuantity>)Session["shoppingResult"];
                gridView.DataSource = shoppingResult;
                gridView.DataBind();
            }
        }

    }
}