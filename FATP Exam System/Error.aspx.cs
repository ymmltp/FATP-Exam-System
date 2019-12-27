using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FATP_Exam_System
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    Error_Text.Text = "Sorry, you have no access to this page.Please contact with Admin...";
                }
                else
                {
                    Error_Text.Text = "Please Sign in...";
                }
            }
        }
    }
}