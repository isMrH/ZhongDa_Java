<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员注册</title>
        <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />

    <link href="../CSS/Registers.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style5
        {
        }
        .style6
        {
            width: 503px;
        }
        .style7
        {
            width: 187px;
            height: 24px;
        }
        .style8
        {
            width: 503px;
            height: 24px;
        }
        .style10
        {
            height: 19px;
        }
    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">管理员注册</div>
    <div class="Main">

            <table class="table">
                <tr>
                    <td class="style5">
                        <i>*</i> 用户名：</td>
                    <td class="style6">
        <asp:TextBox ID="txtUserName" runat="server" class="inputbox"></asp:TextBox>                  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="请输入用户名！" ControlToValidate="txtUserName" 
                ValidationGroup="group1" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="style10">
            <asp:Label ID="lblMes" runat="server" ForeColor="Red"></asp:Label>    
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <i>*</i> 密码：</td>
                    <td class="style6">
        <asp:TextBox ID="txtPwd" runat="server" class="inputbox" TextMode="Password"></asp:TextBox>                  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="请确认电话号码！" ControlToValidate="txtPwd" 
                ValidationGroup="group1"></asp:RequiredFieldValidator>                  

        
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <i>*</i> 确认密码：</td>
                    <td class="style6">
        <asp:TextBox ID="txtRePwd" runat="server" class="inputbox" TextMode="Password"></asp:TextBox>                  
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="txtPwd" ControlToValidate="txtRePwd" 
                ErrorMessage="两次密码输入不同！" ValidationGroup="group1" Display="Dynamic"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="请输入密码！" ControlToValidate="txtRePwd" Display="Dynamic" 
                ValidationGroup="group1"></asp:RequiredFieldValidator>

        
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <i>*</i>电话号码：</td>
                    <td class="style6">
        <asp:TextBox ID="txtTel" runat="server" class="inputbox"></asp:TextBox>                  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ErrorMessage="请输入电话号码！" ControlToValidate="txtTel" Display="Dynamic" 
                ValidationGroup="group1"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="txtTel" ErrorMessage="电话号码格式错误！" 
                ValidationExpression="(^1[3579]\d{9}$)" ValidationGroup="group1"></asp:RegularExpressionValidator>

        
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        <i>*</i> E-mail：</td>
                    <td class="style8">
        <asp:TextBox ID="txtEmail" runat="server" class="inputbox"></asp:TextBox>                  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ErrorMessage="请输入E-mail！" ControlToValidate="txtEmail" Display="Dynamic" 
                ValidationGroup="group1"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtEmail" ErrorMessage="邮箱格式错误！" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="group1"></asp:RegularExpressionValidator>

                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <i>*</i>密保问题：</td>
                    <td class="style6">
        <asp:TextBox ID="txtQuestion" runat="server" class="inputbox"></asp:TextBox>                  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ErrorMessage="请输入密保问题！" ControlToValidate="txtQuestion" Display="Dynamic" 
                ValidationGroup="group1"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <i>*</i>密保问题答案：</td>
                    <td class="style6">
        <asp:TextBox ID="txtKey" runat="server" class="inputbox"></asp:TextBox>                  

            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ErrorMessage="请输入密保问题答案！" ControlToValidate="txtKey" Display="Dynamic" 
                ValidationGroup="group1"></asp:RequiredFieldValidator>

        
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                                                备注：</td>
                    <td class="style6">
        <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" 
            class="inputbox" Height="60px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style5" align="center" colspan="2">
            <asp:ImageButton ID="imgbtnadd" runat="server" 
                ImageUrl="~/images/queding_03.jpg" onclick="imgbtnadd_Click" 
                ValidationGroup="group1" />
            <asp:ImageButton ID="imgbtnexit" runat="server" 
                ImageUrl="~/images/fanhui_03.jpg" onclick="imgbtnexit_Click" />
                    </td>
                </tr>
            </table>

        <div id="infoUserName" class="box_info">
        </div>
    </div>
    </form>
    </div>
</body>
</html>
