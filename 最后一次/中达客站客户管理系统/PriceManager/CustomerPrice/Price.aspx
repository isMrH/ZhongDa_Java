<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Price.aspx.cs" Inherits="BackStage_Price" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/Price.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/iFram.css" rel="stylesheet" type="text/css" />

</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
            <div class="Title">价格模板管理</div>

    <div class="Main">
    <fieldset>
    <legend><asp:Image ID="Image2" runat="server" Height="16px" 
                ImageUrl="~/images/ico06.png" Width="18px" />搜索</legend>
     
        <div class="condition">
            <asp:Label ID="lblPno" runat="server" Text="模板编号:" Font-Size="Small"></asp:Label> 
            <asp:TextBox ID="txtPno" runat="server" Width="83px"></asp:TextBox>
            <asp:Label ID="lblDestination" runat="server" Text="目的地:"></asp:Label>
            <asp:TextBox ID="txtDes" runat="server" Width="83px"></asp:TextBox>
            <asp:Label ID="LblKilo" runat="server" Text="公斤数:"></asp:Label>
            <asp:TextBox ID="txtKilo" runat="server" Width="83px"></asp:TextBox>
            <asp:Label ID="lblPrice" runat="server" Text="价格:"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" Width="83px"></asp:TextBox>
            <asp:ImageButton ID="imgbtnSearch" runat="server" 
                ImageUrl="~/images/chaxun_03.jpg" onclick="imgbtnSearch_Click" 
                Width="61px" />
            <asp:ImageButton ID="imgbtnAll" runat="server" 
                ImageUrl="~/images/chaxunsuoyou.jpg" Width="77px" 
                onclick="imgbtnAll_Click" />
        </div>
        </fieldset>
        <div class="Setup">
            <asp:Image ID="imgExecl" runat="server" ImageUrl="~/images/excel.png" />
            <asp:LinkButton ID="lkbtnExecl" runat="server" onclick="lkbtnExecl_Click">导入表格</asp:LinkButton>
            
        </div>
        <div class="content">
            <asp:GridView ID="gvTemp" runat="server" CssClass="Grid"
                AutoGenerateColumns="False" CellPadding="4" Font-Size="Small" 
                ForeColor="#333333" GridLines="None"  
                 Width="708px" 
                onrowdatabound="gvTemp_RowDataBound" >
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="pno" HeaderText="模板编号" />
                    <asp:BoundField DataField="destination" HeaderText="目的地" />
                    <asp:BoundField DataField="kilo" HeaderText="公斤数" />
                    <asp:BoundField DataField="price" HeaderText="价格" />
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("remark") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Cut(Eval("remark")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="pid" HeaderText="编号" Visible="False" />
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    <asp:Label ID="Label2" runat="server" Text="查无此记录！"></asp:Label>
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <webdiyer:AspNetPager ID="anpPage" runat="server" AlwaysShow="True" 
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
                onpagechanged="anpPage_PageChanged" PrevPageText="上一页" 
                ShowCustomInfoSection="Right" ShowInputBox="Always" SubmitButtonText="跳转">
            </webdiyer:AspNetPager>
        </div>
    </div>
    </form>
    </div>
</body>
</html>
