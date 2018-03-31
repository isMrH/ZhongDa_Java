<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerSendTB.aspx.cs" Inherits="DelGoodsMonTB_CustomerSendTB" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />
         <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <style type="text/css">
        #function
        {
        	margin-top:10px;
            width: 730px;
        }
       #send
        {
        	text-align:center;}
    </style>

</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">送货费管理</div>
   <div class="Main">
       <div id="customer"> 
       <fieldset>
       <legend><asp:Image ID="Image1" runat="server" ImageUrl="~/images/ico06.png" 
                Height="16px" Width="16px" />搜索</legend>
       <table class="style1">
           <tr>
               <td colspan="2">
                  
                   客户：<asp:DropDownList ID="ddlCustomer" runat="server" 
                       Height="20px" Width="70px">
                   </asp:DropDownList>
              
                   &nbsp;&nbsp;
              
                   派件个数：<asp:TextBox ID="txtNumber" runat="server"  Height="20px" 
                           Width="80px" BorderStyle="Solid" BorderColor="#D0DEDE" BorderWidth="1" 
                          ></asp:TextBox>
               &nbsp;&nbsp;
                   派件邮费<asp:TextBox ID="txtPrice" runat="server"  Height="20px" 
                           Width="80px" BorderStyle="Solid" BorderColor="#D0DEDE" BorderWidth="1" 
                           AutoPostBack="True"></asp:TextBox>
               
                   &nbsp;&nbsp;&nbsp; 时间： 
                   <asp:TextBox ID="txtDate" runat="server" 
                       Height="18px" Width="80px" 
                               BorderColor="#D0DEDE" BorderStyle="Solid" BorderWidth="1" class="Wdate" 
                               onFocus="new WdatePicker(this,'%Y-%M-%D ',true,'default')"></asp:TextBox>
                           &nbsp;至&nbsp;&nbsp;<asp:TextBox ID="txtDate2" runat="server" BorderColor="#D0DEDE" 
                               BorderStyle="Solid" BorderWidth="1" class="Wdate" Height="18px" 
                               onFocus="new WdatePicker(this,'%Y-%M-%D ',true,'default')" 
                       Width="80px"></asp:TextBox>
               
               </td>
           </tr>
           <tr>
               <td colspan="2" align="left">
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    
               
               
                   是否结算&nbsp;：<asp:RadioButton 
                           ID="rdoYes" runat="server" GroupName="rdo" Text="是" />
                       &nbsp;<asp:RadioButton ID="rdoNo" runat="server" GroupName="rdo" 
                           Text="否" Checked="True" />
               </td>
           </tr>
       </table>
       </fieldset>
       </div>
       <div id="function" align="right">

                 <asp:ImageButton ID="ImgBtnSeach" runat="server" 
                     ImageUrl="~/images/chaxun_03.jpg" onclick="ImgBtnSeach_Click"  />

               
                 <asp:ImageButton ID="ImgBtnall" runat="server" 
                     ImageUrl="~/images/chaxunsuoyou.jpg" onclick="ImgBtnall_Click" 
                       />

                 <asp:ImageButton ID="ImgBtnAdd" runat="server" 
                     ImageUrl="~/images/tianjia_03.jpg" onclick="ImgBtnAdd_Click"   />

                 <asp:ImageButton ID="ImageButton1" runat="server" 
                     ImageUrl="~/images/daochuExcel.jpg" onclick="ImageButton1_Click" 
                       />

               
                 </div>
       <div id="send" >
           <asp:GridView ID="GVCuoSEnd" runat="server" CellPadding="4" ForeColor="#333333" CssClass="Grid"
               GridLines="None" Width="741px" AutoGenerateColumns="False"   
               align="center" 
               onrowcommand="GVCuoSEnd_RowCommand" onrowdatabound="GVCuoSEnd_RowDataBound" 
               PageSize="5">
               <RowStyle BackColor="#EFF3FB" />
               <Columns>
                   <asp:TemplateField HeaderText="客户">
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("Ccustomer.CusName") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="CEid" Visible="False" />
                   <asp:BoundField DataField="ECount" HeaderText="派件的个数" />
                   <asp:BoundField DataField="EAllPrice" HeaderText="派件邮费" />
                   <asp:BoundField DataField="Issettle" HeaderText="是否结算" />
                   <asp:BoundField DataField="Edate" HeaderText="派件年月" />
                   <asp:BoundField DataField="Remark" HeaderText="备注" />
                   <asp:TemplateField HeaderText="编辑">
                       <ItemTemplate>
                           <asp:ImageButton ID="ImgBtnUpd" runat="server" CommandName="Upd" 
                               ImageUrl="~/images/edit.gif" 
                               CommandArgument='<%# Eval("CEid") %>' />
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="删除">
                       <ItemTemplate>
                           <asp:ImageButton ID="ImgBtnDel" runat="server" CommandName="Del" 
                               ImageUrl="~/images/delete.gif" 
                               CommandArgument='<%# Eval("CEid") %>' />
                       </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                   HorizontalAlign="Center" />
               <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
               <EmptyDataTemplate>
                   没有查询到该条记录！！！！
               </EmptyDataTemplate>
               <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
               <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                   HorizontalAlign="Center" />
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
