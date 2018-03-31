using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //面单分配记录表
    [Serializable]
    public class DisNoteTB
    {
        //面单分配ID
        public int Nid{get;set;}
        //客户ID
        public int CusID
        {
            get;
            set;
        }
        public CustomersTB Customer { get; set; }
        //公司ID
        public int Cid
        {
            get;
            set;
        }
        public CarrieCompanyTB CarrieCompany { get; set; }
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
        //分配时间
        public DateTime Dtime
        {
            get;
            set;
        }
        //金额
        public double Sum
        {
            get;
            set;
        }
        //是否已结算
        public string  IsSet
        {
            get;
            set;
        }
        // 备注
        public string Remark
        {
            get;
            set;
        }
    }
}
