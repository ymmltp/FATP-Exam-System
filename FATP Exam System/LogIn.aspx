﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="FATP_Exam_System.LogIn" EnableEventValidation="false" %>

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
    <link href="~/webinicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <div class="sso-container">
    <div class="panel panel-default">
        <div class="panel-header">
            <img src="images/jabil.png" class="sso-logo" alt="Jabil Circuit - Prod">
        </div>
        <div class="panel-body">
            <form class="form-login" runat="server" id="formLogin">
                <p class="form-login-heading" id="sys-head"> JGP FATP Exam System
                    <!-- <strong>系统</strong> -->
                </p>
                <br/>
                <div class="form-group has-feedback">
                    <label class="sr-only" for="ntid"> NTID </label>
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" OnTextChanged="Password_TextChanged"></asp:TextBox>
                    <span class="glyphicon glyphicon-user form-control-feedback input-icon"></span>
                </div>
                <div class="form-group has-feedback">
                    <label for="password" class="sr-only"> PassWord </label>
                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" OnTextChanged="Password_TextChanged" TextMode="Password"></asp:TextBox>
                    <span class="glyphicon glyphicon-lock form-control-feedback input-icon"></span>
                    <asp:Label ID="lpassword" style="color:red;" Visible="false" runat="server">Error PassWord or UserName</asp:Label>
                </div>
                <div class="form-group has-feedback">
                    <label class="sr-only"> User </label>
                    <asp:DropDownList ID="SeleUser" CssClass="selectpicker form-control ui-select" runat="server">
                        <asp:ListItem Value="User">User</asp:ListItem>
                        <asp:ListItem Value="Admin">Admin</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label id="lusertype" style="color:red;" Visible="False" runat="server">Please enter your UserType</asp:Label>
                </div>
                <div class="form-group has-feedback">
                    <label class="sr-only"> ExamType </label>
                    <asp:DropDownList ID="SeleExam" CssClass="selectpicker form-control ui-select" runat="server">
                    </asp:DropDownList>
                    <asp:Label id="lexamtype" style="color:red;" Visible="false" runat="server">Sorry you don't have access to this exam...</asp:Label>
                </div>
                <div>
                    <asp:Button ID="ButtonLogIn" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Sign In" OnClick="ButtonLogIn_Click"/>
                </div>
            </form>
            <div class="sso-hint">
                <span id="hint"></span>
            </div>
        </div>
    </div>
            <footer style="text-align:center;color:gray">
                <p>&copy; <%: DateTime.Now.Year %> - WuXi FATP Exam System</p>
            </footer>
    </div>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-select.min.js"></script>
</body>
</html>
