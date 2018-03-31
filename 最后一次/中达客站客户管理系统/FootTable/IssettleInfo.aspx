<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IssettleInfo.aspx.cs" Inherits="FootTable_Info" %>

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
    <form id="form1" runat="server">
    <div class="father">
         <div class="Title">
             <asp:Label ID="Label1" runat="server" Text="核实结算信息"></asp:Label></div>
         <div class="main">
             <table class="InfoTable">
                 <tr>
                     <td align="right" class="style4">
                         编号：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label14" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         客户ID：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="lbl1" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         面单费用：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label4" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         发件费用：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label8" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         送件费用：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label9" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         收到附件返利：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label10" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         派发到附件费：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label11" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         其他费用：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label12" runat="server"></asp:Label>
                     </td>
                 </tr>
                 <tr>
                     <td align="right" class="style4">
                         总计：</td>
                     <td align="left" class="style3">
                         <asp:Label ID="Label13" runat="server"></asp:Label>
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
                         <asp:ImageButton ID="ImageButton1" runat="server" 
                             ImageUrl="~/images/queding_03.jpg" onclick="ImageButton1_Click" />
&nbsp;&nbsp;
                    <asp:ImageButton ID="ImgbtnExit" runat="server" 
                            ImageUrl="~/images/fanhui_03.jpg" onclick="ImgbtnExit_Click"/>
                        </td>
                 </tr>
                 <tr>
                     <td class="style2" colspan="2">
                         <asp:Label ID="lblinfos" runat="server"></asp:Label>
                        </td>
                 </tr>
             </table>
         </div>
    </div>
    </form>
</body>
</html>
