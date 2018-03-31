using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using ZDDB.DAL;

namespace ZDDB.BLL
{
    public class DelGoodsMonManager
    {
        DelGoodsMonService dgm=new DelGoodsMonService();
        public List<DelGoodMon> GetAllDelGoodMonInfo()
        {
            return dgm.GetAllDelGoodMonInfo();
        }
        public int UpdateDel(double DelUnitPrice, int DelID)
        {
            return dgm.UpdateDel(DelUnitPrice,DelID);
        }
        public DelGoodMon GetAllDelGoodsInfoByID(int DelID)
        {
            return dgm.GetAllDelGoodsInfoByID(DelID);
        }
        public int UpdateDel(DelGoodMon del)
        {
            return dgm.UpdateDel(del);
        }
        //插入功能
        public int InsertDelMon(DelGoodMon del)
        {
            return dgm.InsertDelMon(del);
        }
        //根据cusid查询
        public List<DelGoodMon> GetALLByCusidGoodsMon(int cusid,string money)
        {
            return dgm.GetALLByCusidGoodsMon(cusid, money);
        }
        //删除功能
        public int DelGoodsMon(string delID)
        {
            return dgm.DelGoodsMon(delID);
        }
         //获取价格
        public object GetMoney(int Cusid)
        {
            return dgm.GetMoney(Cusid);
        }
    }
}
