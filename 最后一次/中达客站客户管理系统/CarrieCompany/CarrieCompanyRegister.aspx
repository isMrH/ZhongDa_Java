<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarrieCompanyRegister.aspx.cs" Inherits="CarrieCompany_CarrieCompany" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/ListPrice.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
    <style type="text/css">


 *{margin:0px auto;padding:0px}
  tr{ background-color:White; font-size:12px;}
        .style2
        {
            width: 59%;
            height: 272px;
        }
        .style3
        {
            padding-left: 10px;
            width: 88px;
        }
        .style5
        {
            height: 117px;
        }
        .style6
        {
           text-align:center;
        }
        .style7
        {
            padding-left: 10px;
            height: 34px;
            width: 88px;
        }
        .style8
        {
            height: 34px;
        }
  </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">承运公司管理</div>
    <div>
    <div class="Search">
            
        <div class="Main">
              
            <table id="ti" class="style2"  bgcolor="#cccccc" border="0" cellpadding="10" cellspacing="1">
                <tr>
                    <td class="style7">
                        <asp:Label ID="Label1" runat="server" Text="公司名称："></asp:Label>
                    </td>
                    <td class="style8">
                       &nbsp;<asp:TextBox ID="txtCoName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtCoName" ErrorMessage="公司名称不能为空！" ValidationGroup="验证"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <asp:Label ID="Label2" runat="server" Text="联系人："></asp:Label>
                    </td>
                    <td class="style8">
                        &nbsp;<asp:TextBox ID="txtMan" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtMan" ErrorMessage="联系人不能为空！" ValidationGroup="验证"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <asp:Label ID="Label3" runat="server" Text="联系电话："></asp:Label>
                    </td>
                    <td class="style8">
                         &nbsp;<asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtTel" Display="Dynamic" ErrorMessage="联系电话不能为空！" 
                            ValidationGroup="验证"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtTel" Display="Dynamic" ErrorMessage="电话格式不正确！" 
                            ValidationExpression="(^1[3578]\d{9}$)" ValidationGroup="验证"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <asp:Label ID="Label4" runat="server" Text="面单费："></asp:Label>
                    </td>
                    <td class="style8">
                         &nbsp;<asp:TextBox ID="txtMoney" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="txtMoney" Display="Dynamic" ErrorMessage="面单费必须为数字！" 
                            Operator="DataTypeCheck" Type="Double" ValidationGroup="验证"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtMoney" Display="Dynamic" ErrorMessage="面单费不能为空！" 
                            ValidationGroup="验证"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label5" runat="server" Text="备注："></asp:Label>
                    </td>
                    <td class="style5">
                         &nbsp;<asp:TextBox ID="txtRemark" runat="server" Height="77px" TextMode="MultiLine" 
                            Width="221px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style6" colspan="2">
                        <asp:ImageButton ID="imgbtnSubmit" runat="server" 
                            ImageUrl="~/images/queding_03.jpg" onclick="imgbtnSubmit_Click" 
                            ValidationGroup="验证" />
                        <asp:ImageButton ID="imgbtnFanhui" runat="server" 
                            ImageUrl="~/images/fanhui_03.jpg" onclick="imgbtnFanhui_Click" />
                        <br />
                        <asp:Label ID="lblMess" runat="server" ForeColor="#CC3300"></asp:Label>
                    </td>
                </tr>
            </table>
              
            </div>
    
    
    </div>
    </form>
    </div>
</body>
</html>
