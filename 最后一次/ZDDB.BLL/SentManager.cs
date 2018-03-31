using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using ZDDB.DAL;

namespace ZDDB.BLL
{
    public class SentManager
    {
        SentService sentservice = new SentService();
        public SentTB GetSentTBById(int cid, DateTime qtime, DateTime ttime)
        {
            return sentservice.GetSentTBById(cid,qtime,ttime);
        }
        //谷恒远1-7
        SentService ss = new SentService();
        //得到所有的信息
        public List<SentTB> GetAllSentTB()
        {
            return ss.GetAllSentTB();
        }
        //插入信息
        public int InsertSentTB(SentTB st)
        {
            return ss.InsertSentTB(st);
        }
        //联合查询
        public List<SentTB> GetInfoByFilter(string Coname, string CusName, string begintime, string begintime1, string numbers)
        {
            return ss.GetInfoByFilter(Coname, CusName, begintime, begintime1, numbers);
        }
        //根据时间查询信息
        public SentTB GetSentTBById(string cid, DateTime qtime, DateTime ttime)
        {
            return sentservice.GetSentTBById(cid, qtime, ttime);
        }
        //修改信
         public int UpdateSentTB(SentTB st)
        {
            return ss.UpdateSentTB(st);
        }
        //根据ID获取信息
        public SentTB GetSentTBById(int Sid)
        {
            return ss.GetSentTBById(Sid);
        }
        //删除
        public int DeleteSentTBInfo(int sid)
        {
            return ss.DeleteSentTBInfo(sid);
        }
        public int GetSentTBById(string id)
        {
            return ss.GetSentTBById(id);
        }
    }
}
