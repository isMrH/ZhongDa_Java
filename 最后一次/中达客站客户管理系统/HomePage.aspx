<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>中达货站客户管理系统</title>
    <link href="CSS/HomePage.css" rel="stylesheet" type="text/css" />

    <script src="JS/Clock.js" type="text/javascript"></script>
    <script type="text/javascript" src="JS/LeftJScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="father">
        <div class="banner">
            
        </div>
        <div class="menu">
              <div class="Exit">
             <asp:Label ID="Label1" runat="server" Font-Bold="False" 
                     Text="欢迎您：" Font-Size="Small" ForeColor="#2162A0"></asp:Label>
                 <asp:Label ID="lblName" runat="server"></asp:Label> &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                 <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="当前时间:" 
                      Font-Size="Small" ForeColor="#2162A0"></asp:Label></asp:Label><span
                id="clock"></span>
                
                <script type="text/javascript">
                    var clock = new Clock();
                    clock.display(document.getElementById("clock"));
            </script>

                  <asp:Label ID="Label3" runat="server" 
                      Text="&lt;a href=&quot;Login.aspx&quot;&gt;注销&lt;/a&gt;" Font-Size="Small"></asp:Label>
             
             </div>
        </div>
        <div class="main">
        
        <div class="left">
            <div style="width: 204px; height: 463px; background-image: url('Images/leftBg.jpg');
        background-repeat: repeat-y; margin: 0 auto;">
        <div id="LeftTop">
        </div>
        <div class="Tab">
            <div class="title">
                <a href="#" onclick="Tab('b','bx',11,1)" class="n1" id="b1"><span>客户管理</span></a></div>
            <div class="tabcon">
                <ul id="bx1">
                    <li id="IdBanLiRuZhu" runat="server"><a href="Customers/UpdateOrEditCustomer.aspx" target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />客户增改</a></li>
                    <li id="IdBookInfo" runat="server"><a href="Customers/SelectCustomers.aspx" target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />客户查询</a></li>
                </ul>
                <div class="line">
                </div>
                <div class="title">
                    <a href="#" onclick="Tab('b','bx',11,2)" class="n2" id="b2"><span>承运公司管理</span></a></div>
                <ul id="bx2" style="display: none;">
                    <li id="IdDepositInfo" runat="server"><a href="CarrieCompany/CarrieCompanyRegister.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />承运公司增改</a></li>
                    <li id="IdElderCost" runat="server"><a href="CarrieCompany/SelectCarrieCompany.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />承运公司查询</a></li>
                </ul>
                <div class="line">
                </div>
                <div class="title">
                    <a href="#" onclick="Tab('b','bx',11,3)" class="n2" id="b3"><span>面单号管理</span></a></div>
                <ul id="bx3" style="display: none;">
                    <li id="IdBedRate" runat="server"><a href="CarrieCompany/SelectCarrieCompany.aspx" target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />面单号设置</a></li>
                    <li id="IdNurseRate" runat="server"><a href="FaxeList/GviRegisterTB.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />面单购入登记</a></li>
                    <li id="IdFoodRate" runat="server"><a href="FaxeList/DisNoteTB.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />面单分配管理</a></li>
                    <li id="IdPhaseRate" runat="server"><a href="FaxeList/ListPrice.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />面单费用查询</a></li>
                </ul>
                <div class="line">
                </div>
                <div class="title">
                    <a href="#" onclick="Tab('b','bx',11,4)" class="n2" id="b4"><span>运费结算管理</span></a></div>
                <ul id="bx4" style="display: none;">
                    <li id="IdRestHome" runat="server"><a href="PriceManager/CustomerPrice/Price.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />价格模板管理</a></li>
                    <li id="IdBuilding" runat="server"><a href="PriceManager/CustomerPrice/SelectCustomerPrice.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />运费价格设置</a></li>
                    <li id="IdRoomType" runat="server"><a href="PriceManager/CarriageMoney/CustomerSent.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />运费结算管理</a></li>
                </ul>
                <div class="line">
                </div>
                <div class="title">
                    <a href="#" onclick="Tab('b','bx',11,5)" class="n2" id="b5"><span>揽发到付件管理</span></a></div>
                <ul id="bx5" style="display: none;">
                    <li id="IdDongJi" runat="server"><a href="AcceptandSent/Sent.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />揽发到付件增删改</a></li>
                    <li id="IdBedTongJi" runat="server"><a href="AcceptandSent/SentShow.aspx" target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />揽发到付件查询</a></li>
                </ul>
                <div class="line">
                </div>
                <div class="title">
                    <a href="#" onclick="Tab('b','bx',11,6)" class="n2" id="b6"><span>派收到付件管理</span></a></div>
                <ul id="bx6" style="display: none;">
                    <li id="IdFamilyInfo" runat="server"><a href="AcceptandSent/Accept.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />派收到付件增删改</a></li>
                    <li id="IdLiveInfo" runat="server"><a href="AcceptandSent/AcceptShow.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />派收到付件查询</a></li>
                </ul>
                <div class="line">
                </div>
                <div class="title">
                    <a href="#" onclick="Tab('b','bx',11,7)" class="n2" id="b7"><span>送货费管理</span></a></div>
                <ul id="bx7" style="display: none;">
                    <li id="Li4" runat="server"><a href="DelGoodsMonTB/GVDelGoodsMonTB.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />送货价格设置</a></li>
                    <li id="Li5" runat="server"><a href="DelGoodsMonTB/CustomerSendTB.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />送件数管理</a></li>
                </ul>
                <div class="line">
                </div>
                <div class="title">
                    <a href="#" onclick="Tab('b','bx',11,8)" class="n2" id="b8"><span>其他收支管理</span></a></div>
                <ul id="bx8" style="display: none;">
                    <li id="Li7" runat="server"><a href="IAE/AddIAE.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />收支增删改</a></li>
                    <li id="Li8" runat="server"><a href="IAE/SelectIAE.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />收支查询</a></li>
                </ul>
                <div class="line">
                </div>
                <div class="title">
                    <a href="#" onclick="Tab('b','bx',11,9)" class="n2" id="b9"><span>结算报表</span></a></div>
                <ul id="bx9" style="display: none;">
                    <li id="Li10" runat="server"><a href="FootTable/FootInfo.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />月结算报表</a></li>
                </ul>
                <div class="line">
                </div>
                <div class="title">
                    <a href="#" onclick="Tab('b','bx',11,10)" class="n2" id="b10"><span>系统管理</span></a></div>
                <ul id="bx10" style="display: none;">
                    <li id="Li13" runat="server"><a href="Administrator/SMS.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />用户管理</a></li>
                    <li id="Li14" runat="server"><a href="Administrator/DataManager.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />数据备份恢复</a></li>
                    <li id="Li15" runat="server"><a href="Administrator/Operation.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />个人信息管理</a></li>
                    <li id="Li1" runat="server"><a href="Administrator/Register.aspx"
                        target="right_ifam">
                        <img src="Images/h1.jpg" style="border: none; margin-right: 3px;" />管理员注册</a></li>
                </ul>
            </div>
        </div>
    </div>
    </div>   
            <div class="right">

                <iframe class="info" src="FootTable/FootInfo.aspx" id="right_ifam" name="right_ifam" frameborder="0" scrolling="auto"></iframe>

            </div>
        </div>
        
        <div class="floor">
        <div class="Copy">
        石家庄职业技术学院软件学院<br />14级软件班最强王者 黄超 段浩 白少杰 杨立君 李兰兰 谷恒远<br />辅导老师 赵阳</div>
        </div>
        </div>
    </form>
</body>
</html>
