using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using ZDDB.DAL;


namespace ZDDB.BLL
{
    public class AcceptManager
    {
        //谷恒远1-7
        AcceptService acceptservice = new AcceptService();
        //按照时间查询信息
        public AcceptTB GetAcceptTBById(int cid, DateTime qtime, DateTime ttime)
        {
            return acceptservice.GetAcceptTBById(cid,qtime,ttime);
        }
        //得到所有信息
        public List<AcceptTB> GetAllAcceptTB()
        {
            return acceptservice.GetAllAcceptTB();
        }
        //插入信息
        public int InsertAcceptTB(AcceptTB ap)
        {
            return acceptservice.InsertAcceptTB(ap);
        }
        //联合查询
        public List<AcceptTB> GetInfoByFilter(string Coname, string CusName, string begintime, string begintime1, string numbers)
        {
            return acceptservice.GetInfoByFilter(Coname, CusName, begintime, begintime1, numbers);
        }
        //通过ID获得信息
        public int GetAcceptTBById(string id)
        {
            return acceptservice.GetAcceptTBById(id);
        }
        //通过时间段获取信息
        public AcceptTB GetAcceptTBById(string cid, DateTime qtime, DateTime ttime)
        {
            return acceptservice.GetAcceptTBById(cid, qtime, ttime);
        }
        //修改信息
        public int UpdateSentTB(AcceptTB at)
        {
            return acceptservice.UpdateAcceptTB(at);
        }
        //通过ID获取信息
        public AcceptTB GetAcceptTBByIds(int Sid)
        {
            return acceptservice.GetAcceptTBByIds(Sid);
        }
        //删除信息
        public int DeleteAcceptTBInfo(int sid)
        {
            return acceptservice.DeleteAcceptTBInfo(sid);
        }
    }
}
