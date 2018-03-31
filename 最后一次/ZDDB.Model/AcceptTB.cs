using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //派收到付件表
    [Serializable]
    public class AcceptTB
    {
        //派收到付件ID
        public int Aid { get; set; }
        //客户ID
        public int CusID { get; set; }
        //承运公司ID
        public int CID { get; set; }
        //客户
        public CustomersTB cust { get; set; }
        //承运公司
        public CarrieCompanyTB company { get; set; }
        //面单号
        public long CSid { get; set; }
        //是否已结算
        public bool ISsettle { get; set; }
        //金额
        public double Price { get; set; }
        //起运时间
        public DateTime BeginDate { get; set; }
        //备注
        public string Remark { get; set; }
    }
}
