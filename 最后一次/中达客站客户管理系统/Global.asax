<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码
        //在出现未处理的错误时运行的代码
        Exception objErr = Server.GetLastError().GetBaseException();
        string error = string.Empty;
        string errortime = string.Empty;
        string erroraddr = string.Empty;
        string errorinfo = string.Empty;
        string errorsource = string.Empty;
        string errortrace = string.Empty;

        error += "发生时间:" + System.DateTime.Now.ToString() + "<br>";
        errortime = "发生时间:" + System.DateTime.Now.ToString();

        error += "发生异常页: " + Request.Url.ToString() + "<br>";
        erroraddr = "发生异常页: " + Request.Url.ToString();

        error += "异常信息: " + objErr.Message + "<br>";
        errorinfo = "异常信息: " + objErr.Message;
        errorsource = "错误源:" + objErr.Source;
        errortrace = "堆栈信息:" + objErr.StackTrace;
        error += "--------------------------------------<br>";
        Server.ClearError();
        Application["error"] = error;
        //独占方式，因为文件只能由一个进程写入.
        System.IO.StreamWriter writer = null;
        try
        {
            lock (this)
            {
                // 写入日志
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string path = string.Empty;
                string filename = DateTime.Now.Day.ToString() + ".txt";
                path = Server.MapPath("~/error/") + year + "/" + month;
                //如果目录不存在则创建
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                System.IO.FileInfo file = new System.IO.FileInfo(path + "/" + filename);
                //if (!file.Exists)
                //    file.Create();
                //file.Open(System.IO.FileMode.Append);   


                writer = new System.IO.StreamWriter(file.FullName, true);//文件不存在就创建,true表示追加
                writer.WriteLine("用户IP:" + Request.UserHostAddress);

                writer.WriteLine(errortime);
                writer.WriteLine(erroraddr);
                writer.WriteLine(errorinfo);
                writer.WriteLine(errorsource);
                writer.WriteLine(errortrace);
                writer.WriteLine("-----------------------");
                //writer.Close();
            }
        }
        finally
        {
            if (writer != null)
                writer.Close();

        }


        //获取Exception 
        Exception ex = this.Context.Server.GetLastError();
        //处理Exception 

        //清除当前的输出 
        this.Context.Response.Clear();
        //转向执行你希望展示给用户看的错误提示页面样子（此时网址依然是出错的那个页面，但是展示的内容就完全是你自己指定的页面了） 
        Context.Response.Redirect("~/error/error.html");
    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }
       
</script>
