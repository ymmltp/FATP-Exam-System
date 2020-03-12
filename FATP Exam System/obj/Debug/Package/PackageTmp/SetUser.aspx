<%@ Page Title="Set User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetUser.aspx.cs" Inherits="FATP_Exam_System.SetUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fiuled">
    <div class="panel-default" style="margin-top:20px;">
        <div class="panel-heading"><b>Set User</b></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-1">
                    <label for="examsele" class="form-label text-right">ExamName:</label>
                </div>
                <div class="col-lg-3">
                     <select id="examsele" class="form-control selectpicker" title="---Select Exam---" multiple data-max-options="1" data-live-search="true" data-size="6"></select>
                </div>
                <div class="col-lg-1">
                    <label for="rolesele" class="form-label text-right">Role:</label>
                </div>
                <div class="col-lg-2">
                   <select id="rolesele" class="form-control selectpicker" title="---User Level---" multiple data-max-options="1" data-live-search="false">
                       <option value="User">User</option>
                       <option value="Admin">Admin</option>
                   </select>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-1">
                    <button id="Addbtn" class="btn btn-success" type="button" style="margin-bottom:0px;width:70px" onclick="Add_User()">Add</button>
                </div>
                <div class="col-lg-1">
                    <button id="showmodel" class="btn btn-info" type="button" style="margin-bottom:0px;width:70px">Upload</button>
                </div>
                <div class="col-lg-1">
                    <button id="Searchbtn" class="btn btn-primary" type="button" style="margin-bottom:0px;width:70px" onclick="Search_User()">Search</button>
                </div> 
            </div>
            <div class="row" style="height:5px"></div>
            <div class="row">
                <div class="col-lg-1">
                    <label for="ntid" class="form-label text-right">NTID:</label>
                </div>
                <div class="col-lg-3">
                    <input id="ntid" type="text"  class="form-control" title="---Add NTID---"/>
                </div>
                 <div class="col-lg-1">
                    <label for="projsele" class="form-label text-right">Project:</label>
                </div>
                <div class="col-lg-2">
                     <select id="projsele" class="form-control selectpicker" title="---Select Project---" multiple data-max-options="1" data-live-search="true" data-size="6"></select>
                </div>
                 <div class="col-lg-1">
                    <label for="departmentsele" class="form-label text-right">Department:</label>
                </div>
                <div class="col-lg-2">
                     <select id="departmentsele" class="form-control selectpicker" multiple data-max-options="1" title="---Select Department---" data-size="6"></select>
                </div>
            </div>
        </div>
    </div>
    <div class="table-responsive">
        <table class="table table-striped table-sm table-bordered table-hover" id="user-table">
            <thead>
                <tr>
                    <th>Index</th>
                    <th hidden>UserID</th>
                    <th>ExamName</th>
                    <th>NTID</th>
                    <th>Department</th>
                    <th>Project</th>
                    <th>UserLevel</th>
                    <th>Operation</th>
                </tr>
            </thead>
            <tbody id="user-table-tr"></tbody>
        </table>
    </div>

<%--delete model--%>
    <input type="hidden" id="secret" name="secret" value=""/>
    <div class="modal fade" id="DeleteModal" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
      <div class="modal-dialog" role="document" style="width:400px">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Check</h5>
          </div>
          <div class="modal-body">
                <label class="col-form-label">Please sure you want to delete this list</label>
          </div>
          <div class="modal-footer">
            <button class="btn btn-primary" type="button" id="user-SureBut">Sure</button>
            <button type="button" class="btn btn-danger" data-dismiss="modal" aria-label="Close">Cancel</button>
          </div>
        </div>
      </div>
    </div>

 <%--upload model--%>
    <div class="modal fade" id="UploadModal" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
      <div class="modal-dialog" role="document" style="width:600px">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title"><b>Upload File</b></h5>
            </div>
            <div class="modal-body">
                <div class="panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-lg-2">
                                <label for="filepath" class="form-label text-right">Sheets:</label>
                            </div>
                            <div class="col-lg-7">
                                <select id="sheetsele" class="form-control selectpicker" title="---Select Sheet---" onchange="ShowUserSheet()"></select>
                            </div>
                            <div class="col-lg-2">
                                <button id="openbtn" type="button" class="btn btn-success" style="margin-bottom:0px;position:relative;overflow:hidden">
                                    OpenFile
                                </button>
                                <input type="file" id="file-input"  onchange="handleFiles(this.files)" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" style="position:absolute;left:0;right:0;top:0;bottom:0;z-index:10;height:100%;width:100%;opacity:0;"/> 
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">
                            <table class="table table-striped table-sm table-bordered table-hover" id="result">
                                <thead>
                                    <tr>
                                        <th>ExamName</th>
                                        <th>NTID</th>
                                        <th>Department</th>
                                        <th>Project</th>
                                        <th>UserLevel</th>
                                    </tr>
                                </thead>
                                <tbody id="user-upload-table-tr"></tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
                <div class="modal-footer">
                    <button class="btn btn-primary" id="upload" onclick="UploadUser()">Upload</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal" aria-label="Close">Cancel</button>
                </div>
            </div>
        </div>
    </div>

</div>
    <script src="Scripts/bootstrap-select.min.js"></script>
    <script src="Scripts/Customer/SettingJS.js"></script>
    <script src="Scripts/Customer/ExcelUpload.js"></script>
    <script src="Scripts/Customer/xlsx.full.min.js"></script>
    <script>
        $(document).ready(function () {
            Select_Department();
            Select_Project();
            Select_Exam();
            //User_Table();
        })
    </script>
</asp:Content>
