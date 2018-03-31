using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //客户费用结算表
    [Serializable]
    public class CustomerPianTB
    {
        //结算ID
        public int CPid { get; set; }
        //客户ID
        public int CusID { get; set; }
        public CustomersTB customer { get; set; }
        //费用年月
        public DateTime DateMon { get; set; }
        //面单费用
        public double OddMon { get; set; }
        //发件费
        public double SendMon { get; set; }
        //送件费
        public double GiveMon { get; set; }
        //收到付件返利
        public double BackMon { get; set; }
        //派到付件款
        public double AccMon { get; set; }
        //其他费用
        public double OtherMon { get; set; }
        //总计
        public double AllMon { get; set; }
        //是否结款
        public string ISsettle { get; set; }
        //备注
        public string Remark { get; set; }

    }
}
