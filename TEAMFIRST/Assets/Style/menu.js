/* 上方菜单 */
function switchTab(tab){
	var tabid=($(tab).attr("rel"));
	$("#TabPage1 > li").removeClass();
	$("#TabPage1 > #Tab"+tabid).addClass("Selected");
	$("#cnt > div").css("display","none");
	$("#dTab"+tabid).css("display","block");
}
/* 左侧菜单 */
function border_left(tabpage,left_tabid){
	$("#"+tabpage + "> li").removeClass();
	$("#"+left_tabid).addClass("Selected");
	$("#left_menu_cnt > ul").css("display","none");
	$("#left_menu_cnt > #d"+left_tabid).css("display","block");
}
/* 左侧菜单active */
function dleft_tab_active(tab){
	$("#left_menu_cnt a").removeClass();
	$(tab).addClass("Selected");
}
function go_cmdurl(tab){
	var rel=$(tab).attr("rel");
	var a=$("#TabPage1 > #Tab"+rel);
	if (a.length==0){
		$("#TabPage1").append($("#Tab1").clone().attr("id","Tab"+rel));
		$("#Tab"+rel).html($(tab).html());
		$("#Tab"+rel).attr("title",$(tab).html());
		$("#Tab"+rel).attr("rel",rel);
		$("#Tab"+rel).append("<a href='javascript:;' onclick='delTab(this);'>X</a>");
		$("#cnt").append($("#dTab1").clone().attr("id","dTab"+rel));
		$("#dTab"+rel).html("");
		var iframe = document.createElement('iframe');
		iframe.src = tab.href;
		iframe.setAttribute("height", document.body.scrollHeight-80);
		//alert(iframe.getAttribute("height"));
		//$("#dTab" + rel).attr("height", document.body.scrollHeight);
		$("#dTab"+rel).append(iframe);
	}
	switchTab(tab);
	dleft_tab_active(tab);
	return false;
}
function delTab(tab)
{
	var s=($("#"+$(tab).parent().parent().attr("id") + " > li"));
	for (i=s.length-1;i>0;i--){
		if(s[i].id==$(tab).parent().attr("id")){
			var tabid=$(s[i-1]).attr("rel");
			i=0;
		}
	}
	$(tab).parent().attr("rel",tabid);
	$("#cnt > #d"+$(tab).parent().attr("id")).remove();
	$(tab).parent().remove();
}
