<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCustomers.aspx.cs" Inherits="Customers_SelectCustomers" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/SelectCustomer.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">客户管理</div>
    <div class="Main">    
       <fieldset><legend>
            <asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/ico06.png" Width="16px" />搜索</legend>
        <asp:Panel ID="Panel1" runat="server" Height="33px" Width="769px">
            <asp:Label ID="Label1" runat="server" Text="客户姓名："></asp:Label>
            <asp:DropDownList ID="ddlName" runat="server" AppendDataBoundItems="True" 
                Width="100px" AutoPostBack="True" 
                onselectedindexchanged="ddlName_SelectedIndexChanged">
                <asp:ListItem Value="0">--请选择--</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label2" runat="server" Text="是否为业务员："></asp:Label>
            <asp:DropDownList ID="ddlIscounterman" runat="server" 
                AppendDataBoundItems="True" AutoPostBack="True" 
                onselectedindexchanged="ddlIscounterman_SelectedIndexChanged" 
                Width="100px">
                <asp:ListItem Value="2">--请选择--</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="ImBtnSelect" runat="server" 
                ImageUrl="~/images/chaxun_03.jpg" onclick="ImBtnSelect_Click" 
                style="height: 20px" />
            <asp:ImageButton ID="imgbtnAll" runat="server" 
                ImageUrl="~/images/chaxunsuoyou.jpg" onclick="imgbtnAll_Click" />
            <asp:ImageButton ID="imgbtnAdd" runat="server" 
                ImageUrl="~/images/tianjia_03.jpg" onclick="imgbtnAdd_Click" />
            <asp:ImageButton ID="imgDaochu" runat="server" 
                ImageUrl="~/images/daochuExcel.jpg" onclick="imgDaochu_Click" />
        </asp:Panel>
    </fieldset>
        <br />
        <div class="content">
        <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" CssClass="Grid"
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onrowcommand="gvCustomers_RowCommand" 
                onrowdatabound="gvCustomers_RowDataBound" Width="765px" 
                 Font-Size="Small">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="CusName" HeaderText="客户姓名" />
                <asp:BoundField DataField="CusTel" HeaderText="联系电话" />
                <asp:BoundField DataField="IsCounterman" HeaderText="业务员" />
                <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Cut(Eval("Remark")) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="编辑">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImbtnEdit" runat="server" 
                            CommandArgument='<%# Eval("Cusid") %>' CommandName="Ed" 
                            ImageUrl="~/images/edit.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImbtnDelete" runat="server" 
                            CommandArgument='<%# Eval("Cusid") %>' CommandName="nDe" 
                            ImageUrl="~/images/delete.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <asp:Label ID="Label3" runat="server" Text="查无此记录！"></asp:Label>
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
            <webdiyer:AspNetPager ID="anpPage" runat="server" FirstPageText="首页" 
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
