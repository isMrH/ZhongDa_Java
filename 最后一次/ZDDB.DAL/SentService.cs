using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using System.Data;
using System.Data.SqlClient;

namespace ZDDB.DAL
{
    public class SentService
    {
        //谷恒远1-7
        //获取揽发到付件表
        public List<SentTB> GetAllSentTB()
        {
            string strsql = "select * from SentTB";
            return GetSentTBBySql(strsql);
        }
        //根据时间查询揽发到付表信息
        public SentTB GetSentTBById(int cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from SentTB where CusID='" + cid + "' and BeginDate between '" + qtime + "' and '" + ttime + "'";
            return GetSentTBBySql(strsql)[0];
        }
        //遍历数组，拿出数据
        private static List<SentTB> GetSentTBBySql(string strsql)
        {
            CustomersService cs = new CustomersService();
            CarrieCompanyService ccs = new CarrieCompanyService();
            List<SentTB> list = new List<SentTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                SentTB st = new SentTB();
                st.Sid = Convert.ToInt32(row["sid"]);
                st.CusID = Convert.ToInt32(row["cusid"]);
                st.Cid = Convert.ToInt32(row["cid"]);
                st.CSid = Convert.ToInt64(row["csid"]);
                st.Kilo = Convert.ToDouble(row["kilo"]);
                st.Price = Convert.ToDouble(row["price"]);
                st.BeginDate = Convert.ToDateTime(row["begindate"]);
                st.Remark = row["remark"].ToString();
                st.cust = cs.GetCusmoerByid(Convert.ToInt32( row["cusid"]));
                st.company = ccs.GetCompanyByid(Convert.ToInt32( row["cid"]));
                list.Add(st);
            }
            return list;
        }
        //联合查询
        public List<SentTB> GetInfoByFilter(string Coname, string CusName, string begintime, string begintime1, string numbers)
        {
            string strsql = "select * from SentTB where 1=1";
            if (Coname != "")
            {
                strsql += " and Cid like '%" + Coname + "%'";
            }
            if (CusName != "")
            {
                strsql += " and CusID= '" + CusName+"'";
            }
            if (begintime != "")
            {
                strsql += " and BeginDate>= '" + begintime+"'";
            }
            if (begintime1 != "")
            {
                strsql += " and BeginDate<= '"+begintime1+"'";
            }
            if (numbers != "")
            {
                strsql += " and CSid= '" + numbers+"'";
            }

            return GetSentTBBySql(strsql);
        }

        //添加揽发到付件
        public int InsertSentTB(SentTB st)
        {
            string strsql = "insert into SentTB(CusID,Cid,CSid,Kilo,Price,BeginDate,Remark) values(@CusID,@Cid,@CSid,@Kilo,@Price,@BeginDate,@Remark)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@CusID",st.CusID),
                new SqlParameter("@Cid",st.Cid),
                new SqlParameter("@CSid",st.CSid),
                new SqlParameter("@Kilo",st.Kilo),
                new SqlParameter("@Price",st.Price),
                new SqlParameter("@BeginDate",st.BeginDate),
                new SqlParameter("@Remark",st.Remark)
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }

        //黄超 01-11
        //根据时间客户查询金额
        public SentTB GetSentTBById(string cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from SentTB where CusID='" + cid + "' and BeginDate between '" + qtime + "' and '" + ttime + "'";
            return GetSentTBSql(strsql)[0];
        }

        private static List<SentTB> GetSentTBSql(string strsql)
        {
            List<SentTB> list = new List<SentTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                SentTB st = new SentTB();
                st.Sid = Convert.ToInt32(row["sid"]);
                st.CusID = Convert.ToInt32(row["cusid"]);
                st.Cid = Convert.ToInt32(row["cid"]);
                st.CSid = Convert.ToInt32(row["csid"]);
                st.Kilo = (float)row["kilo"];
                st.Price = Convert.ToDouble(row["price"]);
                st.BeginDate = Convert.ToDateTime(row["begindate"]);
                st.Remark = row["remark"].ToString();

                list.Add(st);
            }
            return list;
        }
        //谷恒远1.11
        //修改信息
        public int UpdateSentTB(SentTB st)
        {
            string strsql = "update SentTB set CusID=@CusID,Cid=@Cid,CSid=@CSid,Kilo=@Kilo,Price=@Price,BeginDate=@BeginDate,Remark=@Remark where Sid=@Sid";
            SqlParameter[] paras = new SqlParameter[]{
            
                new SqlParameter("@Sid",st.Sid),
                new SqlParameter("@CusID",st.CusID),
                new SqlParameter("@Cid",st.Cid),
                new SqlParameter("@Kilo",st.Kilo),
                new SqlParameter("@Price",st.Price),
                new SqlParameter("@CSid",st.CSid),
                new SqlParameter("@BeginDate",st.BeginDate),
                new SqlParameter("@Remark",st.Remark)
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
        public SentTB GetSentTBById(int Sid)
        {
            string strsql = "select * from SentTB where Sid=" + Sid;
            return GetSentTBBySql(strsql)[0];
        }
        //删除所选类型
        public int DeleteSentTBInfo(int sid)
        {
            string strsql = "delete from SentTB where sid=@sid";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@sid",sid),
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
        public int GetSentTBById(string id)
        {
            string strsql = "select count(*) from SentTB where CSid='" + id + "'";
            return DBHelper.Getscalar(strsql);
        }
    }
}
