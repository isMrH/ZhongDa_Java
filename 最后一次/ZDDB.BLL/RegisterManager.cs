using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.DAL;
using ZDDB.Model;

namespace ZDDB.BLL
{
    //杨立君全部
    
    public class RegisterManager
    {
        RegisterService registerTBService = new RegisterService();
        //插入面单购买信息
        public int InsertRegister(RegisterTB reg)
        {
            return registerTBService.InsertRegister(reg);
        }
        //根据公司id查询所有
        //根据公司查询所有
        public List<RegisterTB> GetAllRegisterTBByCid(string Cid, string begin, string end, string datatime, string datatime2)
        {
            return registerTBService.GetAllRegisterTBByCid(Cid, begin, end, datatime, datatime2);
        }
           //查询所有的面单购买情况
        public List<RegisterTB> GetAllRegisterTB()
        {
            return registerTBService.GetAllRegisterTB();
        }
          //修改面单购买信息
        public int UpdateRegisterTB(RegisterTB reg)
        { 
           return registerTBService.UpdateRegisterTB(reg);
        }
        //根据rid查询所有信息
        public RegisterTB GetAllRegisterTBByRid(long Rid)
        {
            return registerTBService.GetAllRegisterTBByRid(Rid);
        }
             //删除操作
        public int DeleteRegisterTB(string Rid)
        {
            return registerTBService.DeleteRegisterTB(Rid);
        }
         //查询该面单是否购买
        public int IsBuy(long rid)
        {
            return registerTBService.IsBuy(rid);
        }
        //根据id号查询所有信息
        public RegisterTB GetAllTBByRid(string Rid)
        {
            return registerTBService.GetAllTBByRid(Rid);
        }
        //查询有无面单起始号
        public int GetAllbegin(string begin)
        {
            return registerTBService.GetAllbegin(begin);
        }
        //面单结束号
        public int GetAllend(string end)
        {
            return registerTBService.GetAllend(end);
        }
        
        public int number(string id, string begin, string end)
        {

            return registerTBService.number(id, begin, end);
        }
    }
}
