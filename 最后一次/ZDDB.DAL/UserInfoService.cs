using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZDDB.Model;

namespace ZDDB.DAL
{
    public class UserInfoService
    {
        //通过登录名查询所有
        public UserInfoTB GetSelectUserByLoginid(string UserName)
        {
            string sql = "select * from UserInfoTB where LoginId=@UserName";
            UserInfoTB userinfo = new UserInfoTB();
            try
            {
                DataTable dt = DBHelper.GetTable(sql, new SqlParameter("@UserName", UserName));
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        userinfo.UID = (int)row["UID"];
                        userinfo.LoginId = (string)row["LoginID"];
                        userinfo.Password = (string)row["Password"];
                        userinfo.Telephone = (string)row["Telephone"];
                        userinfo.Email = (string)row["Email"];
                        userinfo.Question = (string)row["Question"];
                        userinfo.AKey = (string)row["aKey"];
                        userinfo.Remark = (row["Remark"] == DBNull.Value) ? "" : row[5].ToString();
                    }
                    return userinfo;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //根据账号修改密码
        public int UpdatePwssWord(string Pwd, string userId)
        {
            string str = "update UserInfoTB set Password=@Pwd where LoginID=@UserId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@pwd",Pwd),
                new SqlParameter("@userId",userId)
            };
            return DBHelper.ExecuteCommand(str, para);
        }

        //查看是否重名
        public int IsHasUserName(string LoginId)
        {
            string strsql = "select count(*) from UserInfoTB where LoginId=@LoginId";
            SqlParameter[] paras = new SqlParameter[]{
            new SqlParameter("@LoginId",LoginId),
        };
            return Convert.ToInt32(DBHelper.GetScalar(strsql, paras)); 
        }

        //添加用户
        public int InsertUserInfo(UserInfoTB u)
        {
            string strsql = "insert into UserInfoTB(loginid,password,telephone,email,question,akey,remark) values(@loginid,@password,@telephone,@email,@question,@akey,@remark)";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@loginid",u.LoginId),
                new SqlParameter("@password",u.Password),
                new SqlParameter("@telephone",u.Telephone),
                new SqlParameter("@email",u.Email),
                new SqlParameter("@question",u.Question),
                new SqlParameter("@akey",u.AKey),
                new SqlParameter("@remark",u.Remark),
            };
            return DBHelper.ExecuteCommand(strsql, paras);
        }

        //黄超 01-11
        //获取客户
        public List<UserInfoTB> GetAllUserInfoTB()
        {
            string strsql = "select * from UserInfoTB";
            return GetUserInfoTBBySql(strsql);
        }

        //客户表
        private static List<UserInfoTB> GetUserInfoTBBySql(string strsql)
        {
            List<UserInfoTB> list = new List<UserInfoTB>();

            DataTable table = DBHelper.GetTable(strsql);

            foreach (DataRow row in table.Rows)
            {
                UserInfoTB us = new UserInfoTB();
                us.UID = Convert.ToInt32(row["uid"]);
                us.LoginId = row["loginid"].ToString();
                us.Password = row["password"].ToString();
                us.Telephone = row["telephone"].ToString();
                us.Email = row["email"].ToString();
                us.Question = row["question"].ToString();
                us.AKey = row["akey"].ToString();
                us.Remark = row["remark"].ToString();

                list.Add(us);
            }
            return list;
        }

        //删除
        public void DeleteUserInfoId(int uid)
        {
            string sql = "delete UserInfoTB where uid=@uid";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@uid",uid)
                };
                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw e;
            }
        }

        //修改
        public int UpdateUserInfoTB(UserInfoTB us)
        {
            string sql = string.Format("Update UserInfoTB set Password=@Password,Telephone=@Telephone,Email=@Email,Question=@Question,aKey=@aKey,Remark=@Remark where LoginId=@LoginId");
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@LoginId",us.LoginId),
                    new SqlParameter("@Password",us.Password),
                    new SqlParameter("@Telephone",us.Telephone),
                    new SqlParameter("@Email",us.Email),
                    new SqlParameter("@Question",us.Question),
                    new SqlParameter("@aKey",us.AKey),
                    new SqlParameter("@Remark",us.Remark),
                };
                return DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw e;
            }
        }
    }
  

}
