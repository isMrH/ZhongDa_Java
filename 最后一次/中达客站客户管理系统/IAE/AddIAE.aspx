<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddIAE.aspx.cs" Inherits="IAE_AddIAE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/AddIAE.css" rel="stylesheet" type="text/css" />
        <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
       
      
        
        .style2
        {
            width: 241px;
            height: 82px;
        }
         .style3
         {
         	text-align:center;}
       
      .Insert tr
      {
      	background-color:White;}
        
        .style4
        {
            width: 83px;
            height: 82px;
        }
        .style5
        {
            width: 83px;
            height: 39px;
        }
        .style6
        {
            width: 241px;
            height: 39px;
        }
        
    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">其他收支设置</div>
    <div class="Main">
       <div class="Search">
            <asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/t05.png" Width="18px" /><asp:Label ID="Label1" runat="server"
                    Text="设置"></asp:Label>
       </div>
       <div class="Insert">
       
           <table  cellpadding="10" cellspacing="1" border="0"  bgcolor="#cccccc" 
               width="500px" >
               <tr>
                   <td class="style5">
                       <asp:Label ID="Label2" runat="server" Text="客户姓名："></asp:Label>
                   </td>
                   <td class="style6">
                       <asp:DropDownList ID="ddlName" runat="server" Width="150px">
                       </asp:DropDownList>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ControlToValidate="ddlName" ErrorMessage="客户姓名不能为空！" ValidationGroup="验证">*</asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style5">
                       <asp:Label ID="Label3" runat="server" Text="收支日期："></asp:Label>
                   </td>
                   <td class="style6">
                       <asp:TextBox ID="txtDate" runat="server"  class="Wdate" value="2016-1-1" 
                           onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" Width="150px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ControlToValidate="txtDate" Display="Dynamic" ErrorMessage="日期不能为空！" 
                           ValidationGroup="验证">*</asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style5">
                       <asp:Label ID="Label4" runat="server" Text="费用名称："></asp:Label>
                   </td>
                   <td class="style6">
                       <asp:TextBox ID="txtIaeName" runat="server" Width="150px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ControlToValidate="txtIaeName" ErrorMessage="费用名称不能为空！" 
                           ValidationGroup="验证">*</asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style5">
                       <asp:Label ID="Label5" runat="server" Text="金额："></asp:Label>
                   </td>
                   <td class="style6">
                       <asp:TextBox ID="txtPrice" runat="server" Width="150px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                           ControlToValidate="txtPrice" ErrorMessage="价格不能为空！" Display="Dynamic" 
                           ValidationGroup="验证">*</asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="CompareValidator2" runat="server" 
                           ControlToValidate="txtPrice" ErrorMessage="金额只能输入数字" Type="Double" 
                           Display="Dynamic" Operator="DataTypeCheck" ValidationGroup="验证">*</asp:CompareValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style5">
                       <asp:Label ID="Label6" runat="server" Text="是否结算："></asp:Label>
                   </td>
                   <td class="style6">
                       <asp:RadioButton ID="rdoYes" runat="server" Checked="True" GroupName="IsSet" 
                           Text="是" />
                       <asp:RadioButton ID="rdoNo" runat="server" GroupName="IsSet" Text="否" />
                   </td>
               </tr>
               <tr>
                   <td class="style4">
                       <asp:Label ID="Label7" runat="server" Text="备注："></asp:Label>
                   </td>
                   <td class="style2">
                       <asp:TextBox ID="txtRemark" runat="server" Height="68px" TextMode="MultiLine" 
                           Width="213px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="style3" colspan="2">
                       <asp:ImageButton ID="imgbtnSubmit" runat="server" 
                           ImageUrl="~/images/queding_03.jpg" onclick="imgbtnSubmit_Click" 
                           ValidationGroup="验证" />
                       <asp:Label ID="lblMessage" runat="server"></asp:Label>
                       <asp:ImageButton ID="ImageButton1" runat="server" 
                           ImageUrl="~/images/fanhui_03.jpg" onclick="ImageButton1_Click" />
                       <br />
                       <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                   </td>
               </tr>
           </table>
       
       </div>
    </div>
    </form>
    </div>
</body>
</html>
