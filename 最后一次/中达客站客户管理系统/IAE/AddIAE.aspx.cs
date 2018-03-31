using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.BLL;
using ZDDB.Model;

public partial class IAE_AddIAE : System.Web.UI.Page
{
    //客户表
    CustomersManager cm = new CustomersManager();
    //其他收支表
    IAEManagerManager ia = new IAEManagerManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
                //绑定数据
                ddlName.DataSource = cm.GetAllCustomers();
                ddlName.DataTextField = "cusname";
                ddlName.DataValueField = "cusid";
                ddlName.DataBind();
                //如果传过来的值不为空，则为添加操作
                if (Request.QueryString["iaeid"] != null)
                {
                    IAEManagerTB iam = new IAEManagerTB();
                    //根据传过来的id号获取信息
                    iam = ia.GetIAEManagerTBById(Convert.ToInt32(Request.QueryString["iaeid"]));
                    //填充页面信息
                    ddlName.SelectedValue = iam.CusID.ToString();
                    txtDate.Text = iam.IAEDate.ToString();
                    txtIaeName.Text = iam.IAEName.ToString();
                    txtPrice.Text = iam.Price.ToString();
                    if (iam.ISsettle == "是")
                    {
                        rdoYes.Checked = true;
                    }
                    else
                    {
                        rdoNo.Checked = true;
                    }
                    txtRemark.Text = iam.Remark.ToString();
                }
            
        }
    }
    protected void imgbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        //添加
        if (Request.QueryString["iaeid"] == null)
        {
            IAEManagerTB iam=new IAEManagerTB();
            iam.CusID=Convert.ToInt32( ddlName.SelectedValue);
            iam.IAEDate =Convert.ToDateTime( txtDate.Text);
            iam.IAEName = txtIaeName.Text;
            iam.Price = Convert.ToDouble(txtPrice.Text);
            iam.Remark = txtRemark.Text;
            if (rdoYes.Checked == true)
            {
                iam.ISsettle = "1";
            }
            else
            {
                iam.ISsettle = "0";
            }
            int cnt = ia.InsertInfo(iam);
            if (cnt > 0)
            {
                //添加成功跳转到查询页面
                Response.Redirect("~/IAE/SelectIAE.aspx");
            }
            else
            {
                lblMessage.Text = "添加失败！";
            }
        }
        //修改
        else
        {
            IAEManagerTB iam = new IAEManagerTB();
            iam.CusID = Convert.ToInt32(ddlName.SelectedValue);
            iam.IAEDate = Convert.ToDateTime(txtDate.Text);
            iam.IAEName = txtIaeName.Text;
            iam.Price = Convert.ToDouble(txtPrice.Text);
            iam.Remark = txtRemark.Text;
            if (rdoYes.Checked == true)
            {
                iam.ISsettle = "1";
            }
            else
            {
                iam.ISsettle = "0";
            }
            int cnt = ia.UpdateInfo(iam);
            if (cnt > 0)
            {
                //修改成功跳转到查询页面
                Response.Redirect("~/IAE/SelectIAE.aspx");
            }
            else
            {
                lblMessage.Text = "修改失败！";
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/IAE/SelectIAE.aspx");
    }
}
