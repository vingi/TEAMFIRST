<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactusList.aspx.cs" Inherits="TEAMFIRST.Views.admin.contactusList" %>

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
    <div>
                <table border="0" align="center" style="margin-top:10px;" cellpadding="3" cellspacing="0" width="97%">
                    <tr align="center" style="height:25px;font-weight:bold;background-color:#99ccff;">
                        <td class="border_all">姓名</td><td class="border_trb">聯絡電話</td>
                        <td class="border_trb">聯絡信箱</td><td class="border_trb">提交時間</td><td class="border_trb">查看內容</td>
                    </tr>
                    <%=content%>
                    <!--
                    <tr style="height:22px;" onmouseover="changecolor(this)" onmouseout="returncolor(this)">
                        <td class="border_lbr">姓名</td><td class="border_br">聯絡電話</td>
                        <td class="border_br">聯絡信箱</td><td class="border_br">提交時間</td>
                        <td class="border_br" style="text-align:center;"><a href="#" onclick="javascript:showContent('row1');">查看</a></td>
                    </tr>
                    <tr style="height:22px;display:none;" id="row1">
                        <td class="border_lbr" colspan="5">聯絡電話</td>
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

            function showContent(rowId) {
                if (document.getElementById(rowId).style.display == "none")
                    document.getElementById(rowId).style.display = "";
                else
                    document.getElementById(rowId).style.display = "none";
            }
        </script>
</body>
</html>
