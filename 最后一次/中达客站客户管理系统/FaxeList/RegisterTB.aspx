<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterTB.aspx.cs" Inherits="FaxeList_RegisterTB" %>

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
             width: 147px;
         }
    
       
    
         .style2
         {
             width: 147px;
             height: 33px;
         }
         .style3
         {
             height: 28px;
         }
         .style4
         {
             height: 33px;
         }
    
       
    
    </style>
    <script language="javascript" type="text/javascript">
        function CheckFile(file) {
            var filename = file.value;
            filename = filename.toLowerCase().substr(filename.lastIndexOf("."));
            if (filename != ".jpg") {
                alert("只能上传JPG格式的文件！");
                form1.reset();
            }
        }
    </script>
    
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title"><b>面单管理设置</b></div>

    <div class="Main">
       <div id="top"> <b>面单购买登记</b></div>
       <div id="AddoNumber">
         
           <table   cellpadding="10" cellspacing="1" border="0"  bgcolor="#cccccc"  
               style= "width:724px; height:256px;" >
               <tr>
                   <td class="style1">
                       &nbsp;&nbsp;&nbsp;
                       承运公司：</td>
                   <td>
                        &nbsp;&nbsp; <asp:DropDownList ID="ddlCarrieCompany" runat="server" 
                            Height="22px"  Width="139px" AppendDataBoundItems="True" 
                            AutoPostBack="True" >
                            <asp:ListItem Value="0">--请选择--</asp:ListItem>
                       </asp:DropDownList>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" 
                            ControlToValidate="ddlCarrieCompany" Display="Dynamic" ErrorMessage="请选择承运公司!" 
                            onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style1">
                       &nbsp;&nbsp;&nbsp;
                       面单起始号：</td>
                   <td>&nbsp;&nbsp;
                       <asp:TextBox ID="txtBeginNo" runat="server" 
                            Height="20px" Width="250px" 
                           BorderColor="#D0DEDE" BorderStyle="Solid" BorderWidth="1px" 
                           AutoPostBack="True"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ControlToValidate="txtBeginNo" ErrorMessage="面单起始号不能为空!" Display="Dynamic"></asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="CompareValidator2" runat="server" 
                           ControlToValidate="txtBeginNo" Display="Dynamic" ErrorMessage="面单的结束号不能为空!" 
                           Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style1">
                       &nbsp;&nbsp;&nbsp;
                       面单结束号：</td>
                   <td>&nbsp;&nbsp;
                       <asp:TextBox ID="txtEndNo" runat="server" Height="20px" Width="250px" 
                           BorderColor="#D0DEDE" BorderStyle="Solid" BorderWidth="1px" 
                           AutoPostBack="True"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                           ControlToValidate="txtEndNo" Display="Dynamic" ErrorMessage="面单结束号不能为空!"></asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="CompareValidator1" runat="server" 
                           ControlToValidate="txtEndNo" Display="Dynamic" ErrorMessage="面单的结束号必须大于面单的起始号!" 
                           Operator="GreaterThan" Type="Double" ControlToCompare="txtBeginNo"></asp:CompareValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style2">
                       &nbsp;&nbsp;&nbsp;
                       购买时间：</td>
                   <td class="style4">&nbsp;&nbsp;
                        <asp:TextBox ID="txtDate" class="Wdate" 
                           onFocus="new WdatePicker(this,'%Y-%M-%D ',true,'default')" runat="server" 
                           Height="20px" Width="250px" BorderStyle="Solid" BorderColor="#D0DEDE" BorderWidth="1" ></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="style1" >
                       &nbsp;&nbsp;&nbsp;&nbsp;备注：</td>
                   <td class="style3">
                        &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtRemark" runat="server" Height="84px" TextMode="MultiLine" 
                           Width="340px" BorderColor="#D0DEDE" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                   </td>
               </tr>
                  <tr>  
                   <td colspan="2" align='center'>
                 
                       <asp:ImageButton ID="TmgBtnExit" runat="server" 
                           ImageUrl="~/images/queding_03.jpg" Height="22px" Width="76px" 
                           onclick="TmgBtnExit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:ImageButton ID="ImgBtnSave" runat="server" 
                           ImageUrl="~/images/quxiao_03.jpg" Height="22px" Width="71px" 
                           CausesValidation="False" onclick="ImgBtnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                          &nbsp;&nbsp;&nbsp;&nbsp;  
                           </td>
               </tr>
               <tr>  
                   <td colspan="2" align='center'>
                       <asp:Label ID="lblmessage" runat="server" ForeColor="#FF3300"></asp:Label>
                           <asp:Label ID="lblok" runat="server" ForeColor="Red" Text="lblok"></asp:Label>
                           </td>
               </tr>
           </table>
         
       </div>
       </div>
    </form>
    </div>
</body>

</html>
