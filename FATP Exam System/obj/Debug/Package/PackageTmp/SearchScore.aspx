<%@ Page Title="Score Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchScore.aspx.cs" Inherits="FATP_Exam_System.SearchScore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container-fiuled">
    <div class="panel-default" style="margin-top:20px;">
        <div class="panel-heading"><b>Score Search</b></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-1">
                    <label class="form-label text-right" for="examsele">ExamType:</label>
                </div>
                <div class="col-lg-5">
                   <select id="examsele" class="form-control selectpicker" title="---Exam---" multiple data-live-search="true">
                   </select>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-1">
                    <button id="Searchbtn" class="btn btn-primary" type="button" style="margin-bottom:0px;width:70px" onclick="Search_Score()">Search</button>
                </div>
            </div>
            <div class="row" style="height:5px"></div>
            <div class="row">
                <div class="col-lg-1">
                    <label class="form-label text-right" for="departmentsele">Department:</label>
                </div>
                <div class="col-lg-2">
                    <select id="departmentsele" class="form-control selectpicker" title="---Department---" multiple>
                   </select>
                </div>
                <div class="col-lg-1">
                    <label class="form-label text-right" for="projsele">Project:</label>
                </div>
                <div class="col-lg-2">
                    <select id="projsele" class="form-control selectpicker" title="---Project---" multiple>
                   </select>
                </div>
                <div class="col-lg-1">
                    <label class="form-label text-right" for="ntid">NTID:</label>
                </div>
                <div class="col-lg-2">
                     <input id="ntid" type="text" class="form-control" title="---NTID---"/>
                </div>
            </div>
        </div>
    </div>
    <div class="table-responsive">
        <table class="table table-striped table-sm table-bordered table-hover" id="score-table">
            <thead>
                <tr>
                    <th>Index</th>
                    <th>ExamName</th>
                    <th>Department</th>
                    <th>Project</th>
                    <th>NTID</th>
                    <th>Score</th>
                    <th>TotalScore</th>
                    <th>ExamTime</th>
                </tr>
            </thead>
            <tbody id="score-table-tr"></tbody>
        </table>
    </div>
</div>
    <script src="Scripts/bootstrap-select.min.js"></script>
    <script src="Scripts/Customer/SettingJS.js"></script>
    <script src="Scripts/Customer/getScore.js"></script>
    <script>
        $(document).ready(function () {
            Select_Department();
            Select_Project();
            Select_Exam();
            initial();
        });
            


    </script>
</asp:Content>
