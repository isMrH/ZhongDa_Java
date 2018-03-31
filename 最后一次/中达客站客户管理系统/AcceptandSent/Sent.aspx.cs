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
    DisNoteManager dm = new DisNoteManager();
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["Usermanager"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if(!IsPostBack)
                {
                    if (Request.QueryString["sid"] != null)
                    {   
                        //显示信息
                        int sid = Convert.ToInt32(Request.QueryString["sid"]);
                        SentTB st = new SentTB();
                        st = sm.GetSentTBById(sid);
                        txtNumbers.Text = st.CSid.ToString();
                        lblCom.Text = st.Cid.ToString();
                        lblCus.Text = st.CusID.ToString();
                        txtMoney.Text = st.Price.ToString();
                        txtDatetime.Text = st.BeginDate.ToString();
                        txtWeight.Text = st.Kilo.ToString();
                        txtRemark.Text = st.Remark;
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
            if (Request.QueryString["sid"] == null)
            {
                //获取客户、公司
                DisNoteTB nt = new DisNoteTB();
                nt = dm.GetDisNoteTBByIds(txtNumbers.Text.ToString());
                lblCus.Text = nt.Customer.CusName.ToString();
                lblCom.Text = nt.CarrieCompany.CoName.ToString();
                //插入数据
                SentTB st = new SentTB();
                st.CusID = nt.CusID;
                st.CSid = Convert.ToInt64(txtNumbers.Text);
                st.Cid = nt.Cid;
                st.Kilo = Convert.ToDouble(txtWeight.Text);
                st.Price = Convert.ToDouble(txtMoney.Text);
                st.BeginDate = Convert.ToDateTime(txtDatetime.Text);
                st.Remark = txtRemark.Text.ToString();

                int count = sm.InsertSentTB(st);
                if (count > 0)
                {
                    lblMessage.Text = "插入成功！<br>客户：" + lblCus.Text + "<br>承运公司：" + lblCom.Text + "<br>面单号：" + txtNumbers.Text + "<br>重量：" + txtWeight.Text + "<br>金额：" + txtMoney.Text + "<br>起运时间：" + txtDatetime.Text + "<br>备注：" + txtRemark.Text;
                }
                else
                {
                    lblMessage.Text = "添加失败！";
                }
            }
            else
            {
                //修改信息
                SentTB st = new SentTB();
                st.Sid = Convert.ToInt32(Request.QueryString["sid"]);
                st.CusID = Convert.ToInt32(lblCus.Text);
                st.Cid = Convert.ToInt32(lblCom.Text);
                st.CSid = Convert.ToInt64(txtNumbers.Text);
                st.Kilo = Convert.ToDouble(txtWeight.Text);
                st.Price = Convert.ToDouble(txtMoney.Text);
                st.BeginDate = Convert.ToDateTime(txtDatetime.Text);
                st.Remark = txtRemark.Text;
                int count = sm.UpdateSentTB(st);
                if (count > 0)
                {
                    Response.Redirect("~/AcceptandSent/SentShow.aspx");
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
    protected void txtNumbers_TextChanged(object sender, EventArgs e)
    {
            //输入新的面单号，获取客户、公司
            long number = Convert.ToInt64(txtNumbers.Text);
            int cnt = dm.GetNoteIsDis(number);
            if (cnt <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该件没有分配信息！')</script>");

            }
            else
            {
                DisNoteTB nt = new DisNoteTB();
                nt = dm.GetDisNoteTBByIds(txtNumbers.Text.ToString());
                lblCus.Text = nt.Customer.CusName;
                lblCom.Text = nt.CarrieCompany.CoName;
            }
    }
    protected void txtWeight_TextChanged(object sender, EventArgs e)
    {
         //根据重量自动获取金额
         txtMoney.Text = (3 + Convert.ToInt32(txtWeight.Text) * 2).ToString();
    }
    protected void ImgbtnExit_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/FootTable/FootInfo.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //跳转查询页面
        Response.Redirect("~/AcceptandSent/SentShow.aspx");
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
    }
    protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
    {
        int count = sm.GetSentTBById(txtNumbers.Text);
        if (count > 0)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
}
