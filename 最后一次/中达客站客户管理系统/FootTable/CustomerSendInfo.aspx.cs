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
    FootTableManager Ft = new FootTableManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //显示送件费信息
            if (Request.QueryString["cusid"] != null)
            {
                int cusid = Convert.ToInt32(Request.QueryString["cusid"]);

                FootTableTB FTT = Ft.GetSelectCustomerSendTBid(cusid);
                Label2.Text = FTT.Cusid.ToString();
                Label3.Text = FTT.CName.ToString();
                Label4.Text = FTT.Price.ToString();
                if (FTT.Foot == false)
                {
                    Label5.Text = "否";
                }
                else
                {
                    Label5.Text = "是";
                }
                Label7.Text = FTT.Time.ToString();
                Label6.Text = FTT.Remark.ToString();
            }
        }
    }
    //返回结算
    protected void ImgbtnExit_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/FootTable/FootInfo.aspx");
    }
}
