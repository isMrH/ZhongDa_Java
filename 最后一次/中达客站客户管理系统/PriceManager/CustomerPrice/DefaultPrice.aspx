<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultPrice.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../../CSS/iFram.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
       *
       {
       	 margin :0px auto;
       	 padding:0px;
       }
       .wrapper
       {
       	width:760px;
       	font-size:13px;
       }
       .father
       {
       	margin-top:10px;
       }
    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">

    <div class="Title">文件上传</div>
        <div class="Main">
       <div class="father">
        <asp:Label ID="Label1" runat="server" Text="上传文件："></asp:Label>
        <asp:FileUpload ID="fulFile" runat="server" />
    
           <asp:ImageButton ID="ImageButton1" runat="server" 
               ImageUrl="~/images/shangchuan_03.jpg" onclick="ImageButton1_Click" />
       </div>
       </div>
    </div>
    </form>
    </div>

</body>
</html>
