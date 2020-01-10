var examinfo;
var qlist;
var currentQuestionIndex = 0;
var currentQuestionOption;
var currentQuestion;
var finalscore = 0;

function Get_ExamInfo() {
    var url = "Ashx/Exam.ashx?type=getexaminfo&RandID=" + Math.random();
    var questionlist = "";
    var questioncontent = "";
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.ExamID !== 0) {
                examinfo = data;
                var singlecount = data.SingleCount;
                var multiplecount = data.MultipleCount;
                for (var i = 0; i < parseInt(singlecount) + parseInt(multiplecount); i++) {
                    questionlist += '<li class="col-lg-3 my-col"><button class="question-list-item undo" data="' + (i + 1).toString() + '" type="button" id="Q' + (i + 1).toString() + '" onclick="Question_Select(this)">' + (i + 1).toString() + '</button></li>';
                }
                questioncontent += '<p>This exam have ' + data.SingleCount + ' single questions and ' + data.MultipleCount + ' multiple questions.</p>' +
                    '<p>Total score:<span style="color:green;font-size:16px;">' + data.TotalScore + '</span></p>' +
                    '<p>Pass Score:<span style="color:green;font-size:16px;">' + data.PassScore + '</span></p>' +
                    '<p>Please pay attention to question type.</p>' +
                    '<p>Now Click Start Button.</p>';
                $("#question-list").html("");
                $("#question-content").html("");
                $("#question-list").html(questionlist);
                $("#question-content").html(questioncontent);
                $("#exam-info").html("");
                $("#exam-info").html('<b>Exam Name: ' + data.ExamName + '</b>');
                Get_Question();
            }
            else {
                alert("Please select an exam...")
            }
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}
function Get_Question() {
    var url = "Ashx/Exam.ashx?type=getquestioninfo&RandID=" + Math.random();
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.ExamID !== 0) {
                qlist = data;
            }
        },
        error: function (data) {
            alert(data.responseText);
        }
    })
}

function Question_Select(object) {
    if (object) {
        Save_Answer(currentQuestionOption, currentQuestionIndex);
        var index = object.getAttribute("data");
        currentQuestionIndex = index;
        currentQuestionOption = object;
        currentQuestion = qlist[index - 1];
        var qc = index + '、' + currentQuestion.Question;
        var qt = currentQuestion.QuestionType;
        var sl = "";
        if (qt === "Single") {
            if (currentQuestion.S1.length !== 0) {
                sl += '<li class="select-list-item row"><input type="radio" id="s1" value="A" name="Q' + index + '"';
                if (currentQuestion.UserAnswer) {
                    if (currentQuestion.UserAnswer.indexOf('A') >= 0) {
                        sl += 'checked=true ';
                    }
                }
                sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s1" class="col-xs-11">' + currentQuestion.S1 + '</label></li>';
            }
            if (currentQuestion.S2.length !== 0) {
                sl += '<li class="select-list-item row"><input type="radio" id="s2" value="B" name="Q' + index + '"';
                if (currentQuestion.UserAnswer) {
                    if (currentQuestion.UserAnswer.indexOf('B') >= 0) {
                        sl += 'checked=true ';
                    }
                }
                sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s2" class="col-xs-11">' + currentQuestion.S2 + '</label></li>';
            }
            if (currentQuestion.S3.length !== 0) {
                sl += '<li class="select-list-item row"><input type="radio" id="s3" value="C" name="Q' + index + '"';
                if (currentQuestion.UserAnswer) {
                    if (currentQuestion.UserAnswer.indexOf('C') >= 0) {
                        sl += 'checked=true ';
                    }
                }
                sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s3" class="col-xs-11">' + currentQuestion.S3 + '</label></li>';
            }
            if (currentQuestion.S4.length !== 0) {
                sl += '<li class="select-list-item row"><input type="radio" id="s4" value="D" name="Q' + index + '"';
                if (currentQuestion.UserAnswer) {
                    if (currentQuestion.UserAnswer.indexOf('D') >= 0) {
                        sl += 'checked=true ';
                    }
                }
                sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s4" class="col-xs-11">' + currentQuestion.S4 + '</label></li> ';
            }
        }
        else if (qt === "Multiple") {
            if (currentQuestion.S1.length !== 0) {
                sl += '<li class="select-list-item row"><input type="checkbox" id="s1" value="A" name="Q' + index + '"';
                if (currentQuestion.UserAnswer) {
                    if (currentQuestion.UserAnswer.indexOf('A') >= 0) {
                        sl += 'checked=true ';
                    }
                }
                sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s1" class="col-xs-11">' + currentQuestion.S1 + '</label ></li > ';
            }
            if (currentQuestion.S2.length !== 0) {
                sl += '<li class="select-list-item row"><input type="checkbox" id="s2" value="B" name="Q' + index + '"';
                if (currentQuestion.UserAnswer) {
                    if (currentQuestion.UserAnswer.indexOf('B') >= 0) {
                        sl += 'checked=true ';
                    }
                }
                sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s2" class="col-xs-11">' + currentQuestion.S2 + '</label ></li> ';
            }
            if (currentQuestion.S3.length !== 0) {
                sl += '<li class="select-list-item row"><input type="checkbox" id="s3" value="C" name="Q' + index + '"';
                if (currentQuestion.UserAnswer) {
                    if (currentQuestion.UserAnswer.indexOf('C') >= 0) {
                        sl += 'checked=true ';
                    }
                }
                sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s3" class="col-xs-11">' + currentQuestion.S3 + '</label ></li> ';
            }
            if (currentQuestion.S4.length !== 0) {
                sl += '<li class="select-list-item row"><input type="checkbox" id="s4" value="D" name="Q' + index + '"';
                if (currentQuestion.UserAnswer) {
                    if (currentQuestion.UserAnswer.indexOf('D') >= 0) {
                        sl += 'checked=true ';
                    }
                }
                sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s4" class="col-xs-11">' + currentQuestion.S4 + '</label ></li > ';
            }
        }
        $("#select-list").html("");
        $("#select-list").html(sl);
        $("#question-content").html("");
        $("#question-content").html('<p>' + qc + '</p>');
        Is_Last_Question(currentQuestionIndex);
    }
    else {
        alert("Question Index error...")
    }
}
//保存当前问题的答案
function Save_Answer(object,currentindex) {
    if (currentQuestion) {
        var flag = false;  //有无被选
        var Gbox = document.getElementsByName("Q" + currentindex);
        var answer = new Array();
        for (var i = 0; i < Gbox.length; i++) {
            if (Gbox[i].checked === true) {
                flag = true;
                answer.push(Gbox[i].value);
            }
        }
        if (flag === true) {
            object.setAttribute("class", "question-list-item done")
        }
        else {
            object.setAttribute("class", "question-list-item undo")
        }
        currentQuestion.UserAnswer = answer;
    }
}

