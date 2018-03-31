using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;
public partial class Sent : System.Web.UI.Page 
{
    //谷恒远1-7
    CarrieCompanyManager ccm = new CarrieCompanyManager();
    CustomersManager cm = new CustomersManager();
    SentManager sm = new SentManager();
    AcceptManager am = new AcceptManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usermanager"]==null)
        {
            //跳转登陆页
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                //下拉显示承运公司
                ddlConame.DataSource = ccm.GetAllCarrieCompany();
                ddlConame.DataTextField = "CoName";
                ddlConame.DataValueField = "Cid";
                ddlConame.DataBind();

                //下拉显示客户
                ddlCusName.DataSource = cm.GetAllCustomers();
                ddlCusName.DataTextField = "CusName";
                ddlCusName.DataValueField = "CusID";
                ddlCusName.DataBind();

                //显示查询数据
                if (Request.QueryString["aid"] != null)
                {
                    int aid = Convert.ToInt32(Request.QueryString["aid"]);
                    AcceptTB at = new AcceptTB();
                    at = am.GetAcceptTBByIds(aid);
                    txtNumbers.Text = at.CSid.ToString();
                    ddlConame.Text = at.CID.ToString();
                    ddlCusName.Text = at.CusID.ToString();
                    txtMoney.Text = at.Price.ToString();
                    txtDatetime.Text = at.BeginDate.ToString();
                    txtRemark.Text = at.Remark;
                }
            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImgbtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            if (Request.QueryString["aid"] == null)
            {
                //插入数据
                AcceptTB at = new AcceptTB();
                at.CusID = Convert.ToInt32(ddlCusName.SelectedValue);
                at.CID = Convert.ToInt32(ddlConame.SelectedValue);
                at.CSid = Convert.ToInt64(txtNumbers.Text);
                at.Price = Convert.ToDouble(txtMoney.Text);
                at.BeginDate = Convert.ToDateTime(txtDatetime.Text);
                at.Remark = txtRemark.Text.ToString();

                int count = am.InsertAcceptTB(at);
                if (count > 0)
                {
                    lblMessage.Text = "插入成功！<br>客户ID：" + ddlCusName.SelectedValue + "<br>承运公司ID：" + ddlConame.SelectedValue + "<br>面单号：" + txtNumbers.Text + "<br>金额：" + txtMoney.Text + "<br>起运时间：" + txtDatetime.Text + "<br>备注：" + txtRemark.Text;
                }
                else
                {
                    lblMessage.Text = "添加失败！";
                }
            }
            else
            {
                //修改信息
                AcceptTB at = new AcceptTB();
                at.Aid = Convert.ToInt32(Request.QueryString["aid"]);
                at.CusID = Convert.ToInt32(ddlCusName.SelectedValue);
                at.CID = Convert.ToInt32(ddlConame.SelectedValue);
                at.CSid = Convert.ToInt64(txtNumbers.Text);
                at.Price = Convert.ToDouble(txtMoney.Text);
                at.BeginDate = Convert.ToDateTime(txtDatetime.Text);
                at.Remark = txtRemark.Text.ToString();
                int count = am.UpdateSentTB(at);
                if (count > 0)
                {
                    Response.Redirect("~/AcceptandSent/AcceptShow.aspx");
                }
                else
                {
                    lblMessage.Text = "修改失败！";
                }
            }
        }
    }
    protected void ddlConame1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //跳转查询页面
        Response.Redirect("~/AcceptandSent/AcceptShow.aspx");
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        int count = am.GetAcceptTBById(txtNumbers.Text);
        if (count > 0)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void ImgbtnExit_Click(object sender, ImageClickEventArgs e)
    {
        //跳转首页
        Response.Redirect("~/FootTable/FootInfo.aspx");
    }
}
