using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

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
    }
}
