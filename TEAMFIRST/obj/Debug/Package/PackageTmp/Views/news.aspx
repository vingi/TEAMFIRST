<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="TEAMFIRST.Views.news" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Assets/Css/news.css?V=1.0" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="news_wrapper">
        <!--
        <div id="news_content">
            <div id="n_img">
                <div id="n_img01"></div>
                <div id="n_img02"></div>
                <div id="n_img03"></div>
            </div>
            <div id="n_tip">旺來春秋中秋禮盒  預購中</div>
            <div id="n_icon">
                <div id="n_icon1"><a href="#" onclick="javascript:showNews(2);"></a></div>
                <div id="n_icon2"><a href="#" onclick="javascript:showNews(1);"></a></div>
            </div>
        </div>
        -->
        <div id="n_content">
            <div id="b_blank"><%=content %></div>
            <div id="b_icon">
                <div id="n_icon3"><%=leftUrl %></div>
                <div id="n_icon4"><%=rightUrl %></div>
            </div>
        </div>
    </div>
    
    <script type="text/javascript">
        function showNews(item) {
            if (item == 1) {
                document.getElementById("news_content").style.display = "block";
                document.getElementById("n_content").style.display = "none";
            } else {
                document.getElementById("news_content").style.display = "none";
                document.getElementById("n_content").style.display = "block";
            }
        }
    </script>
</asp:Content>
