function Log_in() {
    var ntid = $("#ntid").val();
    var password = $("#password").val();
    var examtype = $("#examsele").val();
    if (ntid === "User001" && password === "123456") {
        if (examtype === "0") {
            $("#errormsg2").attr("style", "color:red;");
        }
        else {
            setCookie("ntid", ntid, 20);
            setCookie("examtype", examtype, 20);
            setCookie("username", ntid, 20);
            setCookie("power", "1", 20);
            window.location.href = "Exam.aspx";
        }
    }
    else {
        var url = "Ashx/Auth.ashx?type=CheckNTIDAuth&ntid=" + ntid + "&password=" + password + "&RandID=" + Math.random();
        $.getJSON(url, function (data) {
            if (data === true) {
                var url = "Ashx/Auth.ashx?type=GetUserInfo&ntid=" + ntid + "&examtype=" + examtype + "&RandID=" + Math.random();
                $.getJSON(url, function (data) {
                    if (data.ExamType === 999999) {
                        $("#errormsg2").attr("style", "color:red;");
                    } else {
                        add_local_cookie(data);
                        if (data.ExamType == "0") {
                            window.location.href = "SetExam.aspx";
                        }
                        else {
                            window.location.href = "Exam.aspx";
                        }
                    }
                });
            }
            else {
                $("#errormsg1").attr("style", "color:red;");
            }
        });
    }
}

function add_local_cookie(data) {
    setCookie("ntid", data.NTID, 20);
    setCookie("examtype", data.ExamType, 20);
    setCookie("username", data.DisplayName, 20);
    setCookie("power", data.UserGroup, 20);
    setCookie("project", data.Project, 20);
    setCookie("department", data.Department, 20);
}