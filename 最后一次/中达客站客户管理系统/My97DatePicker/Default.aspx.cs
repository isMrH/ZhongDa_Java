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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string message;
        //判断文件是否存在
        if (fulFile.HasFile)
        {
            try
            {
                //指定上传到服务器的路径
                string strPath = Server.MapPath("~/images/");
                //执行上传操作
                fulFile.PostedFile.SaveAs(strPath + fulFile.FileName);

                message = "上传成功！<br/>上传的文件名为：" + fulFile.FileName + "<br>" +
                    "文件大小：" + fulFile.PostedFile.ContentLength + "b<br>" +
                    "文件类型：" + fulFile.PostedFile.ContentType;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
        else
        {
            message = "选中的文件不存在！";
        }
        Label2.Text = message;
    }
}
