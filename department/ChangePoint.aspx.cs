using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class department_ChangePoint : System.Web.UI.Page
{
    ManagerHead mh = new ManagerHead();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["user"] == null)
            Response.Redirect("~/login.aspx");
        else
        {
            Staff user = (Staff)Session["user"];
            if (!(user.Role.Contains("Department Head")) && !user.Role.Contains("Department Representative"))
            {
                Response.Redirect("~/department/Default.aspx"); 
            }else{
                if (!IsPostBack)
                {
                    lbCurrentCP.Text = mh.getCurrentCollectionPoint(user.Department_ID).Name;
                    var allPoints = mh.getAllCollectionPoint();

                    
                    ddlPoint.DataSource = allPoints;
                   
                    var currentPoint = mh.getCurrentCollectionPoint(user.Department_ID);

                   
                    
                    ddlPoint.DataBind();
                    ddlPoint.SelectedValue = currentPoint.CollectionPoint_ID.ToString();
                    lbTime.Text = mh.getCollectionPointByID((Convert.ToInt32(ddlPoint.SelectedValue))).DeliveryPeriod;
                }
               
            }
        }

    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Staff user = (Staff)Session["user"];
        mh.changeCollectionPoint(user.Department_ID, Convert.ToInt32(ddlPoint.SelectedValue));
        lbCurrentCP.Text = ddlPoint.SelectedItem.Text;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Representative Changed to " + ddlPoint.SelectedItem.Text + "');</script>");
        //ScriptManager.RegisterStartupScript方法

        //如果页面中不用Ajax，cs中运行某段js代码方式可以是： Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>window.open('default2.aspx')</script>");

       // 如果页面中使用了Ajax ,则上述代码即使执行也无效果。
        //Response.Redirect(Request.RawUrl);
    }
    protected void ddlPoint_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbTime.Text = mh.getCollectionPointByID((Convert.ToInt32(ddlPoint.SelectedValue))).DeliveryPeriod;
    }
}