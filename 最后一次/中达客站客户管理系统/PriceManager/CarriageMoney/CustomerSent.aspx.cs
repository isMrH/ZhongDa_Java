using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.Model;
using ZDDB.BLL;

public partial class PriceManager_CustomerSent : System.Web.UI.Page
{
    CustomerSentManager csm = new CustomerSentManager();
    CustomersManager cm = new CustomersManager();
    CarrieCompanyManager ccm = new CarrieCompanyManager();
    RegisterManager rm = new RegisterManager();
    public List<CustomerSentTB> allInfo
    {
        get { return ViewState["allinfo"] as List<CustomerSentTB>; }
        set { ViewState["allinfo"] = value; }

    }
    public List<CustomerSentTB> allInfo1
    {
        get { return ViewState["allinfo"] as List<CustomerSentTB>; }
        set { ViewState["allinfo"] = value; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            allInfo = csm.GetAll();
            anpPage.RecordCount = allInfo.Count();
            BindData();

            //绑定数据
            ddlName.DataSource = cm.GetAllCustomers();
            ddlName.DataTextField = "cusname";
            ddlName.DataValueField = "cusid";
            ddlName.DataBind();

            ddlCompany.DataSource = ccm.GetAllCarrieCompany();
            ddlCompany.DataTextField = "coname";
            ddlCompany.DataValueField="cid";
            ddlCompany.DataBind();
            
        }
    }
    //获取所有信息
    private void BindData()
    {
        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allInfo;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpPage.PageSize;
        pagedDataSource.CurrentPageIndex = anpPage.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        if (GridView1.Visible == true)
        {
            GridView1.DataSource = pagedDataSource;
            GridView1.DataBind();
        }
        gvInfo.DataSource = pagedDataSource;
        gvInfo.DataBind();

        //在分页区显示总页数及当前页信息
        anpPage.CustomInfoHTML = " 总页数:<b>" + anpPage.PageCount.ToString() + "</b>";
        anpPage.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpPage.CurrentPageIndex.ToString() + "</b></font>";
    }
    //导入表格
    protected void lkbtnExecl_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PriceManager/CarriageMoney/DefaultTemp.aspx");
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
    
    protected void gvInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        int csid = Convert.ToInt32(e.CommandArgument);
        //执行删除
        if (cmd == "dlinfo")
        {
            csm.DelInfo(csid);
        }
        //跳到添加或编辑页面
        else if (cmd == "edinfo")
        {
            Response.Redirect("~/PriceManager/CarriageMoney/AddCustomerSent.aspx?csid=" + Convert.ToString(csid));
        }
        allInfo = csm.GetAll();
        anpPage.RecordCount = allInfo.Count();
        BindData();
    }
    //跳转到添加页面
    protected void lkbtnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PriceManager/CarriageMoney/AddCustomerSent.aspx");
    }
    //根据条件查询
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        if (gvInfo.Visible == false)
        {
            gvInfo.Visible = true;
            GridView1.Visible = false;
        }
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
        long rid = 0;
        if (txtpno.Text != "")
        {
            rid = Convert.ToInt64(txtpno.Text);
        }
        string des = txtDes.Text;

        allInfo = csm.GetTempByFilter(rid, des, cusid, cid);
        anpPage.RecordCount = allInfo.Count();
        BindData();
        anpPage.CurrentPageIndex = 1;
    }
    //查询所有
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        ddlCompany.SelectedValue = "0";
        ddlName.SelectedValue = "0";
        txtDes.Text = "";
        txtpno.Text = "";
        if (gvInfo.Visible == false)
        {
            gvInfo.Visible = true;
            GridView1.Visible = false;
        }
        allInfo = csm.GetAll();
        anpPage.RecordCount = allInfo.Count();
        BindData();
        anpPage.CurrentPageIndex = 1;
    }
    //无头件信息显示
    protected void lkbtnSelect_Click(object sender, EventArgs e)
    {
        gvInfo.Visible = false;
        if (GridView1.Visible == false)
        {
            GridView1.Visible = true;
        }
        //填充数据
        allInfo1 = csm.GetInfoBycount();
        anpPage.RecordCount = allInfo1.Count();
        BindData();
        anpPage.CurrentPageIndex = 1;
    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        long rid = Convert.ToInt64(e.CommandArgument);
        //重新分配
        if (cmd == "edlinfo")
        {
            //根据面单号查看购买中是否购买过此面单
            int cnt = rm.IsBuy(rid);
            if (cnt > 0)
            {
                //如果购买了，则跳转到面单分配表中重新分配
                Response.Redirect("~/FaxeList/DisNoteTB.aspx?rid="+rid);
            }
            else
            {
                //如果没有购买，则不需要重新分配
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该面单号不属于本公司！')</script>");

            }

        }
        GridView1.DataSource = csm.GetInfoBycount();
        GridView1.DataBind();
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
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //产生光棒效果
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "defaultcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=defaultcolor");
        }
    }
    protected void anpPage_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void imgDaochu_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        // CSid   Rid   CusID  Cid   Destination  Kilo  Price Resdate   IsSet Remark
        if (GridView1.Visible == true)
        {
            Register.Add("Rid", "面单号");
            Register.Add("Destination", "目的地");
            Register.Add("Kilo", "公斤数");
            Register.Add("Price", "运费");
            Register.Add("Resdate", "揽件时间");
            OutExcelHelper.ExportExcel(allInfo, "无头件信息.xls", Register);
        }
        Register.Add("CSid", "编号");
        Register.Add("Rid", "面单号");
        Register.Add("customer", "客户名称");
        Register.Add("carriecompany", "公司名称");
        Register.Add("Destination", "目的地");
        Register.Add("Kilo", "公斤数");
        Register.Add("Price", "运费");
        Register.Add("Resdate", "揽件时间");
        Register.Add("IsSet", "是否结算");
        Register.Add("Remark", "备注");

        OutExcelHelper.ExportExcel(allInfo, "客户发件表.xls", Register);
    }
}
