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
            comm.CommandText = selectText;
            try
            {
                comm.Connection.Open();
                MySqlDataReader sqlReader = comm.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(sqlReader);
                return table;
            }
            catch { throw; }
            finally
            {
                comm.Connection.Close();
            }
        }

        public void Insert(string insertText)
        {
            comm.CommandText = insertText;
            try
            {
                comm.Connection.Open();
                comm.ExecuteNonQuery();
            }
            catch { throw; }
            finally { comm.Connection.Close(); }
        }

        public void Delete(string deleteText)
        {
            comm.CommandText = deleteText;
            try
            {
                comm.Connection.Open();
                comm.ExecuteNonQuery();
            }
            catch { throw; }
            finally { comm.Connection.Close(); }
        }

        public void Update(string updateText)
        {
            comm.CommandText = updateText;
            try
            {
                comm.Connection.Open();
                comm.ExecuteNonQuery();
            }
            catch { throw; }
            finally { comm.Connection.Close(); }
        }

        //public void QueryCombobox(System.Windows.Forms.ComboBox cb, string sql, bool addAll)
        //{
        //    DataTable table = Query(sql);
        //    if (addAll)
        //    {
        //        cb.Items.Add("All");
        //    }
        //    foreach (DataRow row in table.Rows)
        //    {
        //        cb.Items.Add(row[0].ToString());
        //    }
        //}

        /// <summary>
        /// return combox(string ,int)
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="sql"></param>
        /// <param name="addAll"></param>
        //public void QueryCombox_KeyValue(System.Windows.Forms.ComboBox cb, string sql, bool addAll)
        //{
        //    List<KeyValuePair<string, int>> listItem = new List<KeyValuePair<string, int>>();
        //    DataTable table = Query(sql);
        //    if (addAll)
        //    {
        //        listItem.Add(new KeyValuePair<string, int>("_Blank_", 0));
        //    }
        //    foreach (DataRow row in table.Rows)
        //    {
        //        listItem.Add(new KeyValuePair<string, int>(row[0].ToString(),Convert.ToInt32(row[1])));
        //    }
        //    cb.DisplayMember = "Key";
        //    cb.ValueMember = "Value";
        //    cb.DataSource = listItem;
        //}
    }

}
