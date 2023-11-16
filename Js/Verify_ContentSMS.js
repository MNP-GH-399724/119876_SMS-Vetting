
$(window).on('load', function () {

    debugger;
    checkAuth();
});

function checkAuth() {

    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: "Verify_ContentSMS.aspx/checkAuth",

        dataType: "json",
        success: function (Result) {
            debugger;
            if (Result.d == 111) {
                console.info(Result.d, 'success Auth');
                getDropdown();
            } else {
                console.error(Result.d, 'Not Autherised');
               window.open('../Err_Page.aspx', '_self')
            }         
        }
    });

}

function getDropdown() {

    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: "Verify_ContentSMS.aspx/getFillData",
        
        dataType: "json",
        success: function (Result) {
            debugger;
            

            $.each(Result.d, function (key, value) {
                $('#ddlReport').append($("<option></option>").val(value.id).html(value.name));
            });

        }
    });

}

// option on change function
function handleOption() {
    debugger;
    let data =$("#ddlReport").find('option:selected').val();

    console.log(data);
    console.log($('#ddlReport  option:selected').text());
    
    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: "Verify_ContentSMS.aspx/Load_Select_Data",
        data: "{val: '" + data + "'}",
        dataType: "json",
        success: function (Result) {

            debugger;
            console.log('inside responsive load by dropdown')
            if (Result.d) {
                console.log(Result.d);
                //alert('Has resposive drop Result...');
                $('#txt_code').val(Result.d.empcode);
                $('#txt_name').val(Result.d.empname);
                $('#txt_mob').val(Result.d.empmob);
                $('#txtSMS_length').val(Result.d.creted_char_length);
                $('#txtSMS_content').val(Result.d.initialContent);
                $('#txt_dept').val(Result.d.empdep);
                
            } else {
                alert(' Sorry, no dropDown data');
            }
        }
    });

}

function getCharecterLength() {

    let len = $('#txtSMS_content').val().trim().length;
    document.getElementById('txtSMS_lengthNew').value = len;
}

function exitclick() {
    window.location = "../Index/Index.aspx"

}



function approveSubmitclick() {
    debugger;
   
    let empMob = $("#txt_mob").val();
    let textSMS_content = $("#txtSMS_content").val().trim();
    let textSMS_rmk = $("#txtSMS_contentRMK").val().trim();
    let typedSMSLength = $("#txtSMS_lengthNew").val();
    let numberRegex = /^\d+$/;

    let data = $("#ddlReport").find('option:selected').val() + '~' + typedSMSLength + '~' + $("[id*=hdUserId]").val();

    console.log(data);
    if (numberRegex.test(empMob)) {
        if (empMob.length == 10) {
            console.info('PAGE2 Mobile number is currect  ....!✌')
        } else {
            alert('Approver mobile number is not Valid');
            return false;
        }
    } else {
        alert('Please Check your mobile number');
        return false;
    }

    $.ajax({
        type: "post",
        contentType: "application/json;charset=utf-8",
        url: "Verify_ContentSMS.aspx/UpdateSMSTOTable",
        data: "{val: '" + data + "',val1:'" + textSMS_content + '~' + textSMS_rmk + "'}",
        dataType: "json",

        success: function (Result) {
            debugger;
            Result = Result.d;
            if (Result == 111) {
                alert("SUCCESSFULLY UPDATED");
            }
            else {

                alert("INSERTION FAILED");

            }
            window.open('Verify_ContentSMS.aspx', '_self');
        }
    });
}




/////////////////////////////////////////////////////////////////////////////////





