<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateOrEditCustomer.aspx.cs" Inherits="Customers_UpdateOrEditCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/ListPrice.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style4
        {
            height: 56px;
        }
        .style5
        {
            height: 43px;
        }
    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
        <div class="Title">客户管理</div>
        <div class="Main">
     
                <table id="ti" bgcolor="#cccccc" border="0" cellpadding="10" cellspacing="1" 
                    style="width:495px; height:156px;">
                    
                    <tr>
                        <td class="style5" >
                            &nbsp;&nbsp;&nbsp;&nbsp; 客户姓名：</td>
                        <td class="style5">
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txtCusName" runat="server"  BorderColor="#D0DEDE" 
                                BorderStyle="Solid" BorderWidth="1px" Height="22px" Width="147px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtCusName" ErrorMessage="客户姓名不得为空！" 
                                ValidationGroup="验证"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            &nbsp;&nbsp;&nbsp;&nbsp; 联系电话：</td>
                        <td class="style5">
                            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTel" runat="server" BorderColor="#D0DEDE" 
                                BorderStyle="Solid" BorderWidth="1px" Height="22px" Width="147px"></asp:TextBox><asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="联系电话不得为空！" ControlToValidate="txtTel" Display="Dynamic" 
                                ValidationGroup="验证"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtTel" Display="Dynamic" ErrorMessage="电话格式不正确！" 
                                ValidationExpression="(^1[3578]\d{9}$)" ValidationGroup="验证"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td class="style5">
                            &nbsp;&nbsp;&nbsp;&nbsp; 是否为业务员：                    <td class="style5">
                            &nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="rdoYes" runat="server" Checked="True" 
                                GroupName="IsCounterman" Text="是" />
                            <asp:RadioButton ID="rdoNo" runat="server" GroupName="IsCounterman" Text="否" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp; 备注：                        <td>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txtRemark" runat="server" BorderColor="#D0DEDE" 
                                BorderStyle="Solid" BorderWidth="1px" Height="108px" TextMode="MultiLine" 
                                Width="345px" Font-Size="Small"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="style4">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImgBtnQd" runat="server" 
                                ImageUrl="~/images/queding_03.jpg" onclick="ImgBtnQd_Click" 
                                ValidationGroup="验证" />
                            <asp:ImageButton ID="imgbtnFanhui" runat="server" 
                                ImageUrl="~/images/fanhui_03.jpg" onclick="imgbtnFanhui_Click" />
                            <br />
                            <asp:Label ID="lblMess" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </tr>
                </table>

    
    </div>
    </form>
    </div>
</body>
</html>
