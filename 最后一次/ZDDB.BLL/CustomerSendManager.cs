using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using ZDDB.DAL;

namespace ZDDB.BLL
{
    public class CustomerSendManager
    {
      CustomerSendService cusdd = new CustomerSendService();
       //获取所有客户送件信息
      public List<CustomerSendTB> GetAllCustomerSendTB()
      {
          return cusdd.GetAllCustomerSendTB();
      }
        //添加新记录
      public int InsertCustomerSend(CustomerSendTB CSend)
      {
          return cusdd.InsertCustomerSend(CSend);
      }
      //根据CEid查询所有
      public CustomerSendTB SelectCustomerSendByCEid(int CEid)
      {
          return cusdd.SelectCustomerSendByCEid(CEid);
      }
        //修改记录
      public int UpdateCustomerSend(CustomerSendTB CSend)
      {
          return cusdd.UpdateCustomerSend(CSend);
      }
        //根据Cusid查询所有
      public List<CustomerSendTB> SelectCustomerSendByCusid(int Cusid, string number, string money, string date, string data2, int iss)
      {
          return cusdd.SelectCustomerSendByCusid(Cusid, number, money, date, data2, iss);
      }
     
       //根据CEid删除信息
      public int DelCustomerSend(int CEid)
      {
          return cusdd.DelCustomerSend(CEid);
      }

      public CustomerSendTB GetCustomerSendTBById(int cid, DateTime qtime, DateTime ttime)
      {
          return cusdd.GetCustomerSendTBById(cid,qtime,ttime);
      }
    }
   
}
