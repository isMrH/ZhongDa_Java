using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using ZDDB.DAL;
using ZDDB.BLL;
using ZDDB.Model;


  public class ExeclHelper
    {
     
        public static string LoadDataFromExcel(string filePath, string fileName, string tableName)
        {
            string Mess = string.Empty;
            //try
            //{
                if (!tableName.EndsWith("$"))
                {
                    tableName = tableName + "$";
                }

                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                string sql = "SELECT * FROM [" + tableName + "]";
                OleDbCommand com = new OleDbCommand(sql, OleConn);
                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet ds = new DataSet();
                OleDaExcel.Fill(ds, tableName);
                OleConn.Close();
                
                int k = 0;
                int Datacount = 0;
                for (int n = 0; n < ds.Tables.Count; n++)
                {
                    if (ds.Tables[n].Rows.Count < 1)
                    {
                        Mess = "没有任何数据！";
                        Datacount++;
                    }
                }
                //截取文件名
                if (fileName.Length > 0)
                {
                    fileName = fileName.Substring(0, fileName.Length - 4);

                }
                for (int j = 0; j < ds.Tables.Count; j++)
                {
                    for (int i = 0; i < ds.Tables[j].Rows.Count; i++)
                    {
                        for (int w = 1; w < ds.Tables[j].Columns.Count; w++)
                        {
                            string kg = ds.Tables[j].Columns[w].ToString();
                            kg = kg.Substring(0, kg.Length - 2);
                            string sqlStr = "insert into PriceTB(PNo,Destination,Kilo,Price) values";
                            sqlStr += " ('" + fileName + "','";//模板
                            sqlStr += ds.Tables[j].Rows[i][0].ToString() + "','";//目的地
                            sqlStr += Convert.ToSingle(kg) + "',";//公斤数
                            sqlStr += Convert.ToSingle(ds.Tables[j].Rows[i + 1][w]) + ")";//价格
                            int row = DBHelper.ExecuteCommand(sqlStr);
                            k += row;
                        }
                    }
                }
                Mess = k.ToString();
                return Mess;
            //}
            //catch (Exception ex)
            //{
            //    Mess = ex.Message;
            //    return Mess;
            //}
        }

        public static string LoadDataFromExcel1(string filePath, string fileName, string tableName)
        {

            CustomerPriceService priceservce = new CustomerPriceService();
            string Mess = string.Empty;
            try
            {
                if (!tableName.EndsWith("$"))
                {
                    tableName = tableName + "$";
                }

                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                string sql = "SELECT * FROM [" + tableName + "]";
                OleDbCommand com = new OleDbCommand(sql, OleConn);
                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet ds = new DataSet();
                OleDaExcel.Fill(ds, tableName);
                OleConn.Close();
                int k = 0;
                int Datacount = 0;
                for (int n = 0; n < ds.Tables.Count; n++)
                {
                    if (ds.Tables[n].Rows.Count < 1)
                    {
                        Mess = "没有数据！";
                        Datacount++;
                    }
                }
                for (int j = 0; j < ds.Tables.Count; j++)
                {
                    for (int i = 0; i < ds.Tables[j].Rows.Count; i++)
                    {
                        long num = Convert.ToInt64(ds.Tables[j].Rows[i + 1][1]);
                        string sqlStr = "insert into CustomerSentTB(Rid,CusID,Cid,Destination,Kilo,Price,Resdate,IsSet) values";
                        sqlStr += " (" + ds.Tables[j].Rows[i + 1][1].ToString() + ",";//面单号
                        //面单分配
                        DisNoteManager numdis = new DisNoteManager();
                        DisNoteTB dnt = new DisNoteTB();
                        //根据面单号查客户ID和公司ID
                        dnt = numdis.GetNoteByRid(Convert.ToInt64(ds.Tables[j].Rows[i + 1][1]));
                        if (dnt.Customer != null)
                        {
                            sqlStr += dnt.Customer.CusID + ",";//客户ID
                            sqlStr += dnt.CarrieCompany.Cid + ",'";//公司ID
                        }
                        else
                        {
                            sqlStr += "null" + ",";
                            sqlStr += "null" + ",'";
                        }
                        sqlStr += ds.Tables[j].Rows[i + 1][2].ToString() + "',";//目的地
                        double kg = Convert.ToDouble(ds.Tables[j].Rows[i + 1][3]);
                        if (kg % 1 > 0)
                        {
                            kg = kg - kg % 1 + 1;
                        }
                        sqlStr += Convert.ToDouble(ds.Tables[j].Rows[i + 1][3]) + ",";//公斤数
                        if (dnt.Customer != null)
                        {
                            CustomerPriceTB tem = new CustomerPriceTB();
                            tem = priceservce.GetInfoByCusidAndCid(dnt.Customer.CusID, dnt.CarrieCompany.Cid);
                            PriceTB pt = new PriceTB();
                            PricesManager pm = new PricesManager();
                            pt = pm.GetPriceByInfo(tem.PNo, kg, ds.Tables[j].Rows[i + 1][2].ToString());
                            double price = pt.Price;
                            sqlStr += price + ",'";//运费

                        }
                        else
                        {
                            sqlStr += 0 + ",'";//运费
                        }
                        sqlStr += Convert.ToDateTime(ds.Tables[j].Rows[i + 1][4].ToString().Trim()) + "',";//揽件时间
                        sqlStr += 0 + ")";
                        int row = DBHelper.ExecuteCommand(sqlStr);
                        k += row;
                    }
                }
                Mess = k.ToString();
                return Mess;
            }
            catch (Exception ex)
            {
                Mess = "" + ex.Message;
                return Mess;
            }
        }
   
}
