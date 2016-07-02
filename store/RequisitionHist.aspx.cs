using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using LogicUniversity.BLL;

public partial class store_RequisitionHist : System.Web.UI.Page
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
            var v = mc.getAllCategory();

            ddlCategory.DataSource = v;
            ddlCategory.DataBind();

            ddlCategory.DataTextField = "Category1";
            ddlCategory.DataValueField = "Category1";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, "All");

            var d = mc.getAllDepartments();

            ddlDept.DataSource = d;
            ddlDept.DataBind();

            ddlDept.DataTextField = "DepartmentName";
            ddlDept.DataValueField = "DepartmentName";
            ddlDept.DataBind();
            ddlDept.Items.Insert(0, "All");

            selectedDate.Value = DateTime.Today.ToString("yyyy-MM-dd");

        }


    }


    protected void btnView_Click(object sender, EventArgs e)
    {

                

        string strDept = ddlDept.SelectedValue;
        string strCate = ddlCategory.SelectedValue;
        string strDate = selectedDate.Value.ToString();


        Department selectDept;
        //= mc.getDepartmentByName(ddlDept.SelectedValue);
        Category selectCate;
        //= mc.getCategoryByName(ddlCategory.SelectedValue);
        DateTime selectedRetDate = Convert.ToDateTime(selectedDate.Value.ToString());

        List<Retrieval> retList;
        List<Disbursement> disbList;

        GridView1.Visible = false;
        GridView2.Visible = false;
        lbNoResultNotice.Text = "";
        lbRetrivalTitle.Text = "";
        lbDisbTitle.Text = "";






        if (strDept.Equals("All"))
        {
            
            if (strCate.Equals("All"))
            {
                retList = mc.getRetrivalList(selectedRetDate);
                if (retList.Count() > 0)
                {
                    lbRetrivalTitle.Text = "Retrieval List";
                    GridView1.DataSource = retList;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }
                else
                {
                    lbNoResultNotice.Text = "No record found.";
                }

            }
            else
            {
                selectCate = mc.getCategoryByName(strCate);
                retList = mc.getRetrivalListByCategory(selectedRetDate, selectCate);
                if (retList.Count() > 0)
                {
                    lbRetrivalTitle.Text = "Retrieval List";
                    GridView1.DataSource = retList;
                    GridView1.DataBind();
                    GridView1.Visible = true;
                }
                else
                {
                    lbNoResultNotice.Text = "No record found.";
                }
            }
        }
        else
        {
            selectDept = mc.getDepartmentByName(strDept);
            if (strCate.Equals("All"))
            {
                disbList = mc.getDisbursementListHistory(selectDept, selectedRetDate);
                if (disbList.Count() > 0)
                {
                    lbDisbTitle.Text = "Disbursement List - " + selectDept.DepartmentName;
                    GridView2.DataSource = disbList;
                    GridView2.DataBind();
                    GridView2.Visible = true;
                }
                else
                {
                    lbNoResultNotice.Text = "No record found.";
                }

                
            }
            else
            {
                selectCate = mc.getCategoryByName(strCate);
                disbList = mc.getDisbListByCategoryByDept(selectDept, selectCate, selectedRetDate);
                if (disbList.Count() > 0)
                {
                    lbDisbTitle.Text = "Disbursement List - " + selectDept.DepartmentName;
                    GridView2.DataSource = disbList;
                    GridView2.DataBind();
                    GridView2.Visible = true;
                }
                else
                {
                    lbNoResultNotice.Text = "No record found.";
                }
            }
        }

    }

}