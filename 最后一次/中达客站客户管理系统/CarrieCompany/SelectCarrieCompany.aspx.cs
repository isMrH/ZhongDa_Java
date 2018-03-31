using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.Model;
using ZDDB.BLL;

public partial class CarrieCompany_CarrieCompanyRegister : System.Web.UI.Page
{
    CarrieCompanyManager carcom = new CarrieCompanyManager();
    public List<CarrieCompanyTB> allCompany
    {
        get { return ViewState["allcompany"] as List<CarrieCompanyTB>; }
        set { ViewState["allcompany"] = value; }

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
                

                //绑定数据
                ddlCompany.DataSource = carcom.GetAllCarrieCompany();
                ddlCompany.DataTextField = "CoName";
                ddlCompany.DataValueField = "Cid";
                ddlCompany.DataBind();

                ddlMan.DataSource = carcom.GetAllCarrieCompany();
                ddlMan.DataTextField = "Clinkman";
                ddlMan.DataValueField = "Cid";
                ddlMan.DataBind();

                //获取所有信息
                allCompany = carcom.GetAllCarrieCompany();
                anpPage.RecordCount = allCompany.Count;

                DisplayCompany();
            }
        }
    }
    //显示相应页的信息
    private void DisplayCompany()
    {

        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allCompany;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpPage.PageSize;
        pagedDataSource.CurrentPageIndex = anpPage.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        gvCarrieCompany.DataSource = pagedDataSource;
        gvCarrieCompany.DataBind();

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
    //增加光棒和删除提示效果
    protected void gvCarrieCompany_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "defaultcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=defaultcolor");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton igde = e.Row.FindControl("IBtnDelete") as ImageButton;
            igde.Attributes.Add("onclick", "javascript:return confirm('您确认要删除:\"" + e.Row.Cells[0].Text + "\"吗?')");
        }
    }
    //判断为删除操作还是修改操作
    protected void gvCarrieCompany_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //删除
        if (e.CommandName == "Del")
        {
            bool res = carcom.DeleteCarrieCompany(Convert.ToInt32(e.CommandArgument));
            if (!res)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该承运公司的相关信息正在使用中，不允许删除！')</script>");
            }

        }
        //修改
        else if (e.CommandName == "nEd")
        {
            int Cid = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("~/CarrieCompany/CarrieCompanyRegister.aspx?Cid=" + Cid);
        }
        allCompany = carcom.GetAllCarrieCompany();
        anpPage.RecordCount = allCompany.Count;

        DisplayCompany();
    }
    //定义查询的私有方法
    private void Select()
    {
        string CoName = "";
        string Man = "";
        if (ddlCompany.SelectedValue != "0")
        {
            CoName = ddlCompany.SelectedItem.Text.Trim();
        }
        if (ddlMan.SelectedValue != "0")
        {
            Man = ddlMan.SelectedItem.Text.Trim();
        }
        allCompany = carcom.SelectCarrieCompany(CoName, Man);
        anpPage.RecordCount = allCompany.Count;
        DisplayCompany();
    }
    //查询按钮
    protected void ImBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        Select();
    }
    //添加按钮
    protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/CarrieCompany/CarrieCompanyRegister.aspx");
    }
    //查询全部按钮
    protected void imgbtnAll_Click(object sender, ImageClickEventArgs e)
    {
        ddlMan.SelectedValue = "0";
        ddlCompany.SelectedValue = "0";
        allCompany = carcom.GetAllCarrieCompany();
        anpPage.RecordCount = allCompany.Count;
        DisplayCompany();
    }
    
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlMan.SelectedValue = "0";
    }
    
    protected void ddlMan_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlCompany.SelectedValue = "0";
    }
    
    protected void anpPage_PageChanged(object sender, EventArgs e)
    {
        DisplayCompany();
    }
    protected void imgDaochu_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        // Cid         CoName               Clinkman             LinkmanTel           Cmoney                Remark
        Register.Add("Cid", "公司ID");
        Register.Add("CoName", "公司名称");
        Register.Add("Clinkman", "联系人");
        Register.Add("LinkmanTel", "联系电话");
        Register.Add("Cmoney", "面单费");
        Register.Add("Remark", "备注");

        OutExcelHelper.ExportExcel(allCompany, "公司信息.xls", Register);
    }
}
