using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZDDB.Model;

namespace ZDDB.DAL
{
    //杨立君全部
    public  class RegisterService
    {
        //实例化承运公司service
        CarrieCompanyService CCom = new CarrieCompanyService();
        //自定义方法
        private List<RegisterTB> GetAllRegisterTBBySql( string strsql)
        { 
           
            //实例化范集合
            List<RegisterTB> allRegisterTB = new List<RegisterTB>();
            //填充数据集
            DataTable dt = DBHelper.GetTable(strsql);
            //遍历集合
            foreach (DataRow row in dt.Rows)
            {
                //实例化类
                RegisterTB reg = new RegisterTB();
               
                reg.Rid = Convert.ToInt32(row["Rid"]);
                reg.Cid = Convert.ToInt32(row["Cid"]);
                reg.BeginNo = (long)row["BeginNo"];
                reg.EndNo = (long)row["EndNo"];
                reg.Buydate = Convert.ToDateTime(row["BuyDate"]);
                reg.Remark = (row["Remark"] == DBNull.Value) ? "" : row["Remark"].ToString();
                reg.CCompany = CCom.GetCompanyByid(Convert.ToInt32( row["Cid"]));
            

                allRegisterTB.Add(reg);
            }
            return allRegisterTB;
        }
        //李兰兰
        //查询所有的面单购买情况
        public List<RegisterTB> GetAllRegisterTB()
        {
            string strsql = "select * from RegisterTB";
            return GetAllRegisterTBBySql(strsql);
        }
        //李兰兰
        //查询该面单是否购买
        public int IsBuy(long rid)
        {
            string strsql = string.Format("select count(*) from RegisterTB where beginno<='{0}' and endno>='{1}'", rid, rid);
            int cnt = Convert.ToInt32(DBHelper.GetScalar(strsql));
            return cnt;
        }
        //根据公司查询所有
        //根据公司查询所有
        public List<RegisterTB> GetAllRegisterTBByCid(string Cid, string begin, string end, string datatime, string datatime2)
        {
            string strsql = "select * from RegisterTB where 1=1";
            if (Cid != "")
            {
                strsql += " and Cid=" + Cid;
            }
            if (begin != "")
            {
                strsql += " and '" + begin + " ' between BeginNo and EndNo";
            }
            if (end != "")
            {
                strsql += " and '" + end + " ' between BeginNo and EndNo";
            }
            if (datatime != "" || datatime2 != "")
            {
                strsql += " and Buydate between '" + datatime + "' and '" + datatime2 + "'";
            }

            return GetAllRegisterTBBySql(strsql);
        }
        //插入面单购买的面单
        public int InsertRegister(RegisterTB reg)
        {
            //拼写连接串
            string strsql = "insert into RegisterTB values(@Cid,@BeginNo,@EndNo,@Buydate,@Remark)";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                    {
                         new SqlParameter("@Cid",reg.Cid ),
                         new SqlParameter("@BeginNo", reg.BeginNo),
                         new SqlParameter("@EndNo", reg.EndNo),
                         new SqlParameter("@Buydate", reg.Buydate),
                         new SqlParameter("@Remark", reg.Remark)

                    };
                return DBHelper.ExecuteCommand(strsql, para);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }   
        }
        //李兰兰
        //根据rid查询所有信息
        public RegisterTB GetAllRegisterTBByRid(long Rid)
        {
            string strsql = "select * from RegisterTB where beginno=" + Rid;
            return GetAllRegisterTBBySql(strsql)[0];
        }
        //修改面单购买信息
        public int UpdateRegisterTB(RegisterTB reg)
        {
            //拼写连接串
            string strsql = "update RegisterTB set Cid=@Cid,BeginNo=@BeginNo,EndNo=@EndNo,Buydate=@Buydate,Remark=@Remark where Rid=@Rid";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                    {
                         new SqlParameter("@Rid",reg.Rid ),
                         new SqlParameter("@Cid",reg.Cid ),
                         new SqlParameter("@BeginNo", reg.BeginNo),
                         new SqlParameter("@EndNo", reg.EndNo),
                         new SqlParameter("@Buydate", reg.Buydate),
                         new SqlParameter("@Remark", reg.Remark)

                    };
                return DBHelper.ExecuteCommand(strsql, para);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }   
        }
        //删除操作
        public int DeleteRegisterTB(string Rid)
        {
            string strsql = "delete from RegisterTB where Rid= @Rid";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                    {
                         new SqlParameter("@Rid",Rid)
                        
                    };
                return DBHelper.ExecuteCommand(strsql, para);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        //根据id号查询所有信息
        public RegisterTB GetAllTBByRid(string Rid)
        {
            string strsql = "select * from RegisterTB where Rid=" + Rid;
            return GetAllRegisterTBBySql(strsql)[0];
        }
        //查询有无面单起始号
        public int GetAllbegin(string begin)
        {
            string strsql = "select count(*) from RegisterTB where '" + begin + " ' between BeginNo and EndNo";
            return Convert.ToInt32(DBHelper.GetScalar(strsql));
        }
        //面单结束号
        public int GetAllend(string end)
        {
            string strsql = "select count(*) from RegisterTB where '" + end + " ' between BeginNo and EndNo";
            return Convert.ToInt32(DBHelper.GetScalar(strsql));
        }
        //查重复
        public int number(string id, string begin, string end)
        {
            string strsql = "select count(*) from RegisterTB where  Cid='" + id + "' and  '" + begin + "' between BeginNo and EndNo and  '" + end + "' between BeginNo and EndNo";

            return Convert.ToInt32(DBHelper.GetScalar(strsql));
        }


    }
}
