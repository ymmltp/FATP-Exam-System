using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace DAL
{
    public class ManageDatabase
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["mydatabase"].ToString();
        private MySqlCommand comm = new MySqlCommand();

        public ManageDatabase() {
            comm.Connection = new MySqlConnection(connectionString);
        }

        public DataTable Query(string selectText)
        {
            DataTable dt = new DataTable();
            //资源浪费,同时使用了多个connection。如果同时需要链接的次数太多，就会有好多connection
            using (MySqlConnection conn = new MySqlConnection(connectionString))
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(selectText, conn);
                    MySqlDataAdapter ad = new MySqlDataAdapter();
                    ad.SelectCommand = cmd;
                    dt.Clear();
                    ad.Fill(dt);
                    cmd.Dispose();
                    return dt;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Dispose();
                }

            //存在并发式访问报错(原因:comm.connection被多次调用,而上面那种方式，每次都是使用的不同的connection)
            //comm.CommandText = selectText;
            //try
            //{
            //    comm.Connection.Open();
            //    MySqlDataReader sqlReader = comm.ExecuteReader();
            //    DataTable table = new DataTable();
            //    table.Load(sqlReader);
            //    comm.Connection.Close();
            //    return table;
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    comm.Connection.Close();
            //}
        }

        public void Insert(string insertText)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(insertText, conn);
                    cmd.ExecuteReader();
                    cmd.Dispose();
                }
                catch
                {
                    throw;
                }
                finally {
                    conn.Dispose();
                }

            //comm.CommandText = insertText;
            //try
            //{
            //    comm.Connection.Open();
            //    comm.ExecuteNonQuery();
            //}
            //catch { throw; }
            //finally { comm.Connection.Close(); }
        }

        public void Delete(string deleteText)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
           try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(deleteText, conn);
                cmd.ExecuteReader();
                cmd.Dispose();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Dispose();
            }
            //comm.CommandText = deleteText;
            //try
            //{
            //    comm.Connection.Open();
            //    comm.ExecuteNonQuery();
            //}
            //catch { throw; }
            //finally { comm.Connection.Close(); }
        }

        public void Update(string updateText)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(updateText, conn);
                cmd.ExecuteReader();
                cmd.Dispose();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Dispose();
            }
            //comm.CommandText = updateText;
            //try
            //{
            //    comm.Connection.Open();
            //    comm.ExecuteNonQuery();
            //}
            //catch { throw; }
            //finally { comm.Connection.Close(); }
        }

        //csv批量上传
        public int MySQLBulkLoader(DataTable dt)
        {
            if (string.IsNullOrEmpty(dt.TableName)) throw new Exception("Datatable Error...");
            if (dt.Rows.Count == 0) return 0;
            int insertCount = 0;
            string csv = DataTableToCsv(dt);
            string tmpPath = Path.GetTempFileName();
            File.WriteAllText(tmpPath, csv);
            using (MySqlConnection conn = new MySqlConnection(connectionString))
                try {
                    conn.Open();
                    MySqlBulkLoader bulk = new MySqlBulkLoader(conn)
                    {
                        FieldTerminator = ",",
                        FieldQuotationCharacter = '"',
                        EscapeCharacter = '"',
                        LineTerminator = "\r\n",
                        FileName = tmpPath,
                        NumberOfLinesToSkip = 0,
                        TableName = dt.TableName,
                    };
                    insertCount = bulk.Load();
                    return insertCount;
                }
                catch {
                    throw;
                }
                finally {
                    conn.Dispose();                   
                }
        }
        private static string DataTableToCsv(DataTable table)
        {
            //以半角逗号（即,）作分隔符，列为空也要表达其存在。  
            //列内容如存在半角逗号（即,）则用半角引号（即""）将该字段值包含起来。  
            //列内容如存在半角引号（即"）则应替换成半角双引号（""）转义，并用半角引号（即""）将该字段值包含起来。  
            StringBuilder sb = new StringBuilder();
            DataColumn colum;
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    colum = table.Columns[i];
                    if (i != 0) sb.Append(",");
                    if (colum.DataType == typeof(string) && row[colum].ToString().Contains(","))
                    {
                        sb.Append("\"" + row[colum].ToString().Replace("\"", "\"\"") + "\"");
                    }
                    else sb.Append(row[colum].ToString());
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
