﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="webForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <asp:Label runat="server"></asp:Label>
        <h3>Your application description page.</h3>
        <p>Use this area to provide additional information.</p>
    </main>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" runat="server">
    <main aria-labelledby="title">
        <h2>Second content</h2>
    </main>
</asp:Content>
