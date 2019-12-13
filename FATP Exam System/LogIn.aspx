<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="FATP_Exam_System.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>FATP Exam System - Log In</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
        <link href="Content/login.css" type="text/css" rel="stylesheet"/>
    </asp:PlaceHolder>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <div class="sso-container">
    <div class="panel panel-default">
        <div class="panel-header">
            <img src="images/jabil.png" class="sso-logo" alt="Jabil Circuit - Prod">
        </div>
        <div class="panel-body">
            <form class="form-login" method="POST" id="formLogin">
                <p class="form-login-heading" id="sys-head"> JGP FATP Exam System
                    <!-- <strong>系统</strong> -->
                </p>
                <br/>
                <div class="form-group has-feedback">
                    <label class="sr-only" for="ntid"> NTID </label>
                    <asp:Label ID="cntid" Visible="false" runat="server"></asp:Label>
                    <input type="text" id="ntid" name="ntid" class="form-control" value="" placeholder="NTID" autofocus/>
                    <span class="glyphicon glyphicon-user form-control-feedback input-icon"></span>
                </div>
                <div class="form-group has-feedback">
                    <label for="password" class="sr-only"> PassWord </label>
                    <asp:Label ID="cpassword" Visible="false" runat="server"></asp:Label>
                    <input type="password" id="password" name="password" class="form-control" value="" placeholder="Password"/>
                    <span class="glyphicon glyphicon-lock form-control-feedback input-icon"></span>
                    <asp:Label id="lpassword" style="color:red;" Visible="false" runat="server">Error PassWord or UserName</asp:Label>
                </div>
                <div class="form-group has-feedback">
                    <label class="sr-only"> User </label>
                    <asp:Label ID="cuser" Visible="false" runat="server"></asp:Label>
                    <select  id="sele-user" name="site" class="selectpicker form-control ui-select" placeholder="Site" required>
                    <option value="User">User</option><option value="Admin">Admin</option>
                    </select>
                    <asp:Label id="luser" style="color:red;" Visible="false" runat="server">Please enter your UserType</asp:Label>
                </div>
                <div class="form-group has-feedback">
                    <label class="sr-only"> ExamType </label>
                    <asp:Label ID="cexamtype" Visible="false" runat="server"></asp:Label>
                    <select  id="sele-exam" name="examtype" class="selectpicker form-control ui-select" placeholder="ExamType" required>
                    </select>
                    <asp:Label id="lexamtype" style="color:red;" Visible="false" runat="server">Please enter your ExamType</asp:Label>
                </div>
                <div>
                    <%--<input type="submit" class="btn btn-lg btn-primary btn-block" id="sso-login" value="Sign In"/>--%>
                    <button class="btn btn-lg btn-primary btn-block" id="logbtn" type="button">
                        Sign In<i class="fa fa-spinner faa-spin animated"></i>
                    </button>
                </div>
            </form>
            <div class="sso-hint">
                <span id="hint"></span>
            </div>
        </div>
    </div>
    </div>

    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-select.min.js"></script>
    <script src="Scripts/Customer/LogIn.js"></script>
    <script>
        $(document).ready(function () {
            initialExamType();
        });
    </script>
</body>
</html>
