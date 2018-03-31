using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;
using ZDDB.DAL;


namespace ZDDB.BLL
{
   public  class DisNoteManager
    {
       //杨立君全部
       DisNoteService DNTSe=new DisNoteService();
      
       //查询所有的分配记录
       public List<DisNoteTB> GetAllDisNoteTB()
       {
           return DNTSe.GetAllDisNoteTB();
       }
       //条件查询功能
       public List<DisNoteTB> GetAllDisNoteTBByBoth(string cusid, string cid, string begin, string end, string datetimes, string date2, int iss)
       {
           return DNTSe.GetAllDisNoteTBByBoth(cusid, cid, begin, end, datetimes, date2, iss);
       }
        //添加面单分配信息
        public int InsertDisNoteTB(DisNoteTB Disnote)
        {
          return DNTSe.InsertDisNoteTB(Disnote);
        }
        //修改表信息
        public int UpdateDisNoteTB(DisNoteTB Disnote)
        {
          return DNTSe.UpdateDisNoteTB(Disnote);
        }
        //删除的方法
        public int DeleTeDisNoteTB(string Nid)
        {
            return DNTSe.DeleTeDisNoteTB(Nid);
        }
        //根据Nid查询所有返回单行记录
        public DisNoteTB GetByNidDisNoteTB(int Nid)
        {
            return DNTSe.GetByNidDisNoteTB(Nid);
        }
        //根据面单号查询客户id和公司id
        public DisNoteTB GetNoteByRid(long rid)
        {
            return DNTSe.GetNoteByRid(rid);
        }
        //验证是否查重
        public bool CusidAndCid(int cusid, int cid)
        {
            return DNTSe.CusidAndCid(cusid, cid);
        }
       //联合查询
        public DisNoteTB GetDisNoteTBById(int cid, DateTime qtime, DateTime ttime)
        {
            return DNTSe.GetDisNoteTBById(cid, qtime, ttime);
        }
       //查重
        public int numbers(string cusid, string cid, string beginno, string endno)
        {
            return DNTSe.numbers(cusid, cid, beginno, endno);
        }
       //谷恒远1-8 
        //通过面单号获得面单分配表
        public DisNoteTB GetDisNoteTBByIds(string cid)
        {
            return DNTSe.GetDisNoteTBByIds(cid);
        }
        public DisNoteTB GetDisNoteTBById(string cid, DateTime qtime, DateTime ttime)
        {
            return DNTSe.GetDisNoteTBById(cid, qtime, ttime);
        }
       public int GetNoteIsDis(long rid)
        {
            return DNTSe.GetNoteIsDis(rid);
        }

    }
}
