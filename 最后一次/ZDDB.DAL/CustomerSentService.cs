using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using System.Data;
using System.Data.SqlClient;

namespace ZDDB.DAL
{
    public class CustomerSentService
    {
        DisNoteService ds = new DisNoteService();
        //得到所有信息
        public List<CustomerSentTB> GetAll()
        {
            string strsql = "select * from customersenttb";
            return GetAllBySql(strsql);
        }
        //根据id获取信息
        public CustomerSentTB GetInfoByid(int csid)
        {
            string strsql = "select * from customersenttb where csid="+csid;
            return GetAllBySql(strsql)[0];
        }
        //筛选
        public List<CustomerSentTB> GetTempByFilter(long pno, string des, int cusid, int cid)
        {
            string strsql = "select * from customersenttb where 1=1";
            if (pno != 0)
            {
                strsql += " and rid =" + pno;
            }
            if (des != "")
            {
                strsql += " and destination='" + des + "'";
            }
            if (cusid != 0.0)
            {
                strsql += " and cusid=" + cusid;
            }
            if (cid != 0.0)
            {
                strsql += " and cid=" + cid;
            }
            return GetAllBySql(strsql);
        }
        //删除信息
        public void DelInfo(int csid)
        {
            string strsql = "delete from customersenttb where csid=" + csid;
            DBHelper.ExecuteCommand(strsql);
        }
        //插入信息
        public int InsertInfo(CustomerSentTB cst)
        {
            string strsql = "insert into customersenttb values(@Rid,@cusid,@cid,@des,@kilo,@price,@Resdate,@IsSet,@remark)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@rid",cst.Rid),
                new SqlParameter("@cusid",cst.cusid),
                new SqlParameter("@cid",cst.Cid),
                new SqlParameter("@des",cst.Destination),
                new SqlParameter("@kilo",cst.Kilo),
                new SqlParameter("@price",cst.Price),
                new SqlParameter("@Resdate",cst.Resdate),
                new SqlParameter("@IsSet",cst.IsSet),
                new SqlParameter("@remark",cst.Remark),
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
        //修改信息
        public int UpdateInfo(CustomerSentTB cst)
        {
            string strsql = "update customersenttb set rid=@Rid,destination=@des,kilo=@kilo,price=@price,resdate=@Resdate,isset=@IsSet,remark=@remark where rid=@rid";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@rid",cst.Rid),
                new SqlParameter("@cusid",cst.cusid),
                new SqlParameter("@cid",cst.Cid),
                new SqlParameter("@des",cst.Destination),
                new SqlParameter("@kilo",cst.Kilo),
                new SqlParameter("@price",cst.Price),
                new SqlParameter("@Resdate",cst.Resdate),
                new SqlParameter("@IsSet",cst.IsSet),
                new SqlParameter("@remark",cst.Remark),
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
        //修改无头件信息
        public int UpdateWu(int cusid, int comid, double price,long rid)
        {
            string strsql = "update customersenttb set cusid=@cusid,cid=@comid,price=@price where rid=@rid";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@cusid",cusid),
                new SqlParameter("@comid",comid),
                new SqlParameter("@price",price),
                new SqlParameter("@rid",rid)
             };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
        //得到无头件信息
        public List<CustomerSentTB> GetInfoByPrice()
        {
            string strsql = "select * from CustomerSentTB where price=0";
            return GetAllBySql(strsql);
        }
        public CustomerSentTB GetCustomerSentTBById(int cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from CustomerSentTB where CusID='" + cid + "' and Resdate between '" + qtime + "' and '" + ttime + "'";
            return GetAllBySql(strsql)[0];
        }

        //根据sql语句得到信息
        public static List<CustomerSentTB> GetAllBySql(string strsql)
        {
            CustomersService cst = new CustomersService();
            CarrieCompanyService ccs = new CarrieCompanyService();
            List<CustomerSentTB> all = new List<CustomerSentTB>();
            DataTable ds = DBHelper.GetTable(strsql);

            foreach (DataRow row in ds.Rows)
            {
                CustomerSentTB cs = new CustomerSentTB();
                cs.CSid = Convert.ToInt32(row["csid"]);
                cs.Rid = (long)row["rid"];
                //cs.cusid = Convert.ToInt32(row["cusid"]);
                cs.cusid=row["cusid"]!=DBNull.Value ? Convert.ToInt32( row["cusid"]) : 0;
                //cs.Cid = Convert.ToInt32(row["cid"]);
                cs.Cid = row["cid"] != DBNull.Value ? Convert.ToInt32(row["cid"]) : 0;
                if (cs.cusid!=0)
                {
                    cs.customer = cst.GetCusmoerByid(Convert.ToInt32(row["cusid"]));
                    cs.carriecompany = ccs.GetCompanyByid(Convert.ToInt32(row["cid"]));
                }
                cs.Destination = row["destination"].ToString();
                cs.Kilo =Convert.ToDouble( row["kilo"]);
                cs.Price =Convert.ToDouble( row["price"]);
                cs.Resdate=Convert.ToDateTime(row["resdate"]);
                cs.IsSet=(row["isset"].ToString());
                if (cs.IsSet == "true")
                {
                    cs.IsSet = "是";
                }
                else
                {
                    cs.IsSet = "否";
                }
                cs.Remark=row["remark"].ToString();

                all.Add(cs);
            }
            return all;
        }
    

        //黄超 01-11
        //通过时间段和用户名查询金额
        public CustomerSentTB GetCustomerSentTBById(string cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from CustomerSentTB where CusID='" + cid + "' and Resdate between '" + qtime + "' and '" + ttime + "'";
            return GetCustomerSentTBBySql(strsql)[0];
        }

        private static List<CustomerSentTB> GetCustomerSentTBBySql(string strsql)
        {
            List<CustomerSentTB> list = new List<CustomerSentTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                CustomerSentTB cs = new CustomerSentTB();
                cs.CSid = Convert.ToInt32(row["csid"]);
                cs.Rid = Convert.ToInt32(row["rid"]);
                cs.cusid = Convert.ToInt32(row["cusid"]);
                cs.Cid = Convert.ToInt32(row["cid"]);
                cs.Destination = row["destination"].ToString();
                cs.Kilo = (float)(row["kilo"]);
                cs.Price = Convert.ToDouble(row["price"]);
                cs.Resdate = Convert.ToDateTime(row["resdate"]);
                cs.Remark = row["remark"].ToString();

                list.Add(cs);
            }
            return list;
        }
    }
}
