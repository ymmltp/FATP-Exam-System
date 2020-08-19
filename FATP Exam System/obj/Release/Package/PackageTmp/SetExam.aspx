<%@ Page Title="Exam Config" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SetExam.aspx.cs" Inherits="FATP_Exam_System.SetExam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fiuled">
    <div class="panel-default" style="margin-top:20px;">
        <div class="panel-heading"><b>Exam Config</b></div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-1">
                    <label for="examname-input" class="form-label text-right">ExamName:</label>
                </div>
                <div class="col-lg-3">
                    <input id="examname-input" type="text"  class="form-control" title="---Add New Exam---"/>
                </div>
                <div class="col-lg-1">
                    <label for="totalscore-input" class="form-label text-right">TotalScore:</label>
                </div>
                <div class="col-lg-2">
                    <input id="totalscore-input" type="text"  class="form-control" title="---Set TotalScore---" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"/>
                </div>
                <div class="col-lg-1">
                    <label for="passscore-input" class="form-label text-right">PassScore:</label>
                </div>
                <div class="col-lg-2">
                    <input id="passscore-input" type="text"  class="form-control" title="---Set PassScore---" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"/>
                </div>
                <div class="col-lg-2">
                    <button id="Addbtn" class="btn btn-success" style="margin-bottom:0px;width:70px" onclick="Add_Exam()">Add</button>
                </div>
            </div>
            <div class="row" style="height:5px"></div>
            <div class="row">
                <div class="col-lg-1">
                    <label for="singlecount-input" class="form-label text-right">SingleCount:</label>
                </div>
                <div class="col-lg-2">
                    <input id="singlecount-input" type="text"  class="form-control" title="---Set SingleCount---" onkeyup="this.value=this.value.replace(/\D/g,'')"/>
                </div>
                <div class="col-lg-1">
                    <label for="singlescore-input" class="form-label text-right">SingleScore:</label>
                </div>
                <div class="col-lg-2">
                    <input id="singlescore-input" type="text"  class="form-control" title="---Set SingleScore---" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"/>
                </div>
                <div class="col-lg-1">
                    <label for="multiplecount-input" class="form-label text-right">MultipleCount:</label>
                </div>
                <div class="col-lg-2">
                    <input id="multiplecount-input" type="text"  class="form-control" title="---Set MultipleCount---" onkeyup="this.value=this.value.replace(/\D/g,'')"/>
                </div>
                <div class="col-lg-1">
                    <label for="multiplescore-input" class="form-label text-right">MultipleScore:</label>
                </div>
                <div class="col-lg-2">
                    <input id="multiplescore-input" type="text"  class="form-control" title="---Set MultipleScore---" onkeyup="this.value=this.value.replace(/[^\d.]/g,'')"/>
                </div>
            </div>
        </div>
    </div>
    <div class="table-responsive">
        <table class="table table-striped table-sm table-bordered table-hover" id="exam-table">
            <thead>
                <tr>
                    <th>Index</th>
                    <th hidden>ExamID</th>
                    <th>ExamName</th>
                    <th>TotalScore</th>
                    <th>PassScore</th>
                    <th>SingleCount</th>
                    <th>Each Single Score</th>
                    <th>MultipleCount</th>
                    <th>Each Multiple Score</th>
                    <th>Operation</th>
                </tr>
            </thead>
            <tbody id="exam-table-tr"></tbody>
        </table>
    </div>

<%--delete model--%>
    <input type="hidden" id="secret" name="secret" value=""/>
    <div class="modal fade" id="DeleteModal" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
      <div class="modal-dialog" role="document" style="width:400px">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" style="font-weight:600;">Notice</h5>
          </div>
          <div class="modal-body">
              <p class="col-form-label" style="color:#FF0000;">If you delete this exam All of it's information (include Question and User) will be delete.</p>
              <p class="col-form-label">Please sure you want to delete this Exam.</p>
          </div>
          <div class="modal-footer">
            <button class="btn btn-primary" id="exam-SureBut">Sure</button>
            <button type="button" class="btn btn-danger" data-dismiss="modal" aria-label="Close">Cancel</button>
          </div>
        </div>
      </div>
    </div>

</div>
    <script src="Scripts/Customer/SettingJS.js"></script>
    <script src="Scripts/Customer/cookie.js"></script>
    <script>
        $(document).ready(function () {
            get_cookie();
            Exam_Table();
        })
    </script>
</asp:Content>
