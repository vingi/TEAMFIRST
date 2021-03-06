﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="TEAMFIRST.Views.admin.AddNews" %>

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
	<script src="/Assets/xheditor/xheditor.js" type="text/javascript"></script>
	<script src="/Assets/Js/jquery.uniform.js" type="text/javascript"></script>
	<script src="/Assets/Js/jquery.validate.js" type="text/javascript"></script>

</head>
<body>
	<form id="form2" runat="server">
	<div>
				<table border="0" align="center" style="margin-top:10px;" cellpadding="4" cellspacing="0" width="97%">
					<tr style="height:25px;font-weight:bold;">
						<td class="border_all" width="100">標題</td>
						<td class="border_trb"><input type="text" id="MsgTitle" name="MsgTitle" size="64" /></td>
					</tr>
					<tr style="font-weight:bold;">
						<td class="border_lbr" width="100">消息內容</td>
						<td class="border_br"><textarea id="elm1" name="elm1" style="width:860px;height:380px;background:url(img/demobg.jpg) no-repeat right bottom fixed"></textarea>
						<br /><span style="color:#ccc;"></span></td>
					</tr>
					<tr>
						<td colspan="2" class="border_lbr" style="text-align:center;height:30px;" ><input type="submit" value="提交" style="height:28px;width:122px;" /></td>
					</tr>
			   </table>
	</div>
	</form>
</body>
<script type="text/javascript">
	$(pageInit);
	var editor;
	function pageInit() {
		var plugins = {
			Code: { c: 'btnCode', t: '插入代码', h: 1, e: function () {
				var _this = this;
				var htmlCode = '<div><select id="xheCodeType"><option value="html">HTML/XML</option><option value="js">Javascript</option><option value="css">CSS</option><option value="php">PHP</option><option value="java">Java</option><option value="py">Python</option><option value="pl">Perl</option><option value="rb">Ruby</option><option value="cs">C#</option><option value="c">C++/C</option><option value="vb">VB/ASP</option><option value="">其它</option></select></div><div><textarea id="xheCodeValue" wrap="soft" spellcheck="false" style="width:300px;height:100px;" /></div><div style="text-align:right;"><input type="button" id="xheSave" value="确定" /></div>'; var jCode = $(htmlCode), jType = $('#xheCodeType', jCode), jValue = $('#xheCodeValue', jCode), jSave = $('#xheSave', jCode);
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
			map: { c: 'btnMap', t: '插入Google地图', e: function () {
				var _this = this;
				_this.saveBookmark();
				_this.showIframeModal('Google 地图', 'demos/googlemap/googlemap.html', function (v) {
					_this.loadBookmark();
					_this.pasteHTML('<img src="' + v + '" />');
				}, 538, 404);
			}
			}
		};
        editor = $('#elm1').xheditor({ tools: 'Blocktag,Fontface,FontSize,Bold,Italic,Underline,Strikethrough,FontColor,BackColor,SelectAll,Removeformat,Align,List,Outdent,Indent,Link,Unlink,Img,Table,Source,Fullscreen',
            upLinkUrl: 'demos/upload.php?immediate=1',
            upImgUrl: '/Assets/uploadify/UploadHandler.ashx?immediate=0',
            upFlashUrl: 'demos/upload.php?immediate=1',
            upMediaUrl: 'demos/upload.php?immediate=1',
            localUrlTest: /^https?:\/\/[^\/]*?(xheditor\.com)\//i,
            remoteImgSaveUrl: 'demos/saveremoteimg.php',
            plugins: plugins, 
            loadCSS: '<style>pre{margin-left:2em;border-left:3px solid #CCC;padding:0 1em;}</style>'
		});
	}
	function submitForm() { $('#form2').submit(); }

	$(function () {

		$("form").validate({
			submitHandler: function (form) {
				//document.getElementById("NewsContent").value = editor.getSource();
				//alert(editor.getSource());
				//alert(document.getElementById("elm1").value);

				var fields = $("form").serializeArray();
				$.ajax({
					type: "POST",
					url: "/Controls/admin/AddNews.ashx",
					dataType: "text",
					data: fields,
					error: function () {
						alert("error");
					},
					success: function (msg) {
						if (msg == "1") {
							alert("提交成功");
							//window.location.href = window.location.href;
							window.location.href = "/Views/admin/NewsList.aspx";
						}
						else
							alert("提交失敗");
					}
				});
			},
			rules: {
				MsgTitle: {
					required: true
				},
				elm1: {
					required: true
				}
			},
			messages: {
				MsgTitle: {
					required: "<font color='red'>請輸入消息標題</font>"
				},
				elm1: {
					required: "<font color='red'>請輸入消息內容</font>"
				}
			}
		});

	});
</script>
</html>
