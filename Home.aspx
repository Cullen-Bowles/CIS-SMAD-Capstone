<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication4.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../assets/dist/css/bootstrap.min.css" rel="stylesheet">

    <style>
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
    </style>

   
  </head>
  <body>
   
<main>
  <div class="container py-4">
    <header class="pb-3 mb-4 border-bottom">
   
    </header>

    <div class="p-5 mb-4 bg-light rounded-3">
      <div class="container-fluid py-5">
        <h1 class="display-5 fw-bold">Welcome to Story Analyzer</h1>
        <p class="col-md-8 fs-4">A Picture tells a thousand words.......</p>
        <%--<button class="btn btn-primary btn-lg" type="button">Example button</button>--%>
      </div>
    </div>

    <div class="row align-items-md-stretch">
      <div class="col-md-6">
        <div class="h-100 p-5 text-white bg-dark rounded-3">
          <h2>How to begin...</h2>
          <p> Click on the button below to enter a story! </p>
          <button class="btn btn-outline-light" type="button" onclick="StoryEntry.aspx">Go to Story Entry</button>
        </div>
      </div>
      <div class="col-md-6">
        <div class="h-100 p-5 bg-light border rounded-3">
          <h2>What is a story?</h2>
          <p> The term “story” refers to a narrative that involves people, groups, organizations, or other entities (subjects) performing actions that can affect other people, organizations, or entities (objects). These events occur in certain places and at certain times, and they may include other contextual features of interest.</p>
          <%--<button class="btn btn-outline-secondary" type="button">Example button</button>--%>
        </div>
      </div>
    </div>
</asp:Content>
