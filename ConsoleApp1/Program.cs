using Acme.SimpleTaskApp.Tasks;
using ConsoleApp1.Utilty;
using System;
using System.Configuration; 
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();
        }

        private static void Initialize()
        {
            string address = ConfigurationManager.AppSettings["ExcelSource"];
            DataTable tb = GetExcelTable(address);
            var tasks = DataConvert<Tasks>.ToList(tb);

            List<TaskDto> taskSqls = ConvertToSqlFields(tasks);
            string sql = SqlBuilderHelper.BulkInsertSql(taskSqls, "AppTasks");
            StringBuilder sqls =new StringBuilder();
            taskSqls.ForEach(task => {
                sqls.Append(SqlBuilderHelper.InsertSql(task, "AppTasks"));
                sqls.AppendLine();
            });
            //CreateSqlFile(sql);
            CreateSqlFile(sql.ToString());
            Console.WriteLine(sqls);
            Console.WriteLine("Successful.");
            Console.ReadLine();
        }

        private static DataTable GetExcelTable(string excelFilename)
        {
            string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Engine Type=35;Extended Properties=Excel 8.0;Persist Security Info=False", excelFilename);
            DataSet ds = new DataSet();
            string tableName;
            using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(connectionString))
            {
                connection.Open();
                DataTable table = connection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                tableName = table.Rows[0]["Table_Name"].ToString();
                string strExcel = "select * from " + "[" + tableName + "]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, connectionString);
                adapter.Fill(ds, tableName);
                connection.Close();
            }
            return ds.Tables[tableName];
        }

        private static void CreateSqlFile(string content)
        {
            string fileAddress = ConfigurationManager.AppSettings["sqlFileAddress"];
            FileStream fsWrite = new FileStream(fileAddress, FileMode.Create, FileAccess.Write);
            byte[] buffer = Encoding.Default.GetBytes(content);
            fsWrite.Write(buffer, 0, buffer.Length);

            fsWrite.Close();
            fsWrite.Dispose();
        }

        private static List<TaskDto> ConvertToSqlFields(List<Tasks> tasks)
        {
            List<TaskDto> taskSqls = new List<TaskDto>();
            tasks.ForEach(task =>
            {
                TaskDto taskSql = new TaskDto()
                {
                    Id = Convert.ToInt16(task.Id),
                    Title = task.Title,
                    CreationTime = DateTime.Now
                };
                taskSql.State = Convert.ToInt16(DataConvert<TaskState>.ConvertEnumValue(task.State.ToString()).ToString());
                string[] descs = task.Description.Split(',');
                foreach (string desc in descs)
                {
                    taskSql.Description += DataConvert<DescType>.ConvertEnumValue(desc).ToString() + ",";
                }
                taskSql.Description = taskSql.Description.Substring(0, task.Description.Length);
                taskSqls.Add(taskSql);
            });
            return taskSqls;
        }
    }
}
