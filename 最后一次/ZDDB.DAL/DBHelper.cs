using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ZDDB.DAL
{
    public class DBHelper
    {
        //public static string strcon = "server=(local);database=ZDDb;uid=sa;pwd=sa";//连接数据库的连接串
        //public static SqlConnection con = new SqlConnection(strcon);//创建连接对象
        private static string ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        public static SqlConnection con = new SqlConnection(ConStr);

        public static int ExecuteCommand(string strsql)
        {
            SqlCommand cmd = new SqlCommand(strsql, con);//创建命令对象
            //异常处理
            try
            {
                con.Open();//打开连接
                int cnt = cmd.ExecuteNonQuery();//返回影响的记录条数
                return cnt;
            }
            catch (Exception ex)
            {
                throw ex;//抛出异常
            }
            finally
            {
                con.Close();//关闭连接
            }
        }
        /// <summary>
        /// 执行带参数的sql语句
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public static int ExecuteCommand(string strsql, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand(strsql, con);//创建命令对象
            cmd.Parameters.AddRange(paras);
            //异常处理
            try
            {
                con.Open();//打开连接
                int cnt = cmd.ExecuteNonQuery();//返回影响的记录条数
                return cnt;
            }
            catch (Exception ex)
            {
                throw ex;//抛出异常
            }
            finally
            {
                con.Close();//关闭连接
            }
        }

        public static DataTable GetTable(string strsql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(strsql, con);
            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 带参数的查询方法
        /// </summary>
        /// <param name="strsql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataTable GetTable(string strsql, params SqlParameter[] paras)
        {
            SqlDataAdapter sda = new SqlDataAdapter(strsql, con);
            //添加参数集合
            sda.SelectCommand.Parameters.AddRange(paras);
            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 带参数的查询
        /// paras  sql参数数组
        /// </summary>
        /// <param name="strsql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static object GetScalar(string strsql, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand(strsql, con);//创建命令对象
            cmd.Parameters.AddRange(paras);  //传入参数数组

            //异常处理
            try
            {
                con.Open();//打开连接
                object obj = cmd.ExecuteScalar();//返回单行单列
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;//抛出异常
            }
            finally
            {
                con.Close();//关闭连接
            }
        }
        //返回int类型单值的查询方法(带参数)
        public static int Getscalar(string sql, params SqlParameter[] values)
        {
            SqlConnection conn = new SqlConnection(ConStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(values);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }
        public static object GetScalar(string strsql)
        {
            SqlCommand cmd = new SqlCommand(strsql, con);//创建命令对象
            //异常处理
            try
            {
                con.Open();//打开连接
                object obj = cmd.ExecuteScalar();//返回单行单列
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;//抛出异常
            }
            finally
            {
                con.Close();//关闭连接
            }
        }
    }
}
