using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //客户表
    [Serializable ]
    public class CustomersTB
    {
        //客户ID
        public int CusID{
            get;
            set;
        }
        //客户姓名
        public string CusName
        {
            get;
            set;
        }
        //客户联系电话
        public string CusTel
        {
            get;
            set;
        }
        //客户是否为业务员
        public string  IsCounterman 
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
