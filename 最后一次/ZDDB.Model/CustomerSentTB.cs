using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //客户发件表
    [Serializable]
    public class CustomerSentTB
    {
        //客户发件ID
        public int CSid { get; set; }
        //面单号
        public long Rid { get; set; }
        //客户id
        public int cusid { get; set; }
        //客户类
        public CustomersTB customer { get; set; }
        //承运公司类
        public CarrieCompanyTB carriecompany { get; set; }
        //承运公司ID
        public int Cid { get; set; }
        //目的地（省）
        public string Destination { get; set; }
        //公斤数
        public double Kilo { get; set; }
        //运费
        public double Price { get; set; }
        //揽件时间
        public DateTime Resdate { get; set; }
        //是否已结算
        public string  IsSet { get; set; }
        //备注
        public string Remark { get; set; }

    }
}
