//Select
function Select_Project() {
    var url = "Ashx/GetTable.ashx?type=project&RandID=" + Math.random();
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<option value=\"" + data[i].Project + "\">" + data[i].Project + "</option>";
            }
            $("#projsele").html("");
            $("#projsele").html(option);
            $("#projsele").selectpicker('refresh');
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}
function Select_Department() {
    var url = "Ashx/GetTable.ashx?type=department&RandID=" + Math.random();
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<option value=\"" + data[i].Department + "\">" + data[i].Department + "</option>";
            }
            $("#departmentsele").html("");
            $("#departmentsele").html(option);
            $("#departmentsele").selectpicker('refresh');
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}
function Select_Exam() {
    var url = "Ashx/GetTable.ashx?type=exam&RandID=" + Math.random();
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += '<option value="' + data[i].ExamID + '">' + data[i].ExamName + '</option>';
            }
            $("#examsele").html("");
            $("#examsele").html(option);
            $("#examsele").selectpicker('refresh');
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

//Table
function Project_Table() {
    var url = "Ashx/GetTable.ashx?type=project&RandID=" + Math.random();
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType:"json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<tr><td id=\" tr" + i + "ID\">" + data[i].IndexID + "</td>";
                option += "<td id=\" tr" + i + "project\" >" + data[i].Project + "</td>";
                option += "<td><a id=\" tr" + i + "delete\" onclick=\"Delete_Project(this)\">Delete</a></td></tr>";
            }
            $("#project-table-tr").html("");
            $("#project-table-tr").html(option);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}
function Department_Table() {
    var url = "Ashx/GetTable.ashx?type=department&RandID=" + Math.random();
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<tr><td id=\" tr" + i + "ID\">" + data[i].IndexID + "</td>";
                option += "<td id=\" tr" + i + "department\" >" + data[i].Department + "</td>";
                option += "<td><a id=\" tr" + i + "delete\" onclick=\"Delete_Department(this)\">Delete</a></td></tr>";
            }
            $("#department-table-tr").html("");
            $("#department-table-tr").html(option);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}
function Exam_Table() {
    var url = "Ashx/GetTable.ashx?type=exam&RandID=" + Math.random();
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<tr><td id=\" tr" + i + "IndexID\">" + data[i].IndexID + "</td>";
                option += "<td id=\" tr" + i + "ID\" hidden>" + data[i].ExamID + "</td>";
                option += "<td id=\" tr" + i + "ExamName\" >" + data[i].ExamName + "</td>";
                option += "<td id=\" tr" + i + "TotalScore\" >" + data[i].TotalScore + "</td>";
                option += "<td id=\" tr" + i + "PassScore\" >" + data[i].PassScore + "</td>";
                option += "<td id=\" tr" + i + "SingleCount\" >" + data[i].SingleCount + "</td>";
                option += "<td id=\" tr" + i + "SingleScore\" >" + data[i].EachSingleScore + "</td>";
                option += "<td id=\" tr" + i + "MultipleCount\" >" + data[i].MultipleCount + "</td>";
                option += "<td id=\" tr" + i + "MultipleScore\" >" + data[i].EachMultipleScore + "</td>";
                option += "<td><a id=\" tr" + i + "delete\" onclick=\"Show_Delete_Exam(this)\">Delete</a> | <a id=\" tr" + i + "edit\" onclick=\"Edit_Exam(this)\">Edit</a></td></tr>";
            }
            $("#exam-table-tr").html("");
            $("#exam-table-tr").html(option);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}
function User_Table() {
    var url = "Ashx/GetTable.ashx?type=user&RandID=" + Math.random();
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<tr><td id=\" tr" + i + "IndexID\">" + data[i].IndexID + "</td>";
                option += "<td id=\" tr" + i + "ID\" hidden>" + data[i].ID + "</td>";
                option += "<td id=\" tr" + i + "ExamName\" >" + data[i].ExamType + "</td>";
                option += "<td id=\" tr" + i + "NTID\" >" + data[i].NTID + "</td>";
                option += "<td id=\" tr" + i + "Department\" >" + data[i].Department + "</td>";
                option += "<td id=\" tr" + i + "Project\" >" + data[i].Project + "</td>";
                option += "<td id=\" tr" + i + "UserLevel\" >" + data[i].UserLevel + "</td>";
                option += "<td><a id=\" tr" + i + "delete\" onclick=\"Show_Delete_User(this)\">Delete</a> | <a id=\" tr" + i + "edit\" onclick=\"Edit_User(this)\">Edit</a></td></tr>";
            }
            $("#user-table-tr").html("");
            $("#user-table-tr").html(option);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}
