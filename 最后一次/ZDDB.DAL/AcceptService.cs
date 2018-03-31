using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using System.Data;
using System.Data.SqlClient;

namespace ZDDB.DAL
{
    public class AcceptService
    {
        //按时间查询信息
        public AcceptTB GetAcceptTBById(int cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from AcceptTB where CusID='" + cid + "' and BeginDate between '" + qtime + "' and '" + ttime + "'";
            return GetAcceptTBBySql(strsql)[0];
        }
        //谷恒远1-7
        //获取派收到付件管理
        public List<AcceptTB> GetAllAcceptTB()
        {
            string strsql = "select * from AcceptTB";
            return GetAcceptTBBySql(strsql);
        }
        //查询记录行数
        public int GetAcceptTBById(string id)
        {
            string strsql = "select count(*) from AcceptTB where CSid='" + id + "'";
            return DBHelper.Getscalar(strsql);
        }
        //遍历数组，拿出数据
        private static List<AcceptTB> GetAcceptTBBySql(string strsql)
        {
            CustomersService cs = new CustomersService();
            CarrieCompanyService ccs = new CarrieCompanyService();
            List<AcceptTB> list = new List<AcceptTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                AcceptTB at = new AcceptTB();
                at.Aid = Convert.ToInt32(row["aid"]);
                at.CusID =Convert.ToInt32( row["cusid"]);
                at.CID =Convert.ToInt32( row["cid"]);
                at.CSid = Convert.ToInt64(row["csid"]);
                at.Price = Convert.ToDouble(row["price"]);
                at.BeginDate = Convert.ToDateTime(row["begindate"]);
                at.Remark = row["remark"].ToString();
                at.cust = cs.GetCusmoerByid(Convert.ToInt32(row["cusid"]));
                at.company = ccs.GetCompanyByid(Convert.ToInt32(row["cid"]));

                list.Add(at);
            }
            return list;
        }
         //联合查询
        public List<AcceptTB> GetInfoByFilter(string Coname, string CusName, string begintime, string begintime1, string numbers)
        {
            string strsql = "select * from AcceptTB where 1=1";
            if (Coname != "")
            {
                strsql += " and Cid like '%" + Coname + "%'";
            }
            if (CusName != "")
            {
                strsql += " and CusID= '" + CusName + "'";
            }
            if (begintime != "")
            {
                strsql += " and BeginDate>= '" + begintime + "'";
            }
            if (begintime1 != "")
            {
                strsql += " and BeginDate<= '" + begintime1 + "'";
            }
            if (numbers != "")
            {
                strsql += " and CSid= '" + numbers + "'";
            }

            return GetAcceptTBBySql(strsql);
        }

        //添加揽发到付件
        public int InsertAcceptTB(AcceptTB at)
        {
            string strsql = "insert into AcceptTB(CusID,Cid,CSid,Price,BeginDate,Remark) values(@CusID,@Cid,@CSid,@Price,@BeginDate,@Remark)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@CusID",at.CusID),
                new SqlParameter("@Cid",at.CID),
                new SqlParameter("@CSid",at.CSid),
                new SqlParameter("@Price",at.Price),
                new SqlParameter("@BeginDate",at.BeginDate),
                new SqlParameter("@Remark",at.Remark)
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }

        //黄超 01-11
        public AcceptTB GetAcceptTBById(string cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from AcceptTB where CusID='" + cid + "' and BeginDate between '" + qtime + "' and '" + ttime + "'";
            return GetAcceptTBBySql(strsql)[0];
        }
        //谷恒远01-12
        public int UpdateAcceptTB(AcceptTB at)
        {
            string strsql = "update AcceptTB set CusID=@CusID,Cid=@Cid,CSid=@CSid,Price=@Price,BeginDate=@BeginDate,Remark=@Remark where aid=@Aid";
            SqlParameter[] paras = new SqlParameter[]{
            
                new SqlParameter("@Aid",at.Aid),
                new SqlParameter("@CusID",at.CusID),
                new SqlParameter("@Cid",at.CID),
                new SqlParameter("@CSid",at.CSid),
                new SqlParameter("@Price",at.Price),
                new SqlParameter("@BeginDate",at.BeginDate),
                new SqlParameter("@Remark",at.Remark)
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
        //按照ID号获取信息
        public AcceptTB GetAcceptTBByIds(int aid)
        {
            string strsql = "select * from AcceptTB where aid=" + aid;
            return GetAcceptTBBySql(strsql)[0];
        }
        //删除所选类型
        public int DeleteAcceptTBInfo(int aid)
        {
            string strsql = "delete from AcceptTB where aid=@aid";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@aid",aid),
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
    }
}
