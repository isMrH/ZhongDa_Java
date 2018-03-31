using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ZDDB.BLL;
using ZDDB.Model;

public partial class Administrator_SMS : System.Web.UI.Page
{
    UserInfoManager userinfomanager = new UserInfoManager();

    public List<UserInfoTB> allInfo
    {
        get { return ViewState["allinfo"] as List<UserInfoTB>; }
        set { ViewState["allinfo"] = value; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usermanager"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                allInfo = userinfomanager.GetAllUserInfoTB();
                anpInfo.RecordCount = allInfo.Count();
                BindUserInfo();//调用填充方法
            }
        }
    }

    public void BindUserInfo()//填充方法
    {

        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allInfo;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpInfo.PageSize;
        pagedDataSource.CurrentPageIndex = anpInfo.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        gvuserinfo.DataSource= pagedDataSource;
        gvuserinfo.DataBind();

        //在分页区显示总页数及当前页信息
        anpInfo.CustomInfoHTML = " 总页数:<b>" + anpInfo.PageCount.ToString() + "</b>";
        anpInfo.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpInfo.CurrentPageIndex.ToString() + "</b></font>";
    }
    protected void gvuserinfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //产生光棒效果
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "defaultcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=defaultcolor");
        }
        //如果绑定是数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDel = (ImageButton)e.Row.FindControl("imabtndel");
            btnDel.Attributes.Add("onclick", "javascrdipt:return confirm('您确认要删除吗？')");
        }
    }
    protected void gvuserinfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int uid = int.Parse(e.CommandArgument.ToString());//获取命令参数
        //执行删除
        userinfomanager.DeleteUserInfoId(uid);
        allInfo = userinfomanager.GetAllUserInfoTB();
        anpInfo.RecordCount = allInfo.Count();
        BindUserInfo();//调用填充方法
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindUserInfo();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        // UID  LoginId  Password  Telephone  Email  Question   AKey     Remark
        Register.Add("UID", "编号");
        Register.Add("LoginId", "用户名");
        Register.Add("Telephone", "电话");
        Register.Add("Email", "邮箱");
        Register.Add("Question", "密报问题");
        Register.Add("AKey", "问题答案");
        Register.Add("Remark", "备注");
        OutExcelHelper.ExportExcel(allInfo, "管理员信息.xls", Register);
    }
}
