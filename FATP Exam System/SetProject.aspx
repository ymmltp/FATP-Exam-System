<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetProject.aspx.cs" Inherits="FATP_Exam_System.SetProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fiuled">
    <div class="panel-default" style="margin-top:20px;">
        <div class="panel-heading"><b>Set Project</b></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-1">
                    <label for="project-input" class="form-label text-right">Project:</label>
                </div>
                <div class="col-lg-2">
                    <input id="project-input" type="text"  class="form-control" title="---Add Project---" onchange=""/>
                </div>
                <div class="col-lg-3">
                    <button id="Addbtn" class="btn btn-success" type="button" style="margin-bottom:0px;width:70px" onclick="Add_Project()">Add</button>
                </div>
                <div class="col-lg-6">
                </div>
            </div>
        </div>
    </div>
    <div class="table-responsive">
        <table class="table table-striped table-sm table-bordered table-hover" id="project-table">
            <thead>
                <tr>
                    <th>Index</th>
                    <th>Project</th>
                    <th>Operation</th>
                </tr>
            </thead>
            <tbody id="project-table-tr"></tbody>
        </table>
    </div>
</div>
<script src="Scripts/jquery-3.3.1.min.js"></script>
<script src="Scripts/Customer/SettingJS.js"></script>
<script>
    $(document).ready(function(){
            Project_Table();
    })
</script>
</asp:Content>
