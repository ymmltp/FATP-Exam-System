function Get_Personal_Score() {
}

function initial() {
    var url = "Ashx/Auth.ashx?type=UserInfo&RandID=" + Math.random();
    $.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        success: function (data) {
            $("#ntid").html(data.NTID);
            $("#username").html(data.DisplayName);
        },
        error: function (data) {
            alert(data.responseText);
        },
    })
} 

function Search_Score(){
    var project = $("#projsele").val();
    var examtype = $("#examsele").val();
    var department = $("#departmentsele").val();
    var ntid = $("#ntid").val();
    var url = encodeURI("Ashx/ScoreSearch.ashx?type=examscore&examtype=" + examtype + "&project=" + project + "&department=" + department + "&ntid="+ntid+"&RandID=" + Math.random());
    var option = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<tr><td id=\" tr" + i + "IndexID\">" + data[i].IndexID + "</td>";
                option += "<td id=\" tr" + i + "ExamName\" >" + data[i].ExamName + "</td>";
                option += "<td id=\" tr" + i + "Department\" >" + data[i].Department + "</td>";
                option += "<td id=\" tr" + i + "Project\" >" + data[i].Project + "</td>";
                option += "<td id=\" tr" + i + "NTID\" >" + data[i].NTID + "</td>";
                option += "<td id=\" tr" + i + "Score\" >" + data[i].Score + "</td>";
                option += "<td id=\" tr" + i + "ExamTime\" >" + data[i].ExamTime + "</td>";
            }
            $("#score-table-tr").html("");
            $("#score-table-tr").html(option);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}