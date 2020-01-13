<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetQuestion.aspx.cs" Inherits="FATP_Exam_System.SetQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fiuled">
    <div class="panel-default" style="margin-top:20px;">
        <div class="panel-heading"><b>Set Question</b></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-1">
                    <label for="examsele" class="form-label text-right">ExamName:</label>
                </div>
                <div class="col-lg-3">
                     <select id="examsele" class="form-control selectpicker" title="---Select Exam---" data-size="6" multiple data-max-options="1" data-live-search="true"></select>
                </div>
                <div class="col-lg-1">
                    <label for="questiontypesele" class="form-label text-right">Question Type:</label>
                </div>
                <div class="col-lg-2">
                   <select id="questiontypesele" class="form-control selectpicker" title="---Question Type---" multiple data-max-options="1" onchange="change_type()">
                       <option value="Single">Single</option>
                       <option value="Multiple">Multiple</option>
                   </select>
                </div>
                <div class="col-lg-1"></div>
                <div class="col-lg-1">
                    <button id="Addbtn" class="btn btn-success" style="margin-bottom:0px;width:70px" onclick="Add_Question()">Add</button>
                </div>
                <div class="col-lg-1">
                    <button id="showmodel" class="btn btn-info" type="button" style="margin-bottom:0px;width:70px">Upload</button>
                </div>
                <div class="col-lg-1">
                    <button id="Searchbtn" class="btn btn-primary" type="button" style="margin-bottom:0px;width:70px" onclick="Search_Question()">Search</button>
                </div>
            </div>
            <div class="row" style="height:5px"></div>
            <div class="row">
                <div class="col-lg-1">
                    <label for="question" class="form-label text-right">Question:</label>
                </div>
                <div class="col-lg-5">
                    <input id="question" type="text"  class="form-control" title="---Add Question---"/>
                </div> 
                <div class="col-lg-1">
                    <label for="answer" class="form-label text-right">Answer:</label>
                </div>
                <div class="col-lg-5">
                    <select id="answer" class="form-control selectpicker" title="---Answer---" multiple>
                        <option value="A">A</option>
                        <option value="B">B</option>
                        <option value="C">C</option>
                        <option value="D">D</option>
                    </select>
                </div> 
            </div>
            <div class="row" style="height:5px"></div>
            <div class="row">
                <div class="col-lg-1">
                    <label for="s1" class="form-label text-right">SelectA:</label>
                </div>
                <div class="col-lg-5">
                    <input id="s1" type="text"  class="form-control" title="---Add Select1---"/>
                </div>
                <div class="col-lg-1">
                    <label for="s2" class="form-label text-right">SelectB:</label>
                </div>
                <div class="col-lg-5">
                    <input id="s2" type="text"  class="form-control" title="---Add Select2---"/>
                </div> 
            </div>
            <div class="row" style="height:5px"></div>
            <div class="row">
                <div class="col-lg-1">
                    <label for="s3" class="form-label text-right">SelectC:</label>
                </div>
                <div class="col-lg-5">
                    <input id="s3" type="text"  class="form-control" title="---Add Select3---"/>
                </div> 
                <div class="col-lg-1">
                    <label for="s4" class="form-label text-right">SelectD:</label>
                </div>
                <div class="col-lg-5">
                    <input id="s4" type="text"  class="form-control" title="---Add Select4---"/>
                </div> 
            </div>
        </div>
    </div>
    <div class="table-responsive">
        <table class="table table-striped table-sm table-bordered table-hover" id="question-table">
            <thead>
                <tr>
                    <th>Index</th>
                    <th hidden>QuestionID</th>
                    <th>ExamName</th>
                    <th>Question</th>
                    <th>Question Type</th>
                    <th>SelectA</th>
                    <th>SelectB</th>
                    <th>SelectC</th>
                    <th>SelectD</th>
                    <th>Answer</th>
                    <th>Operation</th>
                </tr>
            </thead>
            <tbody id="question-table-tr"></tbody>
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
            <button class="btn btn-primary" id="question-SureBut">Sure</button>
            <button type="button" class="btn btn-danger" data-dismiss="modal" aria-label="Close">Cancel</button>
          </div>
        </div>
      </div>
    </div>

        
 <%--upload model--%>
    <div class="modal fade" id="UploadModal" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
      <div class="modal-dialog" role="document" style="width:1000px">
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
                                <select id="sheetsele" class="form-control selectpicker" title="---Select Sheet---" onchange="ShowQuestionSheet()"></select>
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
                                        <th>Question</th>
                                        <th>QuestionType</th>
                                        <th>SelectA</th>
                                        <th>SelectB</th>
                                        <th>SelectC</th>
                                        <th>SelectD</th>
                                        <th>Answer</th>
                                    </tr>
                                </thead>
                                <tbody id="question-upload-table-tr"></tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
                <div class="modal-footer">
                    <button class="btn btn-primary" id="upload" onclick="UploadQuestion()">Upload</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal" aria-label="Close">Cancel</button>
                </div>
            </div>
        </div>
    </div>

</div>
<%--    <script src="Scripts/jquery-3.3.1.js"></script>--%>
    <script src="Scripts/bootstrap-select.min.js"></script>
    <script src="Scripts/Customer/SettingJS.js"></script>
    <script src="Scripts/Customer/ExcelUpload.js"></script>
    <script src="Scripts/Customer/xlsx.full.min.js"></script>
    <script>
        $(document).ready(function () {
            Select_Exam();
            //Question_Table();
        })
    </script>

</asp:Content>
