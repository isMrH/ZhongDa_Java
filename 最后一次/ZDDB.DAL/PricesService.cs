using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZDDB.Model;
using System.Data.SqlClient;

namespace ZDDB.DAL
{
    public class PricesService
    {
        //李兰兰
        //得到所有信息
        public List<PriceTB> GetAllInfo()
        {
            string strsql = "select * from pricetb";
            return SelectBySql(strsql);
        }
        //根据模板编号得到模板
        public List<PriceTB> GetPriceBypno(string pno)
        {
            string strsql = "select * from pricetb where pno='"+pno+"'";
            return SelectBySql(strsql);
        }
        //根据模板编号，公斤数，目的地获得该件的运费
        public PriceTB GetPriceByInfo(string pno, double kilo, string des)
        {
            string strsql = string.Format("select * from pricetb where pno='{0}' and kilo='{1}' and destination='{2}'",pno,kilo,des);
            return SelectBySql(strsql)[0];
        }
        //查看是否有此模板
        public int GetCount(string pno)
        { 
           string strsql="select count(*) from pricetb where pno='"+pno+"'";
            return Convert.ToInt32(DBHelper.GetScalar(strsql));
        }
        //筛选
        public  List<PriceTB> GetTempByFilter(string pno, string des, double  kilo, double  price)
        {
            string strsql = "select * from pricetb where 1=1";
            if (pno != "")
            {
                strsql += " and pno ='" + pno + "'";
            }
            if (des != "")
            {
                strsql +=" and destination='"+des+"'";
            }
            if (kilo != 0.0)
            {
                strsql += " and kilo=" + kilo;
            }
            if (price != 0.0)
            {
                strsql += " and price=" + price;
            }
            return SelectBySql(strsql);
        }
        //根据sql语句查找
        public static List<PriceTB> SelectBySql(string strsql)
        {
            List<PriceTB> list = new List<PriceTB>();

            DataTable  ds = DBHelper.GetTable(strsql);

            foreach (DataRow row in ds.Rows)
            {
                PriceTB pt = new PriceTB();
                pt.Pid =Convert.ToInt32( row["pid"]);
                pt.PNo = row["pno"].ToString();
                pt.Destination = row["destination"].ToString();
                pt.Kilo = Convert.ToDouble(row["kilo"]);
                pt.Price = Convert.ToInt32(row["price"]);
                pt.Remark = (row["remark"] == DBNull.Value) ? "" : row["remark"].ToString();
                list.Add(pt);
            }
            return list;
        }
    }
}
