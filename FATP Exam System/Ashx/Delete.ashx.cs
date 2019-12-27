using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace FATP_Exam_System.Ashx
{
    /// <summary>
    /// Summary description for Delete
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["type"];
            string ntid = context.Request.QueryString["ntid"];
            string department = context.Request.QueryString["department"];
            string examtype = context.Request.QueryString["examtype"];
            string project = context.Request.QueryString["project"];
            string questionid = context.Request.QueryString["questionid"];
            string userid= context.Request.QueryString["userid"];
            string json = "";
            string callback = "";

            switch (type)
            {
                case "project":
                    callback = BLL.GetData.Delete_Project(project);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "exam":
                    callback = BLL.GetData.Delete_Exam(examtype);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "question":
                    callback = BLL.GetData.Delete_Question(questionid);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "user":
                    callback = BLL.GetData.Delete_User(userid);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "department":
                    callback = BLL.GetData.Delete_Departemnt (department);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "score":
                    callback = BLL.GetData.Delete_ExamScore(examtype,ntid);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "poweruser":
                    callback = BLL.GetData.Delete_Poweruser(ntid);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                default:
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