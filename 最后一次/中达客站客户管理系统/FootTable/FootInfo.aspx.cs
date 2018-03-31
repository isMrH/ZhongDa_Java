using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Drawing;
using ZDDB.Model;
using ZDDB.BLL;

public partial class FootTable_FootInfo : System.Web.UI.Page
{
    CustomersManager customersmanager = new CustomersManager();//实例化业务员
    DisNoteManager disnotemanager = new DisNoteManager();//实例化面单分配
    CustomerSentManager customersentmanager = new CustomerSentManager();//实例化客户发件
    CustomerSendManager customersendmanager = new CustomerSendManager();//实例化客户送件
    SentManager sentmanager = new SentManager();//实例化揽发到付件
    AcceptManager acceptmanager = new AcceptManager();//实例化派收到付款表
    IAEManagerManager iaemanagermanager = new IAEManagerManager();//实例化其他费用
    CustomerPianManager customerpianmanager = new CustomerPianManager();//实例化费用结算
    public List<CustomerPianTB> allInfo
    {
        get { return ViewState["allinfo"] as List<CustomerPianTB>; }
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
                fillddlcus();

                allInfo = customerpianmanager.GetAllCustomerPianTB();
                anpInfo.RecordCount = allInfo.Count();
                BindData();
            }
        }
    }
    //获取所有信息
    private void BindData()
    {
        PagedDataSource pagedDataSource = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值
        pagedDataSource.DataSource = allInfo;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = anpInfo.PageSize;
        pagedDataSource.CurrentPageIndex = anpInfo.CurrentPageIndex - 1;
        //将分页结果显示在gridview中
        gvinfo.DataSource= pagedDataSource;
        gvinfo.DataBind();

        //在分页区显示总页数及当前页信息
        anpInfo.CustomInfoHTML = " 总页数:<b>" + anpInfo.PageCount.ToString() + "</b>";
        anpInfo.CustomInfoHTML += " 当前页:<font color=\"red\"><b>" + anpInfo.CurrentPageIndex.ToString() + "</b></font>";
    }
    //填充业务员下拉列表
    private void fillddlcus()
    {
        ddlcus.DataSource = customersmanager.GetAllCustomers();
        ddlcus.DataTextField = "CusName";
        ddlcus.DataValueField = "CusID";
        ddlcus.DataBind();
    }
    
    //protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
    //{
    //    CustomerPianTB cp = new CustomerPianTB();
    //    int cusid = Convert.ToInt32(ddlcus.SelectedValue);
    //    DateTime qtime = Convert.ToDateTime(txtstime.Text);
    //    DateTime ttime = Convert.ToDateTime(txtttime.Text);

    //    CustomersTB cus = customersmanager.GetCusmoerByid(cusid);
    //    string name = cus.CusName; //获取客户名

    //    DisNoteTB dis = disnotemanager.GetDisNoteTBById(cusid, qtime, ttime);
    //    double oddmon = dis.Sum;//获取面单费用
    //    string issrt = dis.IsSet;//获取面单费用是否已结算
    //    if (issrt == "是")
    //    {
    //        cp.Remark = "面单费已结清！";
    //    }
    //    else
    //    {
    //        cp.Remark = "面单费未结！";
    //    }

    //    CustomerSentTB cs = customersentmanager.GetCustomerSentTBById(cusid, qtime, ttime);
    //    double sendmon = cs.Price;//获取发件费

    //    CustomerSendTB cf = customersendmanager.GetCustomerSendTBById(cusid, qtime, ttime);
    //    double givemon = cf.EAllPrice;//获取送件费

    //    SentTB st = sentmanager.GetSentTBById(cusid, qtime, ttime);
    //    double backmon = st.Price;//获取收到付件返利

    //    AcceptTB at = acceptmanager.GetAcceptTBById(cusid, qtime, ttime);
    //    double accmon = at.Price;//获取派收到付件款

    //    IAEManagerTB ia = iaemanagermanager.GetIAEManagerTBById(cusid, qtime, ttime);
    //    double othermon = ia.Price;//获取其他费用

    //    double allmon = oddmon + sendmon + backmon - givemon - accmon + othermon;//总计

    //    string ISsettle = "false";

    //    cp.CusID = Convert.ToInt32(cusid);
    //    cp.DateMon = ttime;
    //    cp.OddMon = oddmon;
    //    cp.SendMon = sendmon;
    //    cp.GiveMon = givemon;
    //    cp.BackMon = backmon;
    //    cp.AccMon = accmon;
    //    cp.OtherMon = othermon;
    //    cp.AllMon = allmon;
    //    cp.ISsettle = ISsettle;

    //    int cou = customerpianmanager.UpdateCustomerPianTBById(cp);
    //    if (cou > 0)
    //    {
    //        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！')</script>");
    //    }
    //}
    protected void imgbtnselect_Click(object sender, ImageClickEventArgs e)
    {
        //CustomerPianTB cp = new CustomerPianTB();
        //int cusid = Convert.ToInt32(ddlcus.SelectedValue);
        //DateTime qtime = Convert.ToDateTime(txtstime.Text);
        //DateTime ttime = Convert.ToDateTime(txtttime.Text);

        //CustomersTB cus = customersmanager.GetCusmoerByid(cusid);
        //string name = cus.CusName; //获取客户名

        //DisNoteTB dis = disnotemanager.GetDisNoteTBById(cusid, qtime, ttime);
        //double oddmon = dis.Sum;//获取面单费用
        //string issrt = dis.IsSet;//获取面单费用是否已结算
        //if (issrt == "是")
        //{
        //    cp.Remark = "面单费已结清！";
        //}
        //else
        //{
        //    cp.Remark = "面单费未结！";
        //}

        //CustomerSentTB cs = customersentmanager.GetCustomerSentTBById(cusid, qtime, ttime);
        //double sendmon = cs.Price;//获取发件费

        //CustomerSendTB cf = customersendmanager.GetCustomerSendTBById(cusid, qtime, ttime);
        //double givemon = cf.EAllPrice;//获取送件费

        //SentTB st = sentmanager.GetSentTBById(cusid, qtime, ttime);
        //double backmon = st.Price;//获取收到付件返利

        //AcceptTB at = acceptmanager.GetAcceptTBById(cusid, qtime, ttime);
        //double accmon = at.Price;//获取派收到付件款

        //IAEManagerTB ia = iaemanagermanager.GetIAEManagerTBById(cusid, qtime, ttime);
        //double othermon = ia.Price;//获取其他费用

        //double allmon = oddmon + sendmon + backmon - givemon - accmon + othermon;//总计

        //string ISsettle = "false";

        //cp.CusID = Convert.ToInt32(cusid);
        //cp.DateMon = ttime;
        //cp.OddMon = oddmon;
        //cp.SendMon = sendmon;
        //cp.GiveMon = givemon;
        //cp.BackMon = backmon;
        //cp.AccMon = accmon;
        //cp.OtherMon = othermon;
        //cp.AllMon = allmon;
        //cp.ISsettle = ISsettle;

        //int cou = customerpianmanager.AddCustomerPianTBInfo(cp);
        //if (cou == 1)
        //{
            allInfo = customerpianmanager.GetAllCustomerPianTB();
            anpInfo.RecordCount = allInfo.Count();
            BindData();
            anpInfo.CurrentPageIndex = 1;
        //}
    }
    protected void imgbtnsel_Click(object sender, ImageClickEventArgs e)
    {
        
        CustomerPianTB cp = new CustomerPianTB();
        int cusid = Convert.ToInt32(ddlcus.SelectedValue);
        DateTime qtime = Convert.ToDateTime(txtstime.Text);
        DateTime ttime = Convert.ToDateTime(txtttime.Text);
        try
        {
            if (customerpianmanager.GetCustomerPianTBById(cusid, qtime, ttime) != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该用户信息已存在，请确认业务员及时间。')</script>");
                return;
            }
        }
        catch (Exception ex)
        {

            try
            {
                CustomersTB cus = customersmanager.GetCusmoerByid(cusid);
                string name = cus.CusName; //获取客户名

                DisNoteTB dis = disnotemanager.GetDisNoteTBById(cusid, qtime, ttime);
                double oddmon = dis.Sum;//获取面单费用
                string issrt = dis.IsSet;//获取面单费用是否已结算
                if (issrt == "是")
                {
                    cp.Remark = "面单费已结！";
                }
                else
                {
                    cp.Remark = "面单费未结！";
                }

                CustomerSentTB cs = customersentmanager.GetCustomerSentTBById(cusid, qtime, ttime);
                double sendmon = cs.Price;//获取发件费

                CustomerSendTB cf = customersendmanager.GetCustomerSendTBById(cusid, qtime, ttime);
                double givemon = cf.EAllPrice;//获取送件费

                SentTB st = sentmanager.GetSentTBById(cusid, qtime, ttime);
                double backmon = st.Price;//获取收到付件返利

                AcceptTB at = acceptmanager.GetAcceptTBById(cusid, qtime, ttime);
                double accmon = at.Price;//获取派收到付件款

                IAEManagerTB ia = iaemanagermanager.GetIAEManagerTBById(cusid, qtime, ttime);
                double othermon = ia.Price;//获取其他费用

                double allmon = oddmon + sendmon + backmon - givemon - accmon + othermon;//总计

                string ISsettle = "false";

                cp.CusID = Convert.ToInt32(cusid);
                cp.DateMon = ttime;
                cp.OddMon = oddmon;
                cp.SendMon = sendmon;
                cp.GiveMon = givemon;
                cp.BackMon = backmon;
                cp.AccMon = accmon;
                cp.OtherMon = othermon;
                cp.AllMon = allmon;
                cp.ISsettle = ISsettle;

                int cou = customerpianmanager.AddCustomerPianTBInfo(cp);
                if (cou == 1)
                {
                    allInfo = customerpianmanager.GetAllCustomerPianTBInfo(cusid);
                    anpInfo.RecordCount = allInfo.Count();
                    BindData();
                    anpInfo.CurrentPageIndex = 1;
                }
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('无该用户信息，请确认业务员及时间。')</script>");
                return;
            }
        }
    }
    protected void gvinfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //产生光棒效果
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "defaultcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=defaultcolor");
        }
        //如果绑定是数据行
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnDel = (ImageButton)e.Row.FindControl("imabtndel");
            btnDel.Attributes.Add("onclick", "javascrdipt:return confirm('您确认要删除吗？')");
        }
    }
    public static int cusid;
    protected void gvinfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        cusid = int.Parse(e.CommandArgument.ToString());//获取命令参数
        if (cmd == "Del")
        {

           //执行删除
           customerpianmanager.DeleteCInfoId(cusid);
           allInfo = customerpianmanager.GetAllCustomerPianTB();
           anpInfo.RecordCount = allInfo.Count();
           BindData();
        }
        else if (cmd == "oddmon")
        {
            Response.Redirect("~/FootTable/DisNoteInfo.aspx?cusid=" + Convert.ToString(cusid));
        }
        else if (cmd == "SendMon")
        {
            Response.Redirect("~/FootTable/CsentInfo.aspx?cusid=" + Convert.ToString(cusid));
        }
        else if (cmd == "GiveMon")
        {
            Response.Redirect("~/FootTable/CustomerSendInfo.aspx?cusid=" + Convert.ToString(cusid));
        }
        else if (cmd == "BackMon")
        {
            Response.Redirect("~/FootTable/SentInfo.aspx?cusid=" + Convert.ToString(cusid));
        }
        else if (cmd == "AccMon")
        {
            Response.Redirect("~/FootTable/AcceptInfo.aspx?cusid=" + Convert.ToString(cusid));
        }
        else if (cmd == "OtherMon")
        {
            Response.Redirect("~/FootTable/IAEManagerInfo.aspx?cusid=" + Convert.ToString(cusid));
        }
        else if (cmd == "jiesuan")
        {
            Response.Redirect("~/FootTable/IssettleInfo.aspx?cusid=" + Convert.ToString(cusid));
        }

    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Dictionary<string, string> Register = new Dictionary<string, string>();
        Register.Add("CPid", "编号");
        Register.Add("customer", "客户姓名");
        Register.Add("DateMon", "费用年月");
        Register.Add("OddMon", "面单费用");
        Register.Add("SendMon", "发件费");
        Register.Add("GiveMon", "送件费");
        Register.Add("BackMon", "收到付件返利");
        Register.Add("AccMon", "派到付件款");
        Register.Add("OtherMon", "其他费用");
        Register.Add("AllMon", "总计");
        Register.Add("ISsettle", "是否结款");
        Register.Add("Remark", "备注");

        OutExcelHelper.ExportExcel(allInfo, "结算.xls", Register);
    }
}
