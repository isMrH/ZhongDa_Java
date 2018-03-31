using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;

public partial class FaxeList_DisNoteTB : System.Web.UI.Page
{
    //实例化数据访问层
    CarrieCompanyManager ComMan = new CarrieCompanyManager();
    RegisterManager regMan = new RegisterManager();
    CustomersManager CusMan = new CustomersManager();
    DisNoteManager DIsNtMan = new DisNoteManager();
    CarrieCompanyManager ccm = new CarrieCompanyManager();
    CustomerSentManager csm = new CustomerSentManager();
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

                //填充DropDownlist控件承运公司
                this.ddlCompany.DataSource = ComMan.GetAllCarrieCompany();
                this.ddlCompany.DataTextField = "CoName";
                this.ddlCompany.DataValueField = "Cid";
                ddlCompany.DataBind();

                //控件窗体加载不显示
                lblmessage.Visible = false;
                lblerror.Visible = false;

                //判断页面跳转传过来是否有Nid
                if (Request.QueryString["Nid"] == null)
                {
                    if (Request.QueryString["rid"] != null)
                    {
                        txtBeginNo.Text = Request.QueryString["rid"];
                        txtEndNo.Text = Request.QueryString["rid"];
                        RegisterTB rt = new RegisterTB();
                        rt = regMan.GetAllRegisterTBByRid(Convert.ToInt64(Request.QueryString["rid"]));
                        ddlCompany.SelectedValue = rt.Cid.ToString();
                        CarrieCompanyTB cct = new CarrieCompanyTB();
                        cct = ccm.GetCompanyByid(Convert.ToInt32(ddlCompany.SelectedValue));
                        txtmoney.Text = cct.Cmoney.ToString();
                    }
                    else
                    {
                        txtDate.Visible = false;
                        //清空所有的控件
                        txtBeginNo.Text = "";
                        txtEndNo.Text = "";
                        txtmoney.Text = "";
                        txtDate.Text = "";
                        txtRemark.Text = "";
                    }
                }
                else
                {
                    //接受页面穿的值
                    int Nid = Convert.ToInt32(Request.QueryString["Nid"].ToString());

                    //实例化实体类
                    DisNoteTB disno = new DisNoteTB();
                    //调用方法查询记录
                    disno = DIsNtMan.GetByNidDisNoteTB(Nid);
                    ddlCustomer.SelectedValue = disno.CusID.ToString();
                    ddlCompany.SelectedValue = disno.Cid.ToString();
                    txtBeginNo.Text = disno.BeginNo.ToString();
                    txtEndNo.Text = disno.EndNo.ToString();
                    txtDate.Text = disno.Dtime.ToString();
                    txtmoney.Text = disno.Sum.ToString();
                    if (disno.IsSet == "是")
                    {
                        rdoNo.Checked = true;
                    }
                    if (disno.IsSet == "否")
                    {
                        rdoNo.Checked = true;
                    }
                    txtRemark.Text = disno.Remark;
                }

            }
        }
    }
    //页面跳转
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        //跳转到信息详情页面
        Response.Redirect("~/FaxeList/ListPrice.aspx");
    }
    protected void TmgBtnExit_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            string kcid = ddlCustomer.SelectedValue;
            string ccid = ddlCompany.SelectedValue;
            string b = txtBeginNo.Text.Trim();
            string ee = txtEndNo.Text.Trim();
            int cuunt = DIsNtMan.numbers(kcid, ccid, b, ee);
            if (cuunt > 0)
            {
                lblerror.Visible = true;
                lblerror.Text = "该面单号已经被分配过！！！";
                return;
            }


            //if (ddlCompany.SelectedValue == "0" || ddlCustomer.SelectedValue == "0")
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择承运公司或客户！！！')</script>");
            //    return;
            //}
            //实例化实体类
            string time = DateTime.Now.ToString();
            DisNoteTB disnote = new DisNoteTB();
            disnote.CusID = Convert.ToInt32(ddlCustomer.SelectedValue);
            disnote.Cid = Convert.ToInt32(ddlCompany.SelectedValue);
            disnote.BeginNo = Convert.ToInt64(txtBeginNo.Text);
            disnote.EndNo = Convert.ToInt64(txtEndNo.Text);
            disnote.Dtime = Convert.ToDateTime(time);
            int cid = Convert.ToInt32(ddlCompany.SelectedValue);
            object obj = ComMan.GetCarrieCompanyMon(cid);
            int cnt = Convert.ToInt32(obj);

            long Begin = Convert.ToInt64(txtBeginNo.Text);

            long End = Convert.ToInt64(txtEndNo.Text);

            long sums = (End - Begin + 1) * cnt;
            disnote.Sum = sums;
            int iss = 0;
            if (rdoNo.Checked == true)
            {
                iss = 0;
            }
            else if (rdoYes.Checked == true)
            {
                iss = 1;
            }
            else
            {
                iss = 0;
            }
            disnote.IsSet = iss.ToString();
            disnote.Remark = txtRemark.Text;
            disnote.Nid = Convert.ToInt32(Request.QueryString["Nid"]);
            //添加的方法

            if (Request.QueryString["Nid"] == null)
            {
                int cnnt = DIsNtMan.InsertDisNoteTB(disnote);
                if (cnnt > 0)
                {
                    if (Request.QueryString["rid"] != null)
                    {
                        //修改发件表里的数据
                        int cusid = Convert.ToInt32(ddlCustomer.SelectedValue);
                        int comid = Convert.ToInt32(ddlCompany.SelectedValue);
                        double price = Convert.ToDouble(txtmoney.Text);
                        long rid = Convert.ToInt64(txtBeginNo.Text);
                        int res = csm.UpdateWu(cusid, comid, price, rid);
                        if (res > 0)
                        {
                            Response.Redirect("~/PriceManager/CarriageMoney/CustomerSent.aspx");
                        }
                        else
                        {
                            lblmessage.Text = "重新分配失败！";
                        }
                    }
                    //添加成功后清空控件
                    else
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = "增加成功!!!!";
                        txtBeginNo.Text = "";
                        txtEndNo.Text = "";
                        txtmoney.Text = "";
                        txtDate.Text = "";
                        txtRemark.Text = "";
                    }
                }
            }

            ///修改的方法
            if (Request.QueryString["Nid"] != null)
            {
                txtDate.Visible = true;
                string times = txtDate.Text.Trim();
                disnote.Dtime = Convert.ToDateTime(times);

                int cnnnt = DIsNtMan.UpdateDisNoteTB(disnote);

                if (cnnnt > 0)
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "修改成功!!!";
                }
            }

        }

    }
    //点击事件

    protected void txtEndNo_TextChanged1(object sender, EventArgs e)
    {
           try
            {


                //面单结束号的验证
                string end = txtEndNo.Text.Trim();
                int cnnt = regMan.GetAllend(end);
                if (cnnt <= 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该面单号不属于本公司！！！')</script>");
                    return;
                }


                int cid = Convert.ToInt32(ddlCompany.SelectedValue);
                object obj = ComMan.GetCarrieCompanyMon(cid);
                int cnt = Convert.ToInt32(obj);

                long Begin = Convert.ToInt64(txtBeginNo.Text);

                long End = Convert.ToInt64(txtEndNo.Text);
                long sums = (End - Begin + 1) * cnt;

                txtmoney.Text = sums.ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alter('输入值的格式不正确！')</script>");
                return;
            }

        
       
      


    }


    // Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已经存在该成员的分配记录！！！')</script>");

    //面单起始号的验证
    protected void txtBeginNo_TextChanged(object sender, EventArgs e)
    {

       
        string begin = txtBeginNo.Text.Trim();
      
            int cnt = regMan.GetAllbegin(begin);
            if (cnt <= 0)
            {
                //错误输入提示
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该面单号不属于本公司！！！')</script>");
            }

        
     

    }



    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ddlCustomer.SelectedValue == "0")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ddlCompany.SelectedValue=="0")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
}

