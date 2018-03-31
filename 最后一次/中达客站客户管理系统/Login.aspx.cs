using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;

public partial class _Default : System.Web.UI.Page 
{
    UserInfoManager userInfo = new UserInfoManager();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void lkbtnforget_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Seek.aspx");
    }
    protected void lkbtnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administrator/Register.aspx");
    }
    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
        
    //}
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            UserInfoTB user;
            string Pwd = txtPwd.Text.Trim();
            if (userInfo.Register(txtName.Text.Trim(), Pwd, out user))
            {
                string userName = txtName.Text.Trim();
                user = userInfo.GetUserInfoByUserId(userName);
                Session["UserManager"] = user;
                Response.Redirect("~/HomePage.aspx");
            }
            else
            {
                lblMessage.Text = "用户不存在或密码不正确！";
                txtName.Text = "";
                txtPwd.Text = "";
            }
        }
    }
}
