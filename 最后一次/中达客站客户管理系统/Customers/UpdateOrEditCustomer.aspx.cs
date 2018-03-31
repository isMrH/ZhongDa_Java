using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;

public partial class Customers_UpdateOrEditCustomer : System.Web.UI.Page
{
    //客户
    CustomersManager cus = new CustomersManager();
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
                //判断是否为编辑
                if (Request.QueryString["Cusid"] != null)
                {
                    //接受前页面传过来的Cusid值
                    int Cusid = Convert.ToInt32(Request.QueryString["Cusid"]);
                    //获取客户信息，传输到当前页面的文本框中
                    CustomersTB customer = cus.GetCusmoerByid(Cusid);
                    txtCusName.Text = customer.CusName.ToString();
                    txtTel.Text = customer.CusTel.ToString();
                    if (customer.IsCounterman == "是")
                    {
                        rdoYes.Checked = true;
                    }
                    else
                    {
                        rdoNo.Checked = true;
                    }
                    txtRemark.Text = customer.Remark.ToString();
                }
            }
        }
    }
 
    //获取当前文本框的值
    public CustomersTB GetText()
    {
        CustomersTB Cuss = new CustomersTB();
        Cuss.CusName = txtCusName.Text.Trim();
        Cuss.CusTel = txtTel.Text.Trim();
        if (rdoYes.Checked == true)
        {
            Cuss.IsCounterman = "1";
        }
        else
        {
            Cuss.IsCounterman = "0";
        }
        Cuss.Remark = txtRemark.Text.Trim();
        return Cuss;
    }
    //清空当前页所有文本框的值
    public void ClearText()
    {
        txtCusName.Text = "";
        txtRemark.Text = "";
        txtTel.Text = "";
    }
    //确定按钮
    protected void ImgBtnQd_Click(object sender, ImageClickEventArgs e)
    {
        //添加操作
        if (Request.QueryString["Cusid"] == null)
        {
            int cut = cus.InsertCustomer(GetText());
            if (cut > 0)//判断添加是否完成
            {
                lblMess.Text = "添加成功！";
                ClearText();
            }
            else
            {
                lblMess.Text = "添加失败！";
            }
        }
        //修改操作
        else
        {
            int Cusid = Convert.ToInt32(Request.QueryString["Cusid"]);
            int cut = cus.UpdateCustomerByCusId(Cusid, GetText());
            if (cut > 0)//判断修改是否完成
            {
                //修改成功后，跳转到查询页面
                Response.Redirect("~/Customers/SelectCustomers.aspx");
            }
            else
            {
                lblMess.Text = "修改失败！";
            }
        }
    }
    //返回按钮
    protected void imgbtnFanhui_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Customers/SelectCustomers.aspx");
    }
}
