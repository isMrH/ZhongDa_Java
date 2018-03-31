using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using System.Data;
using System.Data.SqlClient;


namespace ZDDB.DAL
{
    //杨立君全部
    public  class DisNoteService
    {
        //实例化承运公司service
        CarrieCompanyService CCom = new CarrieCompanyService();
        //实例化客户service
        CustomersService Cums = new CustomersService();
        //客户发件
        //CustomerSentService css = new CustomerSentService();
        //添加面单分配信息
        public int InsertDisNoteTB(DisNoteTB Disnote)
        {
            string strsql = "insert into DisNoteTB values (@CusID,@Cid,@BeginNO,@EndNo,@Dtime,@Sum,@IsSet,@Remark)";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                    {
                         new SqlParameter("@CusID",Disnote.CusID ),
                         new SqlParameter("@Cid", Disnote.Cid),
                         new SqlParameter("@BeginNO", Disnote.BeginNo),
                         new SqlParameter("@EndNo", Disnote.EndNo),
                         new SqlParameter("@Dtime", Disnote.Dtime),
                         new SqlParameter("@Sum", Disnote.Sum),
                         new SqlParameter("@IsSet", Disnote.IsSet),
                         new SqlParameter("@Remark", Disnote.Remark)

                    };
                return DBHelper.ExecuteCommand(strsql, para);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }   
        }
        //修改表信息
        public int UpdateDisNoteTB(DisNoteTB Disnote)
        {
            string strsql = "update DisNoteTB set CusID= @CusID,Cid=@Cid,BeginNO=@BeginNO,EndNo=@EndNo,Dtime=@Dtime,Sum=@Sum,IsSet=@IsSet,Remark=@Remark where Nid=@Nid";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                    {
                         new SqlParameter("@CusID",Disnote.CusID ),
                         new SqlParameter("@Cid", Disnote.Cid),
                         new SqlParameter("@BeginNO", Disnote.BeginNo),
                         new SqlParameter("@EndNo", Disnote.EndNo),
                         new SqlParameter("@Dtime", Disnote.Dtime),
                         new SqlParameter("@Sum", Disnote.Sum),
                         new SqlParameter("@IsSet", Disnote.IsSet),
                         new SqlParameter("@Remark", Disnote.Remark),
                         new SqlParameter("@Nid", Disnote.Nid)

                    };
                return DBHelper.ExecuteCommand(strsql, para);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        //删除的方法
        public int DeleTeDisNoteTB(string Nid)
        {
            string strsql = "delete from DisNoteTB where  Nid=@Nid";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                    {
                         new SqlParameter("@Nid",Nid)
                        
                    };
                return DBHelper.ExecuteCommand(strsql, para);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        //根据Nid查询所有返回单行记录
        public DisNoteTB GetByNidDisNoteTB(int Nid)
        {
            string strsql = "select * from DisNoteTB where Nid="+Nid;
            List<DisNoteTB> allDisNoteTB = GetAllDisNoteTBBySql(strsql);
            return allDisNoteTB[0];
        }
        //李兰兰
        //查询是否有该面单分配记录
        public int GetNoteIsDis(long rid)
        {
            string strsql = string.Format("select count(*) from disnotetb where beginno<=@rid and endno>=@rid");
            SqlParameter[] paras=new SqlParameter[]{
                new SqlParameter("@rid",rid),
            };
            return (int)DBHelper.GetScalar(strsql, paras);
        }
        //根据面单号查询客户id和公司id
        public DisNoteTB GetNoteByRid(long rid)
        {
            string strsql =string.Format( "select * from disnotetb where beginno<='{0}' and endno>='{1}'",rid,rid);
            return GetAllDisNoteTBBySql1(strsql);
        }
        //李兰兰专用，不能删
        private DisNoteTB GetAllDisNoteTBBySql1(string strsql)
        {
            //填充数据集
            DataTable dt = DBHelper.GetTable(strsql);
            DisNoteTB DNte = new DisNoteTB();
            //遍历数组
            foreach (DataRow row in dt.Rows)
            {

                DNte.Nid = Convert.ToInt32(row["Nid"]);
                DNte.CusID = Convert.ToInt32(row["CusID"]);
                DNte.Cid = Convert.ToInt32(row["Cid"]);
                DNte.BeginNo = (long)row["BeginNo"];
                DNte.EndNo = (long)row["EndNo"];
                DNte.Dtime = Convert.ToDateTime(row["Dtime"]);
                DNte.Sum = Convert.ToDouble(row["Sum"]);
                object obj = row["IsSet"];
                int cnt = Convert.ToInt32(obj);
                string isSets = "";
                if (cnt == 0)
                {
                    isSets = "否";
                }
                if (cnt == 1)
                {
                    isSets = "是";
                }

                DNte.IsSet = isSets;
                DNte.Remark = row["Remark"].ToString();
                DNte.CarrieCompany = CCom.GetCompanyByid(Convert.ToInt32(row["Cid"]));
                DNte.Customer = Cums.GetCusmoerByid(Convert.ToInt32(row["CusID"]));
            }
            return DNte;
        }
        //自定义私有方法
        private List<DisNoteTB> GetAllDisNoteTBBySql(string strsql)
        { 
            //填充数据集
            DataTable dt = DBHelper.GetTable(strsql);
            //实例化泛集合
            List<DisNoteTB> Alldonte = new List<DisNoteTB>();
            //遍历数组
            foreach (DataRow row in dt.Rows)
            {
                DisNoteTB DNte = new DisNoteTB();
                DNte.Nid = Convert.ToInt32(row["Nid"]);
                DNte.CusID = Convert.ToInt32(row["CusID"]);
                DNte.Cid = Convert.ToInt32(row["Cid"]);
                DNte.BeginNo = (long)row["BeginNo"];
                DNte.EndNo = (long)row["EndNo"];
                DNte.Dtime = Convert.ToDateTime(row["Dtime"]);
                DNte.Sum = Convert.ToDouble(row["Sum"]);
                object obj=row["IsSet"];
                int cnt=Convert.ToInt32(obj);
                string isSets = "";
                if (cnt == 0)
                {
                    isSets = "否";
                }
                if (cnt == 1)
                {
                    isSets = "是";
                }

                DNte.IsSet = isSets;
                DNte.Remark = row["Remark"].ToString();
                DNte.CarrieCompany = CCom.GetCompanyByid(Convert.ToInt32( row["Cid"]));
                DNte.Customer = Cums.GetCusmoerByid(Convert.ToInt32( row["CusID"]));

                Alldonte.Add(DNte);

            }
            return Alldonte;
        }
        //查询所有的分配记录
        public List<DisNoteTB> GetAllDisNoteTB()
        {
            string strsql = "select * from DisNoteTB";
            return GetAllDisNoteTBBySql(strsql);
        }
        //条件查询功能
        public List<DisNoteTB> GetAllDisNoteTBByBoth(string cusid, string cid, string begin, string end, string datetimes, string data2, int iss)
        {
            string strsql = "select * from DisNoteTB where 1=1";
            if (cusid != "")
            {
                strsql += " and CusID=" + cusid;
            }
            if (cid != "")
            {
                strsql += " and Cid=" + cid;
            }
            if (begin != "")
            {
                strsql += " and '" + begin + " ' between BeginNo and EndNo";
            }
            if (end != "")
            {
                strsql += " and '" + end + " ' between BeginNo and EndNo";
            }
            if (datetimes != "" || data2 != "")
            {
                strsql += " and Dtime between'" + datetimes + "' and'" + data2 + "'";
            }
            if (iss >= 0)
            {
                strsql += " and IsSet =" + iss + "";
            }
            return GetAllDisNoteTBBySql(strsql);
        }
        public DisNoteTB GetDisNoteTBById(int cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from DisNoteTB where CusID='" + cid + "' and Dtime between '" + qtime + "' and '" + ttime + "'";
            return GetAllDisNoteTBBySql (strsql)[0];
        }
        //谷恒远1-8 
        //通过面单号获得面单分配表
        public DisNoteTB GetDisNoteTBByIds(string cid)
        {
            string strsql = "select * from DisNoteTB where BeginNO<='" + cid + "'" + " and EndNo>='" + cid + "'";
            return GetAllDisNoteTBBySql(strsql)[0];
        }
        //黄超 01-11
        //根据时间客户查询金额
        public DisNoteTB GetDisNoteTBById(string cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from DisNoteTB where CusID='" + cid + "' and Dtime between '" + qtime + "' and '" + ttime + "'";
            return GetDisNoteTBBySql(strsql)[0];
        }

        private static List<DisNoteTB> GetDisNoteTBBySql(string strsql)
        {
            List<DisNoteTB> list = new List<DisNoteTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                DisNoteTB dis = new DisNoteTB();
                dis.Nid = Convert.ToInt32(row["nid"].ToString());
                dis.CusID = Convert.ToInt32(row["cusid"]);
                dis.Cid = Convert.ToInt32(row["cis"]);
                dis.BeginNo = Convert.ToInt32(row["beginno"]);
                dis.EndNo = Convert.ToInt32(row["endno"]);
                dis.Dtime = Convert.ToDateTime(row["dtime"]);
                dis.Sum = Convert.ToDouble(row["sum"]);
                dis.IsSet = row["isset"].ToString();
                dis.Remark = row["remark"].ToString();

                list.Add(dis);
            }
            return list;
        }
        //验证是否查重
        public int numbers(string cusid, string cid, string beginno, string endno)
        {
            string strsql = "select count(*) from DisNoteTB where CusID='" + cusid + "'  and  Cid='" + cid + "' and '" + beginno + "' between BeginNo and EndNo and  '" + endno+ "' between BeginNo and EndNo";
           object cnt= DBHelper.GetScalar(strsql);
           int cnnt = Convert.ToInt32(cnt);
           return cnnt;
        }
        //验证是否查重
        public bool CusidAndCid(int cusid, int cid)
        {
            string strsql = "select count(*) from DisNoteTB where CusID=" + cusid + " and Cid=" + cid + "";
            object cnt = DBHelper.GetScalar(strsql);
            int cnnt = Convert.ToInt32(cnt);
            if (cnnt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
