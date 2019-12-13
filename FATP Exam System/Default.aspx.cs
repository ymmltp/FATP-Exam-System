using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FATP_Exam_System
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                string user = Session["UserName"].ToString();
                User_ID.Text = "Welcome[ " + Session["UserName"].ToString() + " ]";
            }
        }
    }
}