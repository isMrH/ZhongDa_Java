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

public partial class DelGoodsMonTB_DelGoodsMonTBAdd : System.Web.UI.Page
{
    //实例化数据访问层
    CustomersManager CusMan = new CustomersManager();
    DelGoodsMonManager delMon = new DelGoodsMonManager();
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
                //窗体加载标签不显示
                lblMessage.Visible = false;

                //填充DropDownlist控件客户
                this.ddlCustomer.DataSource = CusMan.GetAllCustomers();
                this.ddlCustomer.DataTextField = "CusName";
                this.ddlCustomer.DataValueField = "CusID";
                ddlCustomer.DataBind();

                if (Request.QueryString["DelID"] == null)
                {
                    txtprice.Text = "";
                    txtRemar.Text = "";
                }
                //窗体加载传值
                if (Request.QueryString["DelID"] != null)
                {
                    int del = Convert.ToInt32(Request.QueryString["DelID"]);
                    DelGoodMon dels = delMon.GetAllDelGoodsInfoByID(del);
                    ddlCustomer.SelectedValue = dels.CusID;
                    txtprice.Text = dels.DelUnitPrice.ToString();
                    txtRemar.Text = dels.Remark;

                }

            }
        }
    }

    
    protected void TmgBtnExit_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {//实例化类
            DelGoodMon delm = new DelGoodMon();
            delm.CusID = ddlCustomer.SelectedValue;
            delm.DelUnitPrice = Convert.ToInt32(txtprice.Text);
            delm.Remark = txtRemar.Text;


            //添加功能
            if (Request.QueryString["DelID"] == null)
            {
                int cnt = delMon.InsertDelMon(delm);
                if (cnt > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "添加成功！";
                }
            }
            if (Request.QueryString["DelID"] != null)
            {
                delm.DelID = Convert.ToInt32(Request.QueryString["DelID"]);
                int cnt = delMon.UpdateDel(delm);

                if (cnt > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "修改成功！";
                }
            }

        }

         
            
    }
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        //跳转到信息详情页面
        Response.Redirect("~/DelGoodsMonTB/GVDelGoodsMonTB.aspx");
    }
}
