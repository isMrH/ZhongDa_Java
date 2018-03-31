using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.Model;
using ZDDB.BLL;

public partial class BackStage_CustomerPrice : System.Web.UI.Page
{
    //客户
    CustomersManager cm = new CustomersManager();
    //公司
    CarrieCompanyManager ccm = new CarrieCompanyManager();
    //价格表
    CustomerPriceManager cpm = new CustomerPriceManager();
    //价格模板
    PricesManager pm = new PricesManager();

    public List<CustomerPriceTB> allInfo
    {
        get { return ViewState["allinfo"] as List<CustomerPriceTB>; }
        set { ViewState["allinfo"] = value; }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            allInfo = cpm.GetAllInfo();
            anpPage.RecordCount = allInfo.Count();
            DisPlay();
            //显示客户
            ddlName.DataSource = cm.GetAllCustomers();
            ddlName.DataTextField = "CusName";
            ddlName.DataValueField = "CusID";
            ddlName.DataBind();

            //显示公司
            ddlCompany.DataSource = ccm.GetAllCarrieCompany();
            ddlCompany.DataTextField = "CoName";
            ddlCompany.DataValueField = "Cid";
            ddlCompany.DataBind();

        }
    }
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void lkbtnExecl_Click(object sender, EventArgs e)
    {

    }
    //填充数据
    private void DisPlay()
    {
        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allInfo;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpPage.PageSize;
        pagedDataSource.CurrentPageIndex = anpPage.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        gvInfo.DataSource = pagedDataSource;
        gvInfo.DataBind();

        //在分页区显示总页数及当前页信息
        anpPage.CustomInfoHTML = " 总页数:<b>" + anpPage.PageCount.ToString() + "</b>";
        anpPage.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpPage.CurrentPageIndex.ToString() + "</b></font>";

    }
    //截取文本
    public string Cut(object obj)
    {
        string str = obj.ToString();
        if (str.Length > 5)
        {
            return str.Substring(0, 5) + "...";
        }
        else
        {
            return str;
        }
    }
    //查看价格模板
    protected void lkbtnTemp_Click(object sender, EventArgs e)
    {
        int cusid =Convert.ToInt32( ddlName.SelectedValue);
        int cid =Convert.ToInt32(  ddlCompany.SelectedValue);
        int cnt = cpm.GetCountInfo(cusid, cid);
        if (cnt <= 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('没有该客户在该公司的价格信息！')</script>");

        }
        else
        {
            CustomerPriceTB cp = cpm.GetInfoByCusidAndCid(cusid, cid);
            int res = pm.GetCount(cp.PNo);
            if (res <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('没有此价格模板！')</script>");

            }
            Session["cp"] = cp;
            Response.Redirect("~/PriceManager/CustomerPrice/Price.aspx");
        }
    }
   
    protected void ddlName1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        int cpid = Convert.ToInt32(e.CommandArgument);
        //执行删除
        if (cmd == "delinfo")
        {
            cpm.DelIfo(cpid);
        }
        //跳到添加或编辑页面
        else if (cmd == "edinfo")
        {
            Response.Redirect("~/PriceManager/CustomerPrice/AddCustomerPrice.aspx?cpid=" + Convert.ToString(cpid));
        }
        allInfo = cpm.GetAllInfo();
        anpPage.RecordCount = allInfo.Count();
        DisPlay();
    }
    //跳转到添加页面
    protected void lkbtnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PriceManager/CustomerPrice/AddCustomerPrice.aspx");
    }
    
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //根据条件查询
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        int cusid = 0;
        if (ddlName.SelectedValue != "0")
        {
            cusid = Convert.ToInt32(ddlName.SelectedValue);
        }
        int cid = 0;
        if (ddlCompany.SelectedValue != "0")
        {
            cid = Convert.ToInt32(ddlCompany.SelectedValue);
        }
        string pno = txtPno.Text;
        string cpname = txtPoName.Text;
        allInfo = cpm.GetTempByFilter(cusid, cid, pno, cpname);
        anpPage.RecordCount = allInfo.Count();
        DisPlay();
        anpPage.CurrentPageIndex = 1;
    }
    //查询所有
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        ddlCompany.SelectedValue = "0";
        ddlName.SelectedValue = "0";
        txtPno.Text = "";
        txtPoName.Text = "";
        allInfo = cpm.GetAllInfo();
        anpPage.RecordCount = allInfo.Count();
        DisPlay();
        anpPage.CurrentPageIndex = 1;
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
    protected void anpPage_PageChanged(object sender, EventArgs e)
    {
        DisPlay();
    }
    protected void imgDaochu_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        // Cpid        CusID       Cid         PNo        CpName                                             Remark
        Register.Add("Cpid", "编号");
        Register.Add("customer", "客户名称");
        Register.Add("carriecomapny", "公司名称");
        Register.Add("PNo", "模板编号");
        Register.Add("CpName", "模板名称");
        Register.Add("Remark", "备注");

        OutExcelHelper.ExportExcel(allInfo, "客户价格表.xls", Register);
    }
}
