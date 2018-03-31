using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;
public partial class PriceManager_CustomerPrice_AddCustomerPrice : System.Web.UI.Page
{
    //客户
    CustomersManager cm = new CustomersManager();
    //公司
    CarrieCompanyManager ccm = new CarrieCompanyManager();
    //客户价格
    CustomerPriceManager cpm = new CustomerPriceManager();
    //价格
    PricesManager pm = new PricesManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //显示模板
            ddlPno.DataSource = cpm.GetAllInfo();
            ddlPno.DataTextField = "PNo";
            ddlPno.DataValueField = "PNo";
            ddlPno.DataBind();

            //如果传过来的值是空的，则是添加
            if (Request.QueryString["cpid"] == null)
            {

                //显示客户
                ddlName.DataSource = cm.GetAllCustomers();
                ddlName.DataTextField = "CusName";
                ddlName.DataValueField = "CusID";
                ddlName.DataBind();

                //显示公司
                ddlCompany.DataSource = ccm.GetAllCarrieCompany();
                ddlCompany.DataTextField = "CoName";
                ddlCompany.DataValueField = "Cid";
                ddlCompany.DataBind();

                
            }
            //不为空，则为修改
            else
            {
                

                //填充页面信息
                ddlName.Visible = false;
                ddlCompany.Visible = false;
                lblCus.Visible = true;
                lblCompany.Visible = true;
                int cpid = Convert.ToInt32(Request.QueryString["cpid"]);
                CustomerPriceTB cp = new CustomerPriceTB();
                cp = cpm.GetInfoById(cpid);

                ddlName.Visible = false;
                ddlCompany.Visible = false;
                lblCus.Text = cp.customer.CusName;
                lblCompany.Text = cp.carriecomapny.CoName;
                ddlPno.Text = cp.PNo;
                txtCpname.Text = cp.CpName;
                txtRemark.Text = cp.Remark;
            }
        }
    }
    
    protected void imgbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        //如果传过来的typeid的值为空，则执行添加操作
        if (Request.QueryString["cpid"] == null)
        {
            if (Page.IsValid)
            {
                CustomerPriceTB cpt = new CustomerPriceTB();
                cpt.CusID = Convert.ToInt32(ddlName.SelectedValue);
                cpt.Cid = Convert.ToInt32(ddlCompany.SelectedValue);
                cpt.PNo = ddlPno.Text;
                cpt.CpName = txtCpname.Text;
                cpt.Remark = txtRemark.Text;
                if (Page.IsValid)
                {
                    int cnt = cpm.InsertInfo(cpt);
                    if (cnt > 0)
                    {
                        //如果添加成功，则跳转到查询页面
                        Response.Redirect("~/PriceManager/CustomerPrice/SelectCustomerPrice.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "添加失败！";
                    }
                }
            }
        }
        else
        {
            CustomerPriceTB cp = new CustomerPriceTB();
            string PNo = ddlPno.Text;
            string remark = txtRemark.Text;
            int cpid =Convert.ToInt32( Request.QueryString["cpid"]);
            if (Page.IsValid)
            {
                int cnt = cpm.UpdateTemp(cpid, PNo, remark);
                if (cnt > 0)
                {
                    //如果修改成功，则跳转到查询页面
                    Response.Redirect("~/PriceManager/CustomerPrice/SelectCustomerPrice.aspx");
                }
                else
                {
                    lblMessage.Text = "修改失败！";
                }
            }
        }
    }
    //自动得到价格模板名称
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCpname.Text = ddlName.SelectedItem.Text + ddlCompany.SelectedItem.Text;
    }
    protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cusid =Convert.ToInt32( ddlName.SelectedValue);
        CustomersTB cs = new CustomersTB();
        cs = cm.GetCusmoerByid(cusid);
        //如果该员工不是业务员，则不能有价格模板
        if (cs.IsCounterman == "False")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该客户不是业务员！')</script>");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/PriceManager/CustomerPrice/SelectCustomerPrice.aspx");
    }
}
