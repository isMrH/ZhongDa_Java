using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZDDB.Model;

namespace ZDDB.DAL
{
    public class IAEManagerService
    {
        //李兰兰全部
        //根据id得到信息
        public IAEManagerTB GetIAEManagerTBById(int cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from IAEManagerTB where CusID='" + cid + "' and IAEDate between '" + qtime + "' and '" + ttime + "'";
            return GetIAEManagerTBBySql(strsql)[0];
        }
        //根据id号查找信息
        public IAEManagerTB GetIAEManagerTBById(int iaeid)
        {
            string strsql = "select * from IAEManagerTB where iaeid="+iaeid;
            return GetIAEManagerTBBySql(strsql)[0];
        }
        //得到所有信息
        public List<IAEManagerTB> GetAll()
        {
            string strsql = "select * from IAEManagerTB";
            return GetIAEManagerTBBySql(strsql);
        }
        //筛选
        public List<IAEManagerTB> GetTempByFilter(string  cusid,string  datetime,string endtime)
        {
            string strsql = "select * from IAEManagerTB where 1=1";
            if (cusid != "")
            {
                strsql += " and cusid ='"+cusid+"'";
            }
            if (datetime != ""||endtime!="")
            {
                strsql += " and iaedate between'" + datetime + "' and '"+endtime+"'";
                
            }
            return GetIAEManagerTBBySql(strsql);
        }
        //添加信息
        public int InsertInfo(IAEManagerTB iae)
        {
            string strsql = "insert into IAEManagerTB values(@cusid,@IAEDate,@IAEName,@Price,@ISsettle,@Remark)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@cusid",iae.CusID),
                new SqlParameter("@IAEDate",iae.IAEDate),
                new SqlParameter("@IAEName",iae.IAEName),
                new SqlParameter("@Price",iae.Price),
                new SqlParameter("@ISsettle",iae.ISsettle),
                new SqlParameter("@Remark",iae.Remark)
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
        //修改信息
        public int UpdateInfo(IAEManagerTB iae)
        {
            string strsql = "update IAEManagerTB set iaedate=@IAEDate,iaename=@IAEName,price=@Price,issettle=@ISsettle,remark=@Remark where cusid=@cusid";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@cusid",iae.CusID),
                new SqlParameter("@IAEDate",iae.IAEDate),
                new SqlParameter("@IAEName",iae.IAEName),
                new SqlParameter("@Price",iae.Price),
                new SqlParameter("@ISsettle",iae.ISsettle),
                new SqlParameter("@Remark",iae.Remark)
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
        //根据id删除信息
        public int DelInfo(int iaeid)
        {
            string strsql = "delete from IAEManagerTB where iaeid=@iaeid";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@iaeid",iaeid),
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
        //从数据库取出数据
        private static List<IAEManagerTB> GetIAEManagerTBBySql(string strsql)
        {
            CustomersService cs = new CustomersService();
            List<IAEManagerTB> list = new List<IAEManagerTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                IAEManagerTB ia = new IAEManagerTB();
                ia.IAEid = Convert.ToInt32(row["iaeid"]);
                ia.CusID =Convert.ToInt32( row["cusid"]);
                ia.customer = cs.GetCusmoerByid(Convert.ToInt32(row["cusid"]));
                ia.IAEDate = Convert.ToDateTime(row["iaedate"]);
                ia.IAEName = row["iaename"].ToString();
                ia.Price = Convert.ToDouble(row["price"]);
                ia.ISsettle = row["issettle"].ToString();
                if (ia.ISsettle == "True")
                {
                    ia.ISsettle = "是";
                }
                else
                {
                    ia.ISsettle = "否";
                }
                ia.Remark = row["remark"].ToString();

                list.Add(ia);
            }
            return list;
        }

        //黄超 01-11
        //根据时间客户查询金额
        public IAEManagerTB GetIAEManagerTBById(string cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from IAEManagerTB where CusID='" + cid + "' and IAEDate between '" + qtime + "' and '" + ttime + "'";
            return GetIAEManagerTBSql(strsql)[0];
        }

        private static List<IAEManagerTB> GetIAEManagerTBSql(string strsql)
        {
            List<IAEManagerTB> list = new List<IAEManagerTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                IAEManagerTB ia = new IAEManagerTB();
                ia.IAEid = Convert.ToInt32(row["iaeid"]);
                ia.CusID = Convert.ToInt32(row["cusid"]);
                ia.IAEDate = Convert.ToDateTime(row["iaedate"]);
                ia.IAEName = row["iaename"].ToString();
                ia.Price = Convert.ToDouble(row["price"]);
                ia.Remark = row["remark"].ToString();

                list.Add(ia);
            }
            return list;
        }
    }
}
