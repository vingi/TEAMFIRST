<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TEAMFIRST.Views.admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script src="/Assets/Js/jquery-1.4.1.js?V=1.4.1" type="text/javascript"></script>
</head>
<body style="background-color: #002779;font-size:12px;margin:0px;">
    <table height="768" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td align="middle">
                <table cellspacing="0" cellpadding="0" width="468" border="0">
                    <tr>
                        <td>
                            <img height="23" src="/Assets/images/admin/login_1.jpg" width="468">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img height="147" src="/Assets/images/admin/login_2.jpg" width="468">
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" width="468" bgcolor="#ffffff" border="0">
                    <tr>
                        <td width="16">
                            <img height="122" src="/Assets/images/admin/login_3.jpg" width="16">
                        </td>
                        <td align="middle">
                            <table cellspacing="0" cellpadding="0" width="230" border="0">
                                <form name="form1" method="post" action="login.aspx" id="form1">
<div>
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwULLTE2MTY2ODcyMjlkZC4Wx7DJwGFE1JwRwsqh+XbDXK1U" />
</div>

                                <tr height="5">
                                    <td width="5">
                                    </td>
                                    <td width="56">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr height="36">
                                    <td>
                                    </td>
                                    <td>
                                        用戶名
                                    </td>
                                    <td>
                                        <input style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
                                            border-bottom: #000000 1px solid" maxlength="30" size="24" id="username" name="username">
                                    </td>
                                </tr>
                                <tr height="36">
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        密 碼
                                    </td>
                                    <td>
                                        <input style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
                                            border-bottom: #000000 1px solid" type="password" maxlength="30" size="24" name="userpwd"
                                            id="userpwd">
                                    </td>
                                </tr>
                                <tr height="5">
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <input type="button" height="18" width="70" style="background-image: url(/Assets/images/admin/bt_login.gif);height: 22px;width: 74px;"
                                            id="submitbtn" name="submitbtn" />
                                    </td>
                                </tr>
                                </form>
                            </table>
                        </td>
                        <td width="16">
                            <img height="122" src="/Assets/images/admin/login_4.jpg" width="16">
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" width="468" border="0">
                    <tr>
                        <td>
                            <img height="16" src="/Assets/images/admin/login_5.jpg" width="468">
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" width="468" border="0">
                    <tr>
                        <td align="right">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        <script type="text/javascript">
            $(function () {
                $("#userpwd").keydown(function (event) {
                    if (event.keyCode == "13") {
                        $("#submitbtn").click();
                    }
                });

                $("#submitbtn").click(function () {
                    var fields = $("form").serializeArray();
                    $.ajax({
                        type: "POST",
                        url: "/Controls/admin/login.ashx",
                        dataType: "text",
                        data: fields,
                        error: function () {
                            alert("error");
                        },
                        success: function (msg) {
                            if (msg == "1")
                                window.location.href = "/Views/admin/index.aspx";
                            else
                                alert("帳戶或密碼不正確!");

                        }
                    });
                });
            });
        </script>
</body>
</html>
