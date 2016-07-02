using ReportForLogicUniversity;
using ReportForLogicUniversity.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReportForLogicUniversity;
public partial class Report : System.Web.UI.Page
{
    ReportForLogicUniversity.DataSet1 ds = new ReportForLogicUniversity.DataSet1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] == null)
                Response.Redirect("~/login.aspx");

            else if (!((LogicUniversity.Staff)Session["user"]).Role.ToLower().Equals("supervisor"))
            {
                Response.Redirect("~/store/Default.aspx");
            }
            if (Session["location"] == null)
            {
                PublishData();
            }
            else if (Session["location"].Equals("itemReort"))
            {
                PublishData();
                LoadItemPage();
            }
            else if (Session["location"].Equals("orderReort"))
            {
                PublishData();
                LoadOrderPage();
            }
            else
            {
                PublishData();
                LoadComparePage();
            }
        }
    }
    protected void PublishData()
    {
        PublishCategory();
        PublishDepartment();
        DateTime today = DateTime.Today;
        string todayString = today.ToString("yyyy-MM-dd");
        fromDate.Value = todayString;
        toDate.Value = todayString;
        firstMonth.Value = todayString.Substring(0, 7);
        secondMonth.Value = todayString.Substring(0, 7);
        thirdMonth.Value = todayString.Substring(0, 7);
    }
    private void PublishCategory()
    {
        
        CategoryTableAdapter adapter = new CategoryTableAdapter();
        adapter.FillCategory(ds.Category);
        dpnCategory.DataSource = ds.Tables["Category"];
        dpnCategory.DataValueField = "Category";
        dpnCategory.DataBind();
        dpnCategory.Items.Insert(0, "ALL");
    }
    private void PublishDepartment()
    {
        DepartmentsTableAdapter adapter = new DepartmentsTableAdapter();
        adapter.FillDepartment(ds.Departments);
        dpnDepartment.DataSource = ds.Tables["Departments"];
        dpnDepartment.DataValueField = "DepartmentName";
        dpnDepartment.DataBind();
        dpnDepartment.Items.Insert(0, "ALL");
    }
    protected void btnItem_Click(object sender, EventArgs e)
    {
        LoadItemPage();
        Session["location"] = "itemReort";
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void btnPurchase_Click(object sender, EventArgs e)
    {
        LoadOrderPage();
        Session["location"] = "orderReort";
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void btnCategoryCompare_Click(object sender, EventArgs e)
    {
        LoadComparePage();
        Session["location"] = "compareReort";
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void LoadItemPage()
    {
        illustrationDiv.Visible = false;
        lbFrom.Visible = true;
        fromDate.Visible = true;
        lbTo.Visible = true;
        toDate.Visible = true;
        btnOrder.Visible = false;
        lbCategory.Visible = true;
        dpnCategory.Visible = true;
        lbDepartment.Visible = true;
        dpnDepartment.Visible = true;
        btnCategory.Visible = true;
        lbMonthChoose.Visible = false;
        firstMonth.Visible = false;
        secondMonth.Visible = false;
        thirdMonth.Visible = false;
        btnCateCompare.Visible = false;
    }
    protected void LoadOrderPage()
    {
        illustrationDiv.Visible = false;
        lbFrom.Visible = true;
        fromDate.Visible = true;
        lbTo.Visible = true;
        toDate.Visible = true;
        btnOrder.Visible = true;
        lbCategory.Visible = false;
        dpnCategory.Visible = false;
        lbDepartment.Visible = false;
        dpnDepartment.Visible = false;
        btnCategory.Visible = false;
        lbMonthChoose.Visible = false;
        firstMonth.Visible = false;
        secondMonth.Visible = false;
        thirdMonth.Visible = false;
        btnCateCompare.Visible = false;
    }
    protected void LoadComparePage()
    {
        illustrationDiv.Visible = false;
        monthChoose.Visible = true;
        lbFrom.Visible = false;
        fromDate.Visible = false;
        lbTo.Visible = false;
        toDate.Visible = false;
        btnOrder.Visible = false;
        lbCategory.Visible = true;
        dpnCategory.Visible = true;
        lbDepartment.Visible = true;
        dpnDepartment.Visible = true;
        btnCategory.Visible = false;
        lbMonthChoose.Visible = true;
        firstMonth.Visible = true;
        secondMonth.Visible = true;
        thirdMonth.Visible = true;
        btnCateCompare.Visible = true;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void AlertWindow()
    {
        mainDiv.Visible = false;
        alertDiv.Visible = true;
    }
    protected void ConfirmDate()
    {
        try
        {
            DateTime from = Convert.ToDateTime(fromDate.Value);
            DateTime to = Convert.ToDateTime(toDate.Value);
            if (from > to || from > DateTime.Today || to > DateTime.Today)
            {
                AlertWindow();
            }
        }
        catch(Exception e)
        {
            AlertWindow();
        }
        
    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        ConfirmDate();
        CountDaysForOrder();

    }
    protected void btnCategory_Click(object sender, EventArgs e)
    {
        ConfirmDate();
        CountDaysForRequisition();
    }
    protected void GenerateHalfYearCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        HalfYearCategoryConsumptionReport report = new HalfYearCategoryConsumptionReport();
        report.Load(Server.MapPath("~/HalfYearCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateHalfYearAllCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        HalfYearAllCategoryConsumptionReport report = new HalfYearAllCategoryConsumptionReport();
        report.Load(Server.MapPath("~/HalfYearAllCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateHalfYearAllDepartmentConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        HalfYearAllDepartmentConsumptionReport report = new HalfYearAllDepartmentConsumptionReport();
        report.Load(Server.MapPath("~/HalfYearAllDepartmentConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateHalfYearDepartmentCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        HalfYearDepartmentCategoryConsumptionReport report = new HalfYearDepartmentCategoryConsumptionReport();
        report.Load(Server.MapPath("~/HalfYearDepartmentCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateHalfYearReport()
    {
        if (dpnDepartment.Text.Equals("ALL") && dpnCategory.Text.Equals("ALL"))
        {
            GenerateHalfYearCategoryConsumptionReport();
        }
        else if (!dpnDepartment.Text.Equals("ALL") && dpnCategory.Text.Equals("ALL"))
        {
            GenerateHalfYearAllCategoryConsumptionReport();
        }
        else if (dpnDepartment.Text.Equals("ALL") && !dpnCategory.Text.Equals("ALL"))
        {
            GenerateHalfYearAllDepartmentConsumptionReport();
        }
        else
        {
            GenerateHalfYearDepartmentCategoryConsumptionReport();
        }
    }
    protected void GenerateMonthCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        MonthCategoryConsumptionReport report = new MonthCategoryConsumptionReport();
        report.Load(Server.MapPath("~/MonthCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateMonthAllCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        MonthAllCategoryConsumptionReport report = new MonthAllCategoryConsumptionReport();
        report.Load(Server.MapPath("~/MonthAllCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateMonthAllDepartmentConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        MonthAllDepartmentConsumptionReport report = new MonthAllDepartmentConsumptionReport();
        report.Load(Server.MapPath("~/MonthAllDepartmentConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateMonthDepartmentCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        MonthDepartmentCategoryConsumptionReport report = new MonthDepartmentCategoryConsumptionReport();
        report.Load(Server.MapPath("~/MonthDepartmentCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateMonthReport()
    {
        if (dpnDepartment.Text.Equals("ALL") && dpnCategory.Text.Equals("ALL"))
        {
            GenerateMonthCategoryConsumptionReport();
        }
        else if (!dpnDepartment.Text.Equals("ALL") && dpnCategory.Text.Equals("ALL"))
        {
            GenerateMonthAllCategoryConsumptionReport();
        }
        else if (dpnDepartment.Text.Equals("ALL") && !dpnCategory.Text.Equals("ALL"))
        {
            GenerateMonthAllDepartmentConsumptionReport();
        }
        else
        {
            GenerateMonthDepartmentCategoryConsumptionReport();
        }
    }
    protected void GenerateWeekCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        WeekCategoryConsumptionReport report = new WeekCategoryConsumptionReport();
        report.Load(Server.MapPath("~/WeekCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateWeekAllCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        WeekAllCategoryConsumptionReport report = new WeekAllCategoryConsumptionReport();
        report.Load(Server.MapPath("~/WeekAllCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateWeekAllDepartmentConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        WeekAllDepartmentConsumptionReport report = new WeekAllDepartmentConsumptionReport();
        report.Load(Server.MapPath("~/WeekAllDepartmentConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateWeekDepartmentCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        WeekDepartmentCategoryConsumptionReport report = new WeekDepartmentCategoryConsumptionReport();
        report.Load(Server.MapPath("~/WeekDepartmentCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateWeekReport()
    {
        if (dpnDepartment.Text.Equals("ALL") && dpnCategory.Text.Equals("ALL"))
        {
            GenerateWeekCategoryConsumptionReport();
        }
        else if (!dpnDepartment.Text.Equals("ALL") && dpnCategory.Text.Equals("ALL"))
        {
            GenerateWeekAllCategoryConsumptionReport();
        }
        else if (dpnDepartment.Text.Equals("ALL") && !dpnCategory.Text.Equals("ALL"))
        {
            GenerateWeekAllDepartmentConsumptionReport();
        }
        else
        {
            GenerateWeekDepartmentCategoryConsumptionReport();
        }
    }
    protected void GenerateDayCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        DayCategoryConsumptionReport report = new DayCategoryConsumptionReport();
        report.Load(Server.MapPath("~/DayCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateDayAllCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        DayAllCategoryConsumptionReport report = new DayAllCategoryConsumptionReport();
        report.Load(Server.MapPath("~/DayAllCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateDayAllDepartmentConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        DayAllDepartmentConsumptionReport report = new DayAllDepartmentConsumptionReport();
        report.Load(Server.MapPath("~/DayAllDepartmentConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateDayDepartmentCategoryConsumptionReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        DayDepartmentCategoryConsumptionReport report = new DayDepartmentCategoryConsumptionReport();
        report.Load(Server.MapPath("~/DayDepartmentCategoryConsumptionReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", fromDate.Value.ToString());
        report.SetParameterValue("pmTo", toDate.Value.ToString());
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateDayReport()
    {
        if (dpnDepartment.Text.Equals("ALL") && dpnCategory.Text.Equals("ALL"))
        {
            GenerateDayCategoryConsumptionReport();
        }
        else if (!dpnDepartment.Text.Equals("ALL") && dpnCategory.Text.Equals("ALL"))
        {
            GenerateDayAllCategoryConsumptionReport();
        }
        else if (dpnDepartment.Text.Equals("ALL") && !dpnCategory.Text.Equals("ALL"))
        {
            GenerateDayAllDepartmentConsumptionReport();
        }
        else
        {
            GenerateDayDepartmentCategoryConsumptionReport();
        }
    }
    protected void ReportForDifferentYearNearMonth(int dateOfFrom, int dateOfTo)
    {
        dateOfTo = dateOfTo + 31;
        if (dateOfTo - dateOfFrom < 30)
        {
            GenerateDayReport();
        }
        else
        {
            GenerateWeekReport();
        }
    }
    protected void ChooseReportTypeForSameYear(int fromMonth, int toMonth)
    {
        if (toMonth - fromMonth > 2)
        {
            GenerateMonthReport();
        }
        else if (toMonth - fromMonth <= 1)
        {
            GenerateDayReport();
        }
        else
        {
            GenerateWeekReport();
        }
    }
    protected void ChooseReportTypeForDifferentYears(int fromMonth, int toMonth, int dateOfFrom, int dateOfTo)
    {
        if (fromMonth - toMonth == 11)
        {
            ReportForDifferentYearNearMonth(dateOfFrom, dateOfTo);
        }
        else if (fromMonth - toMonth == 10)
        {
            GenerateWeekReport();
        }
        else if (fromMonth - toMonth < 0)
        {
            GenerateHalfYearReport();
        }
        else
        {
            GenerateMonthReport();
        }
    }
    protected void CountDaysForRequisition()
    {
        try
        {
            int fromMonth = Convert.ToDateTime(fromDate.Value).Month;
            int toMonth = Convert.ToDateTime(toDate.Value).Month;
            int fromYear = Convert.ToDateTime(fromDate.Value).Year;
            int toYear = Convert.ToDateTime(toDate.Value).Year;
            int dateOfFrom = Convert.ToDateTime(fromDate.Value).Day;
            int dateOfTo = Convert.ToDateTime(toDate.Value).Day;
            if (fromYear.Equals(toYear))
            {
                ChooseReportTypeForSameYear(fromMonth, toMonth);
            }
            else if (toYear - fromYear > 1)
            {
                GenerateHalfYearReport();
            }
            else
            {
                ChooseReportTypeForDifferentYears(fromMonth, toMonth, dateOfFrom, dateOfTo);
            }
        }
        catch (Exception e)
        {
            
        }
        

    }
    protected void GenerateOrderHalfYear()
    {
        //HalfYearOrder    BE HAPPY!!!            
        OrderReportTableAdapter adapter = new OrderReportTableAdapter();
        adapter.Fill(ds.OrderReport);
        HalfYearOrderReport report = new HalfYearOrderReport();
        report.Load(Server.MapPath("~/HalfYearOrderReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", Convert.ToDateTime(fromDate.Value));
        report.SetParameterValue("pmTo", Convert.ToDateTime(toDate.Value));
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateOrderMonth()
    {
        //MonthOrder     BE HAPPY!!!
        OrderReportTableAdapter adapter = new OrderReportTableAdapter();
        adapter.Fill(ds.OrderReport);
        MonthOrderReport report = new MonthOrderReport();
        report.Load(Server.MapPath("~/MonthOrderReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", Convert.ToDateTime(fromDate.Value));
        report.SetParameterValue("pmTo", Convert.ToDateTime(toDate.Value));
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateOrderWeek()
    {
        //WeekOrder      BE HAPPY!!!
        OrderReportTableAdapter adapter = new OrderReportTableAdapter();
        adapter.Fill(ds.OrderReport);
        WeekOrderReport report = new WeekOrderReport();
        report.Load(Server.MapPath("~/WeekOrderReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", Convert.ToDateTime(fromDate.Value));
        report.SetParameterValue("pmTo", Convert.ToDateTime(toDate.Value));
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateOrderDay()
    {
        //DayOrder     BE HAPPY!!!
        OrderReportTableAdapter adapter = new OrderReportTableAdapter();
        adapter.Fill(ds.OrderReport);
        DayOrderReport report = new DayOrderReport();
        report.Load(Server.MapPath("~/DayOrderReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmFrom", Convert.ToDateTime(fromDate.Value));
        report.SetParameterValue("pmTo", Convert.ToDateTime(toDate.Value));
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void OrderReportForSameYear(int fromMonth, int toMonth)
    {
        if (toMonth - fromMonth > 2)
        {
            GenerateOrderMonth();
        }
        else if (toMonth - fromMonth == 0)
        {
            GenerateOrderDay();
        }
        else
        {
            GenerateOrderWeek();
        }
    }
    protected void OrderReportForDifferentYearNearMonth(int dateOfFrom, int dateOfTo)
    {
        dateOfTo = dateOfTo + 31;
        if (dateOfTo - dateOfFrom < 30)
        {
            GenerateOrderDay();
        }
        else
        {
            GenerateOrderWeek();
        }
    }
    protected void OrderReportTypeForDifferentYears(int fromMonth, int toMonth, int dateOfFrom, int dateOfTo)
    {
        if (fromMonth - toMonth == 11)
        {
            OrderReportForDifferentYearNearMonth(dateOfFrom, dateOfTo);
        }
        else if (fromMonth - toMonth == 10)
        {
            GenerateOrderWeek();
        }
        else if (fromMonth - toMonth < 0)
        {
            GenerateOrderHalfYear();
        }
        else
        {
            GenerateOrderMonth();
        }
    }
    protected void CountDaysForOrder()
    {
        try
        {
        int fromMonth = Convert.ToDateTime(fromDate.Value).Month;
        int toMonth = Convert.ToDateTime(toDate.Value).Month;
        int fromYear = Convert.ToDateTime(fromDate.Value).Year;
        int toYear = Convert.ToDateTime(toDate.Value).Year;
        int dateOfFrom = Convert.ToDateTime(fromDate.Value).Day;
        int dateOfTo = Convert.ToDateTime(toDate.Value).Day;
        if (fromYear.Equals(toYear))
        {
            OrderReportForSameYear(fromMonth, toMonth);
        }
        else if (toYear - fromYear > 1)
        {
            GenerateOrderHalfYear();
        }
        else
        {
            OrderReportTypeForDifferentYears(fromMonth, toMonth, dateOfFrom, dateOfTo);
        }
        }
        catch (Exception e)
        {
            AlertWindow();
        }
        
    }
    protected void ChooseCompareReportType()
    {
        if (dpnCategory.Text.Equals("ALL") && dpnDepartment.Text.Equals("ALL"))
        {
            //Generate Category Department Report  BE HAPPY!!!
            GenerateCategoryCompareReport();
        }
        else if (dpnCategory.Text.Equals("ALL") && dpnDepartment.Text != "ALL")
        {
            //Generate All Category Report  BE HAPPY!!!
            GenerateAllCategoryCompareReport();
        }
        else if (dpnCategory.Text != "ALL" && dpnDepartment.Text.Equals("ALL"))
        {
            //Generate All Department Report  BE HAPPY!!!
            GenerateAllDepartmentCompareReport();
        }
        else
        {
            //Generate Normal Compare Report  BE HAPPY!!!
            GenerateItemCompareReport();
        }
    }
    protected void GenerateAllCategoryCompareReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        AllCategoryCompareReport report = new AllCategoryCompareReport();
        report.Load(Server.MapPath("~/AllCategoryCompareReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        report.SetParameterValue("pmFirstMonth", Convert.ToDateTime(firstMonth.Value));
        report.SetParameterValue("pmFirstMonthEnd", ComputerMonthEnd(Convert.ToDateTime(firstMonth.Value)));
        report.SetParameterValue("pmSecondMonth", Convert.ToDateTime(secondMonth.Value));
        report.SetParameterValue("pmSecondMonthEnd", ComputerMonthEnd(Convert.ToDateTime(secondMonth.Value)));
        report.SetParameterValue("pmThirdMonth", Convert.ToDateTime(thirdMonth.Value));
        report.SetParameterValue("pmThirdMonthEnd", ComputerMonthEnd(Convert.ToDateTime(thirdMonth.Value)));
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateAllDepartmentCompareReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        AllDepartmentCompareReport report = new AllDepartmentCompareReport();
        report.Load(Server.MapPath("~/AllDepartmentCompareReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        report.SetParameterValue("pmFirstMonth", Convert.ToDateTime(firstMonth.Value));
        report.SetParameterValue("pmFirstMonthEnd", ComputerMonthEnd(Convert.ToDateTime(firstMonth.Value)));
        report.SetParameterValue("pmSecondMonth", Convert.ToDateTime(secondMonth.Value));
        report.SetParameterValue("pmSecondMonthEnd", ComputerMonthEnd(Convert.ToDateTime(secondMonth.Value)));
        report.SetParameterValue("pmThirdMonth", Convert.ToDateTime(thirdMonth.Value));
        report.SetParameterValue("pmThirdMonthEnd", ComputerMonthEnd(Convert.ToDateTime(thirdMonth.Value)));
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void GenerateItemCompareReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        ItemCompareReport report = new ItemCompareReport();
        report.Load(Server.MapPath("~/ItemCompareReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        report.SetParameterValue("pmFirstMonth", Convert.ToDateTime(firstMonth.Value));
        report.SetParameterValue("pmFirstMonthEnd", ComputerMonthEnd(Convert.ToDateTime(firstMonth.Value)));
        report.SetParameterValue("pmSecondMonth", Convert.ToDateTime(secondMonth.Value));
        report.SetParameterValue("pmSecondMonthEnd", ComputerMonthEnd(Convert.ToDateTime(secondMonth.Value)));
        report.SetParameterValue("pmThirdMonth", Convert.ToDateTime(thirdMonth.Value));
        report.SetParameterValue("pmThirdMonthEnd", ComputerMonthEnd(Convert.ToDateTime(thirdMonth.Value)));
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void btnCateCompare_Click(object sender, EventArgs e)
    {
        ConfirmMonth();
    }
    protected void GenerateCategoryCompareReport()
    {
        ItemConsumptionTableAdapter adapter = new ItemConsumptionTableAdapter();
        adapter.Fill(ds.ItemConsumption);
        CategoryCompareReport report = new CategoryCompareReport();
        report.Load(Server.MapPath("~/CategoryCompareReport.rpt"));
        report.SetDataSource(ds);
        report.SetParameterValue("pmCategory", dpnCategory.Text);
        report.SetParameterValue("pmDepartment", dpnDepartment.Text);
        report.SetParameterValue("pmFirstMonth", Convert.ToDateTime(firstMonth.Value));
        report.SetParameterValue("pmFirstMonthEnd", ComputerMonthEnd(Convert.ToDateTime(firstMonth.Value)));
        report.SetParameterValue("pmSecondMonth", Convert.ToDateTime(secondMonth.Value));
        report.SetParameterValue("pmSecondMonthEnd", ComputerMonthEnd(Convert.ToDateTime(secondMonth.Value)));
        report.SetParameterValue("pmThirdMonth", Convert.ToDateTime(thirdMonth.Value));
        report.SetParameterValue("pmThirdMonthEnd", ComputerMonthEnd(Convert.ToDateTime(thirdMonth.Value)));
        CrystalReportViewer1.ReportSource = report;
        CrystalReportViewer1.DisplayToolbar = true;
    }
    protected void ConfirmMonth()
    {
        try
        {
            if (Convert.ToDateTime(firstMonth.Value) > DateTime.Today || Convert.ToDateTime(secondMonth.Value) > DateTime.Today
            || Convert.ToDateTime(thirdMonth.Value) > DateTime.Today)
        {
            AlertWindow();
        }
        else
        {
            ChooseCompareReportType();
        }
        }
        catch (Exception e)
        {
            AlertWindow();
        }
        
    }
    protected DateTime ComputerMonthEnd(DateTime duration)
    {
        int year = duration.Year;
        int month = duration.Month;
        string nextMonth = ChangeToMonthDuration(year, month);
        return Convert.ToDateTime(nextMonth);
    }
    private String ChangeToMonthDuration(int year, int month)
    {
        if (month.Equals(12))
        {
            month = 1;
            year = year + 1;
        }
        else
        {
            month = month + 1;
        }
        string nextMonth = year.ToString() + "-" + month.ToString();
        return nextMonth;
    }
}
