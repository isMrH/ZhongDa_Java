using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //其他收支管理表
    [Serializable]
    public class IAEManagerTB
    {
        //其他收支ID
        public int IAEid { get; set; }
        //客户ID
        public int CusID { get; set; }
        public CustomersTB customer { get; set; }
        //收支日期
        public DateTime IAEDate { get; set; }
        //费用名称
        public string IAEName { get; set; }
        //金额
        public double Price { get; set; }
        //是否已结算
        public string  ISsettle { get; set; }
        //备注
        public string Remark { get; set; }
    }
}
