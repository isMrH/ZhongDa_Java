using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL; 
using ZDDB.Model;

public partial class BackStage_Price : System.Web.UI.Page
{
    //价格模板
    PricesManager pm = new PricesManager();
    public List<PriceTB> allInfo
    {
        get { return ViewState["allinfo"] as List<PriceTB>; }
        set { ViewState["allinfo"] = value; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //填充数据
            allInfo = pm.GetAllInfo();
            anpPage.RecordCount = allInfo.Count;
            DisPlay();

            if (Session["cp"] != null)
            {
                CustomerPriceTB cp = Session["cp"] as CustomerPriceTB;
                gvTemp.DataSource = pm.GetPriceBypno(cp.PNo);
                gvTemp.DataBind();
            }
        }
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
        gvTemp.DataSource = pagedDataSource;
        gvTemp.DataBind();

        //在分页区显示总页数及当前页信息
        anpPage.CustomInfoHTML = " 总页数:<b>" + anpPage.PageCount.ToString() + "</b>";
        anpPage.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpPage.CurrentPageIndex.ToString() + "</b></font>";
    }
    protected void lkbtnExecl_Click(object sender, EventArgs e)
    {
        //导入表格
        Response.Redirect("~/PriceManager/CustomerPrice/defaultprice.aspx");
    }
    //根据条件查询
    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {

        DisplayTem();
        anpPage.CurrentPageIndex = 1;
    }
    //分页
    protected void gvTemp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTemp.PageIndex = e.NewPageIndex;
        DisplayTem();
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
    //绑定数据
    private void DisplayTem()
    {
        string pno = txtPno.Text;
        string des = txtDes.Text;
        double kilo = 0.0;
        if (txtKilo.Text != "")
        {
            kilo = Convert.ToDouble(txtKilo.Text);
        }

        double price = 0.0;
        if (txtPrice.Text != "")
        {
            price = Convert.ToDouble(txtPrice.Text);
        }
        allInfo = pm.GetTempByFilter(pno, des, kilo, price);
        anpPage.RecordCount = allInfo.Count();
        DisPlay();
    }
    //查询所有
    protected void imgbtnAll_Click(object sender, ImageClickEventArgs e)
    {
        txtDes.Text = "";
        txtKilo.Text = "";
        txtPno.Text = "";
        txtPrice.Text = "";
        allInfo = pm.GetAllInfo();
        anpPage.RecordCount = allInfo.Count;
        DisPlay();
    }
    protected void gvTemp_RowDataBound(object sender, GridViewRowEventArgs e)
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
        DisPlay();
    }
}
