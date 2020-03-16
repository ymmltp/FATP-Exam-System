using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

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
            string type = HttpContext.Current.Request["type"];
            string examtype = HttpContext.Current.Request.Cookies["examtype"].Value;
            string ql = HttpContext.Current.Request["qlist"];
            List<QuestionInfo> qlist = new List<QuestionInfo>();
            if (!String.IsNullOrEmpty(ql))
            {
                DataContractJsonSerializer _Json = new DataContractJsonSerializer(qlist.GetType());
                byte[] _Using = System.Text.Encoding.UTF8.GetBytes(ql);
                System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream(_Using);
                _MemoryStream.Position = 0;
                qlist = (List<QuestionInfo>)_Json.ReadObject(_MemoryStream);
            }
                //qlist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuestionInfo>>; 
                      
            string json = "";
            Dictionary<int, List<QuestionInfo>> finalresult = new Dictionary<int, List<QuestionInfo>>();
            List<QuestionInfo> callbackql = new List<QuestionInfo>();
            ExamInfo examinfo = new ExamInfo();

            switch (type) {
                case "getexaminfo":
                    examinfo = BLL.Exam.Get_examInfo(examtype);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(examinfo);
                    break;
                case "getquestioninfo":
                    callbackql = BLL.Exam.Get_Question(examtype);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(callbackql);
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