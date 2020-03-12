﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace FATP_Exam_System
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    User_ID.Text = Session["UserName"].ToString() +"  ";
                    Sign_Off.Visible = true;
                }
            }
        }

        protected void Sing_Out_Click(object sender, EventArgs e)
        {
            Sign_Off.Visible = false;
            Session.Clear();
            User_ID.Text = "Sign In";
            Response.Redirect("LogIn.aspx");
        }
    }
}