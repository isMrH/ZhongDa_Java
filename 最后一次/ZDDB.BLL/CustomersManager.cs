using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.DAL;
using ZDDB.Model;

namespace ZDDB.BLL
{
    public class CustomersManager
    {
        CustomersService customerservice = new CustomersService();
        //获取客户
        public List<CustomersTB> GetAllCustomers()
        {
            return customerservice.GetAllCustomers();
        }
        //查询客户
        public List<CustomersTB> SelectCustomers(string CName, int IsCounterman)
        {
            return customerservice.SelectCustomers(CName,IsCounterman);
        }
        //根据客户id获取客户
        public CustomersTB GetCusmoerByid(int cusid)
        {
            return customerservice.GetCusmoerByid(cusid);
        }
        //插入新的客户
        public int InsertCustomer(CustomersTB cus)
        {
            return customerservice.InsertCustomer(cus);
        }
        //根据Cusid修改客户信息
        public int UpdateCustomerByCusId(int Cusid, CustomersTB cus)
        {
            return customerservice.UpdateCustomerByCusId(Cusid, cus);
        }
        //根据客户id删除客户信息
        //删除客户信息
        public bool DelCustomer(int id)
        {
            return customerservice.DelCustomer(id);
        }
    }
}
