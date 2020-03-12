using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FATP_Exam_System.Ashx
{
    /// <summary>
    /// Summary description for Add
    /// </summary>
    public class Add : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["type"];
            string ntid = context.Request.QueryString["ntid"];
            string role = context.Request.QueryString["role"];
            string examtype = context.Request.QueryString["examtype"];
            string department = context.Request.QueryString["department"];
            string project = context.Request.QueryString["project"];
            string examname = context.Request.QueryString["examname"];
            string totalscore= context.Request.QueryString["totalscore"];
            string passscore = context.Request.QueryString["passscore"];
            string multiplescore = context.Request.QueryString["multiplescore"];
            string multiplecount = context.Request.QueryString["multiplecount"];
            string singlescore = context.Request.QueryString["singlescore"];
            string singlecount = context.Request.QueryString["singlecount"];
            string question = context.Request.QueryString["question"];
            string questiontype = context.Request.QueryString["questiontype"];
            string s1 = context.Request.QueryString["s1"];
            string s2 = context.Request.QueryString["s2"];
            string s3 = context.Request.QueryString["s3"];
            string s4 = context.Request.QueryString["s4"];
            string answer = context.Request.QueryString["answer"];
            string json = "";
            string callback = "";

            switch (type)
            {
                case "project":
                    callback = BLL.GetData.Add_Project(project);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "exam":
                    ntid= HttpContext.Current.Session["NTID"].ToString();
                    project = HttpContext.Current.Session["Project"].ToString();
                    department= HttpContext.Current.Session["Department"].ToString();
                    callback = BLL.GetData.Add_Exam(examname, totalscore, passscore, singlecount, singlescore, multiplecount, multiplescore,ntid,project,department);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "question":
                    callback = BLL.GetData.Add_Question(examtype,question,questiontype,s1,s2,answer,s3,s4);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "user":
                    callback = BLL.GetData.Add_User(examtype,ntid,project,department,role);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "poweruser":
                    callback = BLL.GetData.Add_Poweruser(ntid,project,department);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                case "department":
                    callback = BLL.GetData.Add_Department(department);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callback);
                    break;
                default:
                    json = "Sorry,don't have such function...Please check your url";
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