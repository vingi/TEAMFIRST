<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagePwd.aspx.cs" Inherits="TEAMFIRST.Views.admin.ManagePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-size:12px;
            color:#42414A;
        }
        
        .border_all
        {
            border:1px solid #2981be;
            background-color:#99ccff;
        }
        .border_trb
        {
            border-top:1px solid #2981be;
            border-right:1px solid #2981be;
            border-bottom:1px solid #2981be;
        }
        .border_lbr
        {
            border-left:1px solid #2981be;
            border-bottom:1px solid #2981be;
            border-right:1px solid #2981be;
            background-color:#99ccff;
        }
        .border_br
        {
            border-bottom:1px solid #2981be;
            border-right:1px solid #2981be;
        }
    </style>
	<script src="/Assets/js/jquery-1.4.1.js" type="text/javascript"></script>
	<script src="/Assets/Js/jquery.uniform.js" type="text/javascript"></script>
	<script src="/Assets/Js/jquery.validate.js" type="text/javascript"></script>

</head>
<body>
    <form id="form2" runat="server">
    <div>
                <table border="0" align="center" style="margin-top:10px;" cellpadding="4" cellspacing="0" width="97%">
                    <tr style="height:25px;font-weight:bold;">
                        <td class="border_all" width="100">管理員</td>
                        <td class="border_trb"><%=userName %></td>
                    </tr>
                    <tr style="height:25px;font-weight:bold;">
                        <td class="border_lbr" width="100">舊密碼</td>
                        <td class="border_br"><input type="password" id="OldPwd" name="OldPwd" size="20" /></td>
                    </tr>
                    <tr style="height:25px;font-weight:bold;">
                        <td class="border_lbr" width="100">新密碼</td>
                        <td class="border_br"><input type="password" id="UserPwd" name="UserPwd" size="20" /></td>
                    </tr>
                    <tr style="height:25px;font-weight:bold;">
                        <td class="border_lbr" width="100">確認密碼</td>
                        <td class="border_br"><input type="password" id="AgainPwd" name="AgainPwd" size="20" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="border_lbr" style="text-align:center;height:30px;" ><input type="submit" value="提交" style="height:28px;width:122px;" /></td>
                    </tr>
               </table>
    </div>
    </form>
</body>
<script type="text/javascript">
    $(function () {

        $("form").validate({
            submitHandler: function (form) {

                var fields = $("form").serializeArray();
                $.ajax({
                    type: "POST",
                    url: "/Controls/admin/ManagePwd.ashx",
                    dataType: "text",
                    data: fields,
                    error: function () {
                        alert("error");
                    },
                    success: function (msg) {
                        if (msg == "1") {
                            alert("密碼已成功修改，請記住新密碼！");
                            window.location.href = window.location.href;
                        }
                        else
                            alert("修改失敗");
                    }
                });
            },
            rules: {
                OldPwd: {
                    required: true
                },
                UserPwd: {
                    required: true,
                    minlength: 6,
                    maxlength: 20
                },
                AgainPwd: {
                    required: true,
                    equalTo: "#UserPwd"
                }
            },
            messages: {
                OldPwd: {
                    required: "<font color='red'>請輸入舊密碼</font>"
                },
                UserPwd: {
                    required: "<font color='red'>請輸入新密碼</font>",
                    minlength: "<font color='red'>你的密碼不能少於6個字符</font>",
                    maxlength: "<font color='red'>你的密碼不能多於20個字符</font>"
                },
                AgainPwd: {
                    required: "<font color='red'>請再次輸入密碼</font>",
                    equalTo: "<font color='red'>兩次輸入的密碼不一致</font>"
                }
            }
        });

    });
</script>
</html>
