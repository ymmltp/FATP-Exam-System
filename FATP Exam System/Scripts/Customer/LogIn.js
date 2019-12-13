function initialExamType() {
    var url = "Ashx/GetData.ashx?type=selectexam&RandID=" + Math.random();
    var option = "<option value=\"" + 0 + "\">_blank</option>";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                option += "<option value=\"" + data[i].ExamType + "\">" + data[i].ExamName + "</option>";
            }
            $("#sele-exam").html("");
            $("#sele-exam").html(option);
            $("#sele-exam").selectpicker('refresh');
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

$("#logbtn").click(function () {
    var ntid = $("#ntid").val();
    var password = $("#password").val();
    var role = $("#sele-user").val();
    var examtype = $("#sele-exam").val();  
    var url = "Ashx/Auth.ashx?type=GetUserInfo&ntid=" + ntid + "&role=" + role + "&examtype=" + examtype + "&RandID=" + Math.random();

    var p = CheckAuth(ntid, password);
    if (p === true) {
        $.ajax({
            type: "GET",
            url: url,
            dataType: "json",
            success: function (data) {
                sessionStorage.setItem("NTID", data.NTID);
                sessionStorage.setItem("UserName", data.DisplayName);
                sessionStorage.setItem("UserType", data.UserGroup);
                sessionStorage.setItem("ExamType", data.ExamType);
                window.location.href = "Default.aspx";
            },
            error: function (data) {
                alert(data.responseText);
            }
        });
    }
    else {
        alert(p);
        alert("Error NTID or Password...")
    }
}) 


function CheckAuth(ntid,password) {
    var url = "Ashx/Auth.ashx?type=CheckNTIDAuth&ntid=" + ntid + "&password=" + password + "&RandID=" + Math.random();
    var isOk = false;
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        async: false,
        success: function (data) {
            isOk = data;
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
    return isOk;
}