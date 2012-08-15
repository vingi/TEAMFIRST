using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;


namespace TEAMFIRST
{
    public class Database
    {
        private string sConnectionString = "";
        private SqlConnection Conn;

        public Database() { }

        public Database(string strcon)
        {
            sConnectionString = strcon;
        }

        public string StrCon
        {
            get
            {
                return sConnectionString;
            }
            set
            {
                sConnectionString = value;
            }
        }

        public void Conncetion()
        {
            if (sConnectionString == "" || sConnectionString == null)
            {
                sConnectionString = "";
            }
        }
        private void Open()
        {
            Conncetion();
            Conn = new SqlConnection(sConnectionString);

            if (Conn.State == ConnectionState.Closed)
                Conn.Open();

        }

        public void Close()
        {
            if (Conn != null)
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }

        private void Dispose()
        {
            if (Conn != null)
                Conn.Dispose();
            Conn = null;
        }

        public SqlDataReader ExecuteReader(string cmdText, CommandType cmdType)
        {
            this.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = Conn;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;

            try
            {

                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }

            catch
            {
                this.Close();
                return null;
            }
        }

        public SqlDataReader ExecuteReader(string cmdText, CommandType cmdType, params SqlParameter[] CmdParams)
        {
            this.Open();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = Conn;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;

            if (CmdParams != null)
            {
                foreach (SqlParameter Param in CmdParams)
                {
                    cmd.Parameters.Add(Param);
                }
            }

            try
            {
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();

                return reader;
            }

            catch
            {
                this.Close();
                return null;
            }
        }

        public DataSet GetDataSet(string cmdText, CommandType cmdType)
        {
            Conncetion();
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection Conn = new SqlConnection(sConnectionString))//������ֱ���ͷ���Դ ����������ӻ���
            {
                cmd.Connection = Conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;

                SqlDataAdapter ada = new SqlDataAdapter();
                ada.SelectCommand = cmd;

                DataSet ds = new DataSet();
                try
                {
                    ada.Fill(ds);
                }
                catch (SqlException ex)
                {
                }

                return ds;
            }
        }

