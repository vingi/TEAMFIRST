using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlServerCe;
using System.Data;

namespace TEAMFIRST.Controls
{
    class SqlCeHelper : IDisposable
    {

        private SqlCeConnection connection;

        private SqlCeCommand command;

        private const string connectionString = "Data Source=/DBData/MyDatabase.sdf;pwd=leafteam~20120412;";


        #region　Open/Close

        public void Open()
        {

            try
            {

                connection = new SqlCeConnection(connectionString);

                command = connection.CreateCommand();

                command.Connection = connection;

                command.CommandType = CommandType.Text;


                connection.Open();

            }

            catch (DataException e)
            {

                Console.WriteLine(e.Message);

            }

        }


        public void Close()
        {

            connection.Close();

            connection.Dispose();

        }


        public void Dispose()
        {

            connection.Close();

            connection.Dispose();

            command.Dispose();

        }

        #endregion


        #region　Operatons

        public SqlCeDataReader ExecuteReader(string sql)
        {

            command.CommandText = sql;

            SqlCeDataReader reader = null;

            try
            {

                reader = command.ExecuteReader();

            }

            catch (DataException e)
            {

                Console.WriteLine(e.Message);

            }

            return reader;

        }


        public DataSet ExecuteDataSet(string sql)
        {

            command.CommandText = sql;

            SqlCeDataAdapter adapter = new SqlCeDataAdapter(command);

            DataSet ds = new DataSet(); ;


            try
            {

                adapter.Fill(ds);

            }

            catch (DataException e)
            {

                Console.WriteLine(e.Message);

            }

            return ds;

        }


        public int ExecuteNonQuery(string sql)
        {

            command.CommandText = sql;

            int result = -1;


            try
            {

                result = command.ExecuteNonQuery();

            }

            catch (DataException e)
            {

                Console.WriteLine(e.Message);



            }

            return result;

        }


        public object ExecuteScalar(string sql)
        {

            command.CommandText = sql;

            object o = null;

            try
            {

                o = command.ExecuteScalar();

            }

            catch (DataException e)
            {

                Console.WriteLine(e.Message);

            }

            return o;

        }

        #endregion


        #region　Transaction

        public void BeginTransaction()
        {

            command.Transaction = connection.BeginTransaction();

        }


        public void CommitTransaction()
        {

            command.Transaction.Commit();

        }


        public void RollbackTransaction()
        {

            command.Transaction.Rollback();

        }

        #endregion
    }
}