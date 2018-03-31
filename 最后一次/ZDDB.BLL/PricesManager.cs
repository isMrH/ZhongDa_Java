using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.DAL;
using ZDDB.Model;

namespace ZDDB.BLL
{
    public class PricesManager
    {
        PricesService ps=new PricesService();
        //得到所有信息
        public List<PriceTB> GetAllInfo()
        {
            return ps.GetAllInfo();
        }
        //筛选
        public List<PriceTB> GetTempByFilter(string pno, string des, double kilo, double price)
        {
            return ps.GetTempByFilter(pno, des, kilo, price);
        }
        //根据模板编号得到模板
        public List<PriceTB> GetPriceBypno(string pno)
        {
            return ps.GetPriceBypno(pno);
        }
         //根据模板编号，公斤数，目的地获得该件的运费
        public PriceTB GetPriceByInfo(string pno, double kilo, string des)
        {
            return ps.GetPriceByInfo(pno, kilo, des);
        }
        //查看是否有此模板
        public int GetCount(string pno)
        {
            return ps.GetCount(pno);
        }
    }
}
