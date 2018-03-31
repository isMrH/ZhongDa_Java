<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Operation.aspx.cs" Inherits="Administrator_Operation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Admin.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 87px;
        }
        .style2
        {
            width: 87px;
            height: 25px;
        }
        .style3
        {
            height: 25px;
        }
    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
   <div class="Title">个人信息管理</div>
    <div class="Main">
        <div class="Table">
            <table style="width: 484px; height: 331px;" border="0px">
    <tr>
        <td class="style1">
            登陆账号：</td>
        <td>
            <asp:Label ID="lblid" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style1">
            密码：</td>
        <td>
            <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtpwd" Display="Dynamic" ErrorMessage="密码不得为空!"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            手机号码：</td>
        <td>
            <asp:TextBox ID="txttel" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txttel" Display="Dynamic" ErrorMessage="手机号码不得为空!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="txttel" Display="Dynamic" ErrorMessage="手机号码格式不正确!" 
                ValidationExpression="(^1[3579]\d{9}$)"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Email：</td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email不得为空!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email格式不正确!" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            密保问题：</td>
        <td>
            <asp:TextBox ID="txtmq" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="txtmq" Display="Dynamic" ErrorMessage="密保问题不得为空!"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style2">
            密保答案：</td>
        <td class="style3">
            <asp:TextBox ID="txtmw" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="txtmw" Display="Dynamic" ErrorMessage="密保答案不得为空!"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            备&nbsp;&nbsp;&nbsp; 注：</td>
        <td>
            <asp:TextBox ID="txtremark" runat="server" Height="68px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="char">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:ImageButton ID="imgbtnsave" runat="server" 
                ImageUrl="~/images/queding_03.jpg" onclick="imgbtnsave_Click" 
                style="height: 20px" />
        </td>
    </tr>
     <tr>
        <td colspan="2">
            <asp:Label ID="lblMes" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    </table>
        </div>
    
    </div>
    </form>
    </div>
</body>
</html>
