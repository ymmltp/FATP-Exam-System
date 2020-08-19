function Log_in() {
    var ntid = $("#ntid").val();
    var password = $("#password").val();
    var examtype = $("#examsele").val();
    if (ntid === "User001" && password === "123456") {
        if (examtype === "0") {
            $("#errormsg2").attr("style", "color:red;");
        }
        else {
            setCookie("ntid", ntid, 1);
            setCookie("examtype", examtype, 1);
            setCookie("username", ntid, 1);
            setCookie("power", "1", 1);
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
    setCookie("ntid", data.NTID, 1);
    setCookie("examtype", data.ExamType, 1);
    setCookie("username", data.DisplayName, 1);
    setCookie("power", data.UserGroup, 1);
    setCookie("project", data.Project, 1);
    setCookie("department", data.Department, 1);
}