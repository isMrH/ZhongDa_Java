using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using System.Data;
using System.Data.SqlClient;

namespace ZDDB.DAL
{
    public class CustomerPriceService
    {
        
        //查询所有信息
        public List<CustomerPriceTB> GetAllInfo()
        {
            string strsql = "select * from customerpricetb";
            return GetCustomersBySql(strsql);
        }
        //根据id获取信息
        public CustomerPriceTB GetInfoById(int cpid)
        {
            string strsql = "select * from customerpricetb where cpid=" + cpid;
            return GetCustomersBySql(strsql)[0];
        }
        //根据公司id和客户id获得该客户在该公司的价格模板
        public CustomerPriceTB GetInfoByCusidAndCid(int cusid, int cid)
        {
            string strsql =string.Format( "select * from customerpricetb where cusid='{0}' and cid='{1}'",cusid,cid);
            return GetCustomersBySql(strsql)[0];
        }
        //查看该客户在某公司是否有价格模板
        public int GetCountInfo(int cusid, int cid)
        {
            string strsql = "select count(*) from customerpricetb where cusid=@cusid and cid=@cid";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@cusid",cusid),
                new SqlParameter("@cid",cid)
            };
            return Convert.ToInt32( DBHelper.GetScalar(strsql, paras));
        }
        //插入数据
        public int InsertInfo(CustomerPriceTB cp)
        {
            string strsql = "insert into customerpricetb values(@cusid,@cid,@pno,@cpname,@remark)";

            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@cusid",cp.CusID),
                new SqlParameter("@cid",cp.Cid),
                new SqlParameter("@pno",cp.PNo),
                new SqlParameter("@cpname",cp.CpName),
                new SqlParameter("@remark",cp.Remark)
            };
            int cnt = DBHelper.ExecuteCommand(strsql,paras);
            return cnt;
        }
        //筛选
        public List<CustomerPriceTB> GetTempByFilter(int cusid, int cid, string pno, string cpname)
        {
            string strsql = "select * from customerpricetb where 1=1";
            if (pno != "")
            {
                strsql += " and pno ='"+pno+"'";
            }
            if (cpname != "")
            {
                strsql += " and cpname='" + cpname + "'";
            }
            if (cusid != 0.0)
            {
                strsql += " and cusid=" + cusid;
            }
            if (cid != 0.0)
            {
                strsql += " and cid=" + cid;
            }
            return GetCustomersBySql(strsql);
        }
        //删除
        public void DelIfo(int cpid)
        {
            string strsql = "delete from customerpricetb where cpid=@cpid";
            SqlParameter[] paras=new SqlParameter[]{
                new SqlParameter("@cpid",cpid),
            };
            DBHelper.GetScalar(strsql, paras);
        }
        //修改价格模板
        public int UpdateTemp(int cpid,string pno,string remark)
        {
            string strsql = "update customerpricetb set pno=@pno,remark=@remark where cpid=@cpid";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@cpid",cpid),
                new SqlParameter("@pno",pno),
                new SqlParameter("@remark",remark)
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }
        //根据sql语句查询
        private static List<CustomerPriceTB> GetCustomersBySql(string strsql)
        {
            CustomersService cs = new CustomersService();
            CarrieCompanyService ccs = new CarrieCompanyService();

            List<CustomerPriceTB> list = new List<CustomerPriceTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                CustomerPriceTB cp = new CustomerPriceTB();
                cp.Cpid =Convert.ToInt32( row["cpid"]);
                cp.carriecomapny = ccs.GetCompanyByid(Convert.ToInt32( row["cid"]));
                cp.customer =cs.GetCusmoerByid(Convert.ToInt32( row["cusid"]));
                cp.CusID = Convert.ToInt32(row["cusid"]);
                cp.Cid = Convert.ToInt32(row["cid"]);
                cp.CpName = row["cpname"].ToString();
                cp.PNo = row["pno"].ToString();
                cp.Remark=row["remark"].ToString();
                list.Add(cp);
            }
            return list;
        }
    }
}
