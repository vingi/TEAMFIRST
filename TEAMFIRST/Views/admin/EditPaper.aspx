<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPaper.aspx.cs" Inherits="TEAMFIRST.Views.admin.EditPaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-size: 12px;
            color: #42414A;
        }
        A:visited, A:active, A:link
        {
            font-size: 14px;
            color: #42414A;
            text-decoration: none;
            font-weight: bold;
        }
        A:hover
        {
            font-size: 14px;
            color: #42414A;
            text-decoration: underline;
            font-weight: bold;
        }
        
        .border_all
        {
            border: 1px solid #2981be;
            background-color: #99ccff;
        }
        .border_trb
        {
            border-top: 1px solid #2981be;
            border-right: 1px solid #2981be;
            border-bottom: 1px solid #2981be;
        }
        .border_lbr
        {
            border-left: 1px solid #2981be;
            border-bottom: 1px solid #2981be;
            border-right: 1px solid #2981be;
            background-color: #99ccff;
        }
        .border_br
        {
            border-bottom: 1px solid #2981be;
            border-right: 1px solid #2981be;
        }
        
		.uploadifyButton
		{
			background-color: #505050;
			-webkit-border-radius: 3px;
			-moz-border-radius: 3px;
			border-radius: 3px;
			color: #FFF;
			font: 12px Arial, Helvetica, sans-serif;
			padding: 8px 0;
			text-align: center;
			width: 100%;
		}
		.uploadify:hover .uploadifyButton
		{
			background-color: #808080;
		}
		.uploadifyQueueItem
		{
			background-color: White;
			font: 11px Verdana, Geneva, sans-serif;
			margin-top: 5px;
			width: 160px;
			max-width: 160px;
			padding: 6px;
			border: 1px solid #E0E0E0;
			/* border: 1px solid #DBDBDB; */
			float: left;
			margin-left: 5px;
			-o-transition: opacity .4s ease-in-out;
			-moz-transition: opacity .4s ease-in-out;
			-webkit-transition: opacity .4s ease-in-out;
			-webkit-box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.2);
			-moz-box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.2);
			box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.2);
		}
		.uploadifyImageShow
		{
			margin-top: 10px;
			width: 152px;
			height: 120px;
			line-height: 120px;
			vertical-align:middle; /* 兼容ie */
			text-align:center;
			*display:block; 
		}
		.uploadifyImageShow .ImageShow
		{
			vertical-align: middle;
		}
		.uploadifyLoading
		{
			margin: 52px;
		}
		.uploadifyError
		{
			background-color: #FDE5DD !important;
			border: 2px solid #FBCBBC !important;
		}
		.uploadifyQueueItem .cancel
		{
			float: right;
			cursor: pointer;
		}
		.uploadifyQueue .completed
		{
			background-color: #E5E5E5;
		}
		.uploadifyProgress
		{
			background-color: #E5E5E5;
			margin-top: 10px;
			width: 100%;
		}
		.uploadifyProgressBar
		{
			background-color: #0099FF;
			height: 3px;
			width: 1px;
		}
		.cleanimg
		{
			width: 100px;float: left;
			margin-top: 20px;            
		}
    </style>
    <script src="/Assets/js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="/Assets/xheditor/xheditor.js" type="text/javascript"></script>
    <script src="/Assets/Js/jquery.uniform.js" type="text/javascript"></script>
    <script src="/Assets/Js/jquery.validate.js" type="text/javascript"></script>
    <script src="/Assets/uploadify/jquery.uploadify.js" type="text/javascript"></script>
</head>
<body>
    <form id="form2" runat="server">
    <input type="hidden" name="NewsId" id="NewsId" value="<%=newsId %>" />
    <input type="hidden" name="op" id="op" value="edit" />
    <div>
        <table border="0" align="center" style="margin-top: 10px;" cellpadding="4" cellspacing="0"
            width="97%">
            <tr>
                <td colspan="2" height="30" align="right">
                    <a href="/Views/admin/PaperList.aspx">返 回</a>
                </td>
            </tr>
            <tr style="height: 25px; font-weight: bold;">
                <td class="border_all" width="100">
                    標題
                </td>
                <td class="border_trb">
                    <input type="text" id="NewsTitle" name="NewsTitle" size="64" value="<%=newsTitle %>" />
                </td>
            </tr>
            <tr style="font-weight: bold;">
                <td class="border_lbr" width="100">
                    報道內容
                </td>
                <td class="border_br">
                    <textarea id="elm1" name="elm1" style="width: 860px; height: 350px; background: url(img/demobg.jpg) no-repeat right bottom fixed"><%=newsContent %></textarea>
                    <br />
                    <span style="color: #ccc;"></span>
                    <input type="hidden" id="img" name="img" value="<%=newshidden %>" />
                    <div class="uploadimg">
                        <table id="info_block" cellpadding="0" cellspacing="0" style="width: 750px;">
                            <tr id="trupload" style="">
                                <td class="tr_content">
                                    <div id="divload">
                                        <div id="status-message" style="display: none;">
                                        </div>
                                        <div id="fileQueue">
                                            <%=newsImg %>
                                        </div>
                                        <div style="clear: both;">
                                        </div>
                                        <div style="width: 140px; margin-top: 20px; float: left;">
                                            <input type="file" name="uploadify" id="uploadify" /></div>
                                        <div class="cleanimg">
                                            <div class="uploadify" style="cursor: pointer;" onclick="cleanimg()">
                                                <div class="uploadifyButton">
                                                    <span class="uploadifyButtonText">清除圖片</span></div>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="clear: both">
                    </div>
                </td> </tr>
    <tr>
        <td colspan="2" class="border_lbr" style="text-align: center; height: 30px;">
            <input type="submit" value="提交" style="height: 28px; width: 122px;" />
        </td>
    </tr>
    </table> </div>
    </form>
