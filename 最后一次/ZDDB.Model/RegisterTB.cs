using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //面单购买登记表
    [Serializable]
    public class RegisterTB
    {
        //面单购买ID
        public int Rid
        {
            get;
            set;
        }
        //公司ID
        public int Cid
        {
            get;
            set;
        }
        public CarrieCompanyTB CCompany { get; set; }
        //面单起始号
        public long BeginNo
        {
            get;
            set;
        }
        //面单结束号
        public long EndNo
        {
            get;
            set;
        }
        //购买时间
        public DateTime Buydate
        {
            get;
            set;
        }
        //备注
        public string  Remark
        {
            get;
            set;
        }

    }
}
