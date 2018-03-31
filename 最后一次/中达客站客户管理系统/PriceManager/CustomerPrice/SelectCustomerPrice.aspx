<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCustomerPrice.aspx.cs" Inherits="BackStage_CustomerPrice" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/SelectCustomerPrice.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/iFram.css" rel="stylesheet" type="text/css" />

    </head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
           <div class="Title">运费价格设置 </div>

    <div class="Main">
    <fieldset>
    <legend><asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/ico06.png" Width="18px" /><asp:Label ID="Label1" runat="server"
                    Text="搜索"></asp:Label></legend>
       <div class="Search">
            
            <asp:Label ID="lblName" runat="server" Text="客户姓名:" Font-Size="Small"></asp:Label> 
            <asp:DropDownList ID="ddlName" runat="server" Width="100px" 
                onselectedindexchanged="ddlName_SelectedIndexChanged" 
                AppendDataBoundItems="True">
                <asp:ListItem Value="0">--请选择--</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblCompany" runat="server" Text="公司名称:"></asp:Label>
            <asp:DropDownList ID="ddlCompany" runat="server" Width="100px" 
                onselectedindexchanged="ddlCompany_SelectedIndexChanged" 
                AppendDataBoundItems="True">
                <asp:ListItem Value="0">--请选择--</asp:ListItem>
            </asp:DropDownList>
            <asp:LinkButton ID="lkbtnTemp" runat="server" onclick="lkbtnTemp_Click">查看模板</asp:LinkButton>
            <asp:LinkButton ID="lkbtnAdd" runat="server" onclick="lkbtnAdd_Click">添加客户价格信息</asp:LinkButton>
        </div>
       <div class="condition">
            <asp:Label ID="lblPno" runat="server" Text="模板编号:"></asp:Label>
            <asp:TextBox ID="txtPno" runat="server" Width="98px"></asp:TextBox>
            <asp:Label ID="lblPoName" runat="server" Text="模板名称:"></asp:Label>
            <asp:TextBox ID="txtPoName" runat="server" Width="96px"></asp:TextBox>
            <asp:ImageButton ID="ImageButton3" runat="server" 
                ImageUrl="~/images/chaxun_03.jpg" onclick="ImageButton3_Click" />
            <asp:ImageButton ID="ImageButton4" runat="server" 
                ImageUrl="~/images/chaxunsuoyou.jpg" onclick="ImageButton4_Click" />
            <asp:ImageButton ID="imgDaochu" runat="server" 
                ImageUrl="~/images/daochuExcel.jpg" onclick="imgDaochu_Click" />
        </div>
        </fieldset>
        <div class="content">
           <asp:GridView ID="gvInfo" runat="server" CellPadding="4" Font-Size="Small" CssClass="Grid"
            ForeColor="#333333" GridLines="None"  
                AutoGenerateColumns="False" onrowcommand="gvInfo_RowCommand" Width="740px" 
                onrowdatabound="gvInfo_RowDataBound">
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
                   <asp:TemplateField HeaderText="承运公司">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cid") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" 
                               Text='<%# Eval("carriecomapny.coname") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="pno" HeaderText="模板编号" />
                   <asp:BoundField DataField="cpname" HeaderText="模板名称" />
                   <asp:TemplateField HeaderText="备注">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("remark") %>'></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label3" runat="server" Text='<%# Cut(Eval("remark")) %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="编辑">
                       <ItemTemplate>
                           <asp:ImageButton ID="ImageButton1" runat="server" 
                               CommandArgument='<%# Eval("cpid") %>' CommandName="edinfo" 
                               ImageUrl="~/images/edit.gif" />
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="删除">
                       <ItemTemplate>
                           <asp:ImageButton ID="ImageButton2" runat="server" 
                               CommandArgument='<%# Eval("cpid") %>' CommandName="delinfo" 
                               ImageUrl="~/images/delete.gif" />
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="cpid" HeaderText="编号" Visible="False" />
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
