using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.Model;
using ZDDB.BLL;

public partial class FootTable_Info : System.Web.UI.Page
{
    public static int id;
    CustomerPianManager customerpianmanager = new CustomerPianManager();//实例化费用结算
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["cusid"]);
        if (!IsPostBack)
        {
            if (Request.QueryString["cusid"] != null)
            {
                List<CustomerPianTB> p = customerpianmanager.GetAllCustomerPianTBInfo(id);
                Label14.Text = p[0].CPid.ToString();
                lbl1.Text = p[0].CusID.ToString();
                Label4.Text = p[0].OddMon.ToString();
                Label8.Text = p[0].SendMon.ToString();
                Label9.Text = p[0].GiveMon.ToString();
                Label10.Text = p[0].BackMon.ToString();
                Label11.Text = p[0].AccMon.ToString();
                Label12.Text = p[0].OtherMon.ToString();
                Label13.Text = p[0].AllMon.ToString();
                Label5.Text = p[0].ISsettle.ToString();
                Label7.Text = p[0].DateMon.ToString();
                Label6.Text = p[0].Remark.ToString();
            }
        }
    }
    //返回结算
    protected void ImgbtnExit_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/FootTable/FootInfo.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        CustomerPianTB cp = new CustomerPianTB();
        cp.CPid = Convert.ToInt32(Label14.Text);
        cp.CusID = Convert.ToInt32(lbl1.Text);
        cp.OddMon = Convert.ToDouble(Label4.Text);
        cp.SendMon = Convert.ToDouble(Label8.Text);
        cp.GiveMon = Convert.ToDouble(Label9.Text);
        cp.BackMon = Convert.ToDouble(Label10.Text);
        cp.AccMon = Convert.ToDouble(Label11.Text);
        cp.OtherMon = Convert.ToDouble(Label12.Text);
        cp.AllMon = Convert.ToDouble(Label13.Text);
        cp.ISsettle = "true";
        cp.DateMon = Convert.ToDateTime(Label7.Text);
        cp.Remark = "面单费已结！";
        int count = customerpianmanager.UpdateCustomerPianTBById(cp);
        if (count > 0)
        {
            lblinfos.Text = "结算成功！";
            List<CustomerPianTB> p = customerpianmanager.GetAllCustomerPianTBInfo(id);
            Label14.Text = p[0].CPid.ToString();
            lbl1.Text = p[0].CusID.ToString();
            Label4.Text = p[0].OddMon.ToString();
            Label8.Text = p[0].SendMon.ToString();
            Label9.Text = p[0].GiveMon.ToString();
            Label10.Text = p[0].BackMon.ToString();
            Label11.Text = p[0].AccMon.ToString();
            Label12.Text = p[0].OtherMon.ToString();
            Label13.Text = p[0].AllMon.ToString();
            Label5.Text = p[0].ISsettle.ToString();
            Label7.Text = p[0].DateMon.ToString();
            Label6.Text = p[0].Remark.ToString();
        }
    }
}
