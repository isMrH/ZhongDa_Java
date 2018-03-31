using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

public partial class Administrator_DataManager : System.Web.UI.Page
{
    string newName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usermanager"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    private void GetBackFiles()
    {
        string severpath = Server.MapPath("~/backup");
        //获取backup文件夹中的所有文件
        string[] files = System.IO.Directory.GetFiles(severpath);
        for (int i = 0; i < files.Length; i++)
        {
            int loc = 0;
            string file = files[i];
            for (int j = 0; j < file.Length; j++)
            {
                if (file[j].ToString() == "\\")
                {
                    loc = j + 1;
                }
            }
            files[i] = file.Substring(loc, file.Length - loc);
            newName = files[i];
        }
        this.ddlDate.DataSource = files;
        this.ddlDate.DataBind();
    }

    private void beginProgress()
    {
        //根据ProgressBar.htm显示进度条界面
        string templateFileName = Path.Combine(Server.MapPath("."), "ProgressBar.htm");
        StreamReader reader = new StreamReader(@templateFileName, System.Text.Encoding.GetEncoding("GB2312"));
        string html = reader.ReadToEnd();
        reader.Close();
        Response.Write(html);
        Response.Flush();
    }
    private void setProgress(int percent)
    {
        string jsBlock = "<script>SetPorgressBar('" + percent.ToString() + "'); </script>";
        Response.Write(jsBlock);
        Response.Flush();
    }
    private void finishProgress()
    {
        string jsBlock = "<script>SetCompleted();</script>";
        Response.Write(jsBlock);
        Response.Flush();
    }
    protected void imgBtnCopy_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            beginProgress();
            System.Threading.Thread.Sleep(500);
            for (int i = 1; i <= 20; i++)
            {
                setProgress(i);
            }
            System.Threading.Thread.Sleep(500);
            string ConnectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            for (int i = 30; i <= 40; i++)
            {
                setProgress(i);
            }
            SqlConnection myCon = new SqlConnection(ConnectionString);
            System.Threading.Thread.Sleep(500);
            for (int i = 40; i <= 50; i++)
            {
                setProgress(i);
            }
            myCon.Open();
            for (int i = 50; i <= 60; i++)
            {
                setProgress(i);
            }
            string severpath = Server.MapPath("~/backup");
            for (int i = 60; i <= 70; i++)
            {
                setProgress(i);
            }
            //备份数据库的名
            string backName = "\\" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour.ToString() +
            "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + " ZDDB.bak'";
            string SqlIns = "use master;backup database ZDDB to disk='" + severpath + backName;
            for (int i = 70; i <= 80; i++)
            {
                setProgress(i);
            }
            SqlCommand command = new SqlCommand();
            command.CommandText = SqlIns;
            for (int i = 80; i <= 90; i++)
            {
                setProgress(i);
            }
            command.Connection = myCon;
            command.ExecuteNonQuery();
            for (int i = 90; i <= 100; i++)
            {
                setProgress(i);
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('数据备份成功！');</script>");
            //调用获取备份文件的方法
            GetBackFiles();
            lblName.Text = "数据库名称：" + newName;
            lblBack.Text = "数据库备份位置：" + Directory.GetCurrentDirectory() + "\\backup";
        }
        catch (Exception ex)
        {
            throw ex;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('数据备份失败！');</script>");
        }
        finishProgress();
    }
    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {
        if (this.ddlDate.SelectedValue == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请先备份数据库再还原的数据库！');</script>");
        }
        else
        {
            try
            {
                beginProgress();
                System.Threading.Thread.Sleep(500);
                for (int i = 1; i <= 20; i++)
                {
                    setProgress(i);
                }
                System.Threading.Thread.Sleep(500);
                string ConnectionString = ConfigurationManager.ConnectionStrings["str"].ConnectionString;
                for (int i = 30; i <= 40; i++)
                {
                    setProgress(i);
                }
                SqlConnection myCon = new SqlConnection(ConnectionString);
                System.Threading.Thread.Sleep(500);
                for (int i = 40; i <= 50; i++)
                {
                    setProgress(i);
                }
                myCon.Open();
                for (int i = 50; i <= 60; i++)
                {
                    setProgress(i);
                }
                #region 杀掉所有连接RestHomeDB数据库的进程
                string strSQL = "select spid from master..sysprocesses where dbid=db_id( 'ZDDB') ";
                SqlDataAdapter Da = new SqlDataAdapter(strSQL, myCon);
                DataTable spidTable = new DataTable();
                Da.Fill(spidTable);
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.Connection = myCon;
                for (int iRow = 0; iRow < spidTable.Rows.Count; iRow++)
                {
                    Cmd.CommandText = "kill " + spidTable.Rows[iRow][0].ToString();   //强行关闭用户进程 
                    Cmd.ExecuteNonQuery();
                }
                myCon.Close();
                myCon.Dispose();
                #endregion
                SqlConnection myCon1 = new SqlConnection(ConnectionString);
                myCon1.Open();
                string serverpath = Server.MapPath("~/backup");
                //for (int i = 60; i <= 70; i++)
                //{
                //    setProgress(i);
                //}
                string SqlIns = "use master;restore database ZDDB from disk='" + serverpath + "\\" + this.ddlDate.SelectedValue + "'";
                for (int i = 60; i <= 80; i++)
                {
                    setProgress(i);
                }
                SqlCommand command1 = new SqlCommand(SqlIns, myCon1);
                for (int i = 80; i <= 90; i++)
                {
                    setProgress(i);
                }
                command1.ExecuteNonQuery();
                for (int i = 90; i <= 100; i++)
                {
                    setProgress(i);
                }
                command1.Dispose();
                myCon1.Close();
                myCon1.Dispose();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('数据还原成功！');</script>");
                // Session["back"] = "none";
            }

            catch (Exception ex)
            {
                throw ex;
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('数据还原失败！');</script>"); ;
            }
            finishProgress();
            SqlConnection.ClearAllPools();
        }
    }
}
