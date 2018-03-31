using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.Model;

namespace ZDDB.Model
{
    //客户价格表
    [Serializable]
    public class CustomerPriceTB
    {
        //客户价格表Id号
        public int Cpid { get; set; }
        //客户id
        public int CusID { get; set; }
        //客户类
        public CustomersTB customer { get; set; }
        //公司类
        public CarrieCompanyTB carriecomapny { get; set; }
        //公司ID
        public int Cid { get; set; }
        //模板编号
        public string PNo { get; set; }
        //价格模板名称
        public string CpName{ get; set; }
        //备注
        public string Remark { get; set; }
    }
}
