using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using System.Data;
using System.Data.SqlClient;

namespace ZDDB.DAL
{
    public class CustomerPianService
    {
        private void addCustomerPianTBa(int cusid,DateTime txtqtime,DateTime txtttime)
        {
            string sql = string.Format("insert into CustomerPianTB(CusID,DateMon,OddMon,SendMon) values({0},{1},'select [Sum] from DisNoteTB','select price from CustomerSentTB',)", cusid, txtttime);
            DBHelper.ExecuteCommand(sql);
        }

        //插入信息
        public int AddCustomerPianTBInfo(CustomerPianTB cp)
        {
            int count;
            string sql = "insert into CustomerPianTB(CusID,DateMon,OddMon,SendMon,GiveMon,BackMon,AccMon,OtherMon,AllMon,ISsettle,Remark) values(@CusID,@DateMon,@OddMon,@SendMon,@GiveMon,@BackMon,@AccMon,@OtherMon,@AllMon,@ISsettle,@Remark)";
            try
            {
                SqlParameter[] paras = new SqlParameter[]
               {
                   new SqlParameter("@CusID",cp.CusID),
                   new SqlParameter("@DateMon",cp.DateMon),
                   new SqlParameter("@OddMon",cp.OddMon),
                   new SqlParameter("@SendMon",cp.SendMon),
                   new SqlParameter("@GiveMon",cp.GiveMon),
                   new SqlParameter("@BackMon",cp.BackMon),
                   new SqlParameter("@AccMon",cp.AccMon),
                   new SqlParameter("@OtherMon",cp.OtherMon),
                   new SqlParameter("@AllMon",cp.AllMon),
                   new SqlParameter("@ISsettle",cp.ISsettle),
                   new SqlParameter("@Remark",cp.Remark)
               };
                DBHelper.ExecuteCommand(sql, paras);
                return count = 1;
            }
            catch (Exception e)
            {
                return count = 0;
                Console.Write(e.Message);
                throw e;
            }
        }

        //查找所有信息
        public List<CustomerPianTB> GetAllCustomerPianTB()
        {
            string strsql = "select * from CustomerPianTB";
            //调用根据SQL语句查找所有信息的方法
            return GetAllCustomerPianTBBySql(strsql);
        }

        //按照条件查找所有信息
        public List<CustomerPianTB> GetAllCustomerPianTBInfo(int cusid)
        {
            string strsql = "select * from CustomerPianTB where cusid="+cusid;
            //调用根据SQL语句查找所有信息的方法
            return GetAllCustomerPianTBBySql(strsql);
        }
        //按id日期查询
        public CustomerPianTB GetCustomerPianTBById(int cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from CustomerPianTB where CusID='" + cid + "' and datemon between '" + qtime + "' and '" + ttime + "'";
            return GetAllCustomerPianTBBySql(strsql)[0];
        }

        //根据SQL语句查找所有信息
        public static List<CustomerPianTB> GetAllCustomerPianTBBySql(string strsql)
        {
            List<CustomerPianTB> allinfo = new List<CustomerPianTB>();

            DataTable dt = DBHelper.GetTable(strsql);

            foreach (DataRow row in dt.Rows)
            {
                CustomersService cus = new CustomersService();
                CustomerPianTB t = new CustomerPianTB();
                t.CPid = Convert.ToInt32(row["cpid"]);
                t.CusID = Convert.ToInt32(row["cusid"]);
                t.DateMon = Convert.ToDateTime(row["datemon"]);
                t.OddMon = Convert.ToDouble(row["oddmon"]);
                t.SendMon = Convert.ToDouble(row["sendmon"]);
                t.GiveMon = Convert.ToDouble(row["givemon"]);
                t.BackMon = Convert.ToDouble(row["backmon"]);
                t.AccMon = Convert.ToDouble(row["accmon"]);
                t.OtherMon = Convert.ToDouble(row["othermon"]);
                t.AllMon = Convert.ToDouble(row["allmon"]);
                t.ISsettle = row["issettle"].ToString();
                if (t.ISsettle == "True")
                {
                    t.ISsettle = "已付";
                }
                else
                {
                    t.ISsettle = "未付";
                }
                t.Remark = row["remark"].ToString();
                t.customer = cus.GetCusmoerByid(Convert.ToInt32(row["cusid"]));
                allinfo.Add(t);
            }
            return allinfo;
        }

        //更新结算信息
        public int UpdateCustomerPianTBById(CustomerPianTB cp)
        {
            string sql = "update CustomerPianTB set CusID=@CusID,DateMon=@DateMon,OddMon=@OddMon,SendMon=@SendMon,GiveMon=@GiveMon,BackMon=@BackMon,AccMon=@AccMon,OtherMon=@OtherMon,AllMon=@AllMon,ISsettle=@ISsettle,Remark=@Remark where CPid=@CPid";
            SqlParameter[] paras = new SqlParameter[]
               {
                   new SqlParameter("@CPid",cp.CPid),
                   new SqlParameter("@CusID",cp.CusID),
                   new SqlParameter("@DateMon",cp.DateMon),
                   new SqlParameter("@OddMon",cp.OddMon),
                   new SqlParameter("@SendMon",cp.SendMon),
                   new SqlParameter("@GiveMon",cp.GiveMon),
                   new SqlParameter("@BackMon",cp.BackMon),
                   new SqlParameter("@AccMon",cp.AccMon),
                   new SqlParameter("@OtherMon",cp.OtherMon),
                   new SqlParameter("@AllMon",cp.AllMon),
                   new SqlParameter("@ISsettle",cp.ISsettle),
                   new SqlParameter("@Remark",cp.Remark)
               };
            return DBHelper.ExecuteCommand(sql, paras);
        }

        //删除
        public void DeleteCInfoId(int cusid)
        {
            string sql = "delete CustomerPianTB where cusid=@cusid";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@cusid",cusid)
                };
                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw e;
            }
        }
    }
}
