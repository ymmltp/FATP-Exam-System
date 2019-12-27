var examinfo;
var qlist;
var currentQuestionIndex;
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
            if (data.ExamID != 0) {
                examinfo = data;
                var singlecount = data.SingleCount;
                var multiplecount = data.MultipleCount;
                for (var i = 0; i < parseInt(singlecount) + parseInt(multiplecount); i++) {
                    questionlist += '<li class="col-lg-3 my-col"><button class="question-list-item undo" data="' + (i + 1).toString() + '" type="button" onclick="Question_Select(this)">' + (i + 1).toString() + '</button></li>';
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
    })
}

function Get_Question() {
    var url = "Ashx/Exam.ashx?type=getquestioninfo&RandID=" + Math.random();
    $.ajax({
        type: "GET",
        url: url,
        dataType: "json",
        async: false,
        success: function (data) {
            if (data.ExamID != 0) {
                qlist = data;
            }
        },
        error: function (data) {
            alert(data.responseText);
        }
    })
}

function Question_Select(object) {
    Save_Answer(currentQuestionIndex);
    var index = object.getAttribute("data");
    currentQuestionIndex = index;
    currentQuestion = qlist[index - 1];
    object.setAttribute("class", "question-list-item done")
    var qc = index + '、' + currentQuestion.Question;
    var qt = currentQuestion.QuestionType;
    var sl = "";
    if (qt === "Single") {
        if (currentQuestion.S1.length != 0) {
            sl += '<li class="select-list-item"><input type="radio" id="s1" value="A" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('A') >= 0) {
                    sl += 'checked=true ';
                }
            } 
            sl += '/> <label for="s1">' + currentQuestion.S1 + '</label></li>';
        }
        if (currentQuestion.S2.length != 0) {
            sl += '<li class="select-list-item"><input type="radio" id="s2" value="B" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('B') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += '/> <label for="s2">' + currentQuestion.S2 + '</label></li>';
        }           
        if (currentQuestion.S3.length != 0) {
            sl += '<li class="select-list-item"><input type="radio" id="s3" value="C" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('C') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += '/> <label for="s3">' + currentQuestion.S3 + '</label></li>';
        }
        if (currentQuestion.S4.length != 0) {
            sl += '<li class="select-list-item"><input type="radio" id="s4" value="D" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('D') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += '/> <label for="s4">' + currentQuestion.S4 + '</label></li> ';
        }
    }
    else if (qt === "Multiple") {
        if (currentQuestion.S1.length != 0) {
            sl += '<li class="select-list-item"><input type="checkbox" id="s1" value="A" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('A') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += '/> <label for="s1">' + currentQuestion.S1 + '</label ></li > ';
        }         
        if (currentQuestion.S2.length != 0) {
            sl += '<li class="select-list-item"><input type="checkbox" id="s2" value="B" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('B') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl+='/> <label for="s2">' + currentQuestion.S2 + '</label ></li> ';
        }
        if (currentQuestion.S3.length != 0) {
            sl += '<li class="select-list-item"><input type="checkbox" id="s3" value="C" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('C') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += '/> <label for="s3">' + currentQuestion.S3 + '</label ></li> ';
        }
        if (currentQuestion.S4.length != 0) {
            sl += '<li class="select-list-item"><input type="checkbox" id="s4" value="D" name="Q' + index + '"';
            if (currentQuestion.UserAnswer) {
                if (currentQuestion.UserAnswer.indexOf('D') >= 0) {
                    sl += 'checked=true ';
                }
            }
            sl += '/> <label for="s4">' + currentQuestion.S4 + '</label ></li > ';
        }
    }
    $("#select-list").html("");
    $("#select-list").html(sl);
    $("#question-content").html("");
    $("#question-content").html('<p>' + qc + '</p>');
    //$("#question-type").html("");
    //$("#question-type").html('<b>' + qt + '</b>');
}

//保存上一个答案
function Save_Answer(currentindex) {
    if (currentQuestion) {
        var Gbox = document.getElementsByName("Q" + currentindex);
        var answer = new Array();
        for (var i = 0; i < Gbox.length; i++) {
            if(Gbox[i].checked===true)
                answer.push(Gbox[i].value);
        }
        currentQuestion.UserAnswer = answer;
    }
}

function Change_Answer() {

}

function Submit_Answer() {

}

function Show_Final_Result() {

}

//检测是否所以的题都回答过了
function Check_Is_All_Done() {
    //var ele = document.getElementById("question-list");
    //var questionlist = ele.childNodes("ul");
    //for () {

    //}
}

function Start_Exam() {
    $("#btn-last").attr("style", "display:block");
    $("#btn-next").html("»»»");
    $("#btn-next").attr("onclick", "Next_Question()");
}

function Last_Question() {

}

function Next_Question() {

}