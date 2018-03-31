<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>中达货站客户结算管理系统</title>
    <link href="CSS/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="father">
<form id="form1" runat="server">

        <div id="login">
           
                
             <div id="login1">
                <div class="name1">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Name.png" 
                        Width="25px" /> </div>
                <div class="name2">
                    <asp:TextBox ID="txtName" runat="server" Width="119px" BorderStyle="Solid" 
                        Height="20px" BorderColor="#6699FF"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="*账号不能为空" 
                        ValidationGroup="login" Font-Size="10pt" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                </div>
                <div class="pwd">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Pwd.png" 
                        Width="25px" />
                </div>
                <div class="pwd1">
                    <asp:TextBox ID="txtPwd" runat="server" Width="119px" BorderStyle="Solid" 
                        Height="20px" BorderColor="#6699FF" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPwd" ErrorMessage="*密码不能为空" ValidationGroup="login" 
                        Font-Size="10pt" ForeColor="#CC3300">*</asp:RequiredFieldValidator></div>
                

                <div id="btn">
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/images/denglu_03.jpg" onclick="ImageButton1_Click" />
                 </div>
                    
             </div>
             <div class="text">
                 <asp:Label ID="lblMessage" runat="server" Font-Size="10pt" ForeColor="Red"></asp:Label>
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Size="10pt" 
                     ForeColor="#CC3300" ValidationGroup="login" 
                     DisplayMode="SingleParagraph" Height="31px" />
             </div>
       </div>
</form>
</div>
</body>
</html>
