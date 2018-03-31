<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCustomerSent.aspx.cs" Inherits="PriceManager_CarriageMoney_AddCustomerSent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/AddCustomerSent.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/iFram.css" rel="stylesheet" type="text/css" />

    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 69%;
            height: 340px;
        }
        .style5
        {
            height: 55px;
            text-align:center;
        }
        .style7
        {
            width: 114px;
            height: 28px;
        }
        .style8
        {
            height: 28px;
            width: 391px;
            text-align:left;
        }
        .style9
        {
            width: 114px;
            height: 27px;
        }
        .style10
        {
            height: 27px;
            width: 391px;
        }
    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
            <div class="Title">客户发件信息设置</div>

    <div class="Main">
       <div class="Search">
            <asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/t05.png" Width="18px" /><asp:Label ID="Label1" runat="server"
                    Text="设置"></asp:Label>
       </div>
       <div class="Insert">
           
           <table class="style1"  cellpadding="10" cellspacing="1" bgcolor="#cccccc">
               <tr>
                   <td class="style7">
                       <asp:Label ID="Label2" runat="server" Text="面单号："></asp:Label>
                   </td>
                   <td class="style8">
                       <asp:TextBox ID="txtRid" runat="server" Width="173px" AutoPostBack="True" 
                           ontextchanged="txtRid_TextChanged"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ControlToValidate="txtRid" ErrorMessage="面单号不能为空！" ValidationGroup="验证">*</asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style7">
                       <asp:Label ID="Label3" runat="server" Text="客户姓名："></asp:Label>
                   </td>
                   <td class="style8">
                       <asp:DropDownList ID="ddlName" runat="server" Width="175px">
                       </asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <td class="style7">
                       <asp:Label ID="Label4" runat="server" Text="承运公司："></asp:Label>
                   </td>
                   <td class="style8">
                       <asp:DropDownList ID="ddlCompany" runat="server" Width="175px" 
                           AutoPostBack="True">
                       </asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <td class="style7">
                       <asp:Label ID="Label5" runat="server" Text="目的地："></asp:Label>
                   </td>
                   <td class="style8">
                       <asp:TextBox ID="txtDes" runat="server" Width="173px" 
                           ontextchanged="txtDes_TextChanged"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ControlToValidate="txtDes" ErrorMessage="目的地不能为空！" ValidationGroup="验证">*</asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style7">
                       <asp:Label ID="Label6" runat="server" Text="公斤数："></asp:Label>
                   </td>
                   <td class="style8">
                       <asp:TextBox ID="txtKilo" runat="server" Width="173px" AutoPostBack="True" 
                           ontextchanged="txtKilo_TextChanged"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ControlToValidate="txtKilo" ErrorMessage="公斤数不能为空！" ValidationGroup="验证">*</asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="CompareValidator1" runat="server" 
                           ControlToValidate="txtKilo" ErrorMessage="只能输入数字！" Type="Double" 
                           Display="Dynamic" Operator="DataTypeCheck" ValidationGroup="验证">*</asp:CompareValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style7">
                       <asp:Label ID="Label7" runat="server" Text="运费："></asp:Label>
                   </td>
                   <td class="style8">
                       <asp:TextBox ID="txtPrice" runat="server" Width="173px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                           ControlToValidate="txtPrice" ErrorMessage="运费不能为空！" ValidationGroup="验证">*</asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style7">
                       <asp:Label ID="Label8" runat="server" Text="揽件时间："></asp:Label>
                   </td>
                   <td class="style8">
                       <asp:TextBox ID="txtDatetime" runat="server" class="Wdate" value="2016-1-1" 
                           onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" Width="173px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="style7">
                       <asp:Label ID="Label9" runat="server" Text="是否结算："></asp:Label>
                   </td>
                   <td class="style8">
                       <asp:RadioButton ID="rdoYes" runat="server" Checked="True" Text="是" 
                           GroupName="IsSet" />
                       <asp:RadioButton ID="rdoNo" runat="server" Text="否" GroupName="IsSet" />
                   </td>
               </tr>
               <tr>
                   <td class="style9">
                       <asp:Label ID="Label10" runat="server" Text="备注："></asp:Label>
                   </td>
                   <td class="style10">
                       <asp:TextBox ID="txtRemark" runat="server" Height="69px" TextMode="MultiLine" 
                           Width="292px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="style5" colspan="2">
                       <asp:ImageButton ID="imgbtnSubmit" runat="server" 
                           ImageUrl="~/images/queding_03.jpg" onclick="imgbtnSubmit_Click" 
                           ValidationGroup="验证" />
                       <asp:Label ID="lblMessage" runat="server"></asp:Label>
                       <asp:ImageButton ID="ImageButton1" runat="server" 
                           ImageUrl="~/images/fanhui_03.jpg" onclick="ImageButton1_Click" />
                       <br />
                       <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="25px" />
                   </td>
               </tr>
           </table>
           
       </div>
    </div>
    </form>
    </div>
</body>
</html>
