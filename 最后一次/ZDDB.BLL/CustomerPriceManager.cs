using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.DAL;
using ZDDB.Model;

namespace ZDDB.BLL
{
    public class CustomerPriceManager
    {
        CustomerPriceService cps=new CustomerPriceService();
         //查询所有信息
        public List<CustomerPriceTB> GetAllInfo()
        {
            return cps.GetAllInfo();
        }
         //插入数据
        public int InsertInfo(CustomerPriceTB cp)
        {
            return cps.InsertInfo(cp);
        }
        //筛选
        public List<CustomerPriceTB> GetTempByFilter(int cusid, int cid, string pno, string cpname)
        {
            return cps.GetTempByFilter(cusid, cid,pno,cpname);
        }
        //修改价格模板
        public int UpdateTemp(int cpid, string pno,string remark)
        {
            return cps.UpdateTemp(cpid,pno,remark);
        }
        //删除
        public void DelIfo(int cpid)
        {
            cps.DelIfo(cpid);
        }
        //根据id获取信息
        public CustomerPriceTB GetInfoById(int cpid)
        {
            return cps.GetInfoById(cpid);
        }
         //根据公司id和客户id获得该客户在该公司的价格模板
        public CustomerPriceTB GetInfoByCusidAndCid(int cusid, int cid)
        {
            return cps.GetInfoByCusidAndCid(cusid, cid);
        }
        //查看该客户在某公司是否有价格模板
        public int GetCountInfo(int cusid, int cid)
        {
            return cps.GetCountInfo(cusid, cid);
        }
    }
}
