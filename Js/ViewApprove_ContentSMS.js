
$(window).on('load', function () {
    $("#btn_ext").css("display", "show")
    $("#Form2").css("border", "none");

    debugger;
    let params = (new URL(document.location)).searchParams;
    getLoadData();
});

function getLoadData() {
    debugger;
    let params = (new URL(document.location)).searchParams;
    let seqID = params.get("seqId");
    //alert(seqID);
    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: "ViewApprove_ContentSMS.aspx/get_ReportDtl",
        data: "{val: '" + seqID + "'}",
        dataType: "json",
        success: function (Result) {
            debugger;
            $('#txt_CreteDate').val(Result.d.tradt)
            $('#txt_code').val(Result.d.empcode);
            $('#txt_name').val(Result.d.empname);
            $('#txt_dept').val(Result.d.empdep);
            $('#txt_type_length').val(Result.d.createcharlen)
            // $('#txtRemarks').val(Result.d.textcontent)
            $('#txtRemarks').html(Result.d.textcontent)

            $('#txtUpdteDate').val(Result.d.updatetradt)
            $('#txtUpdt_code').val(Result.d.updatedempcode)
            $('#txtUpdt_name').val(Result.d.updatedempname)
            $('#txtUpdt_dept').val(Result.d.updatedempdep)

            $('#txtSMS_contentRMK').html(Result.d.updatedempRmk)

            $('#txt_UpdtLength').val(Result.d.updatecharlen)
            // $('#txtUpdtRemarks').val(Result.d.updatetextcontent)
            $('#txtUpdtRemarks').html(Result.d.updatetextcontent)
        }
    });
}



function ExportPDF() {

    $("#btn_ext").css("display", "none");
    $("#Form2").css("border" ,"2px solid");
    debugger;

    if (typeof jsPDF === 'undefined') {
        console.error('jsPDF library not yet loaded ...!');
        return;
    }

    var doc = new jsPDF('a4');
    var element = document.querySelector('#CanVas');
    // var width = doc.internal.pageSize.getWidth();
    // var height = doc.internal.pageSize.getHeight()
  
    html2canvas(element).then(function (canvas) {
        
        var imgData = canvas.toDataURL('image/png');
        doc.addImage(imgData, 'PNG', 15, 15, 170, 0);

        doc.save('DocSMSReport.png');
        window.open('ViewReportSMSVetting.aspx', '_self');
    });
}