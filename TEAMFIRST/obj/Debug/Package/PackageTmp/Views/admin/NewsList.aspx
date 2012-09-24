<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="TEAMFIRST.Views.admin.NewsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script src="/Assets/js/jquery-1.4.1.js" type="text/javascript"></script>
	<script src="/Assets/Js/jquery.uniform.js" type="text/javascript"></script>
	<script src="/Assets/Js/jquery.validate.js" type="text/javascript"></script>
    <style type="text/css">
        body
        {
            font-size:12px;
            color:#42414A;
        }
        
        .border_all
        {
            border:1px solid #2981be;
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
        }
        .border_br
        {
            border-bottom:1px solid #2981be;
            border-right:1px solid #2981be;
        }
        .rw_bg
        {
            background-color:#3399cc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <input type="hidden" name="msgid" id="msgid" />
    <input type="hidden" name="state" id="state" />
    <input type="hidden" name="op" id="op" value="deal" />
    <div>
                <table border="0" align="center" style="margin-top:10px;" cellpadding="3" cellspacing="0" width="97%">
                    <tr align="center" style="height:25px;font-weight:bold;background-color:#99ccff;">
                        <td class="border_all">消息標題</td><td class="border_trb">更新時間</td>
                        <td class="border_trb">狀態</td><td class="border_trb">操作</td>
                    </tr>
                    <%=content%>
                    <!--
                    <tr style="height:22px;" onmouseover="changecolor(this)" onmouseout="returncolor(this)">
                        <td class="border_lbr">消息標題</td><td class="border_br">更新時間</td>
                        <td class="border_br">正常</td><td class="border_br"><a href="#" onclick="javascript:dealNews(1,1);">刪除</a>｜
                        <a href="/Views/admin/EditNews.aspx?msgId=1">编辑</a>｜
                        <a href="/Views/news.aspx?naviPage=navi1&msgId=1" target="_blank">瀏覽</a></td>
                    </tr>
                    -->
                </table>
    </div>
    </form>
        <script type="text/javascript">
            function changecolor(obj) {
                obj.bgColor = "#ccccff";
            }

            function returncolor(obj) {
                obj.bgColor = "#FFFFFF";
            }
            function dealNews(msgId, state) {
                document.getElementById("msgid").value = msgId;
                document.getElementById("state").value = state;
                $('#form1').submit();
            }


            $(function () {

                $("form").validate({
                    submitHandler: function (form) {

                        var fields = $("form").serializeArray();
                        $.ajax({
                            type: "POST",
                            url: "/Controls/admin/AddNews.ashx",
                            dataType: "text",
                            data: fields,
                            success: function (data, textStatus) {
                                if (data == "1") {
                                    alert("變更成功");
                                    window.location.reload();
                                } else
                                    alert("變更失敗");
                            },
                            error: function () {
                                alert("變更失敗");
                            }
                        });
                    }
                });

            });
        </script>
</body>
</html>