<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GviRegisterTB.aspx.cs" Inherits="FaxeList_GviRegisterTB" %>

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
            height: 30px;
            width: 733px;
        }
        #SearchAllR
        {
        	margin-left:25px;
        	font-size:12px;
        }
     
        #Main
        {
        	text-align:center;
        }
        #ye
        {
        	text-align:center;
        }
    </style>
</head>
<body>
 <div id="Wapper">
    <form id="form1" runat="server">
   
    <div class="Title"><b>面单管理设置</b></div>

       <div id="SearchAllR"> &nbsp;&nbsp;&nbsp;<table class="style1">
            <tr>
               <td class="style1">
               <fieldset>
                  <legend><asp:Image ID="Image1" runat="server" Height="16px" 
                ImageUrl="~/images/ico06.png" Width="18px" />搜索</legend>
                   承运公司：<asp:DropDownList ID="ddlCompany" runat="server" Height="22px" 
                     Width="90px" AppendDataBoundItems="True">
                     <asp:ListItem Value="0">--请选择--</asp:ListItem>
                     
                 </asp:DropDownList>
                   面单号：<asp:TextBox ID="txtBegin" runat="server" BorderColor="#D0DEDE" 
                       BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="92px"></asp:TextBox>
                   <asp:CompareValidator ID="CompareValidator5" runat="server" 
                       ControlToValidate="txtBegin" Display="Dynamic" ErrorMessage="面单起始号必须数字" 
                       Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>
                   至<asp:TextBox ID="txtEnd" runat="server" BorderColor="#D0DEDE" 
                       BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="99px"></asp:TextBox>
                   <asp:CompareValidator ID="CompareValidator2" runat="server" 
                       ControlToValidate="txtEnd" Display="Dynamic" ErrorMessage="面结束始号必须数字" 
                       Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>
              
                   日期（日）：<asp:TextBox ID="txtDate" class="Wdate" 
                           onFocus="new WdatePicker(this,'%Y-%M-%D ',true,'default')" runat="server" 
                           Height="20px" Width="80px" BorderStyle="Solid" BorderColor="#D0DEDE" 
                       BorderWidth="1" ></asp:TextBox>
                   <asp:CompareValidator ID="CompareValidator3" runat="server" 
                       ControlToValidate="txtDate" ErrorMessage="输入的必须是日期" Operator="DataTypeCheck" 
                       Type="Date">*</asp:CompareValidator>
                   至 
                   <asp:TextBox ID="txtDate2" class="Wdate" 
                           onFocus="new WdatePicker(this,'%Y-%M-%D ',true,'default')" runat="server" 
                           Height="20px" Width="80px" BorderStyle="Solid" BorderColor="#D0DEDE" 
                       BorderWidth="1" ></asp:TextBox>
                   <asp:CompareValidator ID="CompareValidator4" runat="server" 
                       ControlToValidate="txtDate2" ErrorMessage="输入的必须是日期" Operator="DataTypeCheck" 
                       Type="Date">*</asp:CompareValidator>
                       </fieldset>
               </td>
           </tr>
           <tr>
               
          
               <td class="style1">
                  
                   <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="740px" 
                       Height="35px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
             <div id="function" align="right">
     
                 <asp:ImageButton ID="ImgBtnSeach" runat="server" 
                     ImageUrl="~/images/chaxun_03.jpg" onclick="ImgBtnSeach_Click"/>


                 <asp:ImageButton ID="ImgBtnall" runat="server" 
                     ImageUrl="~/images/chaxunsuoyou.jpg" onclick="ImgBtnall_Click" 
                       />
                 
   
                 <asp:ImageButton ID="ImgBtnAdd" runat="server" 
                     ImageUrl="~/images/tianjia_03.jpg" onclick="ImgBtnAdd_Click" />

                 <asp:ImageButton ID="ImageButton1" runat="server" 
                     ImageUrl="~/images/daochuExcel.jpg" onclick="ImageButton1_Click"/>
           

                 </div>
                
                 <div id="Main">
                  <asp:GridView ID="GvRegister" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                         CellPadding="4" ForeColor="#333333" GridLines="None" BackColor="White" BorderColor="#6699FF" 
                         BorderStyle="Solid" BorderWidth="1px" 
                         onrowdatabound="GvRegister_RowDataBound" DataKeyNames="Rid" 
                         onrowcommand="GvRegister_RowCommand" Width="740px" >
                      <PagerSettings Mode="NextPreviousFirstLast" NextPageText="" 
                          PageButtonCount="1" />
                      <RowStyle BackColor="#EFF3FB" />
                      <Columns>
                          <asp:BoundField DataField="Rid" HeaderText="面单Id" Visible="False" />
                          <asp:BoundField DataField="Cid" HeaderText="承运公司Id" Visible="False" />
                          <asp:TemplateField HeaderText="承运公司">
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="Label1" runat="server" Text='<%# Eval("CCompany.CoName") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="BeginNo" HeaderText="面单起始号" />
                          <asp:BoundField DataField="EndNo" HeaderText="面单结束号" />
                          <asp:BoundField DataField="Buydate" HeaderText="日期" 
                              DataFormatString="{0:yyyy-MM-dd}" />
                          <asp:TemplateField HeaderText="备注">
                              <ItemTemplate>
                                  <asp:Label ID="Label2" runat="server" Text='<%# Cut(Eval("Remark")) %>'></asp:Label>
                              </ItemTemplate>
                              <EditItemTemplate>
                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Remark") %>'></asp:TextBox>
                              </EditItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="编辑">
                              <ItemTemplate>
                                  <asp:ImageButton ID="ImgBtnUpd" runat="server" 
                                      CommandArgument='<%# Eval("Rid") %>' CommandName="Upd" 
                                      ImageUrl="~/images/edit.gif" />
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="删除">
                              <ItemTemplate>
                                  <asp:ImageButton ID="ImgBtnDel" runat="server" 
                                      CommandArgument='<%# Eval("Rid") %>' CommandName="Del" 
                                      ImageUrl="~/images/delete.gif" />
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                      <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                      <EmptyDataTemplate>
                          没有查询到该条记录!!!!!!
                      </EmptyDataTemplate>
                      <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                      <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                      <EditRowStyle BackColor="#2461BF" HorizontalAlign="Center" 
                          VerticalAlign="Middle" />
                      <AlternatingRowStyle BackColor="White" />
                 </asp:GridView>
                 <br />
                     
                 </div>
                <div id="ye">
                   <webdiyer:AspNetPager ID="anpPage" runat="server" AlwaysShow="True" 
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" NumericButtonCount="5" 
                        onpagechanged="anpPage_PageChanged" PrevPageText="上一页" 
                        ShowCustomInfoSection="Right" ShowInputBox="Always" SubmitButtonText="跳转">
                     </webdiyer:AspNetPager>
                </div>
         
   
    </form>
    </div>
</body>
</html>
