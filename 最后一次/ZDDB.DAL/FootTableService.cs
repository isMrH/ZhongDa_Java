using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using System.Data;
using System.Data.SqlClient;

namespace ZDDB.DAL
{
    //根据id查询客户详细
     public class FootTableService
    {
         //查询发件费
         public FootTableTB GetSelectUserByLoginid(int Cid)
         {
             string sql = "select customerstb.cusid,customerstb.cusname,customersendtb.eallprice,customersendtb.issettle,customersendtb.edate,customersendtb.remark from customerstb inner join customersendtb on customerstb.cusid=customersendtb.cusid where customerstb.cusid=@Cid";
             FootTableTB userinfo = new FootTableTB();
             try
             {
                 DataTable dt = DBHelper.GetTable(sql, new SqlParameter("@Cid", Cid));
                 if (dt.Rows.Count == 0)
                 {
                     return null;
                 }
                 else
                 {
                     foreach (DataRow row in dt.Rows)
                     {
                         userinfo.Cusid = (int)row["Cusid"];
                         userinfo.CName = row["CusName"].ToString();
                         userinfo.Price = Convert.ToDouble(row["eallprice"]);
                         userinfo.Foot = (bool)row["issettle"];
                         userinfo.Time =Convert.ToDateTime(row["edate"]);
                         userinfo.Remark = (row["Remark"] == DBNull.Value) ? "" : row[5].ToString();
                     }
                     return userinfo;
                 }

             }
             catch (Exception e)
             {
                 throw e;
             }
         }
         //查询面单费
         public FootTableTB GetSelectDisNoteTBid(int Cid)
         {
             string sql = "select customerstb.cusid,customerstb.cusname,DisNoteTB.[sum],DisNoteTB.isset,DisNoteTB.dtime,DisNoteTB.remark from customerstb inner join DisNoteTB on customerstb.cusid=DisNoteTB.cusid where customerstb.cusid=@Cid";
             FootTableTB userinfo = new FootTableTB();
             try
             {
                 DataTable dt = DBHelper.GetTable(sql, new SqlParameter("@Cid", Cid));
                 if (dt.Rows.Count == 0)
                 {
                     return null;
                 }
                 else
                 {
                     foreach (DataRow row in dt.Rows)
                     {
                         userinfo.Cusid = (int)row["cusid"];
                         userinfo.CName = row["cusName"].ToString();
                         userinfo.Price = Convert.ToDouble(row["sum"]);
                         userinfo.Foot = (bool)row["isset"];
                         userinfo.Time = Convert.ToDateTime(row["dtime"]);
                         userinfo.Remark = (row["remark"] == DBNull.Value) ? "" : row[5].ToString();
                     }
                     return userinfo;
                 }

             }
             catch (Exception e)
             {
                 throw e;
             }
         }
         //查询送件费
         public FootTableTB GetSelectCustomerSendTBid(int Cid)
         {
             string sql = "select customerstb.cusid,customerstb.cusname,CustomerSendTB.EAllPrice,CustomerSendTB.Issettle,CustomerSendTB.Edate,CustomerSendTB.remark from customerstb inner join CustomerSendTB on customerstb.cusid=CustomerSendTB.cusid where customerstb.cusid=@Cid";
             FootTableTB userinfo = new FootTableTB();
             try
             {
                 DataTable dt = DBHelper.GetTable(sql, new SqlParameter("@Cid", Cid));
                 if (dt.Rows.Count == 0)
                 {
                     return null;
                 }
                 else
                 {
                     foreach (DataRow row in dt.Rows)
                     {
                         userinfo.Cusid = (int)row["Cusid"];
                         userinfo.CName = row["CusName"].ToString();
                         userinfo.Price = Convert.ToDouble(row["EAllPrice"]);
                         userinfo.Foot = (bool)row["issettle"];
                         userinfo.Time = Convert.ToDateTime(row["edate"]);
                         userinfo.Remark = (row["Remark"] == DBNull.Value) ? "" : row[5].ToString();
                     }
                     return userinfo;
                 }

             }
             catch (Exception e)
             {
                 throw e;
             }
         }
         //查询收货返利费
         public FootTableTB GetSelectSentTBid(int Cid)
         {
             string sql = "select customerstb.cusid,customerstb.cusname,SentTB.Price,SentTB.Issettle,SentTB.BeginDate,SentTB.remark from customerstb inner join SentTB on customerstb.cusid=SentTB.cusid where customerstb.cusid=@Cid";
             FootTableTB userinfo = new FootTableTB();
             try
             {
                 DataTable dt = DBHelper.GetTable(sql, new SqlParameter("@Cid", Cid));
                 if (dt.Rows.Count == 0)
                 {
                     return null;
                 }
                 else
                 {
                     foreach (DataRow row in dt.Rows)
                     {
                         userinfo.Cusid = (int)row["Cusid"];
                         userinfo.CName = row["CusName"].ToString();
                         userinfo.Price = Convert.ToDouble(row["price"]);
                         userinfo.Foot = (bool)row["issettle"];
                         userinfo.Time = Convert.ToDateTime(row["BeginDate"]);
                         userinfo.Remark = (row["Remark"] == DBNull.Value) ? "" : row[5].ToString();
                     }
                     return userinfo;
                 }

             }
             catch (Exception e)
             {
                 throw e;
             }
         }
         //查询派发费
         public FootTableTB GetSelectAcceptTBid(int Cid)
         {
             string sql = "select customerstb.cusid,customerstb.cusname,AcceptTB.Price,AcceptTB.Issettle,AcceptTB.BeginDate,AcceptTB.remark from customerstb inner join AcceptTB on customerstb.cusid=AcceptTB.cusid where customerstb.cusid=@Cid";
             FootTableTB userinfo = new FootTableTB();
             try
             {
                 DataTable dt = DBHelper.GetTable(sql, new SqlParameter("@Cid", Cid));
                 if (dt.Rows.Count == 0)
                 {
                     return null;
                 }
                 else
                 {
                     foreach (DataRow row in dt.Rows)
                     {
                         userinfo.Cusid = (int)row["Cusid"];
                         userinfo.CName = row["CusName"].ToString();
                         userinfo.Price = Convert.ToDouble(row["price"]);
                         userinfo.Foot = (bool)row["issettle"];
                         userinfo.Time = Convert.ToDateTime(row["BeginDate"]);
                         userinfo.Remark = (row["Remark"] == DBNull.Value) ? "" : row[5].ToString();
                     }
                     return userinfo;
                 }

             }
             catch (Exception e)
             {
                 throw e;
             }
         }
         //查询其他费
         public FootTableTB GetSelectIAEManagerTBid(int Cid)
         {
             string sql = "select customerstb.cusid,customerstb.cusname,IAEManagerTB.Price,IAEManagerTB.Issettle,IAEManagerTB.IAEDate,IAEManagerTB.remark from customerstb inner join IAEManagerTB on customerstb.cusid=IAEManagerTB.cusid where customerstb.cusid=@Cid";
             FootTableTB userinfo = new FootTableTB();
             try
             {
                 DataTable dt = DBHelper.GetTable(sql, new SqlParameter("@Cid", Cid));
                 if (dt.Rows.Count == 0)
                 {
                     return null;
                 }
                 else
                 {
                     foreach (DataRow row in dt.Rows)
                     {
                         userinfo.Cusid = (int)row["Cusid"];
                         userinfo.CName = row["CusName"].ToString();
                         userinfo.Price = Convert.ToDouble(row["price"]);
                         userinfo.Foot = (bool)row["issettle"];
                         userinfo.Time = Convert.ToDateTime(row["IAEDate"]);
                         userinfo.Remark = (row["Remark"] == DBNull.Value) ? "" : row[5].ToString();
                     }
                     return userinfo;
                 }

             }
             catch (Exception e)
             {
                 throw e;
             }
         }
    }
}
