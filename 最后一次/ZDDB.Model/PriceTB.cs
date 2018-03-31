using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //价格模板
    [Serializable]
    public class PriceTB
    {
        //价格模板ID
        public int Pid { get; set; }
        //模板编号
        public string PNo { get; set; }
        //目的地（省）
        public string Destination { get; set; }
        //公斤数
        public double Kilo { get; set; }
        //价格
        public double Price { get; set; }
        //备注
        public string Remark{ get; set; }
    }
}