function Question_Table() {
    var url = "Ashx/GetTable.ashx?type=question&RandID=" + Math.random();
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<tr><td id=\" tr" + i + "IndexID\">" + data[i].IndexID + "</td>";
                option += "<td id=\" tr" + i + "ID\" hidden>" + data[i].ID + "</td>";
                option += "<td id=\" tr" + i + "ExamName\" >" + data[i].ExamType + "</td>";
                option += "<td id=\" tr" + i + "Question\" >" + data[i].Question + "</td>";
                option += "<td id=\" tr" + i + "QuestionType\" >" + data[i].QuestionType + "</td>";
                option += "<td id=\" tr" + i + "S1\" >" + data[i].SelectA + "</td>";
                option += "<td id=\" tr" + i + "S2\" >" + data[i].SelectB + "</td>";
                option += "<td id=\" tr" + i + "S3\" >" + data[i].SelectC + "</td>";
                option += "<td id=\" tr" + i + "S4\" >" + data[i].SelectD + "</td>";
                option += "<td id=\" tr" + i + "Answer\" >" + data[i].Answer + "</td>";
                option += "<td><a id=\" tr" + i + "delete\" onclick=\"Show_Delete_Question(this)\">Delete</a> | <a id=\" tr" + i + "edit\" onclick=\"Edit_Question(this)\">Edit</a></td></tr>";
            }
            $("#question-table-tr").html("");
            $("#question-table-tr").html(option);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

//Add
function Add_Project() {
    var project = $("#project-input").val();
    var url = "Ashx/Add.ashx?type=project&project=" + project + "&RandID=" + Math.random();
    $.getJSON(url, function (data) {
        alert(data);
        $("#project-input").val("");
        Project_Table();
    });
}
function Add_Department() {
    var department = $("#department-input").val();
    var url = "Ashx/Add.ashx?type=department&department=" + department + "&RandID=" + Math.random();
    $.getJSON(url, function (data) {
        alert(data);
        $("#department-input").val("");
        Department_Table();
    });
}
function Add_Exam() {
    var examname = $("#examname-input").val();
    var totalscore = $("#totalscore-input").val();
    var passscore = $("#passscore-input").val();
    var singlecount = $("#singlecount-input").val();
    var singlescore = $("#singlescore-input").val();
    var multiplecount = $("#multiplecount-input").val();
    var multiplescore = $("#multiplescore-input").val();
    var url = encodeURI("Ashx/Add.ashx?type=exam&examname=" + examname + "&totalscore=" + totalscore + "&passscore=" + passscore + "&singlescore=" + singlescore + "&singlecount=" + singlecount + "&multiplecount=" + multiplecount + "&multiplescore=" + multiplescore + "&RandID=" + Math.random());
    $.getJSON(url, function (data) {
        alert(data);
    });
}
function Add_User() {
    var ntid = $("#ntid").val();
    var role = $("#rolesele").val();
    var project = $("#projsele").val();
    var department = $("#departmentsele").val();
    var examtype = $("#examsele").val();
    var url = encodeURI("Ashx/Add.ashx?type=user&ntid=" + ntid + "&role=" + role + "&project=" + project + "&department=" + department + "&examtype=" + examtype + "&RandID=" + Math.random());
    $.getJSON(url, function (data) {
        alert(data);
        $("#examsele").selectpicker("val", "");
        $("#examsele").selectpicker("refresh");
        $("#rolesele").selectpicker("val", "");
        $("#rolesele").selectpicker("refresh");
        $("#ntid").val("");
        $("#projsele").selectpicker("val", "");
        $("#projsele").selectpicker("refresh");
        $("#departmentsele").selectpicker("val", "");
        $("#departmentsele").selectpicker("refresh");
        User_Table();
    });
}
function Add_Question() {
    var examtype = $("#examsele").val();
    var questiontype = $("#questiontypesele").val();
    var question = $("#question").val();
    var s1 = $("#s1").val();
    var s2 = $("#s2").val();
    var s3 = $("#s3").val();
    var s4 = $("#s4").val();
    var answer = $("#answer").val();
    var url = encodeURI("Ashx/Add.ashx?type=question&examtype=" + examtype + "&question=" + question + "&questiontype=" + questiontype + "&answer=" + answer + "&s1=" + s1 + "&s2=" + s2 + "&s3=" + s3 + "&s4=" + s4 + "&RandID=" + Math.random());
    $.getJSON(url, function (data) {
        alert(data);
    });
}

