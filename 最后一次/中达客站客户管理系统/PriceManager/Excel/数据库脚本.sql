use master
if exists(select * from sysdatabases where [name]='ZDDB')
   drop database ZDDB
go
create database ZDDB
go
use ZDDB

go
--建立客户表
if exists(select * from sysobjects where [name]='CustomersTB')
   drop table CustomersTB
go
create table CustomersTB
(
    CusID int identity(1001,1) primary key not null,--客户ID
    CusName varchar(20) not null,--客户姓名
    CusTel varchar(20) check(CusTel like '1[3578][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') not null,--客户电话
    IsCounterman bit check(IsCounterman=0 or IsCounterman=1) default 0,--是否为业务员,0不是业务员,1是业务员
    Remark varchar(100),--备注
)
go



--建立承运公司表
if exists(select * from sysobjects where [name]='CarrieCompanyTB')
   drop table CarrieCompanyTB
go
create table CarrieCompanyTB
(
     Cid int identity(1,1) primary key not null,-- 承运公司ID
     CoName varchar(20) not null,--承运公司名称
     Clinkman varchar(20) not null,--联系人
     LinkmanTel varchar(20) check(LinkmanTel like '1[3578][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') not null,--联系电话
     Cmoney money default 0,--面单费,默认为0
     Remark varchar(100),--备注
)
go



--建立面单购买登记表
if exists(select * from sysobjects where [name]='RegisterTB')
   drop table RegisterTB
go
create table RegisterTB
(
      Rid int identity(1,1) primary key not null,--面单购买ID
      Cid int foreign key references CarrieCompanyTB(Cid)  not null,--公司ID
      BeginNo bigint not null,--面单起始号
      EndNo bigint not null,--面单结束号
      Buydate datetime default getdate() not null,--购买时间
      Remark varchar(100),--备注
)
go



--面单分配记录表
if exists(select * from sysobjects where [name]='DisNoteTB')
   drop table DisNoteTB
go
create table DisNoteTB
(
      Nid int identity(1,1) primary key not null,--面单分配ID
      CusID int foreign key references CustomersTB(CusID) not null,--客户ID
      Cid int foreign key references CarrieCompanyTB(Cid) not null,--公司ID
      BeginNO bigint not null,--面单起始号
      EndNo bigint not null,--面单结束号
      Dtime datetime default getdate() not null,--分配时间
      [Sum] money default 0 not null,--金额
      IsSet bit check (IsSet=0 or IsSet=1) default 0 not null,--是否已结算,0表示没有结算,1表示结算了
      Remark varchar(100),--备注
)
go


--建立价格模板
if exists(select * from sysobjects where [name]='PriceTB')
   drop table PriceTB
go
create table PriceTB
(
      Pid int identity(1,1) primary key not null,--价格模板ID
      PNo varchar(10) not null,--模板编号
      Destination varchar(20) not null,--目的地（省）
      Kilo float default 0.0 not null,--公斤数
      Price money default 0 not null,--价格
      Remark varchar(100),--备注
)
go
--建立客户价格表
if exists(select * from sysobjects where [name]='CustomerPriceTB')
   drop table CustomerPriceTB
go
create table CustomerPriceTB
(
      Cpid int identity(1,1) primary key not null,--客户价格ID号
      CusID int foreign key references CustomersTB(CusID)  not null,--客户ID
      Cid int foreign key references CarrieCompanyTB(Cid) not null,--承运公司ID
      PNo varchar(10) not null,--模板编号
      CpName varchar(50) not null,--价格模板名称
      Remark varchar(100) ,--备注
)

--客户发件表
if exists(select * from sysobjects where [name]='CustomerSentTB')
   drop table CustomerSentTB
