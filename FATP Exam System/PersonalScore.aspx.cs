﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FATP_Exam_System
{
    public partial class PersonalScore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string username = HttpContext.Current.Request["ntid"];
            if (!IsPostBack)
            {
                if (username == null)
                {
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
    }
}