using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ZDDB.Model;

namespace ZDDB.DAL
{
    public class DelGoodsMonService
    {
        //段浩
         //查看送货价格表
        public List<DelGoodMon> GetAllDelGoodMonInfo()
        {
            string strsql = "select * from DelGoodsMonTB";
            return GetInfoBysql(strsql);
        }

        //根据客户ID得到客户姓名
        public DelGoodMon GetAllDelGoodsInfoByID(int DelID)
       {
           string strsql = "select * from DelGoodsMonTB where DelID=" + @DelID;
            DelGoodMon Del = new DelGoodMon();
            try
            {
                DataTable dt = DBHelper.GetTable(strsql, new SqlParameter("@DelID", DelID));
                foreach (DataRow row in dt.Rows)
                {
                    Del.CusID = row["CusID"].ToString();
                    Del.DelID= Convert.ToInt32(row["DelID"]);
                    CustomersService CS=new CustomersService();
                    Del.customer= CS.GetCusmoerByid(Convert.ToInt32( Del.CusID));
                    Del.DelUnitPrice=Convert.ToDouble(row["DelUnitPrice"]);
                    Del.Remark= row["Remark"].ToString();
                   
                }
                return Del;
            }
            catch (Exception e)
            {
                throw e;
            }
       }

        public List<DelGoodMon> GetInfoBysql(string strsql)
        {
            DataTable ds = DBHelper.GetTable(strsql);

            List<DelGoodMon> allDelGoods = new List<DelGoodMon>();

            foreach (DataRow r in ds.Rows)
            {
                DelGoodMon Del = new DelGoodMon();
                Del.DelID = Convert.ToInt32(r["DelID"]);
                CustomersService CS = new CustomersService();
                Del.customer= CS.GetCusmoerByid(Convert.ToInt32( r["CusID"]));
                Del.DelUnitPrice = Convert.ToDouble(r["DelUnitPrice"]);
                Del.Remark = r["Remark"].ToString();
            
                allDelGoods.Add(Del);
            }
            return allDelGoods;
        }
        //修改
         public int UpdateDel(double DelUnitPrice, int DelID)
        {
            string strsql = "Update DelGoodsMonTB set DelUnitPrice=@DelUnitPrice where DelID=@DelID";
             SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@DelUnitPrice",DelUnitPrice),
                new SqlParameter("@DelID",DelID)                
             };
             return DBHelper.ExecuteCommand(strsql);

        }
         //修改
         public int UpdateDel(DelGoodMon del)
         {
             string strsql = "Update DelGoodsMonTB set CusID=@CusID,DelUnitPrice=@DelUnitPrice,Remark=@Remark where DelID=@DelID";
             SqlParameter[] para = new SqlParameter[]
             {
                 new SqlParameter("@CusID",del.CusID),
                new SqlParameter("@DelUnitPrice",del.DelUnitPrice),
                 new SqlParameter("@Remark",del.Remark),
                new SqlParameter("@DelID",del.DelID)                
             };
             return DBHelper.ExecuteCommand(strsql, para);

         }

         //插入功能
         public int InsertDelMon(DelGoodMon del)
         {
             string strsql = "insert into DelGoodsMonTB values(@CusID,@DelUnitPrice,@Remark)";
             SqlParameter[] para = new SqlParameter[]
             {
                 new SqlParameter("@CusID",del.CusID),
                new SqlParameter("@DelUnitPrice",del.DelUnitPrice),
                new SqlParameter("@Remark",del.Remark)                
             };
             return DBHelper.ExecuteCommand(strsql, para);

         }
         //根据cusid查询
         public List<DelGoodMon> GetALLByCusidGoodsMon(int cusid,string money)
         {
             string strsql = "select * from DelGoodsMonTB where 1=1";//CusID=" + cusid;
             if (cusid >=0)
             {
                 strsql += "and  CusID=" + cusid;
             }
             if (money != "")
             {
                 strsql += " and DelUnitPrice='" + money + "'";
             }

             return GetInfoBysql(strsql);

         }
         //删除功能
         public int DelGoodsMon(string delID)
         {
             string strsql = "delete  from DelGoodsMonTB where DelID= " + delID;
             return DBHelper.ExecuteCommand(strsql);
         }
         //获取价格
         public object GetMoney(int Cusid)
         {
             string strsql = "select DelUnitPrice from DelGoodsMonTB where CusID=" + Cusid;
             return DBHelper.GetScalar(strsql);
         }
   
    }
}
