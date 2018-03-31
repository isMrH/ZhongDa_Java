using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.Model;
using ZDDB.BLL;
using System.Data;
using System.Data.SqlClient;


public partial class DelGoodsMonTB_CustomerSendTB : System.Web.UI.Page
{
    CustomerSendManager sss = new CustomerSendManager();
    CustomersManager CusMan = new CustomersManager();
    public List<CustomerSendTB> allInfo
    {
        get { return ViewState["allinfo"] as List<CustomerSendTB>; }
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

                //填充DropDownlist控件客户
                this.ddlCustomer.DataSource = CusMan.GetAllCustomers();
                this.ddlCustomer.DataTextField = "CusName";
                this.ddlCustomer.DataValueField = "CusID";
                ddlCustomer.DataBind();
                allInfo = sss.GetAllCustomerSendTB();
                anpInfo.RecordCount = allInfo.Count();
                disbind();
            }
        }
    }
    protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        //跳转到信息详情页面
        Response.Redirect("~/DelGoodsMonTB/CustomerSendTBAdd.aspx");
    }
    //刷新数据表
    protected void disbind()
    {
        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allInfo;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpInfo.PageSize;
        pagedDataSource.CurrentPageIndex = anpInfo.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        GVCuoSEnd.DataSource = pagedDataSource;
        GVCuoSEnd.DataBind();

        //在分页区显示总页数及当前页信息
        anpInfo.CustomInfoHTML = " 总页数:<b>" + anpInfo.PageCount.ToString() + "</b>";
        anpInfo.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpInfo.CurrentPageIndex.ToString() + "</b></font>";
    }
    protected void ImgBtnall_Click(object sender, ImageClickEventArgs e)
    {
        allInfo = sss.GetAllCustomerSendTB();
        anpInfo.RecordCount = allInfo.Count();
        disbind();
        anpInfo.CurrentPageIndex = 1;
    }
    protected void GVCuoSEnd_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //修改功能
        if (e.CommandName == "Upd")
        {
            string CEid = e.CommandArgument.ToString();//获取命令参数
            Response.Redirect("~/DelGoodsMonTB/CustomerSendTBAdd.aspx?CEid=" + CEid);

        }
        //编辑功能  
        else if (e.CommandName == "Del")
        {
            int CEid = Convert.ToInt32(e.CommandArgument.ToString());//获取命令参数 
            int cnt = sss.DelCustomerSend(CEid);

        }
        allInfo = sss.GetAllCustomerSendTB();
        anpInfo.RecordCount = allInfo.Count();
        disbind();
    }
    protected void GVCuoSEnd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            ImageButton ldel = e.Row.FindControl("ImgBtnDel") as ImageButton;
            ldel.Attributes.Add("onclick", "javascrdipt:return confirm('你确认要删除吗？')");

        }
        //产生光棒效果
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "defaultcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=defaultcolor");
        }
    }
    //条件查询
    protected void ImgBtnSeach_Click(object sender, ImageClickEventArgs e)
    {
        int cusid = Convert.ToInt32(ddlCustomer.SelectedValue);
        string number = txtNumber.Text;
        string money = txtPrice.Text.Trim();
        string date = txtDate.Text;
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

        allInfo = sss.SelectCustomerSendByCusid(cusid, number, money, date, data2, iss);
        anpInfo.RecordCount = allInfo.Count();
        disbind();
        anpInfo.CurrentPageIndex = 1;
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        disbind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        // CEid        CusID       ECount      EAllPrice             ISsettle EDate                   Remark
        Register.Add("CEid", "编号");
        Register.Add("Ccustomer", "客户姓名");
        Register.Add("ECount", "派送个数");
        Register.Add("EAllPrice", "派件邮费");
        Register.Add("ISsettle", "是否结算");
        Register.Add("EDate", "派件年月");
        Register.Add("Remark", "备注");
        OutExcelHelper.ExportExcel(allInfo, "客户送件表.xls", Register);
    }
}
