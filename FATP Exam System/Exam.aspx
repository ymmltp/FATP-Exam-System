<%@ Page Title="Exam" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="FATP_Exam_System.Exam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container-fiuled">
    <div class="panel-default" style="margin-top:20px;">
        <div class="panel-heading" style="position:relative;height:40px">
            <span id="exam-info"><b>Exam Name:________</b></span>
            <span id="exam-score"> <b>FinalScore:________</b></span>
        </div>

        <div class="exam-body">
            <div class="col-lg-2 exam-left-list">
                <div class="my-col my-panel-default">
                <div class="my-panel-heading" style="color:white;background-color: #3CB371;"><b>Question List</b></div>
                <div class="my-panel-body" >   
                    <ul id="question-list" style="display:none">
                        <%--题号--%>
                    </ul>
                </div>
                </div>
            </div>

            <div class="col-lg-10 exam-right-body">
                <div class="exam-question" style="background-color:rgba(212, 247, 198, 0.34)">
                    <div class="my-panel-default exam-question-body">
                        <div class="my-panel-heading" id="question-type"></div>
                        <div class="my-panel-body" id="question-content">
                            <%--题目内容--%>
                        </div>
                    </div>
                </div>
                <div class="exam-select">
                    <ul id="select-list" >
                        <%--选项--%>
                    </ul>
                </div>
                <div class="exam-function">
                    <div class="col-lg-5"></div>
                    <div class="col-lg-2"><button class="btn btn-primary" type="button" id="btn-start" style="font-size:14px;">Start</button></div>                   
                    <div class="col-lg-2"></div>
                    <div class="col-lg-1"><button class="btn btn-primary" type="button" id="btn-last" style="font-size:14px;background-color:#008651; display:none;">«««</button></div>
                    <div class="col-lg-1"><button class="btn btn-primary" type="button" id="btn-next" style="font-size:14px;background-color:#008651; display:none;">»»»</button></div>                   
                    <div class="col-lg-1"><button class="btn btn-warning" type="button" id="btn-submit" style="font-size:14px;display:none;">Submit</button></div>
                </div>
            </div>  
            
        </div>
    </div>

    <%--delete model--%>
    <div class="modal fade" id="SubmitModal" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
      <div class="modal-dialog" role="document" style="width:400px">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Check</h5>
          </div>
          <div class="modal-body">
                <label class="col-form-label">You haven't answer all question.</label>
                <label class="col-form-label">Sure you want to Submit?</label>
          </div>

          <div class="modal-footer">
            <button class="btn btn-primary" id="SureBut" type="button">Sure</button>
            <button type="button" class="btn btn-danger" data-dismiss="modal" aria-label="Close">Cancel</button>
          </div>
        </div>
      </div>
    </div>
</div>

    <script src="Scripts/Customer/Exam.js"></script>
    <script>
        $(document).ready(function () {
            Get_ExamInfo()
        });
    </script>
</asp:Content>
