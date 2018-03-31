using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;
public partial class Register : System.Web.UI.Page
{
    UserInfoManager userinfo = new UserInfoManager();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
    {
        string loginID = txtUserName.Text.Trim();
        int cnt = userinfo.IsHasUserName(loginID);
        if (cnt > 0)
        {
            lblMes.Text = "该用户名已被注册！";
        }
        else
        {
            UserInfoTB u = new UserInfoTB();
            u.LoginId = txtUserName.Text.Trim();
            u.Password = txtPwd.Text.Trim();
            u.Telephone = txtTel.Text.Trim();
            u.Email = txtEmail.Text.Trim();
            u.Question = txtQuestion.Text.Trim();
            u.AKey = txtKey.Text.Trim();
            u.Remark = txtRemark.Text.Trim();

            int count = userinfo.InsertUserInfo(u);
            if (count > 0)
            {
                //Response.Redirect("~/Login.aspx");
                Response.Write("<script>if (confirm ('注册成功！')=true) location.href='~/Login.aspx'</script>");

            }
            else
            {
                Response.Write("<script>alert('注册失败！')</script>");
                return;
            }
        }
    }
    protected void imgbtnexit_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/FootTable/FootInfo.aspx");
    }
}
