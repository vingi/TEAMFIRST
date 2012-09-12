<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base.Master" AutoEventWireup="true" CodeBehind="paper.aspx.cs" Inherits="TEAMFIRST.Views.paper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Assets/Css/paper.css?V=1.0" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="news_wrapper">
        <div id="list_content">
            <div id="pre_page"><img width="15" height="59" src="/Assets/Images/pre_page.png" alt="" /></div>
            <div id="news_list">
                    <!--<div class="row"><div class="n_date">2012.08.14</div><div class="n_split"></div><div class="n_title"><a href="/Views/paper_detail.aspx?naviPage=navi5">鳳梨酥揚威江陳會  人手一盒</a></div></div>-->
                    <%=content %>
                    <!--
                    <div class="row"><div class="n_date">2012.08.20</div><div class="n_split"></div><div class="n_title"><a href="#">分享快樂、真實的美味 開始中秋預購</a></div></div>
                    <div class="row"><div class="n_date">2012.08.10</div><div class="n_split"></div><div class="n_title"><a href="#">好心  使蛋糕更好吃  義賣「鳳梨天使蛋糕」 響應”青少年育成計畫”</a></div></div>
                    <div class="row"><div class="n_date">2012.07.20</div><div class="n_split"></div><div class="n_title"><a href="#">新推出「網路購買」方式 推廣期間  「全台免運費」、「滿三仟加送一盒」</a></div></div>
                    <div class="row"><div class="n_date">2012.06.26</div><div class="n_split"></div><div class="n_title"><a href="#">鳳梨農和吉他情歌、山村鄰居和夏威夷呼拉舞 一起共度八卦山上〝微熱的夏夜同樂會〞</a></div></div>
                    -->
                    <div id="n_foot"></div>
            </div>
            <div id="next_page"><img width="15" height="59" src="/Assets/Images/next_page.png" alt="" /></div>
        </div>
    </div>
</asp:Content>
