using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using ZDDB.DAL;


namespace ZDDB.BLL
{
    public class CustomerPianManager
    {
        CustomerPianService customerpianservice = new CustomerPianService();
        public int AddCustomerPianTBInfo(CustomerPianTB cp)
        {
            return customerpianservice.AddCustomerPianTBInfo(cp);
        }

        public List<CustomerPianTB> GetAllCustomerPianTB()
        {
            return customerpianservice.GetAllCustomerPianTB();
        }

        //更新结算信息
        public int UpdateCustomerPianTBById(CustomerPianTB cp)
        {
            return customerpianservice.UpdateCustomerPianTBById(cp);
        }

        //删除
        public void DeleteCInfoId(int cusid)
        {
            customerpianservice.DeleteCInfoId(cusid);
        }

        //查询结算信息
        public List<CustomerPianTB> GetAllCustomerPianTBInfo(int cusid)
        {
            return customerpianservice.GetAllCustomerPianTBInfo(cusid);
        }

        public CustomerPianTB GetCustomerPianTBById(int cid, DateTime qtime, DateTime ttime)
        {
            return customerpianservice.GetCustomerPianTBById(cid,qtime,ttime);
        }
    }
}
