<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Info.aspx.cs" Inherits="FootTable_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvinfo" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="objinfo" PageSize="5">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="CPid" HeaderText="CPid" SortExpression="CPid" />
                <asp:BoundField DataField="CusID" HeaderText="CusID" SortExpression="CusID" />
                <asp:BoundField DataField="DateMon" HeaderText="DateMon" 
                    SortExpression="DateMon" />
                <asp:BoundField DataField="OddMon" HeaderText="OddMon" 
                    SortExpression="OddMon" />
                <asp:BoundField DataField="SendMon" HeaderText="SendMon" 
                    SortExpression="SendMon" />
                <asp:BoundField DataField="GiveMon" HeaderText="GiveMon" 
                    SortExpression="GiveMon" />
                <asp:BoundField DataField="BackMon" HeaderText="BackMon" 
                    SortExpression="BackMon" />
                <asp:BoundField DataField="AccMon" HeaderText="AccMon" 
                    SortExpression="AccMon" />
                <asp:BoundField DataField="OtherMon" HeaderText="OtherMon" 
                    SortExpression="OtherMon" />
                <asp:BoundField DataField="AllMon" HeaderText="AllMon" 
                    SortExpression="AllMon" />
                <asp:CheckBoxField DataField="ISsettle" HeaderText="ISsettle" 
                    SortExpression="ISsettle" />
                <asp:BoundField DataField="Remark" HeaderText="Remark" 
                    SortExpression="Remark" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="objinfo" runat="server" 
            SelectMethod="GetAllCustomerPianTB" TypeName="ZDDB.BLL.CustomerPianManager"></asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
