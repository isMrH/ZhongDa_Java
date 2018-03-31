<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMS.aspx.cs" Inherits="Administrator_SMS" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
            <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
            <link href="../CSS/Admin.css" rel="stylesheet" type="text/css" />

</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
        <div class="Title">用户管理</div>
     <div class="btn1" align="right">
         <asp:ImageButton ID="ImageButton1" runat="server" 
             ImageUrl="~/images/daochuExcel.jpg" onclick="ImageButton1_Click" />
     </div>
    <div class="Main">
    
        <div class="Gd">
            <asp:GridView ID="gvuserinfo" runat="server" CssClass="Grid"
                AutoGenerateColumns="False" onrowcommand="gvuserinfo_RowCommand" 
                onrowdatabound="gvuserinfo_RowDataBound" PageSize="5" Width="740px" 
                 CellPadding="4" ForeColor="#333333" GridLines="None" Font-Size="Small">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="uid" HeaderText="编号" />
                    <asp:BoundField DataField="loginid" HeaderText="账号" />
                    <asp:BoundField DataField="Telephone" HeaderText="电话" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="QuesTion" HeaderText="密保问题" />
                    <asp:BoundField DataField="akey" HeaderText="密保答案" />
                    <asp:BoundField DataField="remark" HeaderText="备注" />
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <asp:ImageButton ID="imabtndel" runat="server" AlternateText="删除" 
                                CommandArgument='<%# Eval("uid") %>' CommandName="del" 
                                ImageUrl="~/images/delete.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
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