go
create table CustomerSentTB
(
      CSid  int identity(1,1) primary key not null,--客户发件ID
      Rid bigint not null,--面单号
      CusID int ,--客户ID
      Cid int ,--承运公司ID
      Destination varchar(50) not null,--目的地（省）
      Kilo float default 0.0 not null,--公斤数
      Price money default 0 not null,--运费
      Resdate datetime default getdate() not null,--揽件时间
      IsSet bit default 0 check(IsSet=0 or IsSet=1) not null,--是否已结算
      Remark varchar(100),--备注
)
go
--揽发到付件表
if exists(select * from sysobjects where [name]='SentTB')
   drop table SentTB
go
create table SentTB
(
      [Sid] int identity(1,1) primary key not null,--揽发到付件表ID
      CusID int foreign key references CustomersTB(CusID) not null,--客户ID
      Cid int foreign key references CarrieCompanyTB(Cid) not null,-- 承运公司ID
      CSid bigint not null,--面单号
      Kilo float default 0.0 not null,--重量
      Price money default 0.0 not null,--金额
      ISsettle bit check(ISsettle=0 or ISsettle=1) default 0 not null,--是否已结款,0表示没有结算，1表是结算了
      BeginDate datetime not null,--起运时间
      Remark varchar(100),--备注
)
go
--揽收到付件
if exists(select * from sysobjects where [name]='AcceptTB')
   drop table AcceptTB
go
create table AcceptTB
(
     Aid int identity(1,1) primary key not null,--派收到付件ID
     CusID int foreign key references CustomersTB(CusID) not null,--客户ID
     Cid int foreign key references CarrieCompanyTB(Cid) not null,-- 承运公司ID
     CSid bigint not null,--面单号
     Price money not null,--金额
     ISsettle bit check(ISsettle=0 or ISsettle=1) default 0 not null,--是否已结款,0表示没有结算，1表是结算了
     BeginDate datetime  default(getdate()),--起运日期
     Remark varchar(150) --备注
    
)
go
--建立  送货价格表DelGoodsMonTB
if exists(select * from sysobjects where [name]='DelGoodsMonTB')
   drop table DelGoodsMonTB
go
create table DelGoodsMonTB
(
     DelID int identity(1,1) primary key not null ,--送货价格id
     CusID int foreign key references CustomersTB(CusID) not null,--客户id
     DelUnitPrice money default 0 not null ,--送货单价
     Remark varchar(150) --备注
)
go
--建立客户送件表
if exists(select * from sysobjects where [name]='CustomerSendTB')
   drop table CustomerSendTB
go
create table CustomerSendTB
(
     CEid int identity(1,1) primary key not null,--客户送件表ID
     CusID int foreign key references CustomersTB(CusID) not null,--客户id
     ECount int default 0 not null ,--派送的个数
     EAllPrice money default 0 not null ,--派件邮费
     ISsettle bit check(ISsettle=0 or ISsettle=1) default 0 not null,--是否已结款,0表示没有结算，1表是结算了
     EDate datetime not null,--派件年月
     Remark varchar(150) --备注
)
go
--建立income and expenses其他收支管理表
if exists(select * from sysobjects where [name]='IAEManagerTB')
   drop table IAEManagerTB
go
create table IAEManagerTB
( 
      IAEid int identity(1,1) primary key not null,--管理表ID
      CusID int foreign key references CustomersTB(CusID) not null,--客户id 
      IAEDate datetime not null,--收支日期
      IAEName varchar(20) not null,--费用名称
      Price money default 0 not  null,--j金额（正负）
      ISsettle bit check(ISsettle=0 or ISsettle=1) default 0 not null,--是否已结款,0表示没有结算，1表是结算了
      Remark varchar(150) --备注
     
)
go
--建立客户费用结算表
if exists(select * from sysobjects where [name]='CustomerPianTB')
   drop table CustomerPianTB
