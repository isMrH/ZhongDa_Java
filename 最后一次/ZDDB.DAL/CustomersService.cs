using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZDDB.Model;

namespace ZDDB.DAL
{
    public class CustomersService
    {
        //获取所有客户
        public List<CustomersTB> GetAllCustomers()
        {
            string strsql = "select * from CustomersTB";
            return GetCustomersBySql( strsql);
        }
        //客户查询
        public List<CustomersTB> SelectCustomers(string CName, int  IsCounterman)
        {
            string strsql = "select * from CustomersTB where 1=1";
            if (CName != "")
            {
                strsql += " and CusName='"+CName+"'";
            }
            if (IsCounterman !=2)
            {
                strsql += " and IsCounterman="+IsCounterman;
            }
            return GetCustomersBySql(strsql);
        }
        //根据客户id获取客户
        public CustomersTB GetCusmoerByid(int cusid)
        {
            string strsql = "select * from customerstb where cusid="+cusid;
          
            return GetCustomersBySql(strsql)[0];
        }
        //根据客户Id修改客户信息
        public int UpdateCustomerByCusId(int Cusid, CustomersTB cus)
        {
            string str = "Update CustomersTB set CusName=@CusName,CusTel=@CusTel,IsCounterman=@IsCounterman,Remark=@Remark where Cusid=@Cusid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Cusid",Cusid),
                new SqlParameter("@CusName",cus.CusName),
                new SqlParameter("@CusTel",cus.CusTel),
                new SqlParameter("@IsCounterman",cus.IsCounterman),
                new SqlParameter("@Remark",cus.Remark)
            };
            return DBHelper.ExecuteCommand(str, para);
        }
        //添加新客户
        public int InsertCustomer(CustomersTB cus)
        {
            string str = "insert into CustomersTB values (@CusName,@CusTel,@IsCounterman,@Remark)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CusName",cus.CusName),
                new SqlParameter("@CusTel",cus.CusTel),
                new SqlParameter("@IsCounterman",cus.IsCounterman),
                new SqlParameter("@Remark",cus.Remark)
            };
            return DBHelper.ExecuteCommand(str, para);
        }
        //根据客户id删除客户信息
        public bool DelCustomer(int id)
        {
            int count = 0;
            string sql;
            sql = "select count(*) from AcceptTB where Cusid=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from CustomerPianTB where Cusid=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from CustomerPriceTB where Cusid=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from CustomerSendTB where Cusid=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from CustomerSentTB where Cusid=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from DelGoodsMonTB where Cusid=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from DisNoteTB where Cusid=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from IAEManagerTB where Cusid=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            sql = "select count(*) from SentTB where Cusid=@id";
            count += DBHelper.Getscalar(sql, new SqlParameter("@id", id));
            if (count > 0)
            {
                return false;
            }
            else
            {
                sql = "delete from CustomersTB where Cusid=@id";
                DBHelper.ExecuteCommand(sql, new SqlParameter("@id", id));
                return true;
            }
        }
        //得到数据
        private static List<CustomersTB> GetCustomersBySql(string strsql)
        {
            List<CustomersTB> list = new List<CustomersTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                CustomersTB cut = new CustomersTB();
                cut.CusID =Convert.ToInt32( row["CusID"]);
                cut.CusName = row["CusName"].ToString();
                cut.CusTel = row["CusTel"].ToString();
                cut.IsCounterman = row["IsCounterman"].ToString();
                if (cut.IsCounterman == "True")
                {
                    cut.IsCounterman = "是";
                }
                else
                {
                    cut.IsCounterman = "否";
                }
                cut.Remark = row["Remark"].ToString();

                list.Add(cut);
            }
            return list;
        }
        
    }
}
