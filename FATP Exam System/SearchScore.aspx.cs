using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FATP_Exam_System
{
    public partial class SearchScore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    if (Int32.Parse(Session["Power"].ToString()) < 3)
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