using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;

public partial class Customers_SelectCustomers : System.Web.UI.Page
{
    //客户
    CustomersManager Customer = new CustomersManager();

    public List<CustomersTB> allCustomers
    {
        get { return ViewState["allcustomers"] as List<CustomersTB>; }
        set { ViewState["allcustomers"] = value; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登陆，若没有登陆，则跳到登陆页面
        if (Session["Usermanager"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                //绑定数据
                ddlName.DataSource = Customer.GetAllCustomers();
                ddlName.DataTextField = "CusName";
                ddlName.DataValueField = "Cusid";
                ddlName.DataBind();


                //获取所有客户信息
                allCustomers = Customer.GetAllCustomers();
                anpPage.RecordCount = allCustomers.Count;
                
                
                //显示信息
                DisplayCustomer();
            }

        }
    }
    //显示相应页的信息
    private void DisplayCustomer()
    {

        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allCustomers;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpPage.PageSize;
        pagedDataSource.CurrentPageIndex = anpPage.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        gvCustomers.DataSource = pagedDataSource;
        gvCustomers.DataBind();

        //在分页区显示总页数及当前页信息
        anpPage.CustomInfoHTML = " 总页数:<b>" + anpPage.PageCount.ToString() + "</b>";
        anpPage.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpPage.CurrentPageIndex.ToString() + "</b></font>";
    }
   
    //获取所有客户信息
    public void GetAllCustomers()
    {
        //填充gridview
        gvCustomers.DataSource = Customer.GetAllCustomers();
        gvCustomers.DataBind();
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
    //判断为删除还是修改操作
    protected void gvCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //删除
        if (e.CommandName == "nDe")
        {
            bool res = Customer.DelCustomer(Convert.ToInt32(e.CommandArgument));
            if (!res)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该客户的相关信息正在使用中，不允许删除！')</script>");
            }
        }
        //修改
        else if (e.CommandName == "Ed")
        {
            //获取ID号
            int Cusid = Convert.ToInt32(e.CommandArgument);
            //将ID号传到修改页面
            Response.Redirect("~/Customers/UpdateOrEditCustomer.aspx?Cusid="+Cusid);
        }
        //更新数据
        allCustomers = Customer.GetAllCustomers();
        anpPage.RecordCount = allCustomers.Count;


        //显示信息
        DisplayCustomer();
    }
    //实现光棒和删除提示效果
    protected void gvCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //光棒效果
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "defaultcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=defaultcolor");
        }
        //删除提示
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton igde = e.Row.FindControl("ImbtnDelete") as ImageButton;
            igde.Attributes.Add("onclick", "javascript:return confirm('您确认要删除:\"" + e.Row.Cells[0].Text + "\"吗?')");
        }
    }
    //定义查询的私有方法
    private void Select()
    {
        string CName = "";
        int IsCounterman = 2;
        //获取客户姓名
        if (ddlName.SelectedValue != "0")
        {
            CName = ddlName.SelectedItem.Text.Trim();
        }
        //获取是否为业务员
        if (ddlIscounterman.SelectedValue != "2")
        {
            IsCounterman = Convert.ToInt32(ddlIscounterman.SelectedValue);
        }
        //调用方法，填充gridview
        allCustomers = Customer.SelectCustomers(CName, IsCounterman);
        anpPage.RecordCount = allCustomers.Count;
        DisplayCustomer();
    }
    //查询按钮
    protected void ImBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        //调用方法
        Select();
        anpPage.CurrentPageIndex = 1;
    }
    //添加按钮
    protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        //跳转到添加页面
        Response.Redirect("~/Customers/UpdateOrEditCustomer.aspx");
    }
    //查询全部按钮
    protected void imgbtnAll_Click(object sender, ImageClickEventArgs e)
    {
        //初始化查询条件
        ddlName.SelectedValue = "0";
        ddlIscounterman.SelectedValue = "2";
        anpPage.CurrentPageIndex = 1;
        allCustomers = Customer.GetAllCustomers();
        anpPage.RecordCount = allCustomers.Count;
        DisplayCustomer();
    }
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlIscounterman.SelectedValue = "2";
    }
    protected void ddlIscounterman_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlName.SelectedValue = "0";
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        DisplayCustomer();
    }
    //导出表格
    protected void imgDaochu_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        //  CusID         CusName              CusTel               IsCounterman                 Remark
        Register.Add("CusID", "客户ID");
        Register.Add("CusName", "客户姓名");
        Register.Add("CusTel", "联系电话");
        Register.Add("IsCounterman", "是否为业务员");
        Register.Add("Remark", "备注");


        OutExcelHelper.ExportExcel(allCustomers, "客户信息.xls", Register);

    }
}
