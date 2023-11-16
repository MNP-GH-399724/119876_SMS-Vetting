
$(window).on('load', function () {

    debugger;
    checkAuth();
    //getDropdown();
});

function checkAuth() {

    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: "ViewReportSMSVetting.aspx/checkAuth",

        dataType: "json",
        success: function (Result) {
            debugger;
            if (Result.d == 111) {
                console.info(Result.d, 'success Auth');
                getDropdown();
            } else {
                //alert( 'Not Autherised');
                window.open('../Err_Page.aspx', '_self')
            }
        }
    });

}

function getDropdown() {
    debugger;
    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: "ViewReportSMSVetting.aspx/getOptionLists",

        dataType: "json",
        success: function (Result) {
            
            $.each(Result.d, function (key, value) {
                $('#ddlReport').append($("<option></option>").val(value.id).html(value.name));
            });

        }
    });
}

// option  change Fn
function handleOption() {
    debugger;
    var dep=$("#ddlReport").find('option:selected').val();
    $("[id*=HdnDepId]").val(dep);
}
