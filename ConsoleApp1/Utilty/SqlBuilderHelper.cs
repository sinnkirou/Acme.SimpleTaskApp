using DbExtensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Utilty
{
    public static class SqlBuilderHelper
    {
        /// <summary>
        /// Insert SQL语句
        /// </summary>
        /// <param name="obj">要转换的对象，不可空</param>
        /// <param name="tableName">要添加的表明，不可空</param>
        /// <returns>
        /// 空
        /// sql语句
        /// </returns>
        public static string InsertSql<T>(T t, string tableName) where T : class
        {
            if (t == null || string.IsNullOrEmpty(tableName))
            {
                return string.Empty;
            }
            string[] columns = GetColmons(t);
            if (columns.Length<=0)
            {
                return string.Empty;
            }
            string[] values = GetValues(t);
            if (values.Length<=0)
            {
                return string.Empty;
            }
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into " + tableName);
            //var sql = SQL
            //   .INSERT_INTO(tableName+"("+string.Join(",",columns)+")")
            //   .VALUES(values);

            sql.Append("(" + string.Join(",", columns) + ")");
            sql.Append(" values(" +  string.Join(",",  values) + ")");
            return sql.ToString();
        }

        /// <summary>
        /// BulkInsert SQL语句（批量添加）
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="objs">要转换的对象集合，不可空</param>
        /// <param name="tableName">>要添加的表明，不可空</param>
        /// <returns>
        /// 空
        /// sql语句
        /// </returns>
        public static string BulkInsertSql<T>(List<T> objs, string tableName) where T : class
        {
            if (objs == null || objs.Count == 0 || string.IsNullOrEmpty(tableName))
            {
                return string.Empty;
            }
            string[] columns = GetColmons(objs[0]);
            if (columns.Length<=0)
            {
                return string.Empty;
            }
            string values = string.Join(",", objs.Select(p => string.Format("({0})", GetValues(p))).ToArray());
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into " + tableName);
            sql.Append("(" + columns + ")");
            sql.Append(" values " + values + "");
            return sql.ToString();
        }

        /// <summary>
        /// 获得类型的列名
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string[] GetColmons<T>(T obj)
        {
            if (obj == null)
            {
                return new string[] { };
            }
            return obj.GetType().GetProperties().Select(p => p.Name).ToArray();
        }

        /// <summary>
        /// 获得值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string[] GetValues<T>(T obj)
        {
            
            if (obj == null)
            {
                return new string[] { };
            }
            return obj.GetType().GetProperties().Select(p => string.Format("'{0}'", formateSql(p.GetValue(obj).ToString()))).ToArray();
        }

        private static string formateSql(string text)
        {
            text = text.Replace("'", "''");
            return text;
        }
    }
}
