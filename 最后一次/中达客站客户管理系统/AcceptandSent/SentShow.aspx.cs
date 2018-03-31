using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;
public partial class SentShow : System.Web.UI.Page
{
    CarrieCompanyManager ccm = new CarrieCompanyManager();
    CustomersManager cm = new CustomersManager();
    SentManager sm = new SentManager();
    AcceptManager am = new AcceptManager();
    public List<SentTB> allInfo
    {
        get { return ViewState["allinfo"] as List<SentTB>; }
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
            if (!IsPostBack)
            {
                //获取下拉列表公司
                ddlConame1.DataSource = ccm.GetAllCarrieCompany();
                ddlConame1.DataTextField = "CoName";
                ddlConame1.DataValueField = "Cid";
                ddlConame1.DataBind();
                //获取下拉列表客户
                ddlCusName1.DataSource = cm.GetAllCustomers();
                ddlCusName1.DataTextField = "CusName";
                ddlCusName1.DataValueField = "CusID";
                ddlCusName1.DataBind();
                //填充gridview
                allInfo = sm.GetAllSentTB();
                anpPage.RecordCount = allInfo.Count;
                Display();
            }
        }
    }
    //显示相应页的信息
    private void Display()
    {

        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allInfo;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpPage.PageSize;
        pagedDataSource.CurrentPageIndex = anpPage.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        GridView1.DataSource = pagedDataSource;
        GridView1.DataBind();

        //在分页区显示总页数及当前页信息
        anpPage.CustomInfoHTML = " 总页数:<b>" + anpPage.PageCount.ToString() + "</b>";
        anpPage.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpPage.CurrentPageIndex.ToString() + "</b></font>";
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //根据查询条件，获取查询信息
        string Coname = ddlConame1.SelectedValue.ToString();
        string CusName = ddlCusName1.SelectedValue.ToString();
        string begintime = txtTime.Text.ToString();
        string begintime1 = txtTime1.Text.ToString();
        string numbers = txtSerachNumbers.Text.ToString();
        allInfo = sm.GetInfoByFilter(Coname, CusName, begintime, begintime1, numbers);
        anpPage.RecordCount = allInfo.Count;
        Display();
        anpPage.CurrentPageIndex = 1;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        //跳转返回
        Response.Redirect("~/AcceptandSent/Sent.aspx");
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        int sid = Convert.ToInt32(e.CommandArgument);
        //执行删除
        if (cmd == "dl")
        {
            sm.DeleteSentTBInfo(sid);
        }
        //跳到添加或编辑页面
        else if (cmd == "ed")
        {
            Response.Redirect("~/AcceptandSent/sent.aspx?Sid=" + Convert.ToString(sid));
        }
        allInfo = sm.GetAllSentTB();
        anpPage.RecordCount = allInfo.Count;
        Display();
        
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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

            ImageButton ldel = e.Row.FindControl("ImageButton4") as ImageButton;
            ldel.Attributes.Add("onclick", "javascrdipt:return confirm('你确认要删除吗？')");

        }
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        Display();
    }
    protected void imgDaochu_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        //Sid         CusID       Cid         CSid                 Kilo                   Price                 ISsettle BeginDate               Remark
        Register.Add("Sid", "编号");
        Register.Add("cust", "客户名称");
        Register.Add("company", "公司名称");
        Register.Add("CSid", "面单号");
        Register.Add("Kilo", "公斤数");
        Register.Add("Price", "金额");
        Register.Add("ISsettle", "是否已结算");
        Register.Add("BeginDate", "起运时间");
        Register.Add("Remark", "备注");

        OutExcelHelper.ExportExcel(allInfo, "面单分配表.xls", Register);
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string Coname = ddlConame1.SelectedValue.ToString();
        string CusName = ddlCusName1.SelectedValue.ToString();
        string begintime = txtTime.Text.ToString();
        string begintime1 = txtTime1.Text.ToString();
        string numbers = txtSerachNumbers.Text.ToString();
        allInfo = sm.GetAllSentTB();
        anpPage.RecordCount = allInfo.Count;
        Display();
        anpPage.CurrentPageIndex = 1;
    }
}
