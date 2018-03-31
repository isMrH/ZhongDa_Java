<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seek.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>中达货站客户结算管理系统</title>
    <link href="CSS/Login.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Seek.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="father">
        <div class="center">
        <div class="aa">
            <div>
                <asp:Label ID="lblName" runat="server" Text="请输入您的账号："></asp:Label>
                <asp:TextBox ID="txtUser" runat="server" Width="161px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUser"
                    Display="Dynamic" ErrorMessage="账号不能为空" Font-Size="11pt" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                <asp:Button ID="btnNext" runat="server" BackColor="#6699FF" BorderStyle="None" Height="28px"
                    OnClick="bntNext_Click" Text="下一步" Width="65px" />
            </div>
            <asp:Label ID="lblMessage" runat="server" Font-Size="10pt" ForeColor="Red"></asp:Label>
            <br />
            <div>
                <asp:Label ID="lblQuestion" runat="server" Text="您的验证问题为："></asp:Label>
                <asp:Label ID="lblValidate" runat="server"></asp:Label>
            </div>
            <br />
            <div>
                <asp:Label ID="lblKey" runat="server" Text="请输入您的答案："></asp:Label>
                <asp:TextBox ID="txtKey" runat="server" Width="161px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtKey"
                    Display="Dynamic" ErrorMessage="答案不能为空" Font-Size="11pt" ValidationGroup="Update">*</asp:RequiredFieldValidator>
                <asp:Button ID="BtnNext1" runat="server" BackColor="#6699FF" BorderStyle="None" Height="28px"
                    OnClick="BtnNext1_Click" Text="下一步" Width="65px" />
            </div>
            <br />
            <div>
                <asp:Label ID="lblPwd" runat="server" Text="请输入新的密码："></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" Width="162px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="密码不能为空"
                    Font-Size="11pt" ControlToValidate="txtPassword" ValidationGroup="Update">*</asp:RequiredFieldValidator>
            </div>
            <br />
            <div>
                <asp:Label ID="lblPwd1" runat="server" Text="请重新确认密码："></asp:Label>
                <asp:TextBox ID="txtPassword1" runat="server" Width="161px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtPassword1" Display="Dynamic" ErrorMessage="两次密码输入不一致" Font-Size="11pt"
                    ValidationGroup="Update">*</asp:CompareValidator>
            </div>
            <br />
            <div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="SingleParagraph"
                    ValidationGroup="Update" Font-Size="10pt" />
            </div>
            
            <br />
            </div>
            
            <div class="bottom">
            <div class="btnUpdate">
                <asp:Button ID="btnUpdate" runat="server" Text="确认修改" Width="65px" BackColor="#6699FF"
                    BorderStyle="None" ValidationGroup="Update" Height="28px" OnClick="btnUpdate_Click" />
            </div>
            <div class="btnBack">
                <asp:Button ID="btnBack" runat="server" BackColor="#6699FF" BorderStyle="None" OnClick="btnBack_Click"
                    Text="返回登陆" Height="28px" Width="65px" />
            </div>
            </div>
           
    </div>
    </div>
    </form>
</body>
</html>