$("#btn-start").click(function () {
    $("#btn-last").attr("style", "display:block;background-color:#008651");
    $("#btn-next").attr("style", "display:block;background-color:#008651");
    $("#question-list").attr("style", "display:block");
    $("#btn-start").attr("style", "display:none");
    var obj = document.getElementById("Q1");
    Question_Select(obj);
});
$("#btn-last").click(function () {
    var obj = document.getElementById("Q" + (parseInt(currentQuestionIndex) - 1).toString());
    Question_Select(obj);
});
$("#btn-next").click(function () {
    var obj = document.getElementById("Q" + (parseInt(currentQuestionIndex) + 1).toString());
    Question_Select(obj);
});
$("#btn-submit").click(function () {
    Save_Answer(currentQuestionOption,currentQuestionIndex);
    if (Is_All_Done()) {
        Submit_Answer();
    }
    else {
        $("#SubmitModal").modal("show");
    }
});
$("#SureBut").click(function () {
    try {
        $("#SubmitModal").modal("hide");
        Calculate_Score();
        Submit_Answer();
    } catch (e) {
        alert(e);
    }
})

//计算得分
function Calculate_Score() {
    var singlescore = examinfo.SingleScore;
    var multiplescore = examinfo.MultipleScore;
    for (var a in qlist) {
        if (JSON.stringify(qlist[a].Answer) === JSON.stringify(qlist[a].UserAnswer)) {
            qlist[a].FinalResult = true;
            if (qlist[a].QuestionType === "Single") {
                finalscore += parseInt(singlescore);
            } else if (qlist[a].QuestionType === "Multiple") {
                finalscore += parseInt(multiplescore);
            }
        }
        else {
            qlist[a].FinalResult = false;
        }
    }
}
//提交答案(只提交分数)
function Submit_Answer() {
    var questionlist = "";
    var questioncontent = "";
    if (finalscore >= examinfo.PassScore) {
        questioncontent += '<p style="color:green;font-size:20px;">Congratuation!</p>';
    }
    else {
        questioncontent += '<p>Sorry,the PassScore is <span style="color:green;">' + examinfo.PassScore + '</span>, you got <span style="color:red;">' + finalscore + '</span></p>';
        questioncontent += '<p>You can check your answer.</p>';
    }
    for (var i = 0; i < qlist.length; i++) {
        if (qlist[i].FinalResult === true) {
            questionlist += '<li class="col-lg-3 my-col"><button class="question-list-item done" data="' + (i + 1).toString() + '" type="button" id="Q' + (i + 1).toString() + '" onclick="Check_Answer(this)">' + (i + 1).toString() + '</button></li>';
        }
        else {
            questionlist += '<li class="col-lg-3 my-col"><button class="question-list-item do-error" data="' + (i + 1).toString() + '" type="button" id="Q' + (i + 1).toString() + '" onclick="Check_Answer(this)">' + (i + 1).toString() + '</button></li>';
        }
    }

    $.ajax({
        url: "Ashx/Update.ashx",
        type: "post",
        contentType: "application/x-www-form-urlencoded;charset=utf-8",
        data: {
            type:"score",
            score:finalscore,
        },
        dataType: "json",
        success: function (data) {
            $("#question-list").html("");
            $("#question-content").html("");
            $("#select-list").html("");
            $("#question-list").html(questionlist);
            $("#question-content").html(questioncontent);
            $("#exam-score").html("<b>FinalScore: " + finalscore + "</b>");
            $(".exam-function").attr("style", "display:none");
        },
        error: function (data) { alert(data.responseText); },
    });
}

