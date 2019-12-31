<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcelUploadDemo.aspx.cs" Inherits="FATP_Exam_System.ExcelUploadDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <button type="button" id="showmodel">Upload</button>

    <%--delete model--%>
    <input type="hidden" id="secret" name="secret" value=""/>
    <div class="modal fade" id="UploadModal" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" >
      <div class="modal-dialog" role="document" style="width:600px">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title"><b>Upload File</b></h5>s
            </div>
            <div class="modal-body">
                <div class="panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-lg-2">
                                <label for="filepath" class="form-label text-right">File Path:</label>
                            </div>
                            <div class="col-lg-7">
                                <input id="filepath" type="text"  class="form-control" title="---File Path---"/>
                            </div>
                            <div class="col-lg-1"></div>
                            <div class="col-lg-2">
                                <button id="openbtn" class="btn btn-success" style="margin-bottom:0px;width:70px" onclick="FileOpen()">Open</button>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">
                            <table class="table table-striped table-sm table-bordered table-hover" id="user-upload-table">
                                <thead>
                                    <tr>
                                        <th>Index</th>
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
                    <button class="btn btn-primary" id="examupload">Upload</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal" aria-label="Close">Cancel</button>
                </div>
            </div>
        </div>
    </div>

<script src="Scripts/Customer/ExacelUpload.js"></script>
</asp:Content>
