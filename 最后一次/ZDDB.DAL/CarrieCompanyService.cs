using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZDDB.Model;
namespace ZDDB.DAL
{
    public class CarrieCompanyService
    {
        //获取承运公司
        public List<CarrieCompanyTB> GetAllCarrieCompany()
        {
            string strsql = "select * from CarrieCompanyTB";
            return GetCarrieCompanyBySql(strsql);
        }
        //组合查询公司
        public List<CarrieCompanyTB> SelectCarrieCompany(string CoName, string Man)
        {
            string strsql = "select * from CarrieCompanyTB where 1=1";
            if (CoName != "")
            {
                strsql += " and CoName='"+CoName+"'";
            }
            if (Man != "")
            {
                strsql += " and Clinkman='"+Man+"'";
            }
            return GetCarrieCompanyBySql(strsql);
        }
        //根据公司id获取公司
        public CarrieCompanyTB GetCompanyByid(int cid)
        {
            string strsql = "select * from CarrieCompanyTB where cid="+cid;
            return GetCarrieCompanyBySql(strsql)[0];
        }
        //获取信息
        private static List<CarrieCompanyTB> GetCarrieCompanyBySql(string strsql)
        {
            List<CarrieCompanyTB> list = new List<CarrieCompanyTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                CarrieCompanyTB cc = new CarrieCompanyTB();
                cc.Cid =Convert.ToInt32( row["Cid"]);
                cc.CoName = row["CoName"].ToString();
                cc.Clinkman = row["Clinkman"].ToString();
                cc.LinkmanTel = row["LinkmanTel"].ToString();
                cc.Cmoney = Convert.ToDouble(row["Cmoney"]);
                cc.Remark = row["Remark"].ToString();

                list.Add(cc);
            }
            return list;
        }
        //根据承运公司id查面单价格
        public object GetCarrieCompanyMon(int cid)
        {
            string strsql = "select Cmoney from CarrieCompanyTB where Cid=" + cid;
            return DBHelper.GetScalar(strsql);

        }
        //根据承运公司cid查询信息
        public CarrieCompanyTB GetCarrieCompanyname(int cid)
        {
            string strsql = "select * from CarrieCompanyTB where Cid=" + cid;
            List<CarrieCompanyTB> allcmy = GetCarrieCompanyBySql(strsql);
            return allcmy[0];
        }

        //根据公司id删除公司
        public bool DeleteCarrieCompany(int id)
        {
            int count = 0;
            string sql;
            sql = "select count(*) from AcceptTB where CID=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from CustomerPriceTB where CID=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from CustomerSentTB where CID=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from DisNoteTB where CID=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from RegisterTB where CID=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from SentTB where CID=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            if (count > 0)
            {
                return false;
            }
            else
            {
                sql = "delete from CarrieCompanyTB where Cid=@id";
                DBHelper.ExecuteCommand(sql, new SqlParameter("@id", id));
                return true;
            }
        }
        //根据Cid修改公司内容
        public int UpdateCarrieCompanyByCid(int Cid, CarrieCompanyTB cacom)
        {
            string str = "Update CarrieCompanyTB set CoName=@CoName,Clinkman=@Clinkman,LinkmanTel=@LinkmanTel,Cmoney=@Cmoney,Remark=@Remark where Cid=@Cid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Cid",Cid),
                new SqlParameter("@CoName",cacom.CoName),
                new SqlParameter("@Clinkman",cacom.Clinkman),
                new SqlParameter("@LinkmanTel",cacom.LinkmanTel),
                new SqlParameter("@Cmoney",cacom.Cmoney),
                new SqlParameter("@Remark",cacom.Remark)
            };
            return DBHelper.ExecuteCommand(str, para);
        }
        //插入新的公司
        public int InsertCarrieCompany(CarrieCompanyTB cacom)
        {
            string str = "insert into CarrieCompanyTB values (@CoName,@Clinkman,@LinkmanTel,@Cmoney,@Remark)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CoName",cacom.CoName),
                new SqlParameter("@Clinkman",cacom.Clinkman),
                new SqlParameter("@LinkmanTel",cacom.LinkmanTel),
                new SqlParameter("@Cmoney",cacom.Cmoney),
                new SqlParameter("@Remark",cacom.Remark)
            };
            return DBHelper.ExecuteCommand(str, para);
        }
        //根据coName查询是否已有该公司
        public CarrieCompanyTB selectIsHaveCarrieCompany(string CoName)
        {
            string str = "select * from CarrieCompanyTB where CoName=@CoName";
            CarrieCompanyTB carcom = new CarrieCompanyTB();
            try
            {
                DataTable dt = DBHelper.GetTable(str, new SqlParameter("@CoName", CoName));
                foreach (DataRow row in dt.Rows)
                {
                    carcom.Cid = Convert.ToInt32(row["Cid"]);
                    carcom.CoName = (string)row["coName"];
                    carcom.Clinkman = (string)row["Clinkman"];
                    carcom.LinkmanTel = (string)row["LinkmanTel"];
                    carcom.Cmoney = Convert.ToDouble(row["Cmoney"]);
                    carcom.Remark = (row["Remark"] == DBNull.Value) ? "" : row[5].ToString();
                }
                return carcom;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
