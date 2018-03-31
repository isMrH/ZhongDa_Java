using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using System.Data;
using System.Data.SqlClient;

namespace ZDDB.DAL
{
    public class CustomerSendService
    {
        //私有方法
        private List<CustomerSendTB> GetInfoBysql(string strsql)
        {
            DataTable ds = DBHelper.GetTable(strsql);

            List<CustomerSendTB> AllCS = new List<CustomerSendTB>();

            foreach (DataRow r in ds.Rows)
            {
                CustomerSendTB CS = new CustomerSendTB();
                CS.CEid = Convert.ToInt32(r["CEid"]);
                CS.CusID = r["CusID"].ToString();
                CS.ECount = Convert.ToInt32(r["ECount"]);
                object iss = r["Issettle"];
                int cnt = Convert.ToInt32(iss);
                string ise = "";
                if (cnt == 1)
                {
                    ise = "是";
                }
                if (cnt == 0)
                {
                    ise = "否";
                }
                CS.Issettle = ise;
                CS.EAllPrice = Convert.ToDouble(r["EAllPrice"]);
                CS.EDate = Convert.ToDateTime(r["Edate"]);
                CS.Remark = r["Remark"].ToString();

                CustomersService cust = new CustomersService();
                CS.Ccustomer = cust.GetCusmoerByid(Convert.ToInt32( r["CusID"].ToString()));

                AllCS.Add(CS);
            }
            return AllCS;
        }
        //获取所有客户送件信息
        public List<CustomerSendTB> GetAllCustomerSendTB()
        {
            string strsql = "select * from CustomerSendTB";
            return GetInfoBysql(strsql);
        }
        //白少杰 01-11
        //添加新记录
        public int InsertCustomerSend(CustomerSendTB CSend)
        {


            string sql = "insert into CustomerSendTB values(@CusID,@ECount,@EAllPrice,@Issettle,@Edate,@Remark)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CusID",CSend.CusID),
                new SqlParameter("@ECount",CSend.ECount),
                new SqlParameter("@Issettle",CSend.Issettle),
                new SqlParameter("@EAllPrice",CSend.EAllPrice),
                new SqlParameter("@Edate",CSend.EDate),
                new SqlParameter("@Remark",CSend.Remark)
            };
            int cut = DBHelper.ExecuteCommand(sql, para);
            return cut;
        }
        //白少杰 01-11
        //修改记录
        public int UpdateCustomerSend(CustomerSendTB CSend)
        {
            string sql = "Update CustomerSendTB set CusID=@CusID,ECount=@ECount,Issettle=@Issettle,EAllPrice=@EAllPrice,Edate=@Edate,Remark=@Remark where CEid=@CEid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CEid",CSend.CEid),
                new SqlParameter("@CusID",CSend.CusID),
                new SqlParameter("@ECount",CSend.ECount),
                new SqlParameter("@Issettle",CSend.Issettle),
                new SqlParameter("@EAllPrice",CSend.EAllPrice),
                new SqlParameter("@Edate",CSend.EDate),
                new SqlParameter("@Remark",CSend.Remark)
            };
            int cut = DBHelper.ExecuteCommand(sql, para);
            return cut;
        }
        //白少杰 01-11
        //根据CEid删除信息
        public int DelCustomerSend(int CEid)
        {
            string str = "Delete from CustomerSendTB where CEid=@CEid";
            int cut = DBHelper.ExecuteCommand(str, new SqlParameter("@CEid", CEid));
            return cut;
        }
        //白少杰 01-11
        //根据CEid查询所有
        public CustomerSendTB SelectCustomerSendByCEid(int CEid)
        {
            string str = "Select * from CustomerSendTB where CEid=@CEid";
            DataTable dt = DBHelper.GetTable(str, new SqlParameter("@CEid", CEid));

            List<CustomerSendTB> AllCS = new List<CustomerSendTB>();

            foreach (DataRow r in dt.Rows)
            {
                CustomerSendTB CS = new CustomerSendTB();
                CS.CEid = Convert.ToInt32(r["CEid"]);
                CS.CusID = r["CusID"].ToString();
                CS.ECount = Convert.ToInt32(r["ECount"]);
                object iss = r["Issettle"];
                int cnt = Convert.ToInt32(iss);
                string ise = "";
                if (cnt == 1)
                {
                    ise = "是";
                }
                if (cnt == 0)
                {
                    ise = "否";
                }
                CS.Issettle = ise;
                CS.EAllPrice = Convert.ToDouble(r["EAllPrice"]);
                CS.EDate = Convert.ToDateTime(r["Edate"]);
                CS.Remark = r["Remark"].ToString();

                CustomersService cust = new CustomersService();
                CS.Ccustomer = cust.GetCusmoerByid(Convert.ToInt32( r["CusID"].ToString()));

                AllCS.Add(CS);
            }
            return AllCS[0];
        }
        //白少杰 01-11
        //根据Cusid查询所有

        public List<CustomerSendTB> SelectCustomerSendByCusid(int Cusid, string number, string money, string date, string data2, int iss)
        {


            string str = "Select * from CustomerSendTB where 1=1";
            if (Cusid >= 0)
            {
                str += " and CusID=" + Cusid;
            }
            if (number != "")
            {
                str += " and ECount='" + number + "'";
            }
            if (money != "")
            {
                str += " and EAllPrice='" + money + "'";
            }
            if (date != "" && data2 != "")
            {
                str += " and Edate between'" + date + "' and '" + data2 + "'";
            }
            if (iss >= 0)
            {
                str += " and Issettle =" + iss + "";
            }
            return GetInfoBysql(str);
        }
    
        //根据时间段和用户名查询金额
        public CustomerSendTB GetCustomerSendTBById(int cid, DateTime qtime, DateTime ttime)
        {
            string strsql = "select * from CustomerSendTB where CusID='" + cid + "' and EDate between '" + qtime + "' and '" + ttime + "'";
            return GetInfoBysql(strsql)[0];
        }
    }
}
