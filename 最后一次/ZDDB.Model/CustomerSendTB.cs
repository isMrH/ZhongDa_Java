
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //客户送件表
    [Serializable]
    public class CustomerSendTB
    {
        //客户送件ID
        public int CEid { get; set; }
        //客户ID
        public string CusID { get; set; }
        //派送的个数
        public int ECount { get; set; }
        //是够结算
        public string Issettle { get; set; }
        //派件邮费
        public double EAllPrice { get; set; }
        //派件年月
        public DateTime EDate { get; set; }
        //备注
        public string Remark { get; set; }

        //实例化客户的实体类
        public CustomersTB Ccustomer { get; set; }

    }
}
