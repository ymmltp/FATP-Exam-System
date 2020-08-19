var wb;
var uploadArray;
var examName;
var examType;

$("#showmodel").click(function () {
    $("#UploadModal").modal("show");
    examName = $("#examsele option:selected").text();
    examType = $("#examsele option:selected").val();
    if (examType === "" || examType === undefined) {
        alert("Please select a exam first...");
        $("#UploadModal").modal("hide");
    }
});
function handleFiles(files) {
    var fileData = files[0]
    $("#filepath").val(fileData.name);
    var reader = new FileReader();
    var strArr = [];
    var rABS = false;
    let that = this;
    reader.onload = function (data) {
        var data = data.content;
        if (rABS) {
            wb = XLSX.read(btoa(this.fixdata(data)), { //手动转化
                type: 'base64'
            });
        } else {
            wb = XLSX.read(data, {
                type: 'binary'
            });
        }

        console.log(wb);
        var option = "";
        for (var i = 0; i < wb.SheetNames.length; i++) {
            option += "<option value=\"" + wb.SheetNames[i] + "\">" + wb.SheetNames[i] + "</option>";
        }
        $("#sheetsele").html("");
        $("#sheetsele").html(option);
        $("#sheetsele").selectpicker('refresh');
    };
    if (rABS) {
        reader.readAsArrayBuffer(fileData);
    } else {
        reader.readAsBinaryString(fileData);
    }
}
//extend FileReader
FileReader.prototype.readAsBinaryString = function (fileData) {
    var binary = "";
    var pt = this;
    var reader = new FileReader();
    reader.onload = function (e) {
        var bytes = new Uint8Array(reader.result);
        var length = bytes.byteLength;
        for (var i = 0; i < length; i++) {
            binary += String.fromCharCode(bytes[i]);
        }
        pt.content = binary;
        pt.onload(pt);
    }
    reader.readAsArrayBuffer(fileData);
}

function ShowUserSheet () {
    var sheetName = $("#sheetsele").val();
    var worksheet = wb.Sheets[sheetName];
    var tempArr = XLSX.utils.sheet_to_json(worksheet);  //dictionary类
    console.log(tempArr);
    var option = "";
    for (var tmp in tempArr) {
        tempArr[tmp]["ExamType"] = examType;
        tempArr[tmp]["ID"] = null;
        option += "<tr><td id=\" tr" + tmp + "ExamName\">" + examName + "</td>";
        option += "<td id=\" tr" + tmp + "NTID\" >" + tempArr[tmp].NTID + "</td>";
        option += "<td id=\" tr" + tmp + "Department\" >" + tempArr[tmp].Department + "</td>";
        option += "<td id=\" tr" + tmp + "Project\" >" + tempArr[tmp].Project + "</td>";
        option += "<td id=\" tr" + tmp + "UserLevel\" >" + tempArr[tmp].UserLevel + "</td></tr>";
    }
    uploadArray = tempArr;
    $("#user-upload-table-tr").html("");
    $("#user-upload-table-tr").html(option);
}
function ShowQuestionSheet() {
    var sheetName = $("#sheetsele").val();
    var worksheet = wb.Sheets[sheetName];
    var tempArr = XLSX.utils.sheet_to_json(worksheet);  //dictionary类
    console.log(tempArr);
    var option = "";
    for (var tmp in tempArr) {
        tempArr[tmp]["ExamType"] = examType;
        tempArr[tmp]["ID"] = null;
        option += "<tr><td id=\" tr" + tmp + "ExamName\">" + examName + "</td>";
        option += "<td id=\" tr" + tmp + "Question\" >" + tempArr[tmp].Question + "</td>";
        option += "<td id=\" tr" + tmp + "QuestionType\" >" + tempArr[tmp].QuestionType + "</td>";
        option += "<td id=\" tr" + tmp + "SelectA\" >" + tempArr[tmp].SelectA + "</td>";
        option += "<td id=\" tr" + tmp + "SelectB\" >" + tempArr[tmp].SelectB + "</td>";
        option += "<td id=\" tr" + tmp + "SelectC\" >" + tempArr[tmp].SelectC + "</td>";
        option += "<td id=\" tr" + tmp + "SelectD\" >" + tempArr[tmp].SelectD + "</td>";
        option += "<td id=\" tr" + tmp + "Answer\" >" + tempArr[tmp].Answer + "</td></tr>";
    }
    uploadArray = tempArr;
    $("#question-upload-table-tr").html("");
    $("#question-upload-table-tr").html(option);
}

function UploadUser() {
    $.ajax({
        url: "Ashx/BatchUpload.ashx",
        type: "post",
        contentType: "application/x-www-form-urlencoded;charset=utf-8",
        data: {
            type: "user",
            uploadArray: JSON.stringify(uploadArray),
            RandID: Math.random()
        },
        dataType: "json",
        success: function (data) {
            alert(data);
            $("#rolesele").selectpicker("val", "");
            $("#rolesele").selectpicker("refresh");
            $("#ntid").val("");
            $("#projsele").selectpicker("val", "");
            $("#projsele").selectpicker("refresh");
            $("#departmentsele").selectpicker("val", "");
            $("#departmentsele").selectpicker("refresh");
            $("#Addbtn").attr("class", "btn btn-success");
            $("#Addbtn").attr("onclick", "Add_User()");
            $("#Addbtn").html("Add");
            User_Table();
        },
        error: function (data) {
            alert(data.responseText);
        }
    })
}
function UploadQuestion() {
    $.ajax({
        url: "Ashx/BatchUpload.ashx",
        type: "post",
        contentType: "application/x-www-form-urlencoded;charset=utf-8",
        data: { 
            type: "question",
            uploadArray: JSON.stringify(uploadArray),
            RandID: Math.random()
        },
        dataType: "json",
        success: function (data) {
            alert(data);
        },
        error: function (data) {
            alert(data.responseText);
            $("#questiontypesele").selectpicker("val", "");
            $("#questiontypesele").selectpicker("refresh");
            $("#question").val("");
            $("#answer").selectpicker("val", "");
            $("#answer").selectpicker("refresh");
            $("#s1").val("");
            $("#s2").val("");
            $("#s3").val("");
            $("#s4").val("");
            $("#Addbtn").attr("class", "btn btn-success");
            $("#Addbtn").attr("onclick", "Add_User()");
            $("#Addbtn").html("Add");
            Question_Table();
        }
    })
}