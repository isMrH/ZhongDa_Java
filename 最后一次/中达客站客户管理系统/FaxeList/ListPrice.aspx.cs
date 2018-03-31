using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.Model;
using ZDDB.BLL;

public partial class FaxeList_ListPrice : System.Web.UI.Page
{

    DisNoteManager DNMan = new DisNoteManager();
    CustomersManager Customer = new CustomersManager();
    CarrieCompanyManager ca = new CarrieCompanyManager();

    public List<DisNoteTB> allInfo
    {
        get { return ViewState["allinfo"] as List<DisNoteTB>; }
        set { ViewState["allinfo"] = value; }

    }


    //定义方法填充gridview控件
    protected void DisPlay()
    {
        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allInfo;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpPage.PageSize;
        pagedDataSource.CurrentPageIndex = anpPage.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        GvDisNoteTB.DataSource = pagedDataSource;
        GvDisNoteTB.DataBind();

        //在分页区显示总页数及当前页信息
        anpPage.CustomInfoHTML = " 总页数:<b>" + anpPage.PageCount.ToString() + "</b>";
        anpPage.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpPage.CurrentPageIndex.ToString() + "</b></font>";
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
                //填充DropDownlist控件客户
                this.ddlSustomer.DataSource = Customer.GetAllCustomers();
                this.ddlSustomer.DataTextField = "CusName";
                this.ddlSustomer.DataValueField = "CusID";
                ddlSustomer.DataBind();

                this.ddlCarrieCompany.DataSource = ca.GetAllCarrieCompany();
                this.ddlCarrieCompany.DataTextField = "CoName";
                this.ddlCarrieCompany.DataValueField = "Cid";
                ddlCarrieCompany.DataBind();

                allInfo = DNMan.GetAllDisNoteTB();
                anpPage.RecordCount = allInfo.Count;
                DisPlay();
            }
        }
    }
    //条件查询
    protected void ImgBtnSeach_Click(object sender, ImageClickEventArgs e)
    {
        //获取页面的值

        string Cusid = ddlSustomer.SelectedValue;
        if (Cusid == "0")
        {
            Cusid = "";
        }

        string Cid = ddlCarrieCompany.SelectedValue;
        if (Cid == "0")
        {
            Cid = "";
        }
        string begin = txtNumber.Text.Trim();
        string end = txtNumber0.Text.Trim();
        string dates = txtDate.Text;
        string data2 = txtDate2.Text;
        int iss = 0;
        if (rdoNo.Checked == true)
        {
            iss = 0;
        }
        else if (rdoYes.Checked == true)
        {
            iss = 1;
        }

        //填充数据集
        allInfo = DNMan.GetAllDisNoteTBByBoth(Cusid, Cid, begin, end, dates, data2, iss);
        anpPage.RecordCount = allInfo.Count;
        DisPlay();
        anpPage.CurrentPageIndex = 1;

    }
    protected void ImgBtnall_Click(object sender, ImageClickEventArgs e)
    {
        allInfo = DNMan.GetAllDisNoteTB();
        anpPage.RecordCount = allInfo.Count;
        DisPlay();
        anpPage.CurrentPageIndex = 1;
    }
    protected void GvDisNoteTB_RowDataBound(object sender, GridViewRowEventArgs e)
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

            ImageButton ldel = e.Row.FindControl("ImgBtnDel") as ImageButton;
            ldel.Attributes.Add("onclick", "javascrdipt:return confirm('你确认要删除吗？')");

        }
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
    
    protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/FaxeList/DisNoteTB.aspx");
    }
    protected void GvDisNoteTB_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //修改功能
        if (e.CommandName == "Upd")
        {
            string Nid = e.CommandArgument.ToString();//获取命令参数
            Response.Redirect("~/FaxeList/DisNoteTB.aspx?Nid=" + Nid);

        }
        //编辑功能  
        else if (e.CommandName == "Del")
        {
            string Nid = e.CommandArgument.ToString();//获取命令参数 
            int cnt = DNMan.DeleTeDisNoteTB(Nid);
        }
        //刷新数据表
        allInfo = DNMan.GetAllDisNoteTB();
        anpPage.RecordCount = allInfo.Count;
        DisPlay();
    }
    protected void anpPage_PageChanged(object sender, EventArgs e)
    {
        DisPlay();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        //Nid         CusID       Cid         BeginNO              EndNo                Dtime                   Sum                   IsSet Remark
        Register.Add("Nid", "编号");
        Register.Add("Customer", "客户名称");
        Register.Add("CarrieCompany", "公司名称");
        Register.Add("BeginNo", "面单起始号");
        Register.Add("EndNo", "面单结束号");
        Register.Add("Dtime", "分配时间");
        Register.Add("Sum", "金额");
        Register.Add("IsSet", "是否已结算");
        Register.Add("Remark", "备注");

        OutExcelHelper.ExportExcel(allInfo, "面单分配表.xls", Register);
    }
}
