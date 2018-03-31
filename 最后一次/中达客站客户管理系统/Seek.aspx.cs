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
            if (!IsPostBack)
            {
                lblQuestion.Visible = false;
                lblValidate.Visible = false;
                lblKey.Visible = false;
                txtKey.Visible = false;
                lblPwd.Visible = false;
                lblPwd1.Visible = false;
                txtPassword.Visible = false;
                txtPassword1.Visible = false;
                BtnNext1.Visible = false;
                //btnUpdate.Visible = false;
                //btnBack.Visible = false;
            }
    }
    protected void lkbtnforget_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Seek.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string userid = txtUser.Text.Trim();
        string pwd = txtPassword.Text.Trim();
        string pwd1 = txtPassword1.Text.Trim();
        if (pwd == pwd1)
        {
            int cut = userInfo.UpdatePasswordByUserId(pwd, userid);
            if (cut > 0)
            {
                Response.Write("<script>alert('密码修改成功！')</script>");
            }

        }

    }
    protected void bntNext_Click(object sender, EventArgs e)
    {
        string userId = txtUser.Text.Trim();
        UserInfoTB user = userInfo.GetUserInfoByUserId(userId);
        if (user == null)
        {
            lblMessage.Text = "请输入正确的账号！";
        }
        else
        {
            lblQuestion.Visible = true;
            lblValidate.Visible = true;
            lblKey.Visible = true;
            txtKey.Visible = true;
            BtnNext1.Visible = true;
            btnNext.Visible = false;
            lblMessage.Text = "";
            lblValidate.Text = user.Question;
        }
    }
    protected void BtnNext1_Click(object sender, EventArgs e)
    {
        string Key = txtKey.Text.Trim();
        string userId = txtUser.Text.Trim();
        UserInfoTB user = userInfo.GetUserInfoByUserId(userId);
        if (Key == user.AKey)
        {
            lblPwd.Visible = true;
            lblPwd1.Visible = true;
            txtPassword.Visible = true;
            txtPassword1.Visible = true;
            btnUpdate.Visible = true;
            BtnNext1.Visible = false;
            btnBack.Visible = true;
            lblMessage.Text = "";
        }
        else
        {
            lblMessage.Text = "输入的答案不正确！";
        }
    }
}
