<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisNoteTB.aspx.cs" Inherits="FaxeList_DisNoteTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/ListPrice.css" rel="stylesheet" type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <style type="text/css">
        
       
        .style1
        {
            height: 28px;
        }
        .style2
        {
            height: 34px;
        }
        .style3
        {
            height: 31px;
        }
        table
        {
        	margin-left:40px;
        }
      
        
        .style4
        {
            height: 24px;
        }
      
        
    </style>

    </head>
<body>
<div id="Wapper">
    <form  runat="server">
    <div class="Title">面单管理设置</div>
<div class="Main">
    
       <div id="top"> <b>面单分配记录表</b></div>
           <table cellpadding="0" cellspacing="1" border="0"  bgcolor="#cccccc" style="height: 203px; width: 674px;"  
              >
               <tr>
                   <td class="style1">
                       &nbsp;&nbsp;&nbsp;&nbsp;
                       客户：</td>
                   <td>
                       &nbsp;&nbsp;  
                       <asp:DropDownList ID="ddlCustomer" runat="server" Height="22px" 
                           Width="170px" AppendDataBoundItems="True" AutoPostBack="True">
                           <asp:ListItem Value="0">--请选择--</asp:ListItem>
                       </asp:DropDownList>
                       <asp:CustomValidator ID="CustomValidator1" runat="server" 
                           ControlToValidate="ddlCustomer" Display="Dynamic" ErrorMessage="请选择客户！" 
                           onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style4">
                       &nbsp;&nbsp;&nbsp;
                       承运公司：</td>
                   <td class="style4">
                    &nbsp;&nbsp;   
                       <asp:DropDownList ID="ddlCompany" runat="server" Height="22px" 
                           Width="170px" 
                            AppendDataBoundItems="True" AutoPostBack="True"
                          >
                           <asp:ListItem Value="0">--请选择--</asp:ListItem>
                       </asp:DropDownList>
                   &nbsp;<asp:CustomValidator ID="CustomValidator2" runat="server" 
                           ControlToValidate="ddlCompany" Display="Dynamic" ErrorMessage="请选择承运公司！" 
                           onservervalidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style1">
                       &nbsp;&nbsp;&nbsp;
                       面单起始号：</td>
                   <td>
                   &nbsp;&nbsp;     <asp:TextBox ID="txtBeginNo"  
                            runat="server" 
                           Height="20px" Width="250px" BorderStyle="Solid" BorderColor="#D0DEDE" 
                           BorderWidth="1" AutoPostBack="True" 
                           ontextchanged="txtBeginNo_TextChanged" ></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ControlToValidate="txtBeginNo" ErrorMessage="面单起始号不能为空！" Display="Dynamic"></asp:RequiredFieldValidator>
                       
                       <asp:CompareValidator ID="CompareValidator2" runat="server" 
                           ControlToValidate="txtBeginNo" Display="Dynamic" ErrorMessage="面单号必须位数字！" 
                           Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                       
                   </td>
               </tr>
               <tr>
                   <td class="style1">
                       &nbsp;&nbsp;&nbsp;
                       面单结束号：</td>
                   <td>
                   &nbsp;&nbsp;     
                       <asp:TextBox ID="txtEndNo" 
                          runat="server" 
                           Height="20px" Width="250px" BorderStyle="Solid" BorderColor="#D0DEDE" 
                           BorderWidth="1" AutoPostBack="True" ontextchanged="txtEndNo_TextChanged1" ></asp:TextBox>
                       
                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ControlToValidate="txtEndNo" Display="Dynamic" ErrorMessage="面单结束号不能为空！"></asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="CompareValidator1" runat="server" 
                           ControlToValidate="txtEndNo" Display="Dynamic" ErrorMessage="面单的结束号必须大于面单起始号！" 
                           Operator="GreaterThanEqual" Type="Double" ControlToCompare="txtBeginNo"></asp:CompareValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style2">
                       &nbsp;&nbsp;&nbsp;
                       分配时间：</td>
                   <td class="style2">
                  &nbsp;&nbsp;     <asp:TextBox ID="txtDate" class="Wdate" 
                           onFocus="new WdatePicker(this,'%Y-%M-%D ',true,'default')" runat="server" 
                           Height="20px" Width="250px" BorderStyle="Solid" BorderColor="#D0DEDE" 
                           BorderWidth="1" ></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="style3">
                       &nbsp;&nbsp;&nbsp;
                       金额（元）：</td>
                   <td class="style3">
                 &nbsp;&nbsp;     
                       <asp:TextBox ID="txtmoney" runat="server"  Height="22px" 
                           Width="250px" BorderColor="#D0DEDE" BorderStyle="Solid" BorderWidth="1px" 
                           Enabled="False" ></asp:TextBox>
                   &nbsp;
                   </td>
               </tr>
               <tr>
                   <td class="style1">
                       &nbsp;&nbsp;&nbsp;
                       是否结算：</td>
                   <td align="left">   
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton 
                           ID="rdoYes" runat="server" GroupName="rdo" Text="是" />
                       &nbsp;<asp:RadioButton ID="rdoNo" runat="server" GroupName="rdo" 
                           Text="否" Checked="True" />
                   </td>
               </tr>
               <tr>
                   <td class="style1">
                       &nbsp;&nbsp;&nbsp;
                       备注：</td>
                   <td class="style4">
                    &nbsp;&nbsp;   <asp:TextBox ID="txtRemark" runat="server" Height="108px" TextMode="MultiLine" 
                           Width="388px"></asp:TextBox>
                   </td>
               </tr>
              
               <tr>
                   <td colspan="2" align='center' class="style3">
                 
                       <asp:ImageButton ID="TmgBtnExit" runat="server" 
                           ImageUrl="~/images/queding_03.jpg" Height="22px" Width="76px" onclick="TmgBtnExit_Click" 
                           />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:ImageButton ID="ImgBtnSave" runat="server" 
                           ImageUrl="~/images/quxiao_03.jpg" Height="22px" Width="71px" 
                           CausesValidation="False" onclick="ImgBtnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                          &nbsp;&nbsp;&nbsp;&nbsp;  
                           </td>
                 
               </tr>
                 <tr>
                   <td colspan="2" align='center' class="style5">
                       <asp:Label ID="lblmessage" runat="server" Text="lblmessage" ForeColor="Red"></asp:Label>
                       &nbsp;&nbsp;&nbsp;
                       <asp:Label ID="lblerror" runat="server" ForeColor="#FF3300" Text="lblerror"></asp:Label>
                       </td>
                 
               </tr>
           </table>
       
 </div>
    </form>
    </div>
</body>
</html>
