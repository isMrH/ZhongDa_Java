using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.DAL;
using ZDDB.Model;

namespace ZDDB.BLL
{
    public class CustomerSentManager
    {
        CustomerSentService css=new CustomerSentService();
         //得到所有信息
        public List<CustomerSentTB> GetAll()
        {
            return css.GetAll();
        }
         //根据id获取信息
        public CustomerSentTB GetInfoByid(int csid)
        {
            return css.GetInfoByid(csid);
        }
         //插入信息
        public int InsertInfo(CustomerSentTB cst)
        {
            return css.InsertInfo(cst);
        }
         //修改信息
        public int UpdateInfo(CustomerSentTB cst)
        {
            return css.UpdateInfo(cst);
        }
        public CustomerSentTB GetCustomerSentTBById(int cid, DateTime qtime, DateTime ttime)
        {
            return css.GetCustomerSentTBById(cid, qtime, ttime);
        }
        //删除信息
        public void DelInfo(int csid)
        {
            css.DelInfo(csid);
        }
        public CustomerSentTB GetCustomerSentTBById(string cid, DateTime qtime, DateTime ttime)
        {
            return css.GetCustomerSentTBById(cid, qtime, ttime);
        }
         //筛选
        public List<CustomerSentTB> GetTempByFilter(long pno, string des, int cusid, int cid)
        {
            return css.GetTempByFilter(pno, des, cusid, cid);
        }
        //得到无头件信息
        public List<CustomerSentTB> GetInfoBycount()
        {
            return css.GetInfoByPrice();
        }
         //修改无头件信息
        public int UpdateWu(int cusid, int comid,double price,long rid)
        {
            return css.UpdateWu(cusid,comid,price,rid);
        }
    }
}
