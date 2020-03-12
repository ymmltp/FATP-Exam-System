using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Data;

namespace FATP_Exam_System
{
    public partial class LogIn : System.Web.UI.Page
    {
        private string ntid;
        private string password;
        //private string userType;
        private string examType;
        //private string examName;
        private UserInfo userinfo;
        private string role;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count>0)
                {
                    ntid = Request["ntid"];
                    examType = Request["examtype"];
                    role = Request["role"];
                    if (!string.IsNullOrEmpty(ntid) && !string.IsNullOrEmpty(examType))
                    {
                        Get_Session_Data(ntid, examType,role);
                    }
                }
                else {
                    dt = new DataTable();
                    dt = BLL.GetData.GetExamConfig_Table();
                    ListItem _blank = new ListItem();
                    _blank.Value = "0";
                    _blank.Text = "_Blank";
                    SeleExam.Items.Add(_blank);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListItem item = new ListItem();
                        item.Value = dt.Rows[i]["ExamID"].ToString();
                        item.Text = dt.Rows[i]["ExamName"].ToString();
                        SeleExam.Items.Add(item);
                    }
                }
            }
            
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {
            ntid = TextBox1.Text;
            password = TextBox2.Text;
            if (Auth(ntid, password))
            {
                lpassword.Text = "Pass";
                lpassword.Visible = true;
                lpassword.Style["color"] = "green";
            }
            else
            {
                lpassword.Visible = true;
            }
        }

        protected void ButtonLogIn_Click(object sender, EventArgs e)
        {
            ntid = TextBox1.Text;
            password = TextBox2.Text;
            //userType = SeleUser.SelectedItem.Value;
            examType = SeleExam.SelectedItem.Value;
            if (ntid == "User001")
            {
                if (password == "123456")
                {
                    if (examType == "0")
                    {
                        lexamtype.Visible = true;
                    }
                    else
                    {
                        Session["NTID"] = "User001";
                        Session["UserName"] = "User001";
                        Session["ExamType"] = examType;
                        Session["Power"] = (int)(UserGroupEnum)(Enum.Parse(typeof(UserGroupEnum), "User"));
                        Session["Project"] = "null";
                        Session["Department"] = "null";
                        Response.Redirect("Exam.aspx");
                    }
                }
                else
                {
                    lpassword.Visible = true;
                }
            }
            else {
                if (Auth(ntid, password))
                {
                    Get_Session_Data(ntid, examType);
                }
                else
                {
                    lpassword.Visible = true;
                }
            }
        }

        protected void Get_Session_Data(string ntid,string examType,string role="")
        {
            userinfo = GetUserInfo(ntid, examType, role);
            if (userinfo.ExamType == 999999)
            {
                lexamtype.Visible = true;
            }
            else
            {
                Session["NTID"] = userinfo.NTID;
                Session["UserName"] = userinfo.DisplayName;
                Session["ExamType"] = userinfo.ExamType;
                Session["Power"] = (int)userinfo.UserGroup;
                Session["Project"] = userinfo.Project;
                Session["Department"] = userinfo.Department;
                if (examType == "0")
                    Response.Redirect("SetExam.aspx");
                else
                    Response.Redirect("Exam.aspx");
            }
        }

        protected bool Auth(string ntid, string password)
        {
            return BLL.Auth.CheckNTIDAuth(ntid, password);
        }
        protected UserInfo GetUserInfo(string ntid, string examtype,string role=null)
        {
            return BLL.Auth.GetUserInfo(ntid,examtype,role);
        }
    }
}