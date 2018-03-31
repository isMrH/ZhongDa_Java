<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DelGoodsMonTBAdd.aspx.cs" Inherits="DelGoodsMonTB_DelGoodsMonTBAdd" %>

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
            height: 47px;
        }
        .style2
        {
            height: 32px;
        }
        .style3
        {
            height: 123px;
        }
        .style4
        {
            height: 26px;
        }
        .style5
        {
            height: 32px;
            width: 99px;
        }
        .style6
        {
            height: 47px;
            width: 99px;
        }
        .style7
        {
            height: 123px;
            width: 99px;
        }
    </style>
    </head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
      <div class="Title">送货费管理</div>

      <div class="Main">
       <div id="AddoNumber">
           <table  cellpadding="10" cellspacing="1" border="0"  bgcolor="#cccccc"  
               style= "width:610px; height:234px;">
               <tr>
                   <td class="style5">
                       &nbsp;&nbsp;
                       客户：</td>
                    <td class="style2">
                       &nbsp;&nbsp; <asp:DropDownList ID="ddlCustomer" runat="server" Height="20px" Width="214px">
                       </asp:DropDownList>
                   </td>
               </tr>
               <tr>
                   <td class="style6">
                       &nbsp;&nbsp;
                       送货单价：</td>
                   <td class="style1">
                      &nbsp;&nbsp; <asp:TextBox ID="txtprice" runat="server" BorderColor="#D0DEDE" 
                           BorderStyle="Solid" BorderWidth="1px" Height="21px" Width="264px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                           ControlToValidate="txtprice" ErrorMessage="送货价格不能为空" Display="Dynamic"></asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="CompareValidator1" runat="server" 
                           ControlToValidate="txtprice" Display="Dynamic" ErrorMessage="输入的价格必须为数字" 
                           Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                   </td>
               </tr>
               <tr>
                   <td class="style7">
                       &nbsp;&nbsp;
                       备注</td>
                   <td class="style3">
                       &nbsp;&nbsp;<asp:TextBox ID="txtRemar" runat="server" BorderColor="#D0DEDE" 
                           BorderStyle="Solid" BorderWidth="1px" Height="90px" TextMode="MultiLine" 
                           Width="418px"></asp:TextBox>
                   </td>
               </tr>
               
              <tr>
                   <td colspan="2" align="center" class="style4">
                 
                       <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                           </td>
                   
               </tr>
               <tr>
                   <td colspan="2" align="center">
                 
                       <asp:ImageButton ID="TmgBtnExit" runat="server" 
                           ImageUrl="~/images/queding_03.jpg" Height="22px" Width="76px" onclick="TmgBtnExit_Click"  
                           />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:ImageButton ID="ImgBtnSave" runat="server" 
                           ImageUrl="~/images/quxiao_03.jpg" Height="22px" Width="71px" 
                           CausesValidation="False" onclick="ImgBtnSave_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;
                          &nbsp;&nbsp;&nbsp;&nbsp;  
                           </td>
                   
               </tr>
           </table>
          </div>
       
    
    </div>
    </form>
</div>

</body>
</html>
