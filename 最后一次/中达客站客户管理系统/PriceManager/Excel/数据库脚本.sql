use master
if exists(select * from sysdatabases where [name]='ZDDB')
   drop database ZDDB
go
create database ZDDB
go
use ZDDB

go
--�����ͻ���
if exists(select * from sysobjects where [name]='CustomersTB')
   drop table CustomersTB
go
create table CustomersTB
(
    CusID int identity(1001,1) primary key not null,--�ͻ�ID
    CusName varchar(20) not null,--�ͻ�����
    CusTel varchar(20) check(CusTel like '1[3578][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') not null,--�ͻ��绰
    IsCounterman bit check(IsCounterman=0 or IsCounterman=1) default 0,--�Ƿ�Ϊҵ��Ա,0����ҵ��Ա,1��ҵ��Ա
    Remark varchar(100),--��ע
)
go



--�������˹�˾��
if exists(select * from sysobjects where [name]='CarrieCompanyTB')
   drop table CarrieCompanyTB
go
create table CarrieCompanyTB
(
     Cid int identity(1,1) primary key not null,-- ���˹�˾ID
     CoName varchar(20) not null,--���˹�˾����
     Clinkman varchar(20) not null,--��ϵ��
     LinkmanTel varchar(20) check(LinkmanTel like '1[3578][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') not null,--��ϵ�绰
     Cmoney money default 0,--�浥��,Ĭ��Ϊ0
     Remark varchar(100),--��ע
)
go



--�����浥����ǼǱ�
if exists(select * from sysobjects where [name]='RegisterTB')
   drop table RegisterTB
go
create table RegisterTB
(
      Rid int identity(1,1) primary key not null,--�浥����ID
      Cid int foreign key references CarrieCompanyTB(Cid)  not null,--��˾ID
      BeginNo bigint not null,--�浥��ʼ��
      EndNo bigint not null,--�浥������
      Buydate datetime default getdate() not null,--����ʱ��
      Remark varchar(100),--��ע
)
go



--�浥�����¼��
if exists(select * from sysobjects where [name]='DisNoteTB')
   drop table DisNoteTB
go
create table DisNoteTB
(
      Nid int identity(1,1) primary key not null,--�浥����ID
      CusID int foreign key references CustomersTB(CusID) not null,--�ͻ�ID
      Cid int foreign key references CarrieCompanyTB(Cid) not null,--��˾ID
      BeginNO bigint not null,--�浥��ʼ��
      EndNo bigint not null,--�浥������
      Dtime datetime default getdate() not null,--����ʱ��
      [Sum] money default 0 not null,--���
      IsSet bit check (IsSet=0 or IsSet=1) default 0 not null,--�Ƿ��ѽ���,0��ʾû�н���,1��ʾ������
      Remark varchar(100),--��ע
)
go


--�����۸�ģ��
if exists(select * from sysobjects where [name]='PriceTB')
   drop table PriceTB
go
create table PriceTB
(
      Pid int identity(1,1) primary key not null,--�۸�ģ��ID
      PNo varchar(10) not null,--ģ����
      Destination varchar(20) not null,--Ŀ�ĵأ�ʡ��
      Kilo float default 0.0 not null,--������
      Price money default 0 not null,--�۸�
      Remark varchar(100),--��ע
)
go
--�����ͻ��۸��
if exists(select * from sysobjects where [name]='CustomerPriceTB')
   drop table CustomerPriceTB
go
create table CustomerPriceTB
(
      Cpid int identity(1,1) primary key not null,--�ͻ��۸�ID��
      CusID int foreign key references CustomersTB(CusID)  not null,--�ͻ�ID
      Cid int foreign key references CarrieCompanyTB(Cid) not null,--���˹�˾ID
      PNo varchar(10) not null,--ģ����
      CpName varchar(50) not null,--�۸�ģ������
      Remark varchar(100) ,--��ע
)

--�ͻ�������
if exists(select * from sysobjects where [name]='CustomerSentTB')
   drop table CustomerSentTB
