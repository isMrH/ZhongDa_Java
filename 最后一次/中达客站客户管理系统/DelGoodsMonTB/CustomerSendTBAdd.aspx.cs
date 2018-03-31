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
public partial class DelGoodsMonTB_CustomerSendTBAdd : System.Web.UI.Page
{
    //实例化数据访问层
    CustomersManager CusMan = new CustomersManager();
    DelGoodsMonManager DelM = new DelGoodsMonManager();
    CustomerSendManager Sudd = new CustomerSendManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usermanager"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            { //窗体加载标签不显示
                lblmessage.Visible = false;

                //填充DropDownlist控件客户
                this.ddlCustomer.DataSource = CusMan.GetAllCustomers();
                this.ddlCustomer.DataTextField = "CusName";
                this.ddlCustomer.DataValueField = "CusID";
                ddlCustomer.DataBind();
                if (Request.QueryString["CEid"] == null)
                {
                    txtcount.Text = "";
                    txtmoney.Text = "";
                    txtDate.Text = "";
                    txtRemark.Text = "";
                }
                if (Request.QueryString["CEid"] != null)
                {
                    int ceid = Convert.ToInt32(Request.QueryString["CEid"]);

                    CustomerSendTB CusSs = Sudd.SelectCustomerSendByCEid(ceid);
                    ddlCustomer.SelectedValue = CusSs.CusID;
                    txtcount.Text = CusSs.ECount.ToString();
                    txtmoney.Text = CusSs.EAllPrice.ToString();
                    string isss = CusSs.Issettle;
                    if (isss == "True")
                    {
                        rdoYes.Checked = true;
                    }
                    else
                    {
                        rdoNo.Checked = true;
                    }
                    txtDate.Text = CusSs.EDate.ToString();
                    txtRemark.Text = CusSs.Remark;
                }

            }
        }
    }
//添加的方法
    protected void TmgBtnExit_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            CustomerSendTB CusS = new CustomerSendTB();
            CusS.CusID = ddlCustomer.SelectedValue;
            CusS.ECount = Convert.ToInt32(txtcount.Text);

            int count = Convert.ToInt32(txtcount.Text);
            object obj = DelM.GetMoney(Convert.ToInt32(ddlCustomer.SelectedValue));
            int mon = Convert.ToInt32(obj);
            double allprice = mon * count;

            CusS.EAllPrice = allprice;
            int iss = 0;
            if (rdoYes.Checked == true)
            {
                iss = 1;
            }
            else
            {
                iss = 0;
            }

            CusS.Issettle = iss.ToString();
            CusS.EDate = Convert.ToDateTime(txtDate.Text);
            CusS.Remark = txtRemark.Text;
            if (Request.QueryString["CEid"] == null)
            {
                int cnt = Sudd.InsertCustomerSend(CusS);
                if (cnt > 0)
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "添加成功";
                    txtcount.Text = "";
                    txtmoney.Text = "";
                    txtDate.Text = "";
                    txtRemark.Text = "";
                }
            }
            if (Request.QueryString["CEid"] != null)
            {

                int CEid = Convert.ToInt32(Request.QueryString["CEid"]);
                CusS.CEid = CEid;
                int cnn = Sudd.UpdateCustomerSend(CusS);
                if (cnn > 0)
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "修改成功";
                }

            }
        }
        
    }
    //文本框时间
    protected void txtcount_TextChanged(object sender, EventArgs e)
    {

        try
        {
            int count = Convert.ToInt32(txtcount.Text);
            object obj = DelM.GetMoney(Convert.ToInt32(ddlCustomer.SelectedValue));

            int mon = Convert.ToInt32(obj);
            double allprice = mon * count;
            txtmoney.Text = allprice.ToString();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alter('输入字符串的格式不正确')</script>");
            return;
        }
    }
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        //跳转到信息详情页面
        Response.Redirect("~/DelGoodsMonTB/CustomerSendTB.aspx");
    }
}
