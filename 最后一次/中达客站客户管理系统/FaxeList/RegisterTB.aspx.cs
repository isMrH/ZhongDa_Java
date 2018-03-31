using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;

public partial class FaxeList_RegisterTB : System.Web.UI.Page
{
    CarrieCompanyManager ComMan = new CarrieCompanyManager();
    RegisterManager regMan = new RegisterManager();
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
                //填充DropDownlist控件
                this.ddlCarrieCompany.DataSource = ComMan.GetAllCarrieCompany();
                this.ddlCarrieCompany.DataTextField = "CoName";
                this.ddlCarrieCompany.DataValueField = "Cid";
                ddlCarrieCompany.DataBind();
                //传过来的id不为空执行删除功能
                if (Request.QueryString["Rid"] != null)
                {
                    txtDate.Visible = true;
                    string Rid = Request.QueryString["Rid"].ToString();
                    RegisterTB Regg = new RegisterTB();
                    Regg = regMan.GetAllTBByRid(Rid);
                    ddlCarrieCompany.SelectedValue = Regg.Cid.ToString();
                    txtBeginNo.Text = Regg.BeginNo.ToString();
                    txtEndNo.Text = Regg.EndNo.ToString();
                    txtDate.Text = Regg.Buydate.ToString();
                    txtRemark.Text = Regg.Remark;
                }
                //清空控件
                else
                {
                    txtDate.Visible = false;
                    txtBeginNo.Text = "";
                    txtEndNo.Text = "";
                    txtDate.Text = "";
                    txtRemark.Text = "";
                }

                lblmessage.Visible = false;
                lblok.Visible = false;
            }
        }
    }

    protected void TmgBtnExit_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            string cid = ddlCarrieCompany.SelectedValue.ToString();
            string b = txtBeginNo.Text.Trim();
            string end = txtEndNo.Text.Trim();

            int cntt = regMan.number(cid, b, end);
            if (cntt > 0)
            {
                lblok.Visible = true;
                lblok.Text = "该公司的面单号已将购买!!!";
                return;
            }
            //实例化实体类
            string time = DateTime.Now.ToString();
            RegisterTB reg = new RegisterTB();
            reg.Cid = Convert.ToInt32(ddlCarrieCompany.SelectedValue);
            reg.BeginNo = Convert.ToInt64(txtBeginNo.Text.Trim());
            reg.EndNo = Convert.ToInt64(txtEndNo.Text.Trim());
            reg.Buydate = Convert.ToDateTime(time);
            reg.Remark = txtRemark.Text;
            //添加房间信息添加成功清空控件
            if (Request.QueryString["Rid"] == null)
            {
                if (Page.IsValid == true)
                {

                    int cnt = regMan.InsertRegister(reg);
                    if (cnt > 0)
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = "添加成功！";

                        txtBeginNo.Text = "";
                        txtEndNo.Text = "";
                        txtDate.Text = "";
                        txtRemark.Text = "";
                    }
                }

            }
            //修改功能
            else
            {
                string Rid = Request.QueryString["Rid"].ToString();
                reg.Rid = Convert.ToInt32(Rid);
                int cnt = regMan.UpdateRegisterTB(reg);
                txtDate.Visible = true;
                string times = txtDate.Text.Trim();
                reg.Buydate = Convert.ToDateTime(times);
                if (cnt > 0)
                {

                    lblmessage.Visible = true;

                    lblmessage.Text = "修改成功！";

                }
            }
        }
    }

    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        //跳转详情页面
        Response.Redirect("~/FaxeList/GviRegisterTB.aspx");
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ddlCarrieCompany.SelectedValue == "0")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
}
