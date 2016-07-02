using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity;
using System.Net.Mail;
using System.Text.RegularExpressions;
using LogicUniversity.BLL;
public partial class login : System.Web.UI.Page
{
    LogicUniversityEntities3 ent = entitySingleton.Entity;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public static bool isStrEmail(string str_Email)
    {
        return Regex.IsMatch(str_Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }

    protected void loginBtn_Click(object sender, EventArgs e)
    {
        string inputUserName = tbUsername.Text.Trim();
        string inputPassword = tbPassword.Text;

        var users = ent.Staffs;
        Staff user = null;
        foreach (Staff u in users)
        {
            if (u.Name.Trim().Equals(inputUserName))
            {
                if (u.Password.Equals(inputPassword))
                    user = u;
            }
        }
        //if (user == null)
        //{
        //    lbLoginFail.Text = "Either your username or password is wrong.";
        //}
        //else
        //{
            Session["user"] = user;
            if (user.Role.Contains("Department")|| user.Role.Contains("Employee"))
                Response.Redirect("~/department/Default.aspx");
            else
                Response.Redirect("~/store/Default.aspx");
            //lbLoginFail.Text = "";
        //}
    }

}