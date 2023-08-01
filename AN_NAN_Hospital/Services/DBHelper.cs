using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OnCube_Switch.Services
{
    public class DBHelper
    {
        private static string ConnectionString = "server=TFMS-WS;database=OnCube;Integrated Security=True";  //uid=使用者名稱;pid=使用者密碼
        /// <summary>
        /// 獲取連接對象
        /// </summary>
        private static SqlConnection Con
        {
            get
            {
                var con = new SqlConnection(ConnectionString);
                con.Open();
                return con;
            }
        }
        /// <summary>
        /// 獲得指令對象
        /// </summary>
        private static SqlCommand Cmd => Con.CreateCommand();

        /// <summary>
        /// 增加或是刪除通用語句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool Update(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        /// <summary>
        /// 返回第一行第一列的結果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object SelectForScalar(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteScalar();
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// 返回DataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader SelectForReader(string sql)
        {
            var cmd = Cmd;
            cmd.CommandText = sql;
            try
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                return null;
            }
        }

        /// <summary>
        /// 多載，需要查詢兩段程式時使用
        /// </summary>
        /// <param name="sql_1"></param>
        /// <param name="sql_2"></param>
        /// <returns></returns>
        public static SqlDataReader SelectForReader(string sql_1, string sql_2)
        {
            var cmd = Cmd;
            cmd.CommandText = sql_1 + sql_2;
            try
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                return null;
            }
        }
    }

}
