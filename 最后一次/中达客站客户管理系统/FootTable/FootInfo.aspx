<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FootInfo.aspx.cs" Inherits="FootTable_FootInfo" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>结算</title>
    <link rel="Stylesheet" type="text/css" href="../CSS/FootInfo.css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .style3
        {
            width: 225px;
        }
  .Grid{
	margin:5px 0 10px 0;
	border:solid 1px #c1c1c1;
}
.Grid th{
	padding:4px 0px;
	font-size:13px;
}

        .style4
        {
            width: 255px;
        }

    </style>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">结算报表</div>
    <div class="Main"> 
    <div class="main">
        <asp:Panel ID="plSeek" runat="server" GroupingText="查询条件" Width="755px" 
            Height="71px" style="margin-right: 0px">
            <table style="width: 100%; height: 48px;">
                <tr>
                    <td class="style4" align="right">
                        业务员：<asp:DropDownList ID="ddlcus" runat="server" Height="22px" Width="150px">
                        </asp:DropDownList>
                    </td>
                    <td align="right" class="style3">
                        &nbsp; 日期：<asp:TextBox ID="txtstime" runat="server" class="Wdate" Height="22px" 
                            onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" value="2016-01-6" 
                            Width="160px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp; 至：<asp:TextBox ID="txtttime" runat="server" class="Wdate" Height="19px" 
                            onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" 
                            value="2016-01-6" Width="160px"></asp:TextBox>
                        &nbsp; &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>  
    </div>
    <div class="btn">
                &nbsp;&nbsp;
        <asp:ImageButton ID="imgbtnselect" runat="server" ImageUrl="~/images/初始化.jpg" 
            onclick="imgbtnselect_Click" style="height: 20px" 
          />&nbsp;&nbsp;
        <asp:ImageButton ID="imgbtnsel" runat="server" 
            ImageUrl="~/images/chaxun_03.jpg" onclick="imgbtnsel_Click"/>&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/images/daochuExcel.jpg" onclick="ImageButton1_Click" />
    </div>
    <div class="result">
        <asp:GridView ID="gvinfo" runat="server" AutoGenerateColumns="False" CssClass="Grid"
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onrowcommand="gvinfo_RowCommand" onrowdatabound="gvinfo_RowDataBound" 
            PageSize="5" 
            style="margin-left: 0px" Width="756px">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="客户">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cusid") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("customer.CusName") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="60px" />
                </asp:TemplateField>
                <asp:BoundField DataField="datemon" HeaderText="费用年月" />
                <asp:TemplateField HeaderText="面单费">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("oddmon") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="linbtnmiandan" runat="server" 
                            CommandArgument='<%# Eval("cusid") %>' CommandName="oddmon" 
                            Text='<%# Eval("oddmon") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发件费">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("sendmon") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="linbtnfajian" runat="server" 
                            CommandArgument='<%# Eval("cusid") %>' CommandName="SendMon" 
                            Text='<%# Eval("SendMon ") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="送件费">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("givemon") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="linbtnsongjian" runat="server" 
                            CommandArgument='<%# Eval("cusid") %>' CommandName="GiveMon" 
                            Text='<%# Eval("GiveMon") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="收到件返利">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("backmon") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" 
                            CommandArgument='<%# Eval("cusid") %>' CommandName="BackMon" 
                            Text='<%# Eval("BackMon") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="派收附件费">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("accmon") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton5" runat="server" 
                            CommandArgument='<%# Eval("cusid") %>' CommandName="AccMon" 
                            Text='<%# Eval("AccMon") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="其他">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("othermon") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton6" runat="server" 
                            CommandArgument='<%# Eval("cusid") %>' CommandName="OtherMon" 
                            Text='<%# Eval("OtherMon") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="allmon" HeaderText="总计" />
                <asp:TemplateField HeaderText="结算">
                    <ItemTemplate>
                        <asp:LinkButton ID="linbtnJiesuan" runat="server" 
                            CommandArgument='<%# Eval("Cusid") %>' CommandName="jiesuan">结算</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="issettle" HeaderText="是否付款" />
                <asp:BoundField DataField="remark" HeaderText="备注" />
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:ImageButton ID="imabtndel" runat="server" 
                            CommandArgument='<%# Eval("cusid") %>' CommandName="Del" 
                            ImageUrl="~/Images/delete.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <asp:Label ID="Label1" runat="server" Text="没有查询记录！"></asp:Label>
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <webdiyer:AspNetPager ID="anpInfo" runat="server" FirstPageText="首页" 
                LastPageText="尾页" NextPageText="下一页" NumericButtonCount="5" 
                onpagechanged="AspNetPager1_PageChanged" PrevPageText="上一页" 
                ShowCustomInfoSection="Right" ShowInputBox="Always" SubmitButtonText="跳转" 
                AlwaysShow="True">
            </webdiyer:AspNetPager>
        </div>
    </div>
    </form>
    </div>

</body>
</html>
