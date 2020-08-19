using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace FATP_Exam_System
{
    public partial class LogIn : System.Web.UI.Page
    {
        private string ntid;
        //private string password;
        //private string userType;
        private string examType;
        //private string examName;
        private UserInfo userinfo;
        private string role;
        //DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    ntid = Request["ntid"];
                    examType = Request["examtype"];
                    role = Request["role"];
                    if (!string.IsNullOrEmpty(ntid) && !string.IsNullOrEmpty(examType))
                    {

                        Get_Session_Data(ntid, examType, role);
                    }
                }
            }

        }


        //protected void Password_TextChanged(object sender, EventArgs e)
        //{
        //    //ntid = TextBox1.Text;
        //    //password = TextBox2.Text;
        //    //if (Auth(ntid, password))
        //    //{
        //    //    lpassword.Text = "Pass";
        //    //    lpassword.Visible = true;
        //    //    lpassword.Style["color"] = "green";
        //    //}
        //    //else
        //    //{
        //    //    lpassword.Visible = true;
        //    //}
        //}

        //protected void ButtonLogIn_Click(object sender, EventArgs e)
        //{
        //    ntid = TextBox1.Text;
        //    password = TextBox2.Text;
        //    //userType = SeleUser.SelectedItem.Value;
        //    examType = SeleExam.SelectedItem.Value;
        //    if (ntid == "User001")
        //    {
        //        if (password == "123456")
        //        {
        //            if (examType == "0")
        //            {
        //                lexamtype.Visible = true;
        //            }
        //            else
        //            {
        //                Session["NTID"] = "User001";
        //                Session["UserName"] = "User001";
        //                Session["ExamType"] = examType;
        //                Session["Power"] = (int)(UserGroupEnum)(Enum.Parse(typeof(UserGroupEnum), "User"));
        //                Session["Project"] = "null";
        //                Session["Department"] = "null";
        //                Response.Redirect("Exam.aspx");
        //            }
        //        }
        //        else
        //        {
        //            lpassword.Visible = true;
        //        }
        //    }
        //    else {
        //        if (Auth(ntid, password))
        //        {
        //            Get_Session_Data(ntid, examType);
        //        }
        //        else
        //        {
        //            lpassword.Visible = true;
        //        }
        //    }
        //}

        protected void Get_Session_Data(string ntid, string examType, string role=null)
        {
            userinfo = GetUserInfo(ntid, examType, role);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ntid", userinfo.NTID));
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("username", userinfo.DisplayName));
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("examtype", examType));
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("power", role));
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("department", userinfo.Department));
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("project", userinfo.Project));

            //Session["NTID"] = userinfo.NTID;
            //Session["UserName"] = userinfo.DisplayName;
            //Session["ExamType"] = userinfo.ExamType;
            //Session["Power"] = (int)userinfo.UserGroup;
            //Session["Project"] = userinfo.Project;
            //Session["Department"] = userinfo.Department;

            if (examType == "0")
                Response.Redirect("SetExam.aspx");
            else
                Response.Redirect("Exam.aspx");
            
        }
        //protected bool Auth(string ntid, string password)
        //{
        //    return BLL.Auth.CheckNTIDAuth(ntid, password);
        //}
        protected UserInfo GetUserInfo(string ntid, string examtype, string role = null)
        {
            return BLL.Auth.GetUserInfo(ntid, examtype, role);
        }
    }
}