//Delete
function Delete_Project(object) {
    var rrow = object.parentNode.parentNode.rowIndex;
    var project = $("#project-table tr:eq(" + rrow + ") td:eq(1)").html();
    var url = "Ashx/Delete.ashx?type=project&project=" + project + "&RandID=" + Math.random();
    $.getJSON(url, function (data) {
        alert(data);
        Project_Table();
    });
}
function Delete_Department(object) {
    var rrow = object.parentNode.parentNode.rowIndex;
    var department = $("#department-table tr:eq(" + rrow + ") td:eq(1)").html();
    var url = "Ashx/Delete.ashx?type=department&department=" + department + "&RandID=" + Math.random();
    $.getJSON(url, function (data) {
        alert(data);
        Department_Table();
    });
}
//Delete exam
function Show_Delete_Exam(object) {
    var rrow = object.parentNode.parentNode.rowIndex;
    var tmp = $("#exam-table tr:eq(" + rrow + ") td:eq(1)").html();
    $("#secret").val(tmp);
    $("#DeleteModal").modal("show");
}
$("#exam-SureBut").click(function () {
    try {
        $("#DeleteModal").modal("hide");
        var examID = $("#secret").val();
        Delete_Exam(examID);
    } catch (e) {
        alert(e);
    }
})
function Delete_Exam(examtype) {
    var url = "Ashx/Delete.ashx?type=exam&examtype=" + examtype + "&RandID=" + Math.random();
    $.getJSON(url, function (data) {
        alert(data);
    });
}
//Delete User
function Show_Delete_User(object) {
    var rrow = object.parentNode.parentNode.rowIndex;
    var tmp = $("#user-table tr:eq(" + rrow + ") td:eq(1)").html();
    $("#secret").val(tmp);
    $("#DeleteModal").modal("show");
}
$("#user-SureBut").click(function () {
    try {
        $("#DeleteModal").modal("hide");
        var userID = $("#secret").val();
        Delete_User(userID);
    } catch (e) {
        alert(e);
    }
})
function Delete_User(userid) {
    var url = "Ashx/Delete.ashx?type=user&userid=" + userid + "&RandID=" + Math.random();
    $.getJSON(url, function (data) {
        alert(data);
        User_Table();
    });
}
//Delete Question
function Show_Delete_Question(object) {
    var rrow = object.parentNode.parentNode.rowIndex;
    var tmp = $("#question-table tr:eq(" + rrow + ") td:eq(1)").html();
    $("#secret").val(tmp);
    $("#DeleteModal").modal("show");
}
$("#question-SureBut").click(function () {
    try {
        $("#DeleteModal").modal("hide");
        var questionID = $("#secret").val();
        Delete_Question(questionID);
    } catch (e) {
        alert(e);
    }
})
function Delete_Question(questionid) {
    var url = "Ashx/Delete.ashx?type=question&questionid=" + questionid + "&RandID=" + Math.random();
    $.getJSON(url, function (data) {
        alert(data);
    });
}

