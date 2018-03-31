<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sent.aspx.cs" Inherits="Sent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Sent.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(function () {
        $('#txtNumbers').blur(function ()) //失去焦点时触发的时间 
    } 
    </script>
    <style type="text/css">
        .style1
        {
            width: 145px;
            height: 49px;
        }
        .style2
        {
            width: 93px;
            height: 49px;
        }
        .style3
        {
            width: 93px;
            height: 106px;
        }
        .style4
        {
            width: 145px;
            height: 106px;
        }
        .style5
        {
            width: 93px;
            height: 39px;
        }
        .style6
        {
            width: 145px;
            height: 39px;
        }
        .style7
        {
            height: 54px;
        }
        .style8
        {
            width: 145px;
            height: 54px;
        }
        .style9
        {
            width: 93px;
            height: 52px;
        }
        .style10
        {
            width: 145px;
            height: 52px;
        }
        .style11
        {
            height: 34px;
        }
    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">揽发到付件管理录入</div>    
    <div class="Main">
            <table id="center" style="width:64%" bgcolor="#cccccc" border="0" 
                cellpadding="10" cellspacing="1">
                <tr>
                    <td class="style7">
                       &nbsp;&nbsp;
                       录入单号：</td>
                    <td class="style8" >
                        &nbsp;
                        <asp:TextBox ID="txtNumbers" runat="server" Width="135px" 
                            ontextchanged="txtNumbers_TextChanged" AutoPostBack="True" 
                            CausesValidation="True" ValidationGroup="sent"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" 
                            ControlToValidate="txtNumbers" ErrorMessage="录入单号只能为数字" 
                            Operator="DataTypeCheck" Type="Double" ValidationGroup="sent" 
                            Display="Dynamic"></asp:CompareValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtNumbers" ErrorMessage="录入单号不能为空" 
                            ValidationGroup="sent" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" 
                            ControlToValidate="txtNumbers" Display="Dynamic" ErrorMessage="单号已存在" 
                            onservervalidate="CustomValidator1_ServerValidate1" ValidationGroup="sent"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        &nbsp;&nbsp;
                        承运公司：</td>
                    <td class="style6">
                        &nbsp;
                        <asp:Label ID="lblCom" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        &nbsp;&nbsp;
                        客户：</td>
                    <td class="style6">
                        &nbsp;
                        <asp:Label ID="lblCus" runat="server"></asp:Label>
                    </td>
                </tr>
                   <tr>
                    <td class="style9">
                      &nbsp;&nbsp;
                      重量：</td>
                    <td class="style10">
                        &nbsp;
                        <asp:TextBox ID="txtWeight" runat="server" Width="135px" AutoPostBack="True" 
                            ontextchanged="txtWeight_TextChanged" CausesValidation="True" 
                            ValidationGroup="sent"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="txtWeight" Display="Dynamic" ErrorMessage="重量只能是数字" 
                            Operator="DataTypeCheck" Type="Double" ValidationGroup="sent"></asp:CompareValidator>
                    </td>
                </tr>
                   <tr>
                    <td class="style2">
                    &nbsp;&nbsp;
                    金额：</td>
                    <td class="style1">
                        &nbsp;
                        <asp:TextBox ID="txtMoney" runat="server" Width="135px" ReadOnly="True"></asp:TextBox>
                        &nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToValidate="txtMoney" Display="Dynamic" ErrorMessage="金额只能是数字" 
                            Operator="DataTypeCheck" Type="Double" ValidationGroup="sent"></asp:CompareValidator>
                    </td>
                </tr>
                   <tr>
                    <td class="style5">
                    &nbsp;&nbsp;
                    起运日期：</td>
                    <td class="style6">
                        &nbsp;
                        <asp:TextBox ID="txtDatetime" runat="server" class="Wdate" value="2016-1-1" 
            onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" Width="135px" ></asp:TextBox>
                    </td>
                    </tr>
                     <tr>
                        <td class="style3">&nbsp;&nbsp; 备注：</td>
                        <td class="style4">
                            &nbsp;
                            <asp:TextBox ID="txtRemark" runat="server" Width="248px" Height="83px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                        </tr>
                      <tr>
                    <td colspan="2" align="center" class="style11">
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
    </form>
    </div>
</body>
</html>
