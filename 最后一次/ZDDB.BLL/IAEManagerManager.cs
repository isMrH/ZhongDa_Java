using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using ZDDB.DAL;

namespace ZDDB.BLL
{
    public class IAEManagerManager
    {
        //李兰兰
        IAEManagerService iaemanagerservice = new IAEManagerService();
        public IAEManagerTB GetIAEManagerTBById(int cid, DateTime qtime, DateTime ttime)
        {
            return iaemanagerservice.GetIAEManagerTBById(cid,qtime,ttime);
        }
        //
        public IAEManagerTB GetIAEManagerTBById(int iaeid)
        {
            return iaemanagerservice.GetIAEManagerTBById(iaeid);
        }
        //得到所有信息
        public List<IAEManagerTB> GetAll()
        {
            return iaemanagerservice.GetAll();
        }
        //添加信息
        public int InsertInfo(IAEManagerTB iae)
        {
            return iaemanagerservice.InsertInfo(iae);
        }
         //修改信息
        public int UpdateInfo(IAEManagerTB iae)
        {
            return iaemanagerservice.UpdateInfo(iae);
        }
        //根据id删除信息
        public int DelInfo(int iaeid)
        {
            return iaemanagerservice.DelInfo(iaeid);
        }
         //筛选
        public List<IAEManagerTB> GetTempByFilter(string cusid, string datetime,string endtime)
        {
            return iaemanagerservice.GetTempByFilter(cusid, datetime,endtime );
        }

        public IAEManagerTB GetIAEManagerTBById(string cid, DateTime qtime, DateTime ttime)
        {
            return iaemanagerservice.GetIAEManagerTBById(cid, qtime, ttime);
        }
    }
}
