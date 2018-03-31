using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDDB.DAL;
using ZDDB.Model;

namespace ZDDB.BLL
{
    public class UserInfoManager
    {
        //通过账号获取所有验证密码是否正确
        UserInfoService userInfo = new UserInfoService();
        public bool Register(string userName, string Pwd, out UserInfoTB UserInfo)
        {
            //查询用户名是否存在
            UserInfoTB user = userInfo.GetSelectUserByLoginid(userName);
            if (user == null)
            {
                UserInfo = null;
                return false;
            }
            if (Pwd == user.Password)
            {
                UserInfo = user;
                return true;
            }
            else
            {
                UserInfo = null;
                return false;
            }
        }
        //通过账号获取所有
        public UserInfoTB GetUserInfoByUserId(string userid)
        {
            UserInfoTB user = userInfo.GetSelectUserByLoginid(userid);
            return user;

        }
        //根据账号修改密码
        public int UpdatePasswordByUserId(string Pwd, string userId)
        {
            return userInfo.UpdatePwssWord(Pwd, userId);
        }
        //注册
        public int IsHasUserName(string LoginId)
        {
            return userInfo.IsHasUserName(LoginId);
        }
        public int InsertUserInfo(UserInfoTB u)
        {
            return userInfo.InsertUserInfo(u);
        }

        //通过账号获取所有验证密码是否正确
        public List<UserInfoTB> GetAllUserInfoTB()
        {
            return userInfo.GetAllUserInfoTB();
        }

        //删除
        public void DeleteUserInfoId(int uid)
        {
            userInfo.DeleteUserInfoId(uid);
        }

        //修改
        public int UpdateUserInfoTB(UserInfoTB us)
        {
            return userInfo.UpdateUserInfoTB(us);
        }
    }
}
