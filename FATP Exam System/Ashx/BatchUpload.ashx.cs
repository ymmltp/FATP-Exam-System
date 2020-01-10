using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using System.Net.Security;
using System.Net;
using System.IO;

namespace FATP_Exam_System.Ashx
{
    /// <summary>
    /// Summary description for BatchUpload
    /// </summary>
    public class BatchUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = HttpContext.Current.Request["type"];
            string UploadArray = HttpContext.Current.Request["uploadArray"];
            string json = "";
            DataTable dt = ToDataTable(UploadArray);
            string callback = "";
            switch (type) {
                case "user":
                    callback = BLL.GetData.Batch_Upload_User(dt);
                    break;
                case "question":
                    callback = BLL.GetData.Batch_Upload_Question(dt);
                    break;
            }
            json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public DataTable ToDataTable(string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, Type.GetType("System.String"));
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }

                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
                throw;
            }
            result = dataTable;
            return result;
        }
    }
}