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
                    Error_Text.Text = @"<h3>Sorry,you have no access to this page!</h3></br>
                                    <h5>Please choose _Blank to get into this setting.</br></br>
                                    If you don't have authority to choose _Blank. Please contact with following address.</h5></br>
                                    <h5><strong>Support:</strong><address><a href='mailto: Adele_Lu @Jabil.com'>Adele_Lu@Jabil.com</a></address></h5></br>";
                }
                else
                {
                    Error_Text.Text = "Please Sign in...";
                }
            }
        }
    }
}