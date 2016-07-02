using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class store_ContactInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ALPAInfo.Visible = false;
        CHEPInfo.Visible = false;
        BANEInfo.Visible = false;
        ENGLInfo.Visible = false;
        CPSCInfo.Visible = false;
        COMMInfo.Visible = false;
        REGRInfo.Visible = false;
        ZOOLInfo.Visible = false;
        ALPA.Visible = false;
        CHEP.Visible = false;
        BANE.Visible = false;
        ENGL.Visible = false;
        CPSC.Visible = false;
        COMM.Visible = false;
        REGR.Visible = false;
        ZOOL.Visible = false;
    }

    protected void Supplier_Click(object sender, EventArgs e)
    {
        ALPA.Visible = true;
        CHEP.Visible = true;
        BANE.Visible = true;
    }
    protected void Department_Click(object sender, EventArgs e)
    {
        ENGL.Visible = true;
        CPSC.Visible = true;
        COMM.Visible = true;
        REGR.Visible = true;
        ZOOL.Visible = true;
    }
    protected void ALPA_Click(object sender, EventArgs e)
    {
        ALPAInfo.Visible = true;
    }
    protected void CHEP_Click(object sender, EventArgs e)
    {
        CHEPInfo.Visible = true;
    }
    protected void BANE_Click(object sender, EventArgs e)
    {
        BANEInfo.Visible = true;
    }
    protected void ENGL_Click(object sender, EventArgs e)
    {
        ENGLInfo.Visible = true;
    }
    protected void CPSC_Click(object sender, EventArgs e)
    {
        CPSCInfo.Visible = true;
    }
    protected void COMM_Click(object sender, EventArgs e)
    {
        COMMInfo.Visible = true;
    }
    protected void REGR_Click(object sender, EventArgs e)
    {
        REGRInfo.Visible = true;
    }
    protected void ZOOL_Click(object sender, EventArgs e)
    {
        ZOOLInfo.Visible = true;
    }       
}