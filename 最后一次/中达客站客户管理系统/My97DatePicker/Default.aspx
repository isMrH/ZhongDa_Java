<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function CheckFile(file) {
            var filename = file.value;
            filename = filename.toLowerCase().substr(filename.lastIndexOf("."));
            if (filename != ".jpg") {
                alert("只能上传JPG格式的文件！");
                form1.reset();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="请选择日期："></asp:Label>
        <asp:TextBox ID="txtDate" class="Wdate" value="2016-01-04" onFocus="new WdatePicker(this,'%Y-%M-%D %h:%m',true,'default')" runat="server"></asp:TextBox>
    
        <br />
        <asp:Label ID="Label3" runat="server" Text="请选中要上传的文件："></asp:Label>
        <asp:FileUpload ID="fulFile" runat="server" onChange="CheckFile(this)" />

        <asp:Button ID="btnSubmit" runat="server" Text="上传" onclick="btnSubmit_Click" />
    
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
