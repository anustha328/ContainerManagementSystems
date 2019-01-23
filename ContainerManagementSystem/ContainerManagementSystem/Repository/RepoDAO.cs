using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Common.Common;
namespace Repository
{
    public class RepoDAO
    {
        SqlConnection _connection;

        public object System { get; internal set; }

        public RepoDAO()
        {
            Init();
        }
        private void Init()
        {
            _connection = new SqlConnection("Server=tcp:containermanagementsystem20190120071355dbserver.database.windows.net,1433;Initial Catalog=ContainerManagementSystem20190120071355_db1;Persist Security Info=False;User ID=NP000019;Password=9813612871Anu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }
        private void OpenConnection()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
            _connection.Open();
        }
        private void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
                this._connection.Close();
        }

        private string GetConnectionString()
        {
            return ConfigurationSettings.AppSettings["connectionString"].ToString();
        }

        public DataSet ExecuteDataset(string sql)
        {
            var ds = new DataSet();
            var cmd = new SqlCommand(sql, _connection);
            cmd.CommandTimeout = 120;
            SqlDataAdapter da;

            try
            {
                OpenConnection();
                //da = new SqlDataAdapter(sql, _connection);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                CloseConnection();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da = null;
                CloseConnection();
            }
            return ds;
        }

        public DataRow ExecuteDataRow(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0].Rows[0];
            }
        }
        public DataTable ExecuteDataTable(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0];
            }
        }

        public String GetSingleResult(string sql)
        {
            try
            {
                var ds = ExecuteDataset(sql);
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return "";

                return ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                CloseConnection();
            }
        }

        public string RemoveDecimal(double amt)
        {
            return Math.Floor(amt).ToString();
        }

        public String FilterString(string strVal)
        {
            var str = FilterQuote(strVal);

            if (str.ToLower() != "null")
                str = "'" + str + "'";

            return str.TrimEnd().TrimStart();
        }

        public String FilterQuote(string strVal)
        {
            if (string.IsNullOrEmpty(strVal))
            {
                strVal = "";
            }
            var str = strVal.Trim();

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace(";", "");
                //str = str.Replace(",", "");
                str = str.Replace("--", "");
                str = str.Replace("'", "");

                str = str.Replace("/*", "");
                str = str.Replace("*/", "");

                str = str.Replace(" select ", "");
                str = str.Replace(" insert ", "");
                str = str.Replace(" update ", "");
                str = str.Replace(" delete ", "");

                str = str.Replace(" drop ", "");
                str = str.Replace(" truncate ", "");
                str = str.Replace(" create ", "");

                str = str.Replace(" begin ", "");
                str = str.Replace(" end ", "");
                str = str.Replace(" char(", "");

                str = str.Replace(" exec ", "");
                str = str.Replace(" xp_cmd ", "");


                str = str.Replace("<script", "");

            }
            else
            {
                str = "null";
            }
            return str;
        }

       public DbResult ParseDbResult(DataTable dt)
        {
            var res = new DbResult();
            if (dt.Rows.Count >= 0)
            {
                res.ErrorCode = dt.Rows[0][0].ToString();
                res.Message = dt.Rows[0][1].ToString();
                if (dt.Columns.Count > 2) { 
                    res.Id = dt.Rows[0][2].ToString();
                }
                if (dt.Columns.Count > 3)
                {
                    res.Extra = dt.Rows[0][3].ToString();
                }
                if (dt.Columns.Count > 4)
                {
                    res.Extra2 = dt.Rows[0][4].ToString();
                }
            }
            return res;
        }

        public DbResult ParseDbResult(string sql)
        {
            return ParseDbResult(ExecuteDataTable(sql));
        }
        public Dictionary<string, string> ParseDictionary(string sql)
        {
            var dictionary = new Dictionary<string, string>();
            var dt = ExecuteDataTable(sql);
            if (null == dt || dt.Rows.Count == 0)
            {
                return dictionary;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dictionary.Add(dt.Columns[j].ColumnName.ToLower(), dt.Rows[i][j].ToString());
                }
            }
            return dictionary;
        }
    }
}