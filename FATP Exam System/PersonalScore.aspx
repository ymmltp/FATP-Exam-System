<%@ Page Title="Personal Score" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalScore.aspx.cs" Inherits="FATP_Exam_System.PersonalScore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fiuled">
    <div class="panel-default" style="margin-top:20px;">
        <div class="panel-heading"><b>Personal Score</b></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-1">
                    <label class="form-label text-right" >NTID</label>
                </div>
                <div class="col-lg-2">
                    <label class="form-label text-left" id="ntid">________</label>
                </div>
                <div class="col-lg-1">
                    <label class="form-label text-right">Name:</label>
                </div>
                <div class="col-lg-2">
                    <label class="form-label text-left" id="username">_________</label>
                </div>
                <div class="col-lg-6">
                </div>
            </div>
        </div>
    </div>
    <div class="table-responsive">
        <table class="table table-striped table-sm table-bordered table-hover" id="personalscore-table">
            <thead>
                <tr>
                    <th>Index</th>
                    <th>ExamName</th>
                    <th>NTID</th>
                    <th>Score</th>
                    <th>ExamTime</th>
                </tr>
            </thead>
            <tbody id="personalscore-table-tr"></tbody>
        </table>
    </div>
</div>
</asp:Content>
