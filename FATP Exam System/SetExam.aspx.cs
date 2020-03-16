using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FATP_Exam_System
{
    public partial class SetExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = HttpContext.Current.Request["ntid"];
                string power = HttpContext.Current.Request["power"];
                if (username != null)
                {
                    if (Int32.Parse(power) < 7)
                    {
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
    }
}