        public DataSet GetDataSet(string cmdText, CommandType cmdType, SqlParameter[] adaParams)
        {
            Conncetion();
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection Conn = new SqlConnection(sConnectionString))
            {
                cmd.Connection = Conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;

                SqlDataAdapter ada = new SqlDataAdapter();

                if (adaParams != null)
                {
                    foreach (SqlParameter Param in adaParams)
                    {
                        cmd.Parameters.Add(Param);
                    }
                }

                ada.SelectCommand = cmd;

                DataSet ds = new DataSet();
                try
                {
                    ada.Fill(ds);
                }
                catch (SqlException ex)
                {
                }


                cmd.Parameters.Clear();

                return ds;
            }
        }

        public DataTable GetDataTable(string cmdText)
        {
            DataTable tempdt = new DataTable();
            try
            {
                tempdt = GetDataSet(cmdText, CommandType.Text).Tables[0];
            }
            catch (Exception)
            {
            }

            return tempdt;
        }

        public DataTable GetDataTable(string cmdText, CommandType cmdType)
        {
            DataTable tempdt = new DataTable();
            try
            {
                tempdt = GetDataSet(cmdText, cmdType).Tables[0];
            }
            catch (Exception)
            {
            }

            return tempdt;
        }

        public DataTable GetDataTable(string cmdText, CommandType cmdType, SqlParameter[] adaParams)
        {
            return GetDataSet(cmdText, cmdType, adaParams).Tables[0];
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType)
        {
            int i;
            try
            {
                this.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = Conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;

                i = cmd.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }

            return i;

        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType, SqlParameter[] cmdParams)
        {
            int i;
            try
            {
                this.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = Conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;

                foreach (SqlParameter Param in cmdParams)
                {
                    cmd.Parameters.Add(Param);
                }


                i = cmd.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }

            return i;
        }

        public int ExecuteReturnValue(string cmdText, CommandType cmdType)
        {
            SqlCommand cmd;
            try
            {
                this.Open();
                cmd = new SqlCommand();

                cmd.Connection = Conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;

                cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));

                cmd.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }

            return (int)cmd.Parameters["ReturnValue"].Value;
        }

        public int ExecuteReturnValue(string cmdText, CommandType cmdType, SqlParameter[] cmdParams)
        {
            SqlCommand cmd;
            try
            {
                this.Open();
                cmd = new SqlCommand();

                cmd.Connection = Conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;

                foreach (SqlParameter Param in cmdParams)
                {
                    cmd.Parameters.Add(Param);
                }

                cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                    ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));

                cmd.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }

            return (int)cmd.Parameters["ReturnValue"].Value;
        }

        public object ExecuteScalar(string cmdText)
        {
            object o;
            try
            {
                this.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdText;
                o = cmd.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }
            return o;
        }

        public object ExecuteScalar(string cmdText, CommandType cmdType)
        {
            object o;
            try
            {
                this.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;
                o = cmd.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                this.Close();
            }
            return o;
        }

        public object ExecuteScalar(string cmdText, CommandType cmdType, SqlParameter[] cmdParams)
        {
            object o;
            SqlCommand cmd = new SqlCommand();
            try
            {
                this.Open();
                cmd.Connection = Conn;
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;
                foreach (SqlParameter Param in cmdParams)
                {
                    cmd.Parameters.Add(Param);
                }
                o = cmd.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                cmd.Parameters.Clear();
                this.Close();
            }
            return o;
        }

        //------------------------------------------------------------------------------------


        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <returns>�Ƿ�ִ�гɹ�</returns>
        public bool RunProc(string procName)
        {
            try
            {
                SqlCommand cmd = CreateCommand(procName, null, CommandType.StoredProcedure);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["ReturnValue"].Value) == 0 ? true : false;
            }
            catch { return false; }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="prams">ִ�иô洢��������Ҫ�� sql �������� SqlParameter[]</param>
        /// <returns>�Ƿ�ִ�гɹ�</returns>
        public int RunProc(string procName, SqlParameter[] prams)
        {
            try
            {
                SqlCommand cmd = CreateCommand(procName, prams, CommandType.StoredProcedure);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["ReturnValue"].Value);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return 0;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="dataReader">SqlDataReader �������ܴ洢������ȡ�����ݼ�</param>
        /// <returns>�Ƿ�ִ�гɹ�</returns>
        public bool RunProc(string procName, out SqlDataReader dataReader)
        {
            try
            {
                SqlCommand cmd = CreateCommand(procName, null, CommandType.StoredProcedure);
                dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return true;
            }
            catch
            {
                dataReader = null;
                return false;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="prams">ִ�иô洢��������Ҫ�� sql �������� SqlParameter[]</param>
        /// <param name="dataReader">SqlDataReader �������ܴ洢������ȡ�����ݼ�</param>
        /// <returns>�Ƿ�ִ�гɹ�</returns>
        public bool RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
            try
            {
                SqlCommand cmd = CreateCommand(procName, prams, CommandType.StoredProcedure);
                dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                return true;
            }
            catch { dataReader = null; return false; }
            finally
            {
                Close();
            }
        }


        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="procName">�洢������</param>	
        /// <param name="dataset">DataSet �������ܴ洢������ȡ�����ݼ�</param>
        /// <returns>�Ƿ�ִ�гɹ�</returns>
        public bool RunProc(string procName, out DataSet dataset)
        {
            try
            {
                SqlCommand cmd = CreateCommand(procName, null, CommandType.StoredProcedure);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                dataset = new DataSet();
                da.Fill(dataset);
                return true;
            }
            catch { dataset = null; return false; }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="prams">ִ�иô洢��������Ҫ�� sql �������� SqlParameter[]</param>
        /// <param name="dataset">DataSet �������ܴ洢������ȡ�����ݼ�</param>
        /// <returns>�Ƿ�ִ�гɹ�</returns>
        public bool RunProc(string procName, SqlParameter[] prams, out DataSet dataset)
        {
            try
            {
                SqlCommand cmd = CreateCommand(procName, prams, CommandType.StoredProcedure);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                dataset = new DataSet();

                da.Fill(dataset);
                return true;
            }
            catch { dataset = null; return false; }
            finally
            {
                Close();
            }
        }


        /// <summary>
        /// Ϊ�洢���̴��� SqlCommand ����
        /// </summary>
        /// <param name="procName_sSQL">Ҫ���� SqlCommand ����Ĵ洢������---///---������ ��ͨ��SQL ���(��sql����)</param>
        /// <param name="prams">�洢��������� sql �������� SqlParameter[]</param>
        /// <returns>���� SqlCommand ����</returns>
        private SqlCommand CreateCommand(string procName_sSQL, SqlParameter[] prams, CommandType cmdType)
        {
            // ȷ���Ѿ��� �������Ӷ��� SqlConnection
            Open();

            SqlCommand cmd = new SqlCommand(procName_sSQL, Conn);
            cmd.CommandType = cmdType;

            // ��SqlCommand ���� ���sql ����
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }

            if (cmdType == CommandType.StoredProcedure)
            {
                // ��SqlCommand ���� ��ӷ���ֵ sql ���� ---- ReturnValue
                cmd.Parameters.Add(
                    new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                    ParameterDirection.ReturnValue, false, 0, 0,
                    string.Empty, DataRowVersion.Default, null));
            }
            return cmd;
        }

        /// <summary>
        /// ִ�д洢����(֧�� ���� SqlTransaction)
        /// </summary>
        /// <param name="transaction">SqlTransaction �������</param>
        /// <param name="procName">�洢������</param>
        /// <param name="prams">ִ�иô洢��������Ҫ�� sql �������� SqlParameter[]</param>
        /// <returns></returns>
        public bool RunProc(SqlTransaction transaction, string procName, SqlParameter[] prams)
        {
            try
            {
                SqlCommand cmd = CreateCommand(transaction, procName, prams, CommandType.StoredProcedure);
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["ReturnValue"].Value) == 0 ? true : false;
            }
            catch { return false; }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Ϊ�洢���̴��� SqlCommand ���� (֧�� ���� SqlTransaction)
        /// </summary>
        /// <param name="transaction">SqlTransaction �������</param>
        /// <param name="procName_sSQL">�洢������---///---������ ��ͨ��SQL ���(��sql����)</param>
        /// <param name="prams">�洢��������Ҫ�� sql �������� SqlParameter[]</param>
        /// <returns></returns>
        private SqlCommand CreateCommand(SqlTransaction transaction, string procName_sSQL, SqlParameter[] prams, CommandType cmdType)
        {
            // ȷ���Ѿ��� �������Ӷ��� SqlConnection
            if (transaction.Connection.State != ConnectionState.Open)
            {
                transaction.Connection.ConnectionString = StrCon.ToString();
                transaction.Connection.Open();
            }

            SqlCommand cmd = new SqlCommand(procName_sSQL, transaction.Connection, transaction);
            cmd.CommandType = cmdType;

            //-- ��SqlCommand ���� ���sql ����
            if (prams != null)
            {
                foreach (SqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }

            if (cmdType == CommandType.StoredProcedure)
            {
                // ��SqlCommand ���� ��ӷ���ֵ sql ���� ---- ReturnValue
                cmd.Parameters.Add(
                    new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                    ParameterDirection.ReturnValue, false, 0, 0,
                    string.Empty, DataRowVersion.Default, null));
            }
            return cmd;
        }


        /// <summary>
        /// �����洢����/�����ı��� sql �������(SqlParameter)
        /// </summary>
        /// <param name="ParamName">������</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������ֵ��Χ</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>������������</returns>
        public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// �����洢����/�����ı��� sql �������(SqlParameter)
        /// </summary>
        /// <param name="ParamName">������</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������ֵ��Χ</param>
        /// <returns>������������</returns>
        public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        /// <summary>
        /// �����洢����/�����ı��� sql ����(SqlParameter)
        /// </summary>
        /// <param name="ParamName">������</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������ֵ��Χ</param>
        /// <param name="Direction">����������ʽ</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>����� SqlParameter</returns>
        public SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }


        public DataSet ExecuteNonQuery(string SqlStr)
        {
            //sConncetion();
            SqlConnection SqlCon = new SqlConnection(sConnectionString);
            SqlCon.Open();
            SqlCommand SqlCom = new SqlCommand(SqlStr.ToString(), SqlCon);
            SqlCom.CommandType = CommandType.Text;
            //SqlCom.ExecuteNonQuery();
            DataSet ObjDs = new DataSet();
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCom);
            SqlDa.Fill(ObjDs);


            SqlCon.Close();
            return ObjDs;
        }

    }
}