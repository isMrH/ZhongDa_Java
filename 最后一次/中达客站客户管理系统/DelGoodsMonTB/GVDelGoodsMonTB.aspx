<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GVDelGoodsMonTB.aspx.cs" Inherits="DelGoodsMonTB_GVDelGoodsMonTB" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/iFram.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        #function
        {
        	margin-top:10px;
            height: 21px;
        }
        #customer
        {
            height: 35px;
        }
        #Main
        {
        	text-align:center;
        }
        #DelGoodsMon
        {
        	text-align:center;
        }
    </style>

</head>
<body>
<div id="Wapper">
    <form id="form1" runat="server">
    <div class="Title">送货费管理</div>
    <div class="Main">
     <fieldset>
     <legend><asp:Image ID="Image1" runat="server" ImageUrl="~/images/ico06.png" 
                Height="16px" Width="16px" />搜索</legend>
       <div id="customer">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 客户：<asp:DropDownList ID="ddlCustomer" runat="server" Height="23px" 
               Width="156px">
           </asp:DropDownList>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
           送货价格：<asp:TextBox ID="txtmoney" runat="server"  Height="20px" 
                           Width="150px" BorderStyle="Solid" BorderColor="#D0DEDE" BorderWidth="1" 
                           AutoPostBack="True"></asp:TextBox>
       </div>
       </fieldset>
       <div id="function" align="right">

                 <asp:ImageButton ID="ImageButton1" runat="server" 
                     ImageUrl="~/images/daochuExcel.jpg" onclick="ImageButton1_Click"  
                       />


                 <asp:ImageButton ID="ImgBtnall" runat="server" 
                     ImageUrl="~/images/chaxunsuoyou.jpg" onclick="ImgBtnall_Click" 
                       />


                 <asp:ImageButton ID="ImgBtnAdd" runat="server" 
                     ImageUrl="~/images/tianjia_03.jpg" onclick="ImgBtnAdd_Click"  />

                 <asp:ImageButton ID="ImgBtnSeach" runat="server" 
                     ImageUrl="~/images/chaxun_03.jpg" onclick="ImgBtnSeach_Click" />

               
                 </div>
       <div id="DelGoodsMon">
           <asp:GridView ID="gvGoods" runat="server" CellPadding="4" ForeColor="#333333" CssClass="Grid"
               GridLines="None" Width="756px" AutoGenerateColumns="False"
               onrowcommand="gvGoods_RowCommand" 
               onrowdatabound="gvGoods_RowDataBound1" 
           PageSize="5" >
               <RowStyle BackColor="#EFF3FB" />
               <Columns>
                   <asp:BoundField DataField="DelID" Visible="False" />
                   <asp:TemplateField HeaderText="客户">
                       <EditItemTemplate>
                           <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                       </EditItemTemplate>
                       <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("Customer.CusName") %>'></asp:Label>
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:BoundField DataField="DelUnitPrice" HeaderText="送货单价" />
                   <asp:BoundField DataField="Remark" HeaderText="备注" />
                   <asp:TemplateField HeaderText="编辑">
                       <ItemTemplate>
                           <asp:ImageButton ID="ImgBtnUpd" runat="server" 
                               CommandArgument='<%# Eval("DelID") %>' CommandName="Upd" Height="18px" 
                               ImageUrl="~/images/edit.gif" Width="18px" />
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="删除">
                       <ItemTemplate>
                           <asp:ImageButton ID="ImgBtnDel" runat="server" 
                               CommandArgument='<%# Eval("DelID") %>' CommandName="Del" Height="15px" 
                               ImageUrl="~/images/delete.gif" Width="18px" />
                       </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
               <EmptyDataTemplate>
                   没有查询到该条记录！！！！！
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
