using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.DAL;
using ZDDB.Model;

namespace ZDDB.BLL
{
    public class CarrieCompanyManager
    {
        CarrieCompanyService ccs = new CarrieCompanyService();

        //获取承运公司
        public List<CarrieCompanyTB> GetAllCarrieCompany()
        {
            return ccs.GetAllCarrieCompany();
        }
        //组合查询公司
        public List<CarrieCompanyTB> SelectCarrieCompany(string CoName, string Man)
        {
            return ccs.SelectCarrieCompany(CoName, Man);
        }
         //根据公司id获取公司
        public CarrieCompanyTB GetCompanyByid(int cid)
        {
            return ccs.GetCompanyByid(cid);
        }
        //根据承运公司id查面单价格
        public object GetCarrieCompanyMon(int cid)
        {
            return ccs.GetCarrieCompanyMon(cid);
        }
        //根据公司id删除公司
        public bool DeleteCarrieCompany(int Cid)
        {
            return ccs.DeleteCarrieCompany(Cid);
        }
        //根据公司名查看是否已有该公司
        public int SelectCarrieCompanyByCoName(string CoName)
        {
            CarrieCompanyTB car = ccs.selectIsHaveCarrieCompany(CoName);
            if (car.CoName == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        //根据Cid修改公司内容
        public int UpdateCarrieCompanyByCid(int Cid, CarrieCompanyTB cacom)
        {
            return ccs.UpdateCarrieCompanyByCid(Cid, cacom);
        }
        //插入新的公司
        public int InsertCarrieCompany(CarrieCompanyTB cacom)
        {
            return ccs.InsertCarrieCompany(cacom);
        }
    }
}