</body>
<script type="text/javascript">
    $(pageInit);
    var editor;
    function pageInit() {
        var plugins = {
            Code: { c: 'btnCode', t: '插入代碼', h: 1, e: function () {
                var _this = this;
                var htmlCode = '<div><select id="xheCodeType"><option value="html">HTML/XML</option><option value="js">Javascript</option><option value="css">CSS</option><option value="php">PHP</option><option value="java">Java</option><option value="py">Python</option><option value="pl">Perl</option><option value="rb">Ruby</option><option value="cs">C#</option><option value="c">C++/C</option><option value="vb">VB/ASP</option><option value="">其它</option></select></div><div><textarea id="xheCodeValue" wrap="soft" spellcheck="false" style="width:300px;height:100px;" /></div><div style="text-align:right;"><input type="button" id="xheSave" value="確定" /></div>'; var jCode = $(htmlCode), jType = $('#xheCodeType', jCode), jValue = $('#xheCodeValue', jCode), jSave = $('#xheSave', jCode);
                jSave.click(function () {
                    _this.loadBookmark();
                    _this.pasteHTML('<pre class="prettyprint lang-' + jType.val() + '">' + _this.domEncode(jValue.val()) + '</pre>');
                    _this.hidePanel();
                    return false;
                });
                _this.saveBookmark();
                _this.showDialog(jCode);
            }
            },
            map: { c: 'btnMap', t: '插入Google地圖', e: function () {
                var _this = this;
                _this.saveBookmark();
                _this.showIframeModal('Google 地圖', 'demos/googlemap/googlemap.html', function (v) {
                    _this.loadBookmark();
                    _this.pasteHTML('<img src="' + v + '" />');
                }, 538, 404);
            }
            }
        };
        editor = $('#elm1').xheditor({ tools: 'Blocktag,Fontface,FontSize,Bold,Italic,Underline,Strikethrough,FontColor,BackColor,SelectAll,Removeformat,Align,List,Outdent,Indent,Link,Unlink,Table,Source,Fullscreen', localUrlTest: /^https?:\/\/[^\/]*?(xheditor\.com)\//i, remoteImgSaveUrl: 'demos/saveremoteimg.php', plugins: plugins, loadCSS: '<style>pre{margin-left:2em;border-left:3px solid #CCC;padding:0 1em;}</style>'
        });
    }
    function submitForm() { $('#form2').submit(); }

    function cleanimg() {
        $("#img").val("");
        $("#fileQueue").empty();
        $("#status-message").empty();

    }

    $(function () {

        $("form").validate({
            submitHandler: function (form) {

                var fields = $("form").serializeArray();
                $.ajax({
                    type: "POST",
                    url: "/Controls/admin/AddPaper.ashx",
                    dataType: "text",
                    data: fields,
                    error: function () {
                        alert("error");
                    },
                    success: function (msg) {
                        if (msg == "1") {
                            alert("修改成功");
                            //window.location.href = window.location.href;
                            window.location.href = "/Views/admin/PaperList.aspx";
                        }
                        else
                            alert("修改失敗");
                    }
                });
            },
            rules: {
                NewsTitle: {
                    required: true
                },
                elm1: {
                    required: true
                }
            },
            messages: {
                NewsTitle: {
                    required: "<font color='red'>請輸入報道標題</font>"
                },
                elm1: {
                    required: "<font color='red'>請輸入報道內容</font>"
                }
            }
        });


        var iscompled = false;
        var filelimiz = 2048; // 2048K
        $('#uploadify').uploadify({
            'swf': '/Assets/uploadify/uploadify.swf',
            'uploader': '/Assets/uploadify/UploadHandler.ashx',
            'cancelImage': '/Assets/uploadify/close.png',
            'multi': true,
            'auto': true,
            'checkExisting': false,
            'fileTypeExts': '*.jpg;*.gif;*.png;*.bmp;',
            'fileTypeDesc': 'Image Files (.JPG, .GIF, .PNG, .BMP)',
            'queueID': 'fileQueue',
            'queueSizeLimit': 3,
            'uploadLimit': 3,
            'fileSizeLimit': filelimiz,
            'buttonImage': '',
            'buttonText': '瀏覽圖片',
            'removeCompleted': false,
            'onDialogClose': function (queue) {
                $('#status-message').text(queue.filesQueued + ' files have been added to the queue.');
            },
            'onUploadSuccess': function (file, data, response) {
                //if (data.indexOf("http://") == 0) {
                    var thisfileobj = jQuery('#' + file.id);
                    thisfileobj.find(".uploadifyImageShow").html("<img src='" + data + "' alt='' width='152' height='102' class='ImageShow' />");
                    thisfileobj.find(".data,.uploadifyProgress").remove();
                    $("#img").val($("#img").val() + ',' + data);
                //}
                //else
                //    alert(data);
            },
            'onQueueComplete': function (stats) {
                $('#status-message').text(stats.successful_uploads + ' files uploaded, ' + stats.upload_errors + ' errors.');
            }
        });


    });
</script>
</html>