go
create table CustomerPianTB
(
     CPid int identity(1,1) primary key not null,--结算表ID
     CusID int foreign key references CustomersTB(CusID) not null,--客户id 
     DateMon datetime not null,--费用年月
     OddMon money default 0 not null,--面单费用
     SendMon money default 0 not null,--发件费
     GiveMon money default 0 not null,--送件费
     BackMon money default 0 not null,--收到付件返利
     AccMon money default 0 not null,--派收到付件款
     OtherMon money default 0 not null,--其它费用
     AllMon money default 0 not null,--总计
     ISsettle bit check(ISsettle=0 or ISsettle=1) default 0 not null,--是否已结款,0表示没有结算，1表是结算了
     Remark varchar(150) --备注
)
go
--用户登录信息表UserInfoTB
if exists(select * from sysobjects where [name]='UserInfoTB')
   drop table UserInfoTB
go
create table UserInfoTB
(
    UID int identity(1,1) primary key not null,--用户id
    LoginId varchar(50) not null,--登陆账号
    [Password] varchar(50) not null,--密码
    Telephone varchar(50) check(Telephone like '1[3578][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') not null,--电话
    Email varchar(50) check(Email like '%@%') not null,--email
    Question varchar(100) not null,--密保问题
    AKey varchar(100) not null,--问题答案
    Remark varchar(150) --备注
  
)
go
--往客户表中插入数据
insert into CustomersTB values('张文','13830892234',1,null)
insert into CustomersTB values('杨洋','13834562234',1,null)
insert into CustomersTB values('乐乐','15830892234',1,null)
insert into CustomersTB values('珊珊','17830892234',0,null)
insert into CustomersTB values('依依','18830894567',0,null)
go
select * from CustomersTB
go
--往承运公司表插入数据
go
insert into CarrieCompanyTB values('韵达','苏安然','13562789028',2,null)
insert into CarrieCompanyTB values('中通','张森','15273894036',5,null)
insert into CarrieCompanyTB values('申通','李瑞强','17283904678',4,null)
insert into CarrieCompanyTB values('顺丰','淼淼','18263748903',3,null)
go
select * from CarrieCompanyTB
go
--往面单购买登记表中插入数据
insert into RegisterTB values(1,1900903581900,1900903581980,'2015-12-02',null)
insert into RegisterTB values(4,2900903581100,2900903581220,'2015-11-15',null)
insert into RegisterTB values(3,3900903581875,3900903581990,'2015-12-14',null)
insert into RegisterTB values(1,1900903581980,1900903582100,'2016-12-08',null)
insert into RegisterTB values(1,1900879699134,1900879699134,'2016-01-07',null)
insert into RegisterTB values(1,1900838887588,1900838887588,'2016-01-08',null)

go
select * from RegisterTB

--往分配表中插入数据
insert into DisNoteTB values(1001,1,1900903581909,1900903581999,'2015-01-23',300,0,null)
insert into DisNoteTB values(1001,1,1900903581910,1900903581920,'2015-01-23',300,0,null)
insert into DisNoteTB values(1001,1,1900855992482,1900855992482,'2015-01-23',300,0,null)
insert into DisNoteTB values(1001,1,1900917332001,1900917332008,'2015-01-23',300,0,null)
go
select * from DisNoteTB

--往客户价格表里插入数据
insert into CustomerPriceTB values(1001,1,'YD01','张文韵达',null)
insert into CustomerPriceTB values(1001,3,'ZT01','张文申通',null)
insert into CustomerPriceTB values(1002,1,'YD02','杨洋韵达',null)
go
select * from CustomerPriceTB

--往其他收支管理表中插入数据
insert into IAEManagerTB values(1001,'2016-01-01','维修费',23,0,null)
insert into IAEManagerTB values(1003,'2015-12-01','交通费',12,0,null)
insert into IAEManagerTB values(1002,'2016-01-05','伙食费',10,0,null)

--往用户信息表里插入数据
insert into UserInfoTB values('admin','admin','13253674656','admin@qq.com','你的生日是哪天','1985-02-26',null)
insert into UserInfoTB values('sa','sa','13223674656','sa@sina.com','你最喜欢的明星是谁','李敏镐',null)
insert into UserInfoTB values('boss','666666','15653674656','boss@qq.com','你的外号是什么','男神',null)
go
select * from UserInfoTB
