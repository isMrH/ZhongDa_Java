<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectIAE.aspx.cs" Inherits="IAE_SelectIAE" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/IAE.css" rel="stylesheet" type="text/css" />
            <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
           <div class="Title">其他收支管理</div>

    <div class="Main">
    <fieldset>
    <legend><asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/ico06.png" Width="18px" /><asp:Label ID="Label1" runat="server"
                    Text="搜索"></asp:Label></legend>
       <div class="Search">
            
            <asp:Label ID="lblName" runat="server" Text="客户姓名："></asp:Label>
            <asp:DropDownList ID="ddlName" runat="server" Width="85px" 
                AppendDataBoundItems="True">
                <asp:ListItem Value="0">--请选择--</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblDate" runat="server" Text="收支日期："></asp:Label>
            <asp:TextBox ID="txtDate" runat="server"  class="Wdate" value="2016-1-1" 
                           onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" 
                Width="113px"></asp:TextBox>--
             <asp:TextBox ID="TextBox3" runat="server"  class="Wdate" value="2016-1-1" 
                           onFocus="new WdatePicker(this,'%Y-%M-%D',true,'default')" 
                Width="113px"></asp:TextBox>
            
            <asp:LinkButton ID="lkbtnAdd" runat="server" onclick="lkbtnAdd_Click">添加信息</asp:LinkButton>
        </div>
        <div id="Search1">
           <asp:ImageButton ID="imgbtnSelect" runat="server" 
                ImageUrl="~/images/chaxun_03.jpg" onclick="imgbtnSelect_Click" />
            <asp:ImageButton ID="imgbtnSelectall" runat="server" 
                ImageUrl="~/images/chaxunsuoyou.jpg" onclick="imgbtnSelectall_Click" />
            <asp:ImageButton ID="ImageButton3" runat="server" 
                ImageUrl="~/images/daochuExcel.jpg" onclick="ImageButton3_Click" />
        </div>
        </fieldset>
        <div class="content">
           
            <asp:GridView ID="gvInfo" runat="server" CssClass="Grid"
                AutoGenerateColumns="False" CellPadding="4" Font-Size="Small" 
                ForeColor="#333333" GridLines="None" 
               onrowcommand="gvInfo_RowCommand" 
                Width="628px" onrowdatabound="gvInfo_RowDataBound">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:TemplateField HeaderText="客户姓名">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cusid") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("customer.cusname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IAEName" HeaderText="费用名称" />
                    <asp:BoundField DataField="IAEDate" DataFormatString="{0:yyyy-MM-dd}" 
                        HeaderText="收支日期" />
                    <asp:BoundField DataField="Price" HeaderText="金额" />
                    <asp:BoundField DataField="ISsettle" HeaderText="是否结算" />
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("remark") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Cut(Eval("remark")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="IAEid" HeaderText="编号" Visible="False" />
                    <asp:TemplateField HeaderText="编辑">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                CommandArgument='<%# Eval("IAEid") %>' CommandName="edinfo" 
                                ImageUrl="~/images/edit.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" 
                                CommandArgument='<%# Eval("IAEid") %>' CommandName="deinfo" 
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
