using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZDDB.DAL;
using ZDDB.Model;

namespace ZDDB.BLL
{
    public class FootTableManager
    {
        FootTableService FT = new FootTableService();
        //发件费
        public FootTableTB GetSelectUserByLoginid(int Cid)
        {
            return FT.GetSelectUserByLoginid(Cid);
        }
        //面单费
        public FootTableTB GetSelectDisNoteTBid(int Cid)
        {
            return FT.GetSelectDisNoteTBid(Cid);
        }
        //查询送件费
        public FootTableTB GetSelectCustomerSendTBid(int Cid)
        {
            return FT.GetSelectCustomerSendTBid(Cid);
        }
        //查询收货返利费
        public FootTableTB GetSelectSentTBid(int Cid)
        {
            return FT.GetSelectSentTBid(Cid);
        }
        //查询派发费
        public FootTableTB GetSelectAcceptTBid(int Cid)
        {
            return FT.GetSelectAcceptTBid(Cid);
        }
        //查询其他费
        public FootTableTB GetSelectIAEManagerTBid(int Cid)
        {
            return FT.GetSelectIAEManagerTBid(Cid);
        }
    }
}
