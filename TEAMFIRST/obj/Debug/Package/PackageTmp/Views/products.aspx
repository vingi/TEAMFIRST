<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="TEAMFIRST.Views.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Assets/Css/products.css?V=1.0" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="prod_wrapper">
        <div id="prod_content">
            <div id="pre_page"><a href="#" id="pre_p"><span></span></a></div>
            <div id="prod_list">
                <div id="prod_tip">產品總覽</div>
                <div id="prod_bar"></div>
                <div id="prod_img">
                    <div id="prod_img1"><a href="#" id="imgbtn1"><span></span></a></div>
                    <div id="prod_img2"><a href="#" id="imgbtn2"><span></span></a></div>
                    <div id="prod_img3"><a href="#" id="imgbtn3"><span></span></a></div>
                </div>
                <div id="prod_btn">
                    <div id="prod_btn1"><a href="#" id="btn1"><span></span></a></div>
                    <div id="prod_btn2"><a href="#" id="btn2"><span></span></a></div>
                    <div id="prod_btn3"><a href="#" id="btn3"><span></span></a></div>
                </div>
            </div>
            <div id="next_page"><a href="#" id="next_p"><span></span></a></div>
        </div>
    </div>
    <script type="text/javascript">
        var pos, str, para, parastr, tempstr1;
        tempstr = "";
        str = window.location.href;
        pos = str.indexOf("?")
        parastr = str.substring(pos + 1);
        //document.write("<br>文件路径：" + str);
        if (pos > 0) {
            //document.write("<br>所有参数：" + parastr);
        }
        else {
            //document.write("<br>无参数");
        }


        var item = 1;
        var thisSide = 1;
        if (parastr.indexOf("=") > 0) {
            para = parastr.split("&");
            for (i = 0; i < para.length; i++) {
                tempstr1 = para[i];
                var param, value;
                pos = tempstr1.indexOf("=");
                param = tempstr1.substring(0, pos);
                value = tempstr1.substring(pos + 1).replace("#",'');
                //document.write("<br>参数" + i + ":" + tempstr1.substring(0, pos));
                //document.write("等于:" + tempstr1.substring(pos + 1));
                if (param == "item") {
                    //document.getElementById(value).style.color = "#ff0000";
                    item = value;
                    break;
                }
            }
        }
        var defaultImage = "url(/Assets/Images/" + item + "-1.jpg)";
        document.getElementById("prod_wrapper").style.backgroundImage = defaultImage;
        var preItem = parseInt(item) - 1;
        var nexItem = parseInt(item) + 1;
        if (preItem == 0) {
            document.getElementById("pre_p").href = '#';
            document.getElementById("pre_page").style.display = "none";
        } else {
            document.getElementById("pre_p").href = '/Views/products.aspx?naviPage=navi3&item=' + preItem;
            document.getElementById("pre_page").style.display = "block";
        }
        if (nexItem == 4) {
            document.getElementById("next_p").href = '#';
            document.getElementById("next_page").style.display = "none";
        } else {
            document.getElementById("next_p").href = '/Views/products.aspx?naviPage=navi3&item=' + nexItem;
            document.getElementById("next_page").style.display = "block";
        }
        for (i = 1; i <= 3; i++) {
            var func = "show(" + item + ", " + i + ")";
            var btnId = "btn" + i;
            var imgId = "imgbtn" + i;
            var prodimgId = "prod_img" + i;
            var colorFunc = "showColor('" + prodimgId + "'," + i + ")";
            var bColorFunc = "bColor('" + prodimgId + "'," + i + ")";
            document.getElementById(btnId).onclick = Function(func);
            document.getElementById(imgId).onclick = Function(func);
            document.getElementById(prodimgId).onmouseover = Function(colorFunc);
            document.getElementById(prodimgId).onmouseout = Function(bColorFunc);
        }
        function showColor(prodimgId, i) {
            document.getElementById(prodimgId).style.backgroundImage = "url(/Assets/Images/sm_1-" + i + ".png)";
        }
        function bColor(prodimgId, i) {
            if(i!=thisSide)
                document.getElementById(prodimgId).style.backgroundImage = "url(/Assets/Images/sm_1-" + i + "_b.png)";
        }
        function show(item, side) {
            thisSide = side;
            var bgImage = "url(/Assets/Images/" + item + "-" + side + ".jpg)";
            document.getElementById("prod_wrapper").style.backgroundImage = bgImage;
            for (i = 1; i <= 3; i++) {
                var prod_btnId = "prod_btn" + i;
                var prod_imgId = "prod_img" + i;
                var prod_btnImage;
                var prod_img;
                if (i == side) {
                    prod_btnImage = "url(/Assets/Images/icon_bt0" + i + ".png)";
                    prod_img = "url(/Assets/Images/sm_1-" + i + ".png)";
                } else {
                    prod_btnImage = "url(/Assets/Images/icon_bt0" + i + "_b.png)";
                    prod_img = "url(/Assets/Images/sm_1-" + i + "_b.png)";
                }
                //alert(prod_btnImage);
                document.getElementById(prod_btnId).style.backgroundImage = prod_btnImage;
                document.getElementById(prod_imgId).style.backgroundImage = prod_img;
            }
        }
    </script>
</asp:Content>
