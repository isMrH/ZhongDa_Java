using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDDB.Model
{
    //用户登录信息表
    [Serializable]
    public class UserInfoTB
    {
        //用户ID
        public int UID { get; set; }
        //登陆账号
        public string LoginId { get; set; }
        //密码
        public string Password { get; set; }
        //联系电话
        public string Telephone { get; set; }
        //邮箱
        public string Email { get; set; }
        //密保问题
        public string Question { get; set; }
        //问题答案
        public string AKey { get; set; }
        //备注
        public string Remark { get; set; }
    }
}
