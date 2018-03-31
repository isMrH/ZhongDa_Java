<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Price.aspx.cs" Inherits="BackStage_Price" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Price.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
            <div class="Title">价格模板设置</div>

    <div class="Main">
        <div class="Search">
            <asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/ico06.png" Width="18px" /><asp:Label ID="Label1" runat="server"
                    Text="搜索"></asp:Label>
        </div>
        <div class="condition">
            <asp:Label ID="lblPno" runat="server" Text="模板编号:" Font-Size="Small"></asp:Label> 
            <asp:DropDownList ID="ddlPno" runat="server" Width="80px">
            </asp:DropDownList>
            <asp:Label ID="lblDestination" runat="server" Text="目的地:"></asp:Label>
            <asp:DropDownList ID="ddlDrstination" runat="server" Width="80px">
            </asp:DropDownList>
            <asp:Label ID="LblKilo" runat="server" Text="公斤数:"></asp:Label>
            <asp:DropDownList ID="ddlKilo" runat="server" Width="80px">
            </asp:DropDownList>
            <asp:Label ID="lblPrice" runat="server" Text="价格:"></asp:Label>
            <asp:DropDownList ID="ddlPrice" runat="server" Width="80px">
            </asp:DropDownList>
            <asp:ImageButton ID="imgbtnSearch" runat="server" 
                ImageUrl="~/images/chaxun_03.jpg" />
            <asp:ImageButton ID="imgbtnAll" runat="server" 
                ImageUrl="~/images/chaxunsuoyou.jpg" Width="91px" />
        </div>
        <div class="Setup">
            <asp:Image ID="imgExecl" runat="server" ImageUrl="~/images/excel.png" />
            <asp:LinkButton ID="lkbtnExecl" runat="server">导入表格</asp:LinkButton>
        </div>
        <div class="content">
            <asp:GridView ID="GridView1" runat="server" Height="247px" Width="515px">
            </asp:GridView>
        </div>
    </div>
    </form>
    </div>
</body>
</html>
