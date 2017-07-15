using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Bluejay.Core.Entities;

namespace Bluejay.Core.Data
{
    public class BaseDataObject
    {
        #region Properties
        protected string _ConnectionString;
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }
        #endregion

        #region Constructor
        public BaseDataObject()
        {            
            _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataSystemConnection"].ConnectionString;            
        }
        #endregion

        #region Metodos
        public int ExecuteNonQuery(string CommandText, string[] ParamNames, Object[] ParamValues)
        {
            SqlConnection conn;
            SqlCommand cmd;
            int res;

            conn = new SqlConnection(ConnectionString);
            conn.Open();

            cmd = new SqlCommand(CommandText, conn);
            cmd.CommandTimeout = 480; //8 Min

            if (ParamNames != null)
            {
                SetCommandParameters(cmd, ParamNames, ParamValues);
            }

            res = cmd.ExecuteNonQuery();

            conn.Close();

            if (conn != null) conn.Dispose();
            if (cmd != null) cmd.Dispose();

            return res;
        }

        public Object ExecuteScalar(string CommandText, string[] ParamNames, Object[] ParamValues)
        {
            SqlConnection conn;
            SqlCommand cmd;
            Object obj;

            conn = new SqlConnection(ConnectionString);
            conn.Open();

            cmd = new SqlCommand(CommandText, conn);
            cmd.CommandTimeout = 480; //8 Min

            if (ParamNames != null)
            {
                SetCommandParameters(cmd, ParamNames, ParamValues);
            }

            obj = cmd.ExecuteScalar();

            conn.Close();

            if (conn != null) conn.Dispose();
            if (cmd != null) cmd.Dispose();

            return obj;
        }

        public DataTable ExecuteDataTable(string CommandText, string[] ParamNames, Object[] ParamValues)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt = new DataTable();

            conn = new SqlConnection(ConnectionString);
            conn.Open();

            cmd = new SqlCommand(CommandText, conn);
            cmd.CommandTimeout = 480; //8 Min

            if (ParamNames != null)
            {
                SetCommandParameters(cmd, ParamNames, ParamValues);
            }

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            conn.Close();

            if (conn != null) conn.Dispose();
            if (cmd != null) cmd.Dispose();
            if (da != null) da.Dispose();

            return dt;
        }

        private void SetCommandParameters(SqlCommand Command, string[] ParamNames, Object[] ParamValues)
        {
            if (ParamNames.Length == ParamValues.Length)
            {
                for (int i = 0; i < ParamNames.Length; i++)
                {
                    Command.Parameters.AddWithValue(ParamNames[i], ParamValues[i]);
                }
            }
        }
        #endregion
    }


}
