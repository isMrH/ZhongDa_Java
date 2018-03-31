using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //承运公司表
    [Serializable]
    public class CarrieCompanyTB
    {
        //承运公司ID
        public int Cid
        {
            get;
            set;
        }
        //公司名称
        public string CoName
        {
            get;
            set;
        }
        //联系人
        public string Clinkman
        {
            get;
            set;
        }
        //联系电话
        public string LinkmanTel
        {
            get;
            set;
        }
        //面单费
        public double Cmoney
        {
            get;
            set;
        }
        //备注
        public string Remark
        {
            get;
            set;
        }
    }
}
