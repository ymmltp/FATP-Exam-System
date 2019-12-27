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
    public class GetData : IHttpHandler,System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["type"];
            string ntid = context.Request.QueryString["ntid"];
            string role = context.Request.QueryString["role"];
            string examtype = context.Request.QueryString["examtype"];
            string department= context.Request.QueryString["department"];
            string project = context.Request.QueryString["project"];
            string examname = context.Request.QueryString["examname"];
            string score = context.Request.QueryString["score"];
            string question = context.Request.QueryString["question"];
            string questiontype= context.Request.QueryString["questiontype"];
            string s1 = context.Request.QueryString["s1"];
            string s2 = context.Request.QueryString["s2"];
            string s3 = context.Request.QueryString["s3"];
            string s4 = context.Request.QueryString["s4"];
            DataTable dt = new DataTable();
            string json = "";

            if (string.IsNullOrEmpty(department))
            {
                department = HttpContext.Current.Session["Department"].ToString();
            }
            if (string.IsNullOrEmpty(project))
            {
                project = HttpContext.Current.Session["Project"].ToString();
            }
            if (string.IsNullOrEmpty(examtype) && examtype!="0")
            {
                examtype = HttpContext.Current.Session["ExamType"].ToString();
            }


            switch (type)
            {
                case "project":
                    dt = BLL.GetData.GetProject_Table(project);
                    break;
                case "department":
                    dt = BLL.GetData.GetDepartment_Table(department);
                    break;
                case "exam":
                    dt = BLL.GetData.GetExamConfig_Table(examname);
                    break;
                case "examscore":
                    dt = BLL.GetData.GetExamScore_Table(examtype,ntid);
                    break;
                case "question":
                    dt = BLL.GetData.GetQuestion_Table(examtype,questiontype);
                    break;
                case "user":
                    dt = BLL.GetData.GetUser_Table(examtype,project,department,ntid);
                    break;
                case "poweruser":
                    dt = BLL.GetData.GetPoweruser_Table();
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