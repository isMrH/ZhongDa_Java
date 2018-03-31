<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerSendTBAdd.aspx.cs" Inherits="DelGoodsMonTB_CustomerSendTBAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/ListPrice.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
   
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 137px;
        }
        .style3
        {
            width: 137px;
            height: 27px;
        }
        .style4
        {
            height: 27px;
        }
    </style>
</head>
<body>
<div id="Wapper">    
<form id="form1" runat="server">
<div class="Title">送货费管理</div>
    <div id="Main">

       <div id="AddoNumber">
       
           <table class="style1"  cellpadding="10" cellspacing="1" border="0"  
               bgcolor="#cccccc"  style= "width:711px; height:246px;">
               <tr>
                   <td class="style2">
                       &nbsp;&nbsp;
                       客户：</td>
                   <td>
                       &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlCustomer" runat="server" Height="20px" Width="244px" 
                          >
                       </asp:DropDownList>
                   &nbsp;</td>
               </tr>
               <tr>
                   <td class="style2">
                       &nbsp;&nbsp;
                       派送的个数：</td>
                   <td>
                      &nbsp;&nbsp;  <asp:TextBox ID="txtcount" runat="server"  Height="20px" 
                           Width="250px" BorderStyle="Solid" BorderColor="#D0DEDE" BorderWidth="1" 
                           AutoPostBack="True" ontextchanged="txtcount_TextChanged"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ControlToValidate="txtcount" Display="Dynamic" ErrorMessage="派件的个数不能为空！"></asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" 
                           ErrorMessage="派件的个数必须为数值！" Operator="DataTypeCheck" Type="Integer" 
                           ControlToValidate="txtcount"></asp:CompareValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style2">
                       &nbsp;&nbsp;
                       派送的邮费：</td>
                   <td>
                      &nbsp;&nbsp;  <asp:TextBox ID="txtmoney" runat="server"  Height="20px" 
                           Width="250px" BorderStyle="Solid" BorderColor="#D0DEDE" BorderWidth="1" 
                           Enabled="False"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="style3">
                       &nbsp;&nbsp;
                       书否结算：</td>
                   <td class="style4">
                       
                       &nbsp;&nbsp; <asp:RadioButton ID="rdoYes" runat="server" GroupName="yesorno" Text="是" /> &nbsp;&nbsp;
                       <asp:RadioButton ID="rdoNo" runat="server" GroupName="yesorno" Text="否" 
                           Checked="True" />
                       
               </tr>
               <tr>
                   <td class="style2">
                       &nbsp;&nbsp;
                       派件年月：</td>
                   <td>
                        &nbsp; &nbsp;<asp:TextBox ID="txtDate" class="Wdate" 
                           onFocus="new WdatePicker(this,'%Y-%M-%D ',true,'default')" runat="server" 
                           Height="20px" Width="250px" BorderStyle="Solid" BorderColor="#D0DEDE" BorderWidth="1" ></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                           ControlToValidate="txtDate" ErrorMessage="派件年月不能为空！" Display="Dynamic"></asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="CompareValidator3" runat="server" 
                           ControlToValidate="txtDate" Display="Dynamic" ErrorMessage="输入的必须是日期！" 
                           Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                               </td>
               </tr>
               <tr>
                   <td class="style2">
                       &nbsp;&nbsp;
                       备注：</td>
                   <td>
                       &nbsp;&nbsp; <asp:TextBox ID="txtRemark" runat="server" Height="150px" TextMode="MultiLine" 
                           Width="409px"   BorderStyle="Solid" BorderColor="#D0DEDE" BorderWidth="1"></asp:TextBox>
                   </td>
               </tr>
             
               <tr>
                   <td colspan="2" align="center">
                   
                       <asp:ImageButton ID="TmgBtnExit" runat="server" 
                           ImageUrl="~/images/queding_03.jpg" Height="22px" Width="76px" onclick="TmgBtnExit_Click" 
                           />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:ImageButton ID="ImgBtnSave" runat="server" 
                           ImageUrl="~/images/quxiao_03.jpg" Height="22px" Width="71px" 
                           CausesValidation="False" onclick="ImgBtnSave_Click"  />&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;</td>
                   
               </tr>
               <tr>
                   <td colspan="2" align="center">
                       <asp:Label ID="lblmessage" runat="server" Text="Label" ForeColor="#FF3300"></asp:Label>
                   </td>
                 
               </tr>
           </table>
       
       </div>
    
    </div>
    </form>
</div>

</body>
</html>
