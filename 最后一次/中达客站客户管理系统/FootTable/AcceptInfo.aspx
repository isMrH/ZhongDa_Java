<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AcceptInfo.aspx.cs" Inherits="FootTable_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <link href="../CSS/Info.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
    <style type="text/css">

        .style2
        {
        }
        .style3
        {
            width: 311px;
        }
        .style4
        {
            width: 146px;
        }
        .style5
        {
            width: 146px;
            height: 38px;
        }
        .style6
        {
            width: 311px;
            height: 38px;
        }
    </style>
</head>
<body>
    <div id="Wapper">
    <form id="form1" runat="server">

         <div class="Title">
             <asp:Label ID="Label1" runat="server" Text="详细信息"></asp:Label></div>
         <div class="main">
             <table class="InfoTable">
                 <tr>
                     <td align="right" class="style4">
                         客户ID：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label2" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         客户姓名：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label3" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         金额：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label4" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         是否已结算：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label5" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style5">
                         费用日期：</td>
                     <td align="left" class="style6">
                         <asp:Label ID="Label7" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style5">
                         备注：</td>
                     <td align="left" class="style6">
                         <asp:Label ID="Label6" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td class="style2" colspan="2">
                    <asp:ImageButton ID="ImgbtnExit" runat="server" 
                            ImageUrl="~/images/fanhui_03.jpg" onclick="ImgbtnExit_Click"/>
                        </td>
                 </tr>
             </table>
         </div>
    </form>
        </div>
</body>
</html>
