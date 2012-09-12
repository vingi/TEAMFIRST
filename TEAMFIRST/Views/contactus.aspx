<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="TEAMFIRST.Views.contactus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Assets/Css/contactus.css?V=1.0" rel="stylesheet" type="text/css" />
	<script src="/Assets/Js/jquery-1.4.1.js" type="text/javascript"></script>
	<script src="/Assets/Js/jquery.uniform.js" type="text/javascript"></script>
	<script src="/Assets/Js/jquery.validate.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="con_wrapper">
        <div id="group" class="clearfix">
            <div class="f16 con_font">聯絡我們</div>
            <ul>
                 <li><img width="296" height="1" src="/Assets/Images/line.png" alt="" /></li>
                 <li>電話：<span>(02)2346-3929</span></li>
                 <li>傳真：<span>(02)2346-4618</span></li>
                 <li>電子郵件：<span>pineapplecake259@gmail.com</span></li>
                 <li>　</li>
                 <li>　</li>
                 <li>　</li>
                 <li><img width="8" height="7" src="/Assets/Images/icon1.png" alt="" />　姓名　　　　<input type="text" id="UserName" name="UserName" size="32" /></li>
                 <li><img width="8" height="7" src="/Assets/Images/icon1.png" alt="" />　連絡電話　　<input type="text" id="Mobile" name="Mobile" size="32" /></li>
                 <li><img width="8" height="7" src="/Assets/Images/icon1.png" alt="" />　聯絡信箱　　<input type="text" id="Email" name="Email" size="32" /></li>
                 <li><img width="8" height="7" src="/Assets/Images/icon1.png" alt="" />　信件內容&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</li>
                 <li><textarea rows="8" id="MsgContent" name="MsgContent" cols="46"></textarea></li>
                 <li><input type="submit" value="" style="background-image:url(/Assets/Images/send.png);height:28px;width:122px;border:0px;cursor:pointer;" /></li>
            </ul>
        </div>
    </div>
        <script type="text/javascript">
            $(function () {

                $("form").validate({
                    submitHandler: function (form) {

                        var fields = $("form").serializeArray();
                        $.ajax({
                            type: "POST",
                            url: "/Controls/ContactUs.ashx",
                            dataType: "text",
                            data: fields,
                            error: function () {
                                alert("error");
                            },
                            success: function (msg) {
                                if (msg == "1") {
                                    alert("發送成功");
                                    window.location.href = window.location.href;
                                }
                                else
                                    alert("發送失敗");
                            }
                        });
                    },
                    rules: {
                        UserName: {
                            required: true
                        },
                        Mobile: {
                            required: true
                        },
                        Email: {
                            required: true,
                            email: true
                        },
                        MsgContent: {
                            required: true
                        }
                    },
                    messages: {
                        UserName: {
                            required: "<font color='red'>請輸入姓名</font>"
                        },
                        Mobile: {
                            required: "<font color='red'>請輸入聯絡電話</font>"
                        },
                        Email: {
                            required: "<font color='red'>請輸入電子信箱</font>",
                            email: "<font color='red'>請輸入正確的Email格式</font>"
                        },
                        MsgContent: {
                            required: "<font color='red'>請輸入信件內容</font>"
                        }
                    }
                });

            });
        </script>
</asp:Content>
