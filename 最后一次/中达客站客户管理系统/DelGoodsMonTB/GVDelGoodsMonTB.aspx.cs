using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.Model;
using ZDDB.BLL;

public partial class DelGoodsMonTB_GVDelGoodsMonTB : System.Web.UI.Page
{
    //实例化数据访问层对象
    DelGoodsMonManager DelGood = new DelGoodsMonManager();
    CustomersManager CusMan = new CustomersManager();
    public List<DelGoodMon> allInfo
    {
        get { return ViewState["allinfo"] as List<DelGoodMon>; }
        set { ViewState["allinfo"] = value; }

    }
    //填充数据集
    private void DisBind()
    {
        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allInfo;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpInfo.PageSize;
        pagedDataSource.CurrentPageIndex = anpInfo.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        gvGoods.DataSource = pagedDataSource;
        gvGoods.DataBind();

        //在分页区显示总页数及当前页信息
        anpInfo.CustomInfoHTML = " 总页数:<b>" + anpInfo.PageCount.ToString() + "</b>";
        anpInfo.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpInfo.CurrentPageIndex.ToString() + "</b></font>";
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

                //刷新数据集
                allInfo = DelGood.GetAllDelGoodMonInfo();
                anpInfo.RecordCount = allInfo.Count();
                DisBind();
            }
        }
    }
    
  
    //条件查询
    protected void ImgBtnSeach_Click(object sender, ImageClickEventArgs e)
    {
        int cusid = Convert.ToInt32(ddlCustomer.SelectedValue);
        string money = txtmoney.Text.Trim();

        //根据cusid查询

        allInfo = DelGood.GetALLByCusidGoodsMon(cusid, money);
        anpInfo.RecordCount = allInfo.Count();
        DisBind();
        anpInfo.CurrentPageIndex = 1;
       
    }
    //查询所有
    protected void ImgBtnall_Click(object sender, ImageClickEventArgs e)
    {
        allInfo = DelGood.GetAllDelGoodMonInfo();
        anpInfo.RecordCount = allInfo.Count();
        DisBind();
        anpInfo.CurrentPageIndex = 1;
    }
   //跳转页面
    protected void ImgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        //跳转到信息详情页面
        Response.Redirect("~/DelGoodsMonTB/DelGoodsMonTBAdd.aspx");
    }
    protected void gvGoods_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //修改功能
        if (e.CommandName == "Upd")
        {
            string delID = e.CommandArgument.ToString();//获取命令参数
            Response.Redirect("~/DelGoodsMonTB/DelGoodsMonTBAdd.aspx?DelID=" + delID);

        }
        //编辑功能  
        else if (e.CommandName == "Del")
        {
            string delID = e.CommandArgument.ToString();//获取命令参数 
            int cnt = DelGood.DelGoodsMon(delID);

        }
        allInfo = DelGood.GetAllDelGoodMonInfo();
        anpInfo.RecordCount = allInfo.Count();
        DisBind();
    }

    protected void gvGoods_RowDataBound1(object sender, GridViewRowEventArgs e)
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

    protected void gvGoods_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //显示当前点击业
        gvGoods.PageIndex = e.NewPageIndex;
        DisBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        // DelID       CusID       DelUnitPrice          Remark
        Register.Add("DelID", "编号");
        Register.Add("customer", "客户姓名");
        Register.Add("DelUnitPrice", "送货单价");
        Register.Add("Remark", "备注");


        OutExcelHelper.ExportExcel(allInfo, "送货价格表.xls", Register);
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        DisBind();
    }
}
