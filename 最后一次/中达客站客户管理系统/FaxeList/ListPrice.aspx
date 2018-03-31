<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListPrice.aspx.cs" Inherits="FaxeList_ListPrice" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>
    <link href="../CSS/ListPrice.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

   
</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title"><b>面单管理设置</b></div>
     
    <div class="Main">
       <div id="Seach"> 
         <fieldset>
         <legend><asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/ico06.png" Width="18px" />搜索</legend>
               <table class="detail">
                   <tr>
                       <td colspan="2">
                           客户：<asp:DropDownList ID="ddlSustomer" runat="server" Height="22px" 
                               Width="140px" BackColor="White" ForeColor="Black" 
                               AppendDataBoundItems="True">
                               <asp:ListItem Value="0">--请选择--</asp:ListItem>
                           </asp:DropDownList>
                     
                           &nbsp;&nbsp; 承运公司：<asp:DropDownList ID="ddlCarrieCompany" runat="server" Height="22px" 
                               Width="140px" ForeColor="Black" AppendDataBoundItems="True">
                               <asp:ListItem Value="0">--请选择--</asp:ListItem>
                           </asp:DropDownList>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 是否结算：&nbsp;&nbsp;<asp:RadioButton 
                           ID="rdoYes" runat="server" GroupName="rdo" Text="是" />
                       &nbsp;<asp:RadioButton ID="rdoNo" runat="server" GroupName="rdo" 
                           Text="否" Checked="True" />
                       </td>
                      
                      
                   </tr>
                   <tr>
                       
                         <td>
                               面单号：<asp:TextBox ID="txtNumber" runat="server" BorderColor="#D0DEDE" 
                               BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="100px"></asp:TextBox>
                               <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                   ControlToValidate="txtNumber" ErrorMessage="输入的面单起始号号必须为数字" 
                                   Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>至
                               <asp:TextBox ID="txtNumber0" runat="server" BorderColor="#D0DEDE" 
                               BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="100px"></asp:TextBox>
                               <asp:CompareValidator ID="CompareValidator5" runat="server" 
                                   ControlToValidate="txtNumber0" ErrorMessage="输入的面单结束号必须为数字" 
                                   Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>
                       </td>
                       <td >
                                                      &nbsp; 时间：<asp:TextBox ID="txtDate" runat="server" Height="18px" Width="100px" 
                               BorderColor="#D0DEDE" BorderStyle="Solid" BorderWidth="1" class="Wdate" 
                               onFocus="new WdatePicker(this,'%Y-%M-%D ',true,'default')"></asp:TextBox>
                           &nbsp;<asp:CompareValidator ID="CompareValidator3" runat="server" 
                               ControlToValidate="txtDate" ErrorMessage="输入必须为日期" Operator="DataTypeCheck" 
                               Type="Date">*</asp:CompareValidator>
                           &nbsp;至&nbsp;&nbsp;&nbsp; 
                           <asp:TextBox ID="txtDate2" runat="server" BorderColor="#D0DEDE" 
                               BorderStyle="Solid" BorderWidth="1" class="Wdate" Height="18px" 
                               onFocus="new WdatePicker(this,'%Y-%M-%D ',true,'default')" Width="100px"></asp:TextBox>
                           <asp:CompareValidator ID="CompareValidator4" runat="server" 
                               ControlToValidate="txtDate2" ErrorMessage="输入必须为日期" Operator="DataTypeCheck" 
                               Type="Date">*</asp:CompareValidator>
                         </td>
                         
                   </tr>
                    <tr>
                       
                         <td colspan="2"  align="center">
                             <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="28px" 
                                 Width="570px" />
                       </td>
                       
                         
                   </tr>
               </table>
          </fieldset>
           </div>
           <div id="function">
           <div class="public">
                 <asp:ImageButton ID="ImageButton1" runat="server" 
                     ImageUrl="~/images/daochuExcel.jpg" onclick="ImageButton1_Click" 
                     Height="21px" Width="86px"
                       />
                 </div>
           <div class="public">
                 <asp:ImageButton ID="ImgBtnall" runat="server" 
                     ImageUrl="~/images/chaxunsuoyou.jpg" onclick="ImgBtnall_Click"
                       />
                 </div>
             <div class="public">
                 <asp:ImageButton ID="ImgBtnAdd" runat="server" 
                     ImageUrl="~/images/tianjia_03.jpg" onclick="ImgBtnAdd_Click" /></div>
            <div class="public">
                 <asp:ImageButton ID="ImgBtnSeach" runat="server" 
                     ImageUrl="~/images/chaxun_03.jpg" onclick="ImgBtnSeach_Click"/></div>
           </div>
           <div id="main">
               <asp:GridView ID="GvDisNoteTB" runat="server" CellPadding="4" CssClass="Grid"
                   ForeColor="Black" GridLines="None" AutoGenerateColumns="False" 
                   Width="771px" AllowSorting="True" 
                   DataKeyNames="Nid" 
                   onrowcommand="GvDisNoteTB_RowCommand" onrowdatabound="GvDisNoteTB_RowDataBound" 
                   PageSize="5" RowHeaderColumn="1">
                   <PagerSettings FirstPageText="1" LastPageText="1" Mode="NumericFirstLast" 
                       NextPageText="1" PageButtonCount="1" PreviousPageImageUrl="1" 
                       PreviousPageText="1" />
                   <RowStyle BackColor="#EFF3FB" Font-Strikeout="False" />
                   <Columns>
                       <asp:TemplateField HeaderText="客户姓名">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%# Eval("Customer.CusName") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="承运公司">
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                           </EditItemTemplate>
                           <ItemTemplate>
                               <asp:Label ID="Label2" runat="server" 
                                   Text='<%# Eval("CarrieCompany.CoName") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField DataField="Nid" Visible="False" />
                       <asp:BoundField DataField="CusID" Visible="False" />
                       <asp:BoundField DataField="Cid" Visible="False" />
                       <asp:BoundField DataField="BeginNO" HeaderText="面单起始号" />
                       <asp:BoundField DataField="EndNo" HeaderText="面单结束号" />
                       <asp:BoundField DataField="Dtime" HeaderText="分配时间" 
                           DataFormatString="{0:yyyy-MM-dd}" />
                       <asp:BoundField DataField="Sum" HeaderText="金额" DataFormatString="{0:c}" />
                       <asp:BoundField DataField="IsSet" HeaderText="是否结算" />
                       <asp:TemplateField HeaderText="备注">
                           <ItemTemplate>
                               <asp:Label ID="Label3" runat="server" Text='<%# Cut(Eval("Remark")) %>'></asp:Label>
                           </ItemTemplate>
                           <EditItemTemplate>
                               <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                           </EditItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="编辑">
                           <ItemTemplate>
                               <asp:ImageButton ID="ImgBtnUpd" runat="server" 
                                   CommandArgument='<%# Eval("Nid") %>' CommandName="Upd" Height="15px" 
                                   ImageUrl="~/images/edit.gif" />
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="删除">
                           <ItemTemplate>
                               <asp:ImageButton ID="ImgBtnDel" runat="server" 
                                   CommandArgument='<%# Eval("Nid") %>' CommandName="Del" 
                                   ImageUrl="~/images/delete.gif" />
                           </ItemTemplate>
                       </asp:TemplateField>
                   </Columns>
                   <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                   <EmptyDataTemplate>
                       没有查询到该条记录!!!!!!!
                   </EmptyDataTemplate>
                   <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                   <EditRowStyle BackColor="#2461BF" />
                   <AlternatingRowStyle BackColor="White" VerticalAlign="Middle" />
               </asp:GridView>
                   <div>  
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
