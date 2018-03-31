using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;

public partial class CarrieCompany_CarrieCompany : System.Web.UI.Page
{
    CarrieCompanyManager CarCom = new CarrieCompanyManager();
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
                if (Request.QueryString["Cid"] != null)
                {
                    int Cid = Convert.ToInt32(Request.QueryString["Cid"]);
                    //获取前页面所传Cid的公司信息
                    CarrieCompanyTB CarrCom = CarCom.GetCompanyByid(Cid);
                    txtCoName.Text = CarrCom.CoName.ToString();
                    txtMan.Text = CarrCom.Clinkman.ToString();
                    txtTel.Text = CarrCom.LinkmanTel.ToString();
                    txtMoney.Text = CarrCom.Cmoney.ToString();
                    txtRemark.Text = CarrCom.Remark.ToString();

                }
            }
        }
    }
    //获取当前文本框的值
    public CarrieCompanyTB Getparm()
    {
        CarrieCompanyTB CCom = new CarrieCompanyTB();
        CCom.CoName = txtCoName.Text.Trim();
        CCom.Clinkman = txtMan.Text.Trim();
        CCom.LinkmanTel = txtTel.Text.Trim();
        CCom.Cmoney =Convert.ToDouble(txtMoney.Text);
        CCom.Remark = txtRemark.Text.Trim();
        return CCom;
    }
    //清空当前文本框内的值
    public void ClearText()
    {
        txtCoName.Text = "";
        txtMan.Text = "";
        txtMoney.Text = "";
        txtRemark.Text = "";
        txtTel.Text = "";
    }
    //返回按钮
    protected void imgbtnFanhui_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/CarrieCompany/SelectCarrieCompany.aspx");
    }
    //确定按钮
    protected void imgbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        //添加操作
        if (Request.QueryString["Cid"] == null )
        {
            int cut = CarCom.InsertCarrieCompany(Getparm());
            if (cut > 0)
            {
                lblMess.Text = "添加成功！";
                ClearText();
            }
        }
        //修改操作
        else
        {
            int Cid = Convert.ToInt32(Request.QueryString["Cid"]);
            int cut = CarCom.UpdateCarrieCompanyByCid(Cid, Getparm());
            if (cut > 0)
            {
                Response.Redirect("~/CarrieCompany/SelectCarrieCompany.aspx");
            }
            else
            {
                lblMess.Text = "修改失败！";
            }
        }
    }
}
