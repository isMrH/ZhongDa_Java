using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string message;
        string PriceTemplet = "Sheet1";

        //判断所选的文件是否存在
        if (fulFile.HasFile)
        {
            try
            {
                //指定上传到服务器的路径
                string strPath = Server.MapPath("~/PriceManager/Excel/");
                //执行上传操作
                fulFile.PostedFile.SaveAs(strPath + fulFile.FileName);
                //显示上传后的文件信息
                message = "上传成功！<br>上传的文件名为：" + fulFile.FileName;
                message = ExeclHelper.LoadDataFromExcel(strPath, fulFile.FileName, PriceTemplet);

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
        else
        {
            message = "您没有选择任何文件！";
        }

        Response.Redirect("~/PriceManager/CustomerPrice/Price.aspx");
        
    }
}
