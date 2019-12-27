using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Model;
using System.Data;

namespace FATP_Exam_System.Ashx
{
    /// <summary>
    /// Summary description for Exam
    /// </summary>
    public class Exam : IHttpHandler,System.Web.SessionState.IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["type"];
            string examtype = HttpContext.Current.Session["ExamType"].ToString();
            string ql = context.Request.QueryString["qlist"];
            List<QuestionInfo> qlist = new List<QuestionInfo>();
            if(!String.IsNullOrEmpty(ql))
                qlist = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(ql); 
                      
            string json = "";
            Dictionary<int, List<QuestionInfo>> finalresult = new Dictionary<int, List<QuestionInfo>>();
            List<QuestionInfo> callbackql = new List<QuestionInfo>();
            ExamInfo examinfo = new ExamInfo();
            int finalscore = 0;

            switch (type) {
                case "getexaminfo":
                    examinfo = BLL.Exam.Get_examInfo(examtype);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(examinfo);
                    break;
                case "getquestioninfo":
                    callbackql = BLL.Exam.Get_Question(examtype);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callbackql);
                    break;
                case "getresult":
                    BLL.Exam.Final_Result_Check(qlist, out callbackql, out finalscore);
                    finalresult.Add(finalscore, callbackql);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(finalresult);
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