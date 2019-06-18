
/********************************************
 * Alvin made it!
 * input 的id 尾字符串必须为
 *          _ID _Pwd .....
 *     例子 ： $('input[id$=_ID]').val();
 *
 *  span 的id 尾字符串必须为
 *          _Tip_ID _Tip_Pwd .....
 *      例子 ： $('span[id$=_Tip_ID]').text();
 ********************************************/
//验证ID
function IDValidate() {
    var id = $('input[id$=_ID]').val();
    if (id.length < 6) {
        $('span[id$=_Tip_ID]').text("ID长度小于6个字符");
    }
    else
    {
        $('span[id$=_Tip_ID]').text("");
        $('span[id$=_Tip_ID]').attr('class',"WarningShow")
    }
}
//验证Email
function EmailValidate() {
    var id = $('input[id$=_Email]').val();
    var format = /^(\w)+(\.\w+)*@(\w)+((\.\w+)+)$/;
    if (format.test(id)) {
        $('span[id$=_Tip_Email]').text("");
    } else
    {
        $('span[id$=_Tip_Email]').text("Email输入不正确！");
    }
}

//验证密码
function PwdValidate() {
    var id = $('input[id$=_Pwd]').val();
    var num = /^\d{6,20}$/;
    var let = /^[a-zA-Z]{6,20}$/;
    if (num.test(id) || let.test(id) || id.length < 6) {
        $('span[id$=_Tip_Pwd]').text("请输入6-20位的字母数字或标点符号组合！");
    }
    else
    {
        $('span[id$=_Tip_Pwd]').text("");
    }
}

//验证手机号码
function TelValidate() {
    var id = $('input[id$=_Tel]').val();
    if (id.length != 11) {
        $('span[id$=_Tip_Tel]').text("手机号码必须是11位");
    }
    else {
        $('span[id$=_Tip_Tel]').text("");
    }
}


//验证身份证号码
function IdentifyNumValidate() {
    var id = $('input[id$=_IdentifyNum]').val();
    if (id.length != 18) {
        $('span[id$=_Tip_Pwd]').text("身份证号码位数不足");
    }
    else {
        $('span[id$=_Tip_Pwd]').text("");
    }
}



//外部调用 加入到Ready
function AddReadyValidate() {
    $('input[id$=_ID]').bind('change', IDValidate);
    $('input[id$=_Pwd]').bind('change', PwdValidate);
    $('input[id$=_Email]').bind('change', EmailValidate);
    $('input[id$=_Tel]').bind('change', TelValidate);
    $('input[id$=_IdentifyNum]').bind('change', IdentifyNumValidate);
}

/***
密码验证
***/
function PwdValidate1() {

    if ($('input[id$=_Pwd1]').val() == "") {
    $('span[id$=_Tip_Pwd1]').text("请输入旧密码");
} else {
    $('span[id$=_Tip_Pwd1]').text("");
}
}

function PwdValidate2() {
    var id = $('input[id$=_Pwd2]').val();
    var num = /^\d{6,20}$/;
    var let = /^[a-zA-Z]{6,20}$/;
    if (num.test(id) || let.test(id) || id.length < 6) {
    $('span[id$=_Tip_Pwd2]').text("请输入6-20位的字母数字或标点符号组合！");
} else {
    $('span[id$=_Tip_Pwd2]').text("");
}
}

function PwdValidate3() {
    var id = $('input[id$=_Pwd2]').val();
    var id1 = $('input[id$=_Pwd3]').val();
    if (id != id1) {
    $('span[id$=_Tip_Pwd2]').text("前后密码不一致！");
$('span[id$=_Tip_Pwd3]').text("前后密码不一致！");
    } else {
    $('span[id$=_Tip_Pwd3]').text("");
$('span[id$=_Tip_Pwd2]').text("");
    }
}
//提交时候检查是否ok
function submit_Pwd() {
    if ($('span[id$=_Tip_Pwd]').text() != "" || $('span[id$=_Tip_Pwd2]').text() || $('span[id$=_Tip_Pwd3]').text()) {
        return false;
    } else {
        $('#submitForm').submit();
    }
}
//外部调用 加入到Ready
function AddReadyValidate_ModifyPwd() {
    $('span[id$=_Tip_Pwd1]').text("");
    $('span[id$=_Tip_Pwd2]').text("");
    $('span[id$=_Tip_Pwd3]').text("");
    $('input[id$=_Pwd1]').bind('change', PwdValidate1);
    $('input[id$=_Pwd2]').bind('change', PwdValidate2);
    $('input[id$=_Pwd3]').bind('change', PwdValidate3);
    $('input[id$=submit_Pwd]').bind('click', submit_Pwd);
}

