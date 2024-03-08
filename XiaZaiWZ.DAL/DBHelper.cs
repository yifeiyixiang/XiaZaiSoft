using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaZaiWZ.DAL
{
    public class DBHelper
    {
        private static readonly string ConnString = ConfigurationManager.ConnectionStrings["XiaZaiWZ"].ConnectionString;

        /// <summary>
        /// 准备命令
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static SqlCommand PrepareCommand(SqlConnection conn, string sql, CommandType cmdType, params SqlParameter[] parameters)
        {
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = cmdType;

            foreach (var param in parameters)
            {
                cmd.Parameters.Add(param);
            }

            return cmd;
        }

        /// <summary>
        /// 执行SQL查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnString))
            {
                conn.Open();
                var dt = new DataTable();
                var cmd = PrepareCommand(conn, sql, CommandType.Text, parameters);
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            SqlDataReader reader = null;
            var conn = new SqlConnection(ConnString);
            conn.Open();
            var cmd = PrepareCommand(conn, sql, CommandType.Text, parameters);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;

        }

        /// <summary>
        /// 执行(返回第一行第一列)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnString))
            {
                conn.Open();
                var cmd = PrepareCommand(conn, sql, CommandType.Text, parameters);
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 执行增(Insert)删(Delete)改(Update)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(ConnString))
            {
                conn.Open();
                var cmd = PrepareCommand(conn, sql, CommandType.Text, parameters);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
