using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ZDDB.Model;
using ZDDB.BLL;

public partial class Administrator_Operation : System.Web.UI.Page
{
    UserInfoManager userinfomanager = new UserInfoManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usermanager"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                UserInfoTB user = Session["UserManager"] as UserInfoTB;
                lblid.Text = user.LoginId.ToString();
                txtpwd.Text = user.Password.ToString();
                txttel.Text = user.Telephone.ToString();
                txtEmail.Text = user.Email.ToString();
                txtmq.Text = user.Question.ToString();
                txtmw.Text = user.AKey.ToString();
                txtremark.Text = user.Remark.ToString();
            }
        }
    }
    protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)//判断验证是否通过
        {
            string loginid = lblid.Text;
            string pwd = txtpwd.Text;
            string tel = txttel.Text;
            string email = txtEmail.Text;
            string question = txtmq.Text;
            string akey = txtmw.Text;
            string remark = txtremark.Text;

            UserInfoTB us = new UserInfoTB();
            us.LoginId = loginid;
            us.Password = pwd;
            us.Telephone = tel;
            us.Email = email;
            us.Question = question;
            us.AKey = akey;
            us.Remark = remark;
            int con = userinfomanager.UpdateUserInfoTB(us);//修改
            if (con == 1)
            {
                lblMes.Text = "修改成功！";
                txtpwd.Text = "";
                txttel.Text = "";
                txtEmail.Text = "";
                txtmq.Text = "";
                txtmw.Text = "";
                txtremark.Text = "";
            }
        }
    }
}
