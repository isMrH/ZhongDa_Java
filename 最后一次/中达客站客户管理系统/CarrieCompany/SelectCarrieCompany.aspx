<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCarrieCompany.aspx.cs" Inherits="CarrieCompany_CarrieCompanyRegister" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/SelectCarrieCompany.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">承运公司管理</div>
     <fieldset>
     <legend>
            <asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/ico06.png" Width="16px" />搜索</legend>
   
        
    
        <asp:Panel ID="Panel1" runat="server" Height="31px" Width="765px">
            <asp:Label ID="Label1" runat="server" Text="承运公司：" Font-Size="10pt"></asp:Label>
            <asp:DropDownList ID="ddlCompany" runat="server" AppendDataBoundItems="True" 
                Width="98px" AutoPostBack="True" 
                onselectedindexchanged="ddlCompany_SelectedIndexChanged">
                <asp:ListItem Value="0">--请选择--</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblMan" runat="server" Text="联系人：" Font-Size="10pt"></asp:Label>
            <asp:DropDownList ID="ddlMan" runat="server" AppendDataBoundItems="True" 
                Width="98px" AutoPostBack="True" 
                onselectedindexchanged="ddlMan_SelectedIndexChanged">
                <asp:ListItem Value="0">--请选择--</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="ImBtnSelect" runat="server" 
    ImageUrl="~/images/chaxun_03.jpg" onclick="ImBtnSelect_Click" />
            <asp:ImageButton ID="imgbtnAll" runat="server" 
                ImageUrl="~/images/chaxunsuoyou.jpg" onclick="imgbtnAll_Click" />
            <asp:ImageButton ID="imgbtnAdd" runat="server" 
                ImageUrl="~/images/tianjia_03.jpg" onclick="imgbtnAdd_Click" />
            <asp:ImageButton ID="imgDaochu" runat="server" 
                ImageUrl="~/images/daochuExcel.jpg" onclick="imgDaochu_Click" />
        </asp:Panel>
    </fieldset>
        <br />
         <div class="Main">
        <div class="content">
        <asp:GridView ID="gvCarrieCompany" runat="server" AutoGenerateColumns="False" CssClass="Grid"
            CellPadding="4" ForeColor="#333333" GridLines="None"
            onrowcommand="gvCarrieCompany_RowCommand" 
            onrowdatabound="gvCarrieCompany_RowDataBound1" 
             Width="732px" >
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="CoName" HeaderText="承运公司" />
                <asp:BoundField DataField="Clinkman" HeaderText="联系人" />
                <asp:BoundField DataField="LinkmanTel" HeaderText="联系电话" />
                <asp:BoundField DataField="Cmoney" DataFormatString="{0:C}" HeaderText="面单费" />
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
                        <asp:ImageButton ID="IBtnEdit" runat="server" 
                            CommandArgument='<%# Eval("Cid") %>' CommandName="nEd" 
                            ImageUrl="~/images/edit.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        &nbsp;<asp:ImageButton ID="IBtnDelete" runat="server" 
                            CommandArgument='<%# Eval("Cid") %>' CommandName="Del" 
                            ImageUrl="~/images/delete.gif" />
                    </ItemTemplate>
                </asp:TemplateField>
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
            <br />
            <webdiyer:AspNetPager ID="anpPage" runat="server" AlwaysShow="True" 
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" NumericButtonCount="5" 
                onpagechanged="anpPage_PageChanged" PrevPageText="上一页" 
                ShowCustomInfoSection="Right" ShowInputBox="Always" SubmitButtonText="跳转">
            </webdiyer:AspNetPager>
      </div>
    </div>
    </div>

    </form>
    </div>
</body>
</html>
