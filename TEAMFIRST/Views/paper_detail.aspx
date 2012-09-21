<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base.Master" AutoEventWireup="true" CodeBehind="paper_detail.aspx.cs" Inherits="TEAMFIRST.Views.paper_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Assets/Css/paper_detail.css?V=1.0" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="detail_wrapper">
            <div id="pre_page"><%=prePage %></div>
            <div id="d_content">
                <div id="d_head">
                    <div id="d_head_left"></div>
                    <div id="d_head_right"><%=adddate %></div>
                </div>
                <div id="d_bar"></div>
                <div id="d_detail"><span id="d_title"><%=title %></span><br />
                <%=content %>
                </div>
                <div id="about_img">
                    <div id="abt_img1"><%=img1 %></div>
                    <div id="abt_img2"><%=img2 %></div>
                    <div id="abt_img3"><%=img3 %></div>
                </div>
            </div>
            <div id="next_page"><%=nextPage %></div>
    </div>
</asp:Content>