//检查结果
function Check_Answer(object) {
    var index = object.getAttribute("data");
    currentQuestionIndex = index;
    currentQuestion = qlist[index - 1];
    var answertips = "Correct answer is "+ currentQuestion.Answer;
    var qc = index + '、' + currentQuestion.Question;
    var qt = currentQuestion.QuestionType;
    var sl = "";
    if (qt === "Single") {
        if (currentQuestion.S1.length != 0) {
            sl += '<li class="select-list-item row"><input type="radio" id="s1" value="A" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('A') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s1" class="col-xs-11">' + currentQuestion.S1 + '</label></li>';
        }
        if (currentQuestion.S2.length != 0) {
            sl += '<li class="select-list-item row"><input type="radio" id="s2" value="B" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('B') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s2" class="col-xs-11">' + currentQuestion.S2 + '</label></li>';
        }
        if (currentQuestion.S3.length != 0) {
            sl += '<li class="select-list-item row"><input type="radio" id="s3" value="C" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('C') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s3" class="col-xs-11">' + currentQuestion.S3 + '</label></li>';
        }
        if (currentQuestion.S4.length != 0) {
            sl += '<li class="select-list-item row"><input type="radio" id="s4" value="D" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('D') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s4" class="col-xs-11">' + currentQuestion.S4 + '</label></li> ';
        }
        sl += '<li class="select-list-item row" style="font-weight:800;">&nbsp&nbsp&nbspCorrect Answer：<span style="color:blue;font-weight:800;">' + currentQuestion.Answer.toString() + '</span></li>';
    }
    else if (qt === "Multiple") {
        if (currentQuestion.S1.length != 0) {
            sl += '<li class="select-list-item row"><input type="checkbox" id="s1" value="A" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('A') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s1" class="col-xs-11">' + currentQuestion.S1 + '</label ></li > ';
        }
        if (currentQuestion.S2.length != 0) {
            sl += '<li class="select-list-item row"><input type="checkbox" id="s2" value="B" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('B') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s2" class="col-xs-11">' + currentQuestion.S2 + '</label ></li> ';
        }
        if (currentQuestion.S3.length != 0) {
            sl += '<li class="select-list-item row"><input type="checkbox" id="s3" value="C" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('C') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s3" class="col-xs-11">' + currentQuestion.S3 + '</label ></li> ';
        }
        if (currentQuestion.S4.length != 0) {
            sl += '<li class="select-list-item row"><input type="checkbox" id="s4" value="D" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('D') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += ' style="margin-left:-1em; margin-right:-2em;" class="col-xs-1"/> <label for="s4" class="col-xs-11">' + currentQuestion.S4 + '</label ></li > ';
        }
        sl += '<li class="select-list-item row" style="font-weight:800;">&nbsp&nbsp&nbspCorrect Answer：<span style="color:blue;font-weight:800;">' + currentQuestion.Answer.toString() + '</span></li>';
    }
    $("#select-list").html("");
    $("#select-list").html(sl);
    $("#question-content").html("");
    $("#question-content").html('<p>' + qc + '</p>');
}

//检测是否所以的题都回答过了  问题都答过才能交卷,不然要提示
function Is_All_Done() {
    var flag = true;   //是否全部答过了
    $("#question-list").find("li button").each(function () {
        if (this.classList.contains("undo")) {
            flag = false;
            return flag;
        }
    });
    return flag;
}
//最后一道题显示交卷按钮
function Is_Last_Question(index) {
    if (parseInt(index) === parseInt(qlist.length)) {
        $("#btn-submit").attr("style", "display:block;");
    }
    else {
        $("#btn-submit").attr("style", "display:none;");
    }
}
