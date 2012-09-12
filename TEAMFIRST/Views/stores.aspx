<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base.Master" AutoEventWireup="true" CodeBehind="stores.aspx.cs" Inherits="TEAMFIRST.Views.stores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Assets/Css/stores.css?V=1.0" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="stores_wrapper">
            <div id="store_blank"></div>
            <div id="stores" class="clearfix">
                <div id="groupl">
                    <div class="f16 stores_font">總公司<br />台北門市部</div>
                    <ul>
                        <li><img width="237" height="1" src="/Assets/Images/line.png" alt="" /></li>
                        <li>台北市信義區松德路259號</li>
                        <li>洽購電話：(02)2346-3929</li>
                        <li>傳　　真：(02)2346-4618</li>
                    </ul>
                </div>
                <div id="groupr">
                    <div class="f16 stores_font"><br />埔里分店</div>
                    <ul>
                        <li><img width="237" height="1" src="/Assets/Images/line.png" alt="" /></li>
                        <li>南投縣埔里鎮中華路96號之1</li>
                        <li>洽購電話：(049)2930-255</li>
                        <li></li>
                    </ul>
                </div>
            </div>
    </div>
</asp:Content>
