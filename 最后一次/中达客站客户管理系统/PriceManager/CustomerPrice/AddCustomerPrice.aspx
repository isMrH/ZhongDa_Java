<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCustomerPrice.aspx.cs" Inherits="PriceManager_CustomerPrice_AddCustomerPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/AddCustomerPrice.css" rel="stylesheet" type="text/css" />
            <link href="../../CSS/iFram.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style1
        {
            height: 29px;
            width: 398px;
        }
        .style2
        {
            height: 112px;
        }
        .style3
        {
            height: 56px;
            text-align:center;
        }
        .style6
        {
            height: 42px;
        }
    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">客户价格表设置</div>
    <div class="Main">
  
       <div class="Search">
            <asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/t05.png" Width="18px" /><asp:Label ID="Label1" runat="server"
                    Text="设置"></asp:Label>
      <div class="Insert">
            <table class="style1" cellpadding="10" cellspacing="1" bgcolor="#cccccc">
        <tr>
            <td class="style6">
                <asp:Label ID="Label3" runat="server" Text="客户姓名："></asp:Label>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlName" runat="server" Width="184px" AutoPostBack="True" 
                    onselectedindexchanged="ddlName_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblCus" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label4" runat="server" Text="承运公司："></asp:Label>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlCompany" runat="server" Width="184px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlCompany_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblCompany" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label5" runat="server" Text="模板名称："></asp:Label>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlPno" runat="server" Width="185px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlPno" ErrorMessage="模板名称不能为空！" ValidationGroup="验证">*</asp:RequiredFieldValidator>
                <a href="../Excel/<%= ddlPno.Text%>.xls" >查看模板</a>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label6" runat="server" Text="价格模板名称："></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtCpname" runat="server" Width="184px" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtCpname" ErrorMessage="价格模板名称不能为空！" 
                    ValidationGroup="验证">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="备注："></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtRemark" runat="server" Height="75px" TextMode="MultiLine" 
                    Width="269px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
               <asp:ImageButton 
                    ID="imgbtnSubmit" runat="server" 
                    ImageUrl="~/images/queding_03.jpg" onclick="imgbtnSubmit_Click" 
                    ValidationGroup="验证" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/images/fanhui_03.jpg" onclick="ImageButton1_Click" />
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
    </table>
        </div>
        </div>
    </div>
    </form>
    </div>
</body>
</html>
