<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultTemp.aspx.cs" Inherits="PriceManager_CarriageMoney_DefaultTemp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="../../CSS/iFram.css" rel="stylesheet" type="text/css" />

    <style type="text/css">

    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    
        <asp:Label ID="Label1" runat="server" Text="上传文件："></asp:Label>
        <asp:FileUpload ID="fulFile" runat="server" />
    
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/images/shangchuan_03.jpg" onclick="ImageButton1_Click" />
    
        <br />

    </form>
        
    </div>
</body>
</html>