go
create table CustomerSentTB
(
      CSid  int identity(1,1) primary key not null,--�ͻ�����ID
      Rid bigint not null,--�浥��
      CusID int ,--�ͻ�ID
      Cid int ,--���˹�˾ID
      Destination varchar(50) not null,--Ŀ�ĵأ�ʡ��
      Kilo float default 0.0 not null,--������
      Price money default 0 not null,--�˷�
      Resdate datetime default getdate() not null,--����ʱ��
      IsSet bit default 0 check(IsSet=0 or IsSet=1) not null,--�Ƿ��ѽ���
      Remark varchar(100),--��ע
)
go
--������������
if exists(select * from sysobjects where [name]='SentTB')
   drop table SentTB
go
create table SentTB
(
      [Sid] int identity(1,1) primary key not null,--������������ID
      CusID int foreign key references CustomersTB(CusID) not null,--�ͻ�ID
      Cid int foreign key references CarrieCompanyTB(Cid) not null,-- ���˹�˾ID
      CSid bigint not null,--�浥��
      Kilo float default 0.0 not null,--����
      Price money default 0.0 not null,--���
      ISsettle bit check(ISsettle=0 or ISsettle=1) default 0 not null,--�Ƿ��ѽ��,0��ʾû�н��㣬1���ǽ�����
      BeginDate datetime not null,--����ʱ��
      Remark varchar(100),--��ע
)
go
--���յ�����
if exists(select * from sysobjects where [name]='AcceptTB')
   drop table AcceptTB
go
create table AcceptTB
(
     Aid int identity(1,1) primary key not null,--���յ�����ID
     CusID int foreign key references CustomersTB(CusID) not null,--�ͻ�ID
     Cid int foreign key references CarrieCompanyTB(Cid) not null,-- ���˹�˾ID
     CSid bigint not null,--�浥��
     Price money not null,--���
     ISsettle bit check(ISsettle=0 or ISsettle=1) default 0 not null,--�Ƿ��ѽ��,0��ʾû�н��㣬1���ǽ�����
     BeginDate datetime  default(getdate()),--��������
     Remark varchar(150) --��ע
    
)
go
--����  �ͻ��۸��DelGoodsMonTB
if exists(select * from sysobjects where [name]='DelGoodsMonTB')
   drop table DelGoodsMonTB
go
create table DelGoodsMonTB
(
     DelID int identity(1,1) primary key not null ,--�ͻ��۸�id
     CusID int foreign key references CustomersTB(CusID) not null,--�ͻ�id
     DelUnitPrice money default 0 not null ,--�ͻ�����
     Remark varchar(150) --��ע
)
go
--�����ͻ��ͼ���
if exists(select * from sysobjects where [name]='CustomerSendTB')
   drop table CustomerSendTB
go
create table CustomerSendTB
(
     CEid int identity(1,1) primary key not null,--�ͻ��ͼ���ID
     CusID int foreign key references CustomersTB(CusID) not null,--�ͻ�id
     ECount int default 0 not null ,--���͵ĸ���
     EAllPrice money default 0 not null ,--�ɼ��ʷ�
     ISsettle bit check(ISsettle=0 or ISsettle=1) default 0 not null,--�Ƿ��ѽ��,0��ʾû�н��㣬1���ǽ�����
     EDate datetime not null,--�ɼ�����
     Remark varchar(150) --��ע
)
go
--����income and expenses������֧�����
if exists(select * from sysobjects where [name]='IAEManagerTB')
   drop table IAEManagerTB
go
create table IAEManagerTB
( 
      IAEid int identity(1,1) primary key not null,--�����ID
      CusID int foreign key references CustomersTB(CusID) not null,--�ͻ�id 
      IAEDate datetime not null,--��֧����
      IAEName varchar(20) not null,--��������
      Price money default 0 not  null,--j��������
      ISsettle bit check(ISsettle=0 or ISsettle=1) default 0 not null,--�Ƿ��ѽ��,0��ʾû�н��㣬1���ǽ�����
      Remark varchar(150) --��ע
     
)
go
--�����ͻ����ý����
if exists(select * from sysobjects where [name]='CustomerPianTB')
   drop table CustomerPianTB
