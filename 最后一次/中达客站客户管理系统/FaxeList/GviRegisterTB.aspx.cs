using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.Model;
using ZDDB.BLL;


public partial class FaxeList_GviRegisterTB : System.Web.UI.Page
{
    CarrieCompanyManager ComMan = new CarrieCompanyManager();
    RegisterManager RegMan = new RegisterManager();

    public List<RegisterTB> allInfo
    {
        get { return ViewState["allinfo"] as List<RegisterTB>; }
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
                //填充DropDownlist控件
                this.ddlCompany.DataSource = ComMan.GetAllCarrieCompany();
                this.ddlCompany.DataTextField = "CoName";
                this.ddlCompany.DataValueField = "Cid";
                ddlCompany.DataBind();
                //调用方法填充数据gridview控件


                allInfo = RegMan.GetAllRegisterTB();
                anpPage.RecordCount = allInfo.Count;
                DisPlay();
            }
        }
    }
    protected void GvRegister_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //显示当前点击业
        GvRegister.PageIndex = e.NewPageIndex;
        DisPlay();
    }
    //自定义方法刷新表格
    private void DisPlay()
    {
        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allInfo;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpPage.PageSize;
        pagedDataSource.CurrentPageIndex = anpPage.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        GvRegister.DataSource = pagedDataSource;
        GvRegister.DataBind();

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
    protected void GvRegister_RowDataBound(object sender, GridViewRowEventArgs e)
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
    //查询功能的设计
    protected void ImgBtnSeach_Click(object sender, ImageClickEventArgs e)
    {
        string Cid = ddlCompany.SelectedValue.ToString();
        if (Cid == "0")
        {
            Cid = "";
        }
        string begin = txtBegin.Text.Trim();
        string end = txtEnd.Text.Trim();
        string datatime = txtDate.Text.Trim();
        string datatime2 = txtDate2.Text.Trim();

        allInfo = RegMan.GetAllRegisterTBByCid(Cid,begin,end,datatime,datatime2);
        anpPage.RecordCount = allInfo.Count;
        DisPlay();
        anpPage.CurrentPageIndex = 1;

    }
    //查询所有
    protected void ImgBtnall_Click(object sender, ImageClickEventArgs e)
    {
        allInfo = RegMan.GetAllRegisterTB();
        anpPage.RecordCount = allInfo.Count;
        DisPlay();
        anpPage.CurrentPageIndex = 1;
    }
    protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/FaxeList/RegisterTB.aspx");
    }
    protected void GvRegister_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //修改功能
        if (e.CommandName == "Upd")
        {
            string rid = e.CommandArgument.ToString();//获取命令参数
            Response.Redirect("~/FaxeList/RegisterTB.aspx?Rid=" + rid);

        }
        //编辑功能  
        else if (e.CommandName == "Del")
        {
            string rid = e.CommandArgument.ToString();//获取命令参数 
            int cnt = RegMan.DeleteRegisterTB(rid);

        }
        //刷新数据表
        allInfo = RegMan.GetAllRegisterTB();
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
        // Rid         Cid         BeginNo              EndNo                Buydate                 Remark
        Register.Add("Rid", "编号");
        Register.Add("CCompany", "公司名称");
        Register.Add("BeginNo", "面单起始号");
        Register.Add("EndNo", "面单结束号");
        Register.Add("Buydate", "购买时间");
        Register.Add("Remark", "备注");

        OutExcelHelper.ExportExcel(allInfo, "面单购入表.xls", Register);
    }
}
