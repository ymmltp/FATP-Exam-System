using System;
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
                    string user = Session["UserName"].ToString();
                    User_ID.Text = "Welcome [ " + Session["UserName"].ToString() + " ]";
                }
            }
        }


    }
}