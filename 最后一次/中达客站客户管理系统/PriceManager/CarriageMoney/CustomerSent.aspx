<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerSent.aspx.cs" Inherits="PriceManager_CustomerSent" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/CustomerSent.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/iFram.css" rel="stylesheet" type="text/css" />

</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
            <div class="Title">运费结算管理</div>

    
    <fieldset>
    <legend> <asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/ico06.png" Width="18px" />
        <asp:Label ID="Label1" runat="server"
                    Text="搜索" Font-Size="Small"></asp:Label></legend>
        <div class="Search">
           
            <asp:Label ID="lblName" runat="server" Text="客户姓名："></asp:Label>
            <asp:DropDownList ID="ddlName" runat="server" Width="121px" 
                AppendDataBoundItems="True">
                <asp:ListItem Value="0">--请选择--</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblCompany" runat="server" Text="承运公司："></asp:Label>
            <asp:DropDownList ID="ddlCompany" runat="server" Width="96px" 
                AppendDataBoundItems="True">
                <asp:ListItem Value="0">--请选择--</asp:ListItem>
            </asp:DropDownList>
            <asp:LinkButton ID="lkbtnAdd" runat="server" onclick="lkbtnAdd_Click">添加信息</asp:LinkButton>
            <asp:LinkButton ID="lkbtnSelect" runat="server" onclick="lkbtnSelect_Click">查询无头件</asp:LinkButton>
        </div>
        <div class="condtion">
            
            <asp:Label ID="lblPno" runat="server" Text="面单号："></asp:Label>
            <asp:TextBox ID="txtpno" runat="server" Width="117px"></asp:TextBox>
            <asp:Label ID="lblDes" runat="server" Text="目的地："></asp:Label>
            <asp:TextBox ID="txtDes" runat="server" Width="93px"></asp:TextBox>
            <asp:ImageButton ID="ImageButton3" runat="server" 
                ImageUrl="~/images/chaxun_03.jpg" onclick="ImageButton3_Click" />
            <asp:ImageButton ID="ImageButton4" runat="server" 
                ImageUrl="~/images/chaxunsuoyou.jpg" onclick="ImageButton4_Click" />
            
            <asp:ImageButton ID="imgDaochu" runat="server" 
                ImageUrl="~/images/daochuExcel.jpg" onclick="imgDaochu_Click" />
            
        </div>
        </fieldset>
        <div class="Main">
        <div class="Setup">
            <asp:Image ID="imgExecl" runat="server" ImageUrl="~/images/excel.png" />
            <asp:LinkButton ID="lkbtnExecl" runat="server" onclick="lkbtnExecl_Click">导入表格</asp:LinkButton>
        </div>
        <div class="content">
            <asp:GridView ID="gvInfo" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                CellPadding="4" ForeColor="#333333" GridLines="None" Width="740px" 
                onrowcommand="gvInfo_RowCommand"  
                onrowdatabound="gvInfo_RowDataBound">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="rid" HeaderText="面单号" />
                    <asp:TemplateField HeaderText="客户姓名">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cusid") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("customer.cusname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="承运公司">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cid") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" 
                                Text='<%# Eval("carriecompany.coname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="destination" HeaderText="目的地" />
                    <asp:BoundField DataField="kilo" HeaderText="公斤数" />
                    <asp:BoundField DataField="price" HeaderText="运费" />
                    <asp:BoundField DataField="resdate" HeaderText="揽件时间" 
                        DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="isset" HeaderText="是否结算" />
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("remark") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Cut(Eval("remark")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="csid" HeaderText="编号" Visible="False" />
                    <asp:TemplateField HeaderText="编辑">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                CommandArgument='<%# Eval("csid") %>' CommandName="edinfo" 
                                ImageUrl="~/images/edit.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" 
                                CommandArgument='<%# Eval("csid") %>' CommandName="dlinfo" 
                                ImageUrl="~/images/delete.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    <asp:Label ID="Label4" runat="server" Text="查无此记录！"></asp:Label>
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <asp:GridView ID="GridView1" runat="server" cssClass="Grid"
                AutoGenerateColumns="False" CellPadding="4" Font-Size="Small" 
                ForeColor="#333333" GridLines="None"  
                onrowcommand="GridView1_RowCommand" Visible="False" Width="705px" 
                onrowdatabound="GridView1_RowDataBound">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="rid" HeaderText="面单号" />
                    <asp:BoundField DataField="Destination" HeaderText="目的地" />
                    <asp:BoundField DataField="Kilo" HeaderText="公斤数" />
                    <asp:BoundField DataField="Price" HeaderText="运费" />
                    <asp:BoundField DataField="Resdate" HeaderText="揽件时间" 
                        DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText="面单重新分配">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnEdit" runat="server" 
                                CommandArgument='<%# Eval("rid") %>' CommandName="edlinfo" Height="18px" 
                                ImageUrl="~/images/edit.png" Width="18px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    <asp:Label ID="Label5" runat="server" Text="查无此记录！"></asp:Label>
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
