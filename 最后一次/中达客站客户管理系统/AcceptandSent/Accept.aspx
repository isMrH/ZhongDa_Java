<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Accept.aspx.cs" Inherits="Sent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Sent.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 144px;
        }
        .style3
        {
            width: 144px;
            height: 39px;
        }
        .style4
        {
            width: 80px;
            height: 39px;
        }
        .style5
        {
            width: 80px;
        }
        .style6
        {
            width: 80px;
            height: 56px;
        }
        .style7
        {
            width: 144px;
            height: 56px;
        }
        .style8
        {
            width: 80px;
            height: 48px;
        }
        .style9
        {
            width: 144px;
            height: 48px;
        }
        .style10
        {
            width: 80px;
            height: 43px;
        }
        .style11
        {
            width: 144px;
            height: 43px;
        }
        .style12
        {
            height: 31px;
        }
    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">派收到付件管理录入</div>

    <div class="Main">
        <div>
            <table id="center" style="width: 65%;" bgcolor="#cccccc" border="0" 
                cellpadding="10" cellspacing="1">
                <tr>
                    <td class="style4">
                        &nbsp;&nbsp;
                        客户：</td>
                    <td class="style3">
                        &nbsp;
                        <asp:DropDownList ID="ddlCusName" runat="server" Width="130px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;&nbsp;
                        承运公司：</td>
                    <td class="style3">
                        &nbsp;
                        <asp:DropDownList ID="ddlConame" runat="server" Width="130px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                       &nbsp;&nbsp;
                       录入单号：</td>
                    <td class="style9">
                        &nbsp;
                        <asp:TextBox ID="txtNumbers" runat="server" Width="135px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtNumbers" ErrorMessage="录入单号不能为空" 
                            ValidationGroup="sent" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="单号已存在" 
                            ControlToValidate="txtNumbers" Display="Dynamic" 
                            onservervalidate="CustomValidator1_ServerValidate" ValidationGroup="sent"></asp:CustomValidator>
                    </td>
                </tr>
                   <tr>
                    <td class="style6">
                    &nbsp;&nbsp;
                    金额：</td>
                    <td class="style7">
                        &nbsp;
                        <asp:TextBox ID="txtMoney" runat="server" Width="135px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="金额不能为空" ControlToValidate="txtMoney" Display="Dynamic" 
                            ValidationGroup="sent"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToValidate="txtMoney" Display="Dynamic" ErrorMessage="金额只能是数字" 
                            Operator="DataTypeCheck" Type="Double" ValidationGroup="sent"></asp:CompareValidator>
                    </td>
                </tr>
                   <tr>
                    <td class="style10">
                    &nbsp;&nbsp;
                    起运日期：</td>
                    <td class="style11">
                        &nbsp;
                        <asp:TextBox ID="txtDatetime" runat="server" class="Wdate" value="2016-1-1" 
            onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" Width="135px" 
                            ></asp:TextBox>
                    </td>
                    </tr>
                     <tr>
                        <td class="style5">&nbsp;&nbsp; 备注：</td>
                        <td class="style1">
                            &nbsp;
                            <asp:TextBox ID="txtRemark" runat="server" Width="234px" Height="85px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                        </tr>
                      <tr>
                    <td colspan="2" align="center" class="style12">
                        <asp:ImageButton ID="ImgbtnAdd" runat="server" 
                            ImageUrl="~/images/tijiao_03.jpg" onclick="ImgbtnAdd_Click" 
                            ValidationGroup="sent" />
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/images/chaxun_03.jpg" onclick="ImageButton1_Click" />
                            <asp:ImageButton ID="ImgbtnExit" runat="server" 
                            ImageUrl="~/images/fanhui_03.jpg" onclick="ImgbtnExit_Click"/>
                    </td>
                    </tr>

            </table>
            <div id="lbl" style=" text-align:center">
            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="10"></asp:Label>
        </div>
        </div>
    </div>
    </form>
    </div>

</body>
</html>
