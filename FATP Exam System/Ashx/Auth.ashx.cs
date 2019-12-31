
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace FATP_Exam_System.Ashx
{
    /// <summary>
    /// Summary description for Auth
    /// </summary>
    public class Auth : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["type"];
            string ntid = context.Request.QueryString["ntid"];
            string password = context.Request.QueryString["password"];
            string role = context.Request.QueryString["role"];
            string examtype = context.Request.QueryString["examtype"];
            bool isAuthOk = false;
            UserInfo userinfo = new UserInfo();
            string json = "";
            switch (type) {
                case "CheckNTIDAuth":
                    isAuthOk = BLL.Auth.CheckNTIDAuth(ntid, password);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(isAuthOk);
                    break;
                case "GetUserInfo":
                    userinfo = BLL.Auth.GetUserInfo(ntid, role, examtype);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(userinfo);
                    break;
                case "UserInfo":
                    userinfo.NTID = HttpContext.Current.Session["NTID"].ToString();
                    userinfo.DisplayName = HttpContext.Current.Session["UserName"].ToString();
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(userinfo);
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