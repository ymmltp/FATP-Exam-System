var examtype;
var ntid;
var username;
var project;
var departmen;
var power;

function get_cookie() {
    examtype = getCookie("examtype");
    ntid = getCookie("ntid");
    username = getCookie("username");
    project = getCookie("project");
    department = getCookie("department");
    power = getCookie("power");
}

function initial() {
    if (power < 3) {
        $("#ntid").attr("value", ntid);
        $("#ntid").attr("disabled", "disabled");
        $("#departmentsele").selectpicker("val", department);
        $("#departmentsele").attr("disabled", "disabled");
        $("#departmentsele").selectpicker("refresh");
        $("#projsele").selectpicker("val", project);
        $("#projsele").attr("disabled", "disabled");
        $("#projsele").selectpicker("refresh");
        Search_Score();
    }
    else if (power < 7) {
        $("#examsele").selectpicker("val", examtype);
        $("#examsele").attr("disabled", "disabled");
        $("#examsele").selectpicker("refresh");
    }
}
   

function Search_Score(){
    var project = $("#projsele").val();
    var examtype = $("#examsele").val();
    var department = $("#departmentsele").val();
    var ntid = $("#ntid").val();
    var url = encodeURI("Ashx/ScoreSearch.ashx?type=examscore&power=" + power + "&examtype=" + examtype + "&project=" + project + "&department=" + department + "&ntid=" + ntid + "&RandID=" + Math.random());
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                if (data[i].IsPass === "N") {
                    option += '<tr style="background-color:#FF6347">';
                }
                else {
                    option += "<tr>";
                }
                option += "<td id=\" tr" + i + "IndexID\">" + data[i].IndexID + "</td>";
                option += "<td id=\" tr" + i + "ExamName\" >" + data[i].ExamName + "</td>";
                option += "<td id=\" tr" + i + "Department\" >" + data[i].Department + "</td>";
                option += "<td id=\" tr" + i + "Project\" >" + data[i].Project + "</td>";
                option += "<td id=\" tr" + i + "NTID\" >" + data[i].NTID + "</td>";
                option += "<td id=\" tr" + i + "Score\" >" + data[i].Score + "</td>";
                option += "<td id=\" tr" + i + "TotalScore\" >" + data[i].TotalScore + "</td>";
                option += "<td id=\" tr" + i + "ExamTime\" >" + data[i].ExamTime + "</td></tr>";
            }
            $("#score-table-tr").html("");
            $("#score-table-tr").html(option);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}