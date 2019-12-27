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
        private string userType;
        private string examType;
        private string examName;
        private UserInfo userinfo;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            userType = SeleUser.SelectedItem.Value;
            examType = SeleExam.SelectedItem.Value;
            if (Auth(ntid, password))
            {
                userinfo = GetUserInfo(ntid, userType, examType);
                if (userinfo.ExamType == 999999)
                {
                    lexamtype.Visible = true;
                }
                else {
                    Session["NTID"] = userinfo.NTID;
                    Session["UserName"] = userinfo.DisplayName;
                    Session["ExamType"] = userinfo.ExamType;
                    Session["Power"] = (int)userinfo.UserGroup;
                    Session["Project"] = userinfo.Project;
                    Session["Department"] = userinfo.Department;
                    Response.Redirect("Default.aspx");
                }
            }
            else {
                lpassword.Visible = true;
            }
        }

        protected bool Auth(string ntid, string password)
        {
            return BLL.Auth.CheckNTIDAuth(ntid, password);
        }
        protected UserInfo GetUserInfo(string ntid, string usertype, string examtype)
        {
            return BLL.Auth.GetUserInfo(ntid, usertype, examtype);
        }
    }
}