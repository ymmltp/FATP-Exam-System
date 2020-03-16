using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FATP_Exam_System.Ashx
{
    /// <summary>
    /// Summary description for ScoreSearch
    /// </summary>
    public class ScoreSearch : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["type"];
            string ntid = context.Request.QueryString["ntid"];
            string examtype = context.Request.QueryString["examtype"];
            string department = context.Request.QueryString["department"];
            string project = context.Request.QueryString["project"];
            string power = context.Request.QueryString["power"];


            DataTable dt = new DataTable();
            string json = "";
            switch (type)
            {
                case "examscore":
                    dt = BLL.GetData.GetExamScore_Table(examtype, project, department, ntid);
                    break;
                default:
                    json = "Sorry,don't have such function...Please check your url";
                    break;
            }
            json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
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