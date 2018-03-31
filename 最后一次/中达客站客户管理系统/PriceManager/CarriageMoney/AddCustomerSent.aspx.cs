using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.Model;
using ZDDB.BLL;

public partial class PriceManager_CarriageMoney_AddCustomerSent : System.Web.UI.Page
{
    //客户表
    CustomersManager cm = new CustomersManager();
    //承运公司
    CarrieCompanyManager ccm = new CarrieCompanyManager();
    //面单分配
    DisNoteManager dm = new DisNoteManager();
    //客户价格
    CustomerPriceManager cpm = new CustomerPriceManager();
    //价格模板
    PricesManager pm = new PricesManager();
    //客户发件
    CustomerSentManager csm = new CustomerSentManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //绑定数据
            ddlName.DataSource = cm.GetAllCustomers();
            ddlName.DataTextField = "cusname";
            ddlName.DataValueField = "cusid";
            ddlName.DataBind();

            ddlCompany.DataSource = ccm.GetAllCarrieCompany();
            ddlCompany.DataTextField = "coname";
            ddlCompany.DataValueField = "cid";
            ddlCompany.DataBind();
            //如果传过来的值不为空，则为添加操作
            if (Request.QueryString["csid"] != null)
            {
                CustomerSentTB cst = new CustomerSentTB();
                //跟据传过来的id获取信息
                cst = csm.GetInfoByid(Convert.ToInt32(Request.QueryString["csid"]));
                //如果为无头件，则不显示客户姓名和公司姓名
                if (cst.cusid == 0)
                {
                    ddlName.Visible = false;
                    ddlCompany.Visible = false;
                }
                else
                {
                    ddlName.SelectedValue = cst.cusid.ToString();
                    ddlCompany.SelectedValue = cst.Cid.ToString();
                }
                //填充页面信息
                txtRid.Text = cst.Rid.ToString();
                txtDes.Text = cst.Destination;
                txtKilo.Text = cst.Kilo.ToString();
                txtPrice.Text = cst.Price.ToString();
                txtRemark.Text = cst.Remark;
                if (cst.IsSet == "是")
                {
                    rdoYes.Checked = true;
                }
                else
                {
                    rdoNo.Checked = true;
                }
            }
        }
    }
    protected void txtRid_TextChanged(object sender, EventArgs e)
    {
        //根据面单号得到客户id和公司id
        long rid =Convert.ToInt64( txtRid.Text);
        int cnt = dm.GetNoteIsDis(rid);
        if (cnt <= 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该件为无头件！')</script>");

        }
        else
        {
            DisNoteTB dnt = new DisNoteTB();
            dnt = dm.GetNoteByRid(rid);
            ddlName.SelectedValue = dnt.CusID.ToString();
            ddlCompany.SelectedValue = dnt.Cid.ToString();
        }
    }
    //公斤输入之后，自动计算运算
    protected void txtKilo_TextChanged(object sender, EventArgs e)
    {
        Charging();
    }
    //计算运费
    private void Charging()
    { 
        //根据客户id和公司id获得模板编号
        CustomerPriceTB cpt = new CustomerPriceTB();
        int cusid = Convert.ToInt32(ddlName.SelectedValue);
        int cid = Convert.ToInt32(ddlCompany.SelectedValue);
        cpt = cpm.GetInfoByCusidAndCid(cusid,cid);
        //根据模板编号，公斤数和目的地计算运费
        string pno=cpt.PNo;
        double kilo=Convert.ToDouble( txtKilo.Text);
        string des=txtDes.Text;
        PriceTB pt = new PriceTB();
        pt = pm.GetPriceByInfo(pno, kilo, des);
        //计算出价格
        txtPrice.Text = pt.Price.ToString();
    }
    protected void txtDes_TextChanged(object sender, EventArgs e)
    {
        //
    }
    protected void imgbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        //如果传过来的值为空则为添加
        if (Request.QueryString["csid"] == null)
        {
            CustomerSentTB cst = new CustomerSentTB();
            cst.Rid =Convert.ToInt64( txtRid.Text);
            cst.cusid =Convert.ToInt32( ddlName.SelectedValue);
            cst.Cid = Convert.ToInt32(ddlCompany.SelectedValue);
            cst.Destination = txtDes.Text;
            cst.Kilo =Convert.ToDouble( txtKilo.Text);
            cst.Price =Convert.ToDouble( txtPrice.Text);
            cst.Resdate =Convert.ToDateTime( txtDatetime.Text);
            cst.Remark = txtRemark.Text;
            if (Page.IsValid)
            {
                if (rdoYes.Checked == true)
                {
                    cst.IsSet = "1";
                }
                else
                {
                    cst.IsSet = "0";
                }

                int cnt = csm.InsertInfo(cst);
                if (cnt > 0)
                {
                    //添加成功，跳转到查询页面
                    Response.Redirect("~/PriceManager/CarriageMoney/CustomerSent.aspx");
                }
                else
                {
                    lblMessage.Text = "添加失败！";
                }
            }
        }
        //如果不为空则为修改
        else
        {
            CustomerSentTB cst = new CustomerSentTB();
            cst.Rid = Convert.ToInt64(txtRid.Text);
            cst.cusid = Convert.ToInt32(ddlName.SelectedValue);
            cst.Cid = Convert.ToInt32(ddlCompany.SelectedValue);
            cst.Destination = txtDes.Text;
            cst.Kilo = Convert.ToDouble(txtKilo.Text);
            cst.Price = Convert.ToDouble(txtPrice.Text);
            cst.Resdate = Convert.ToDateTime(txtDatetime.Text);
            cst.Remark = txtRemark.Text;
            if (rdoYes.Checked == true)
            {
                cst.IsSet = "1";
            }
            else
            {
                cst.IsSet = "0";
            }
            if (Page.IsValid)
            {
                int cnt = csm.UpdateInfo(cst);
                if (cnt > 0)
                {
                    //修改成功，跳转到查询页面
                    Response.Redirect("~/PriceManager/CarriageMoney/CustomerSent.aspx");
                }
                else
                {
                    lblMessage.Text = "修改失败！";
                }
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/PriceManager/CarriageMoney/CustomerSent.aspx");
    }
}
