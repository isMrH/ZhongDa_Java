using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //送货价格表
    [Serializable]
    public class DelGoodMon
    {
        //送货价格ID
        public int DelID { get; set; }
        //客户ID
        public string CusID { get; set; }
        //客户类
        public CustomersTB customer { get; set; }
        //送货单价
        public double DelUnitPrice { get; set; }
        //备注
        public string Remark { get; set; }
    }
}
