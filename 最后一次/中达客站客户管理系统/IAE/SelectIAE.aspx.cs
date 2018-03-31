using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;

public partial class IAE_SelectIAE : System.Web.UI.Page
{
    //其他收支表
    IAEManagerManager iam = new IAEManagerManager();
    //客户表
    CustomersManager cm = new CustomersManager();
    public List<IAEManagerTB> allInfo
    {
        get { return ViewState["allinfo"] as List<IAEManagerTB>; }
        set { ViewState["allinfo"] = value; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            allInfo = iam.GetAll();
            anpInfo.RecordCount = allInfo.Count();
            BindData();

            //绑定数据
            ddlName.DataSource = cm.GetAllCustomers();
            ddlName.DataTextField = "cusname";
            ddlName.DataValueField = "cusid";
            ddlName.DataBind();
        }
    }
    //获取所有信息
    private void BindData()
    {
        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allInfo;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpInfo.PageSize;
        pagedDataSource.CurrentPageIndex = anpInfo.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        gvInfo.DataSource = pagedDataSource;
        gvInfo.DataBind();

        //在分页区显示总页数及当前页信息
        anpInfo.CustomInfoHTML = " 总页数:<b>" + anpInfo.PageCount.ToString() + "</b>";
        anpInfo.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpInfo.CurrentPageIndex.ToString() + "</b></font>";
    }
    //截取文本
    public string Cut(object obj)
    {
        string str = obj.ToString();
        if (str.Length > 20)
        {
            return str.Substring(0, 5) + "...";
        }
        else
        {
            return str;
        }
    }
    protected void gvInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        int iaeid = Convert.ToInt32(e.CommandArgument);
        //执行删除
        if (cmd == "deinfo")
        {
            iam.DelInfo(iaeid);
        }
        //跳到添加或编辑页面
        else if (cmd == "edinfo")
        {
            Response.Redirect("~/IAE/AddIAE.aspx?iaeid=" + Convert.ToString(iaeid));
        }
        allInfo = iam.GetAll();
        anpInfo.RecordCount = allInfo.Count();
        BindData();
    }
    //分页
    protected void gvInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ddlName.SelectedValue != "0")
        {
            string cusid = "";
            if (ddlName.SelectedValue != "0")
            {
                cusid = ddlName.SelectedValue.ToString();
            }
            string datetime = txtDate.Text;
            string endtime = TextBox3.Text;
            gvInfo.PageIndex = e.NewPageIndex;
            gvInfo.DataSource = iam.GetTempByFilter(cusid, datetime,endtime);
            gvInfo.DataBind();
        }
        else
        {
            gvInfo.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
    //查询所有信息
    protected void imgbtnSelectall_Click(object sender, ImageClickEventArgs e)
    {
        ddlName.SelectedValue = "0";
        txtDate.Text = "";
        allInfo = iam.GetAll();
        anpInfo.RecordCount = allInfo.Count();
        BindData();
        anpInfo.CurrentPageIndex = 1;
    }
    //根据条件查询
    protected void imgbtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        string cusid = "";
        if (ddlName.SelectedValue != "0")
        {
            cusid = ddlName.SelectedValue.ToString();
        }
        string datetime = txtDate.Text;
        string endtime = TextBox3.Text;
        allInfo= iam.GetTempByFilter(cusid, datetime,endtime);
        anpInfo.RecordCount = allInfo.Count();
        BindData();
        anpInfo.CurrentPageIndex = 1;
    }
    //跳转到添加页面
    protected void lkbtnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/IAE/AddIAE.aspx");
    }
    protected void gvInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //产生光棒效果
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "defaultcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=defaultcolor");
        }
        //删除提示
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            ImageButton ldel = e.Row.FindControl("ImageButton2") as ImageButton;
            ldel.Attributes.Add("onclick", "javascrdipt:return confirm('你确认要删除吗？')");

        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        // IAEid       CusID       IAEDate                 IAEName              Price                 ISsettle Remark
        Register.Add("IAEid", "编号");
        Register.Add("customer", "客户姓名");
        Register.Add("IAEDate", "收支日期");
        Register.Add("IAEName", "费用名称");
        Register.Add("ISsettle", "是否结算");
        Register.Add("Price", "金额");
        Register.Add("Remark", "备注");
        OutExcelHelper.ExportExcel(allInfo, "其他费用表.xls", Register);
    }
}
