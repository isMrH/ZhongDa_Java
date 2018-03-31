using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDDB.Model;

public partial class HomePage : System.Web.UI.Page
{
    public static UserInfoTB um;
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
                um = Session["UserManager"] as UserInfoTB;
                lblName.Text = um.LoginId;
            }
        }
    }
}
