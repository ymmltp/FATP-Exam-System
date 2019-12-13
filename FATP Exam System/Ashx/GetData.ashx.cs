using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FATP_Exam_System.Ashx
{
    /// <summary>
    /// Summary description for GetData
    /// </summary>
    public class GetData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["type"];
            string ntid = context.Request.QueryString["ntid"];
            string password = context.Request.QueryString["password"];
            string role = context.Request.QueryString["role"];
            string examtype = context.Request.QueryString["examtype"];
            string department= context.Request.QueryString["department"];
            string project = context.Request.QueryString["project"];
            string examname = context.Request.QueryString["examname"];
            string score = context.Request.QueryString["score"];
            string question = context.Request.QueryString["question"];
            string s1 = context.Request.QueryString["s1"];
            string s2 = context.Request.QueryString["s2"];
            string s3 = context.Request.QueryString["s3"];
            string s4 = context.Request.QueryString["s4"];
            DataTable dt = new DataTable();
            string json = "";
            string callback = "";

            switch (type)
            {
                case "selectexam":
                    dt = BLL.GetData.GetExamConfig_Table();
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
                    break;
            }
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}