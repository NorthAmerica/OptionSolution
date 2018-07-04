using System;
using System.Data;
using System.Data.OleDb;

namespace OP.Web.Tools
{
    /// <summary>
    /// 读取Excel
    /// </summary>
    public class ExcelReader
    {
        /// <summary>
        /// 读取期权产品Excel
        /// </summary>
        /// <param name="fileExtenSion">文件格式</param>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static DataSet ReadOptionsProductExcel(string fileExtenSion, string path)
        {
            try
            {
                //HDR=Yes，这代表第一行是标题，不做为数据使用 ，如果用HDR=NO，则表示第一行不是标题，做为数据来使用。系统默认的是YES
                string connstr2003 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                string connstr2007 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
                OleDbConnection conn;
                string OptionsProductTbName = "OptionsProduct$";
                string FallRoleTbName = "FallRole$";
                string RiseRoleTbName = "RiseRole$";
                if (fileExtenSion.ToLower() == ".xls")
                {
                    conn = new OleDbConnection(connstr2003);
                }
                else
                {
                    conn = new OleDbConnection(connstr2007);
                }
                DataSet ds = new DataSet();
                //===========读取OptionsProduct$============================================
                conn.Open();
                string sql1 = string.Format("select * from [{0}]", OptionsProductTbName);
                OleDbCommand cmd1 = new OleDbCommand(sql1, conn);
                DataTable OptionsProductDT = new DataTable("OptionsProduct");
                OleDbDataReader sdr1 = cmd1.ExecuteReader();
                OptionsProductDT.Load(sdr1);
                sdr1.Close();
                conn.Close();
                ds.Tables.Add(OptionsProductDT);
                //===========读取FallRole$=============================================
                conn.Open();
                string sql2 = string.Format("select * from [{0}]", FallRoleTbName);
                OleDbCommand cmd2 = new OleDbCommand(sql2, conn);
                DataTable FallRoleDT = new DataTable("FallRole");
                OleDbDataReader sdr2 = cmd2.ExecuteReader();
                FallRoleDT.Load(sdr2);
                sdr2.Close();
                conn.Close();
                ds.Tables.Add(FallRoleDT);
                //============读取RiseRole$============================================
                conn.Open();
                string sql3 = string.Format("select * from [{0}]", RiseRoleTbName);
                OleDbCommand cmd3 = new OleDbCommand(sql3, conn);
                DataTable RiseRoleDT = new DataTable("RiseRole");
                OleDbDataReader sdr3 = cmd3.ExecuteReader();
                RiseRoleDT.Load(sdr3);
                sdr3.Close();
                conn.Close();
                ds.Tables.Add(RiseRoleDT);

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        /// <summary>
        /// 读取Excel,默认只读Sheet1$
        /// </summary>
        /// <param name="fileExtenSion">文件格式</param>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static DataTable ReadExcel(string fileExtenSion, string path)
        {
            try
            {
                //HDR=Yes，这代表第一行是标题，不做为数据使用 ，如果用HDR=NO，则表示第一行不是标题，做为数据来使用。系统默认的是YES
                string connstr2003 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                string connstr2007 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
                OleDbConnection conn;
                string tablename = "";//sheet的名称
                if (fileExtenSion.ToLower() == ".xls")
                {
                    conn = new OleDbConnection(connstr2003);
                    // tablename = GetExcelTableName(Server.MapPath(FileName), connstr2003).Rows[0][2].ToString();  //取出第一个sheet的名称
                    tablename = GetExcelTableName(path, connstr2003);
                }
                else
                {
                    conn = new OleDbConnection(connstr2007);
                    // tablename = GetExcelTableName(Server.MapPath(FileName),connstr2007).Rows[0][2].ToString();  //取出第一个sheet的名称
                    tablename = GetExcelTableName(path, connstr2007);
                }
                conn.Open();
                //[Sheet1$]
                string sql = string.Format("select * from [{0}]", tablename);
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                DataTable dt = new DataTable();
                OleDbDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                sdr.Close();
                conn.Close();
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取Excel文件里的表名
        /// </summary>
        /// <param name="excelPath"></param>
        /// <returns></returns>
        public static string GetExcelTableName(string excelPath, string connstr)
        {
            try
            {
                if (System.IO.File.Exists(excelPath))
                {
                    OleDbConnection _ExcelConn = new OleDbConnection(connstr);
                    _ExcelConn.Open();
                    DataTable dt = _ExcelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    _ExcelConn.Close();
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    if (row["TABLE_NAME"].ToString() == "")
                    //    {
                    //        continue;
                    //    }
                    //    return row["TABLE_NAME"].ToString();
                    //}
                    return dt.Rows[0][2].ToString();

                }
                return "";
            }
            catch
            {
                return "";
            }
        }
    }
}