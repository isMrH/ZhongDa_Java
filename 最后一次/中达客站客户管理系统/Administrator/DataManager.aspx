<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataManager.aspx.cs" Inherits="Administrator_DataManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Admin.css" rel="stylesheet" type="text/css" />


</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title"> 数据库备份还原</div>
    <div class="Main">

 
        <div class="Gd">
            <br />
            <asp:Panel ID="Panel6" runat="server" Width="690px" 
                Height="163px">
               <asp:Label ID="lblName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblBack" runat="server"></asp:Label>
        <br />
        数据库备份：<asp:ImageButton ID="imgBtnCopy" runat="server" 
            ImageUrl="~/Images/备份按钮.jpg" onclick="imgBtnCopy_Click" />
        <br />
        <br />
        数据还原：<asp:DropDownList ID="ddlDate" runat="server" Width="150px" >
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="imgBtnReset" runat="server" 
            ImageUrl="~/Images/还原按钮.jpg" onclick="imgBtnReset_Click"/>
            </asp:Panel>
            </div>
            </div>
    </form>
    </div>
</body>
</html>
