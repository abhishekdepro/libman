<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryManager._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1><i class="fa fa-pencil-square-o"></i> Library Manager</h1>
        <h4 class="lead">Search for a huge collection of books and journals.<br /> Read them. Borrow them.</h4>
        <p><a href="/Account/Login.aspx" class="btn btn-primary btn-large">Dive in! &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-lg-6">
            <h2>Search for a book</h2>
            <h4>
                Search for a variety of novels, comics and journals</h4>
            <br />
                <div id="input-collection" class="input-group input-group-lg">
          
              <span class="input-group-btn">
              <asp:button id="btnrain" runat="server" OnClick="btnsearch_Click" class="btn btn-primary" type="button" Text="Search"></asp:button>
          </span>
                <input id= "book_name" runat="server" type="text" class="form-control" name = "url" placeholder="Enter ISBN/Name of Book">
          
           </div>
        </div>
        <div class="col-md-6">
            <h2>Borrow a Book</h2>
            <h4>
                Borrow from a variety of novels, comics and journals</h4>
            <br />
                <span class="input-group-btn-lg">
              <asp:button id="btnborrow" runat="server" OnClick="btnborrow_Click" class="btn btn-primary btn-lg" type="button" Text="Borrow a Book"></asp:button>     

                </span>
                </div>
           
        
    </div>

</asp:Content>
