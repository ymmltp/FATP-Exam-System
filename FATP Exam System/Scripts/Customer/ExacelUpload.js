$("#showmodel").click(function () {
    $("#UploadModal").modal("show");
});

function handleFiles(files) {
    var fileData = files[0]
    $("#filepath").val(fileData.name);
    var reader = new FileReader();
    var strArr = [];
    var wb;
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
        //wb.SheetNames[0]是获取Sheets中第一个Sheet的名字
        //wb.Sheets[Sheet名]获取第一个Sheet的数据
        //var tempArr = XLSX.utils.sheet_to_json(wb.Sheets[wb.SheetNames[0]]);
        //for (var i = 0; i < tempArr.length; i++) {
        //    var tt = tempArr[i];
        //    var ss = {};
        //    ss.filename = tt['文件名称'];
        //    ss.filenum = tt['张数'];
        //    ss.remark = tt['备注'];
        //    ss.editable = false;
        //    strArr.push(ss);
        //    that.form.qdmxVOS.push(ss);
        //}
        //that.dialogVisible = false;
        //that.page = 'view';
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



//function outputWorkbook(workbook) {
//    var sheetNames = workbook.SheetNames; // 工作表名称集合
//    sheetNames.forEach(name => {
//        var worksheet = workbook.Sheets[name]; // 只能通过工作表名称来获取指定工作表
//        for (var key in worksheet) {
//            // v是读取单元格的原始值
//            console.log(key, key[0] === '!' ? worksheet[key] : worksheet[key].v);
//        }
//    });
//}

//function readWorkbook(workbook) {
//    var sheetNames = workbook.SheetNames; // 工作表名称集合
//    var worksheet = workbook.Sheets[sheetNames[0]]; // 这里我们只读取第一张sheet
//    var csv = XLSX.utils.sheet_to_csv(worksheet);
//    document.getElementById('result').innerHTML = csv2table(csv);
//}