//Edit
//Edit exam
function Edit_Exam(object) {
    var rrow = object.parentNode.parentNode.rowIndex;
    var examtype = $("#exam-table tr:eq(" + rrow + ") td:eq(1)").html();
    var examname = $("#exam-table tr:eq(" + rrow + ") td:eq(2)").html();
    var totalscore = $("#exam-table tr:eq(" + rrow + ") td:eq(3)").html();
    var passscore = $("#exam-table tr:eq(" + rrow + ") td:eq(4)").html();
    var singlecount = $("#exam-table tr:eq(" + rrow + ") td:eq(5)").html();
    var singlescore = $("#exam-table tr:eq(" + rrow + ") td:eq(6)").html();
    var multiplecount = $("#exam-table tr:eq(" + rrow + ") td:eq(7)").html();
    var multiplescore = $("#exam-table tr:eq(" + rrow + ") td:eq(8)").html(); 

    $("#examname-input").val(examname);
    $("#totalscore-input").val(totalscore);
    $("#passscore-input").val(passscore);
    $("#singlecount-input").val(singlecount);
    $("#singlescore-input").val(singlescore);;
    $("#multiplecount-input").val(multiplecount);
    $("#multiplescore-input").val(multiplescore);

    $("#Addbtn").attr("class", "btn btn-warning");
    $("#Addbtn").attr("onclick", "Save_Exam(" + examtype + ")");
    $("#Addbtn").html("Save");
}
function Save_Exam(examtype) {
    var examname = $("#examname-input").val();
    var totalscore = $("#totalscore-input").val();
    var passscore = $("#passscore-input").val();
    var singlecount = $("#singlecount-input").val();
    var singlescore = $("#singlescore-input").val();
    var multiplecount = $("#multiplecount-input").val();
    var multiplescore = $("#multiplescore-input").val();

    var url = encodeURI("Ashx/Update.ashx?type=exam&examtype=" + examtype + "&examname=" + examname + "&totalscore=" + totalscore + "&passscore=" + passscore + "&singlescore=" + singlescore + "&singlecount=" + singlecount + "&multiplecount=" + multiplecount + "&multiplescore=" + multiplescore + "&RandID=" + Math.random());
    $.getJSON(url, function (data) {
        alert(data);
    });
}
//Edit user
function Edit_User(object) {
    var rrow = object.parentNode.parentNode.rowIndex;
    var userid = $("#user-table tr:eq(" + rrow + ") td:eq(1)").html();
    var examname = $("#user-table tr:eq(" + rrow + ") td:eq(2)").html();
    var ntid = $("#user-table tr:eq(" + rrow + ") td:eq(3)").html();
    var department = $("#user-table tr:eq(" + rrow + ") td:eq(4)").html();
    var project = $("#user-table tr:eq(" + rrow + ") td:eq(5)").html();
    var userlevel = $("#user-table tr:eq(" + rrow + ") td:eq(6)").html();
    var exantype = "";

    var url = "Ashx/GetTable.ashx?type=exam&examname=" + examname + "&RandID=" + Math.random();
    $.ajax({
        url: url,
        type:"GET",
        dataType: "json",
        success: function (data) {
            if (data.length === 0) {
                alert("This ExamName doesn't exist in database.Please add first!")
            }
            else {
                examtype = data[0].ExamID;

                $("#examsele").selectpicker("val", examtype);
                $("#examsele").selectpicker("refresh");
                $("#rolesele").selectpicker("val", userlevel);
                $("#rolesele").selectpicker("refresh");
                $("#ntid").val(ntid);
                $("#projsele").selectpicker("val", project);
                $("#projsele").selectpicker("refresh");
                $("#departmentsele").selectpicker("val", department);
                $("#departmentsele").selectpicker("refresh");

                $("#Addbtn").attr("class", "btn btn-warning");
                $("#Addbtn").attr("onclick", "Save_User(" + userid + ")");
                $("#Addbtn").html("Save");
            }
        },
        error: function (data) {
            alert(data.responseText);
        },
    });
}
function Save_User(userid) {
    var ntid = $("#ntid").val();
    var role = $("#rolesele").val();
    var project = $("#projsele").val();
    var department = $("#departmentsele").val();
    var examtype = $("#examsele").val();
    var url = encodeURI("Ashx/Update.ashx?type=user&userID=" + userid + "&examtype=" + examtype + "&ntid=" + ntid + "&role=" + role + "&department=" + department + "&project=" + project + "&RandID=" + Math.random());
    $.getJSON(url, function (data) {
        alert(data);
        $("#examsele").selectpicker("val", "");
        $("#examsele").selectpicker("refresh");
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
    });
}
//Edit question
function Edit_Question(object) {
    var rrow = object.parentNode.parentNode.rowIndex;
    var questionid = $("#question-table tr:eq(" + rrow + ") td:eq(1)").html();
    var examname = $("#question-table tr:eq(" + rrow + ") td:eq(2)").html();
    var question = $("#question-table tr:eq(" + rrow + ") td:eq(3)").html();
    var questiontype = $("#question-table tr:eq(" + rrow + ") td:eq(4)").html();
    var s1 = $("#question-table tr:eq(" + rrow + ") td:eq(5)").html();
    var s2 = $("#question-table tr:eq(" + rrow + ") td:eq(6)").html();
    var s3 = $("#question-table tr:eq(" + rrow + ") td:eq(7)").html();
    var s4 = $("#question-table tr:eq(" + rrow + ") td:eq(8)").html();
    var answer = $("#question-table tr:eq(" + rrow + ") td:eq(9)").html().split(",");
    var url = "Ashx/GetTable.ashx?type=exam&examname=" + examname + "&RandID=" + Math.random();
    $.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        success: function (data) {
            if (data.length === 0) {
                alert("This ExamName doesn't exist in database.Please add first!")
            }
            else {
                examtype = data[0].ExamID;

                $("#examsele").selectpicker("val", examtype);
                $("#examsele").selectpicker("refresh");
                $("#questiontypesele").selectpicker("val", questiontype);
                $("#questiontypesele").selectpicker("refresh");
                $("#question").val(question);
                $("#s1").val(s1);
                $("#s2").val(s2);
                $("#s3").val(s3);
                $("#s4").val(s4);
                $("#answer").selectpicker("val", answer);
                $("#answer").selectpicker("refresh");

                $("#Addbtn").attr("class", "btn btn-warning");
                $("#Addbtn").attr("onclick", "Save_Question(" + questionid + ")");
                $("#Addbtn").html("Save");
            }
        },
        error: function (data) {
            alert(data.responseText);
        },
    });
}
function Save_Question(questionid) {
    var examtype = $("#examsele").val();
    var questiontype = $("#questiontypesele").val();
    var question = $("#question").val();
    var s1 = $("#s1").val();
    var s2 = $("#s2").val();
    var s3 = $("#s3").val();
    var s4 = $("#s4").val();
    var answer = $("#answer").val();
    var url = encodeURI("Ashx/Update.ashx?type=question&questionID=" + questionid + "&examtype=" + examtype + "&question=" + question + "&questiontype=" + questiontype + "&s1=" + s1 + "&s2=" + s2 + "&answer=" + answer + "&s3=" + s3 + "&s4=" + s4 + "&RandID=" + Math.random());
    $.getJSON(url, function (data) {
        alert(data);
    });
}

