using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlServerCe;

namespace TEAMFIRST.Controls
{
    public class SDF
    {
        string fileName = "C:\\MyDatabase.sdf"; //要创建的SQLCE数据库位置
        public SDF(string file)
        {
            fileName = file;
        }
        /// <summary>
        /// 创建数据库函数
        /// </summary>
        /// <param name="file"></param>
        private void CreateDB(string file)
        {
            fileName = file;
            //SQLCE连接字符串
            string connStr = "Data Source=" + file;
            try
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                //在指定位置创建数据库
                SqlCeEngine eng = new SqlCeEngine();
                eng.LocalConnectionString = connStr;
                eng.CreateDatabase();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        //执行传入的脚本，在SqlCE数据库中创建表并插入数据
        private void CreateTab(string ScriptStr)
        {
            string connStr = "Data Source=" + fileName;
            string[] ss = ScriptStr.Split(';');//分割脚本语句。
            using (SqlCeConnection conn = new SqlCeConnection(connStr))
            {
                //ＳＱＬＣＥ中逐条执行语句。。。
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.Connection = conn;
                conn.Open();
                foreach (string sqlstr in ss)
                {
                    cmd.CommandText = sqlstr;//循环
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        //通过文件名和脚本文件组装数据库
        public void Create(string File, string Script)
        {
            this.CreateDB(File);
            this.CreateTab(Script);
        }
    }
 
}