go
create table CustomerPianTB
(
     CPid int identity(1,1) primary key not null,--�����ID
     CusID int foreign key references CustomersTB(CusID) not null,--�ͻ�id 
     DateMon datetime not null,--��������
     OddMon money default 0 not null,--�浥����
     SendMon money default 0 not null,--������
     GiveMon money default 0 not null,--�ͼ���
     BackMon money default 0 not null,--�յ���������
     AccMon money default 0 not null,--���յ�������
     OtherMon money default 0 not null,--��������
     AllMon money default 0 not null,--�ܼ�
     ISsettle bit check(ISsettle=0 or ISsettle=1) default 0 not null,--�Ƿ��ѽ��,0��ʾû�н��㣬1���ǽ�����
     Remark varchar(150) --��ע
)
go
--�û���¼��Ϣ��UserInfoTB
if exists(select * from sysobjects where [name]='UserInfoTB')
   drop table UserInfoTB
go
create table UserInfoTB
(
    UID int identity(1,1) primary key not null,--�û�id
    LoginId varchar(50) not null,--��½�˺�
    [Password] varchar(50) not null,--����
    Telephone varchar(50) check(Telephone like '1[3578][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') not null,--�绰
    Email varchar(50) check(Email like '%@%') not null,--email
    Question varchar(100) not null,--�ܱ�����
    AKey varchar(100) not null,--�����
    Remark varchar(150) --��ע
  
)
go
--���ͻ����в�������
insert into CustomersTB values('����','13830892234',1,null)
insert into CustomersTB values('����','13834562234',1,null)
insert into CustomersTB values('����','15830892234',1,null)
insert into CustomersTB values('ɺɺ','17830892234',0,null)
insert into CustomersTB values('����','18830894567',0,null)
go
select * from CustomersTB
go
--�����˹�˾���������
go
insert into CarrieCompanyTB values('�ϴ�','�հ�Ȼ','13562789028',2,null)
insert into CarrieCompanyTB values('��ͨ','��ɭ','15273894036',5,null)
insert into CarrieCompanyTB values('��ͨ','����ǿ','17283904678',4,null)
insert into CarrieCompanyTB values('˳��','��','18263748903',3,null)
go
select * from CarrieCompanyTB
go
--���浥����ǼǱ��в�������
insert into RegisterTB values(1,1900903581900,1900903581980,'2015-12-02',null)
insert into RegisterTB values(4,2900903581100,2900903581220,'2015-11-15',null)
insert into RegisterTB values(3,3900903581875,3900903581990,'2015-12-14',null)
insert into RegisterTB values(1,1900903581980,1900903582100,'2016-12-08',null)
insert into RegisterTB values(1,1900879699134,1900879699134,'2016-01-07',null)
insert into RegisterTB values(1,1900838887588,1900838887588,'2016-01-08',null)

go
select * from RegisterTB

--��������в�������
insert into DisNoteTB values(1001,1,1900903581909,1900903581999,'2015-01-23',300,0,null)
insert into DisNoteTB values(1001,1,1900903581910,1900903581920,'2015-01-23',300,0,null)
insert into DisNoteTB values(1001,1,1900855992482,1900855992482,'2015-01-23',300,0,null)
insert into DisNoteTB values(1001,1,1900917332001,1900917332008,'2015-01-23',300,0,null)
go
select * from DisNoteTB

--���ͻ��۸�����������
insert into CustomerPriceTB values(1001,1,'YD01','�����ϴ�',null)
insert into CustomerPriceTB values(1001,3,'ZT01','������ͨ',null)
insert into CustomerPriceTB values(1002,1,'YD02','�����ϴ�',null)
go
select * from CustomerPriceTB

--��������֧������в�������
insert into IAEManagerTB values(1001,'2016-01-01','ά�޷�',23,0,null)
insert into IAEManagerTB values(1003,'2015-12-01','��ͨ��',12,0,null)
insert into IAEManagerTB values(1002,'2016-01-05','��ʳ��',10,0,null)

--���û���Ϣ�����������
insert into UserInfoTB values('admin','admin','13253674656','admin@qq.com','�������������','1985-02-26',null)
insert into UserInfoTB values('sa','sa','13223674656','sa@sina.com','����ϲ����������˭','������',null)
insert into UserInfoTB values('boss','666666','15653674656','boss@qq.com','��������ʲô','����',null)
go
select * from UserInfoTB
