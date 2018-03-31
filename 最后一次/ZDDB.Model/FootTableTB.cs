using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    [Serializable]
    public class FootTableTB
    {
         //客户id
        public int Cusid { get; set; }
        //客户姓名
        public string CName { get; set; }
        //金额
        public double  Price { get; set; }
       //是否已结算
        public bool Foot{ get; set; }
        //费用日期
        public DateTime Time { get; set; }
        //承运公司ID
        public string Remark { get; set; }
    }
}
