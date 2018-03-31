<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SentShow.aspx.cs" Inherits="SentShow" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Sent.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />

</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
        <div class="Title">揽发到付件管理查询</div>

    <div class="Main">
    <fieldset>
    <legend>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/ico06.png" 
                Height="16px" Width="16px" />搜索</legend>
        <div id="search1"><asp:Label ID="Label2" runat="server" Text="承运公司:"></asp:Label>
            <asp:DropDownList ID="ddlConame1"
                runat="server" Width="100px">
            </asp:DropDownList>
             &nbsp;
            <asp:Label ID="Label3" runat="server" Text="客户:"></asp:Label>
            <asp:DropDownList
                ID="ddlCusName1" runat="server" Width="100px">
            </asp:DropDownList>
            &nbsp;
            <asp:Label ID="Label4" runat="server" Text="时间段:"></asp:Label>
            <asp:TextBox ID="txtTime"
                runat="server" Width="80px"></asp:TextBox>
            <asp:Label ID="Label5" 
                runat="server" Text="—"></asp:Label>
            <asp:TextBox ID="txtTime1" 
                runat="server" Width="80px"></asp:TextBox>
                 &nbsp;
            <asp:Label ID="Label6" runat="server" Text="单号:"></asp:Label>
            <asp:TextBox ID="txtSerachNumbers"
                runat="server" Width="100px"></asp:TextBox>
           
        </div>
        </fieldset>
     <div id="search3" align="right">
          <asp:ImageButton ID="ImageButton1" runat="server" 
                ImageUrl="~/images/chaxun_03.jpg" onclick="ImageButton1_Click" />
            <asp:ImageButton ID="ImageButton5" runat="server" 
              ImageUrl="~/images/chaxunsuoyou.jpg" onclick="ImageButton5_Click" />
            <asp:ImageButton ID="ImageButton2" runat="server" 
                ImageUrl="~/images/fanhui_03.jpg" onclick="ImageButton2_Click" />
          <asp:ImageButton ID="imgDaochu" runat="server" 
              ImageUrl="~/images/daochuExcel.jpg" onclick="imgDaochu_Click" />
     </div>
    <div id="search2">
            <asp:GridView ID="GridView1" runat="server" CssClass="Grid"
                    
                    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" Font-Size="Small" 
                    Width="740px"  
                    onrowcommand="GridView1_RowCommand" 
                    onrowdatabound="GridView1_RowDataBound">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField HeaderText="客户">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CusID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("cust.CusName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="承运公司">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Cid") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("company.CoName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CSid" HeaderText="面单号" />
                        <asp:BoundField DataField="Kilo" HeaderText="重量" />
                        <asp:BoundField DataField="BeginDate" HeaderText="起运日期" />
                        <asp:BoundField DataField="Remark" HeaderText="备注" />
                        <asp:BoundField DataField="Sid" HeaderText="揽发到付ID" Visible="False" />
                        <asp:TemplateField HeaderText="编辑">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton3" runat="server" 
                                    CommandArgument='<%# Eval("Sid") %>' CommandName="ed" 
                                    ImageUrl="~/images/edit.gif" Height="15px" Width="15px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton4" runat="server" 
                                    CommandArgument='<%# Eval("Sid") %>' ImageUrl="~/images/delete.gif" 
                                    CommandName="dl" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <asp:Label ID="Label7" runat="server" Text="查无此信息！"></asp:Label>
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
