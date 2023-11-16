
$(window).on('load', function () {
    document.getElementById('txtSMS_length').value = 0;
    getData();
});

function getData() {
    debugger;
    $.ajax({
        type: "post",
        contentType: "application/json; charset=utf-8",
        url: "Check_ContentSMS.aspx/get_dtl",
        data: "{typ:'',val:''}",
        dataType: "json",
        success: function (Result) {
            debugger;
                $('#txt_code').val(Result.d.empcode);
                $('#txt_name').val(Result.d.empname);
                $('#txt_dept').val(Result.d.empdep);
                $("[id*=hdDeptId]").val(Result.d.empdepID);            
        }
    });

}

function getCharecterLength() {
   
    let len = $('#txtSMS_content').val().trim().length;
    document.getElementById('txtSMS_length').value = len 
}
function exitclick() {
    window.location = "../Index/Index.aspx"
}

function Submitclick() {
    let empName = $('#txt_name').val();
    let empCode = $("#txt_code").val();
    let empMob = $("#txt_mob").val();
    let empDep = $("[id*=hdDeptId]").val();
    let textSMS_content = $("#txtSMS_content").val().trim();
    let typedSMSLength = $("#txtSMS_length").val();
    let numberRegex = /^\d+$/;
    debugger;

    let data = empCode + '~' + empMob + '~' + typedSMSLength + '~' + empDep;

    //console.log(data);
    if (numberRegex.test(empMob) && textSMS_content) {
        if ((empMob.length == 10) && (textSMS_content.length > 0)) {
            console.log('Mobile number/Text field is currect  ....!✌')
            
        } else {
            alert('Number / Text field is not complete');
            return false;
        }
    } else {
        alert('Please Check your mobile number/Text field');
        return false;
    }

    $.ajax({
       
        type: "post",
        contentType: "application/json;charset=utf-8",
        url: "Check_ContentSMS.aspx/AddCreateSMSTOTable",
        data: "{val: '" + data + "',val1:'" + textSMS_content +"'}",
        dataType: "json",
        success: function (Result) {
            debugger;
            Result = Result.d;
            if (Result == 111) {

                alert("INSERTED SUCCESSFULLY");
            }
            else {

                alert("SORRY SOMETHING WENT WRONG");

            }
         window.open('Check_ContentSMS.aspx', '_self');
        }
    });
}
    
          
    
    