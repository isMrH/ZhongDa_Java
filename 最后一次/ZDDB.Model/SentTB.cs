using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //揽发到付件表
    [Serializable]
    public class SentTB
    {
        //揽发到付件ID
        public int Sid { get; set; }
        //客户ID
        public int CusID { get; set; }
        public CustomersTB cust { get; set; }
        //承运公司
        public CarrieCompanyTB company { get; set; }
        //承运公司ID
        public int Cid { get; set; }
        //面单号
        public long CSid { get; set; }
        //重量
        public double Kilo { get; set; }
        //金额
        public double Price { get; set; }
        //是否已结算
        public bool ISsettle { get; set; }
        //起运时间
        public DateTime BeginDate { get; set; }
        //备注
        public string Remark { get; set; }

    }
}
