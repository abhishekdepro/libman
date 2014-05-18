<%@ Page Title="ISBN search results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="searchbyISBN.aspx.cs" Inherits="LibraryManager.searchbyISBN" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
  <h1>ISBN search results <small>powered by Google Books API</small></h1>
</div>

    <div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title">Book Details</h3>
  </div>
  <div class="panel-body">
    <ul class="list-group" runat="server" id="book_details">
  
  
</ul>
      
  </div>
</div>
    <div class="row">
        
        
        <div class="col-md-12">
            
            
            
            
                    
                   
                       <div class="bs-callout bs-callout-warning" id="bottom">
                           <asp:label id="error" runat="server" Enabled="false" Text="Book not fetched!"></asp:label>
                       </div>
                
        </div> 

              
            
    </div>

</asp:Content>
