using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace FATP_Exam_System.Ashx
{
    /// <summary>
    /// Summary description for Update
    /// </summary>
    public class Update : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = HttpContext.Current.Request["type"];
            string ntid = HttpContext.Current.Request["ntid"];
            string role = context.Request.QueryString["role"];
            string examtype = HttpContext.Current.Request["ExamType"];
            string userID = context.Request.QueryString["userID"];
            string questionID = context.Request.QueryString["questionID"];
            string department = context.Request.QueryString["department"];
            string project = context.Request.QueryString["project"];
            string examname = context.Request.QueryString["examname"];
            string totalscore = context.Request.QueryString["totalscore"];
            string passscore = context.Request.QueryString["passscore"];
            string score = HttpContext.Current.Request["score"];
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

            //if (string.IsNullOrEmpty(ntid))
            //{
            //    ntid= HttpContext.Current.Session["NTID"].ToString();
            //}
            //if (string.IsNullOrEmpty(examtype))
            //{
            //    examtype = HttpContext.Current.Session["ExamType"].ToString();
            //}

            switch (type)
            {
                case "exam":
                    callback = BLL.GetData.Update_Exam(examtype, examname, totalscore, passscore, singlecount, singlescore, multiplecount, multiplescore);
                    break;
                case "user":
                    callback = BLL.GetData.Update_User(userID, examtype, ntid, project, department, role);
                    break;
                case "question":
                    callback = BLL.GetData.Update_Question(questionID, examtype, question, questiontype, s1, s2, answer, s3, s4);
                    break;
                case "score":
                    callback = BLL.GetData.Replace_ExamScore(examtype, ntid, score);
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
    }
}