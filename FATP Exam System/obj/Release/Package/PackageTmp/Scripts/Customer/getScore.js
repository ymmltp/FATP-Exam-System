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
    $("#score-table").bootstrapTable('destroy').bootstrapTable({
        url: url,
        type: 'GET',
        cache: false,                       //清除缓存
        dataType: 'json',
        //showColumns: true,
        showExport: function (row, index) { //增加\Helper\html资料\bootstrap-table-excel-export中的js文件，实现表格内容导出功能
            var sUserAgent = navigator.userAgent.toLowerCase();
            var bIsIpad = sUserAgent.match(/ipad/i) == "ipad";
            var bIsIphoneOs = sUserAgent.match(/iphone os/i) == "iphone os";
            var bIsMidp = sUserAgent.match(/midp/i) == "midp";
            var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4";
            var bIsUc = sUserAgent.match(/ucweb/i) == "ucweb";
            var bIsAndroid = sUserAgent.match(/android/i) == "android";
            var bIsCE = sUserAgent.match(/windows ce/i) == "windows ce";
            var bIsWM = sUserAgent.match(/windows mobile/i) == "windows mobile";
            if (bIsIpad || bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM) {
                return false;
            } else {
                return true;
            }
        },
        exportDataType: "basic",            //导出内容的范围'basic', 'all', 'selected'.
        exportTypes: ['csv', 'excel', 'xlsx'], //导出类型
        exportOptions: {
            fileName: 'Exam Report - ' + Date.now().toString(), //文件名称设置
            worksheetName: 'Sheet1',           //表格工作区名称
            tableName: 'ExamReport',
            excelstyles: ['background-color', 'color', 'font-size', 'font-weight'],
        },
        rowStyle: function (row, index) {
            var style = {};
            if (row.IsPass === "N") {
                style = { css: { 'background-color': '#FF6347' } };
            }
            return style;
        },
        columns: [{
                field: 'id',
                title: 'ID',
                formatter: function (value,row, index){
                    return index + 1;
                }
            },{
                field: 'ExamName',
                title: 'Exam Name',
            }, {
                field: 'Department',
                title: 'Department',
            }, {
                field: 'Project',
                title: 'Project',
            }, {
                field: 'UserName',
                title: 'User Name',
            }, {
                field: 'NTID',
                title: 'NTID',
                visible: false,
            },{
                field: 'Score',
                title: 'Score',
            }, {
                field: 'TotalScore',
                title: 'Total Score',
            }, {
                field: 'ExamTime',
                title: 'Exam Time',
            }],
    });
}