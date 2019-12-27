<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="FATP_Exam_System.Exam" %>
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
                    <ul id="question-list">
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
                    <ul id="select-list">
<%--                    <li class="select-list-item"><input type="radio" id="s1" name="Q1"/><label for="s1">SELECT1</label></li>
                        <li class="select-list-item"><input type="radio" id="s2" name="Q1"/><label for="s2">SELECT2</label></li>
                        <li class="select-list-item"><input type="radio" id="s3" name="Q1"/><label for="s3">SELECT3</label></li>
                        <li class="select-list-item"><input type="radio" id="s4" name="Q1"/><label for="s4">SELECT4</label></li>--%>
                       <%-- <li class="select-list-item"><input type="checkbox" id="s1" name="Q2"/><label for="s1">SELECT1</label></li>
                        <li class="select-list-item"><input type="checkbox" id="s2" name="Q2"/><label for="s2">SELECT2</label></li>
                        <li class="select-list-item"><input type="checkbox" id="s3" name="Q2"/><label for="s3">SELECT3</label></li>
                        <li class="select-list-item"><input type="checkbox" id="s4" name="Q2"/><label for="s4">SELECT4</label></li>--%>
                    </ul>
                </div>
                <div class="exam-function">
                    <div class="col-lg-9"></div>
                    <div class="col-lg-1"><button class="btn btn-primary" type="button" id="btn-last" type="button" style="font-size:14px;background-color:#008651;display:none;" onclick="Last_Question()">«««</button></div>
                    <div class="col-lg-1"><button class="btn btn-primary" type="button" id="btn-next" type="button" style="font-size:14px;background-color:#008651" onclick="Start_Exam()">Start</button></div>                   
                </div>
            </div>  
            
        </div>
    </div>
</div>
    <script src="Scripts/Customer/Exam.js"></script>
    <script>
        $(document).ready(function () {
            Get_ExamInfo()
        })
    </script>
</asp:Content>