//Search
function Search_User() {
    var ntid = $("#ntid").val();
    var project = $("#projsele").val();
    var department = $("#departmentsele").val();
    var examtype = $("#examsele").val();
    var url = encodeURI("Ashx/GetTable.ashx?type=user&ntid=" + ntid + "&project=" + project + "&department=" + department + "&examtype=" + examtype + "&RandID=" + Math.random());
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<tr><td id=\" tr" + i + "IndexID\">" + data[i].IndexID + "</td>";
                option += "<td id=\" tr" + i + "ID\" hidden>" + data[i].ID + "</td>";
                option += "<td id=\" tr" + i + "ExamName\" >" + data[i].ExamType + "</td>";
                option += "<td id=\" tr" + i + "NTID\" >" + data[i].NTID + "</td>";
                option += "<td id=\" tr" + i + "Department\" >" + data[i].Department + "</td>";
                option += "<td id=\" tr" + i + "Project\" >" + data[i].Project + "</td>";
                option += "<td id=\" tr" + i + "UserLevel\" >" + data[i].UserLevel + "</td>";
                option += "<td><a id=\" tr" + i + "delete\" onclick=\"Show_Delete_User(this)\">Delete</a> | <a id=\" tr" + i + "edit\" onclick=\"Edit_User(this)\">Edit</a></td></tr>";
            }
            $("#user-table-tr").html("");
            $("#user-table-tr").html(option);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}
function Search_Question() {
    var examtype = $("#examsele").val();
    var questiontype = $("#questiontypesele").val();
    var url = encodeURI("Ashx/GetTable.ashx?type=question&examtype=" + examtype + "&questiontype=" + questiontype + "&RandID=" + Math.random());
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<tr><td id=\" tr" + i + "IndexID\">" + data[i].IndexID + "</td>";
                option += "<td id=\" tr" + i + "ID\" hidden>" + data[i].ID + "</td>";
                option += "<td id=\" tr" + i + "ExamName\" >" + data[i].ExamType + "</td>";
                option += "<td id=\" tr" + i + "Question\" >" + data[i].Question + "</td>";
                option += "<td id=\" tr" + i + "QuestionType\" >" + data[i].QuestionType + "</td>";
                option += "<td id=\" tr" + i + "S1\" >" + data[i].SelectA + "</td>";
                option += "<td id=\" tr" + i + "S2\" >" + data[i].SelectB + "</td>";
                option += "<td id=\" tr" + i + "S3\" >" + data[i].SelectC + "</td>";
                option += "<td id=\" tr" + i + "S4\" >" + data[i].SelectD + "</td>";
                option += "<td id=\" tr" + i + "Answer\" >" + data[i].Answer + "</td>";
                option += "<td><a id=\" tr" + i + "delete\" onclick=\"Show_Delete_Question(this)\">Delete</a> | <a id=\" tr" + i + "edit\" onclick=\"Edit_Question(this)\">Edit</a></td></tr>";
            }
            $("#question-table-tr").html("");
            $("#question-table-tr").html(option);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

//Upload  请见下回分晓


//QuestionType change  不生效
function change_type() {
    var type = $("#questiontypesele").val();
    if (type[0] === "Single") {
        $("#answer").attr("data-max-options", "1");
    }
    else {
        $("#answer").removeAttr("data-max-options", "1");
    }
    $("#answer").selectpicker("refresh");
};