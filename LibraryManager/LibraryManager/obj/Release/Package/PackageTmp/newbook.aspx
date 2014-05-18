<%@ Page Title="Admin Panel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="newbook.aspx.cs" Inherits="LibraryManager.newbook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
  <h1>Administration Panel <small>add, update or delete a book/user</small></h1>
</div>
    <div class="row">
   <div class="col-md-4">         <div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title">Add a new book</h3>
  </div>
  <div class="panel-body">
    <ul class="list-group" runat="server" id="book_details">
   <li class="list-group-item">
       ISBN number:
       <div id="input-collection" class="input-group">
          
              <span class="input-group-btn">
              <asp:button id="btnsearch" runat="server" OnClick="btnsearch_Click" class="btn btn-primary" type="button" Text="🔎"></asp:button>
          </span>
                <input id= "isbn" runat="server" type="text" class="form-control" name = "url" placeholder="ISBN number">
          
           </div>
   </li>
  <li class="list-group-item">Book Name:<input type="text" runat="server" id="bname" class="form-control"></li>
  <li class="list-group-item">Author Name:<input type="text" runat="server" id="author" class="form-control"></li>
  <li class="list-group-item">Publisher Name:<input type="text" runat="server" id="publisher" class="form-control"></li>
  <li class="list-group-item">Year of publication:<input type="text" runat="server" id="year" class="form-control"></li>
  <li class="list-group-item">Number of copies:<input type="text" runat="server" id="copies" class="form-control"></li>
     <li class="list-group-item"><span class="input-group-btn-lg">
              <asp:button id="btnaddnew" runat="server" OnClick="btnaddnew_Click" class="btn btn-primary btn-lg" type="button" Text="  Add a new Book  "></asp:button>     

                </span></li>
         <li class="list-group-item">
        <div class="bs-callout bs-callout-warning" id="foot">
                           <asp:label id="error" runat="server" Enabled="false" Text="Book not fetched!"></asp:label>
                       </div></li>
  </ul>
      
  </div>
</div>
       </div>
   
   
        <div class="col-md-4">
         <div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title">Update/Delete a book</h3>
  </div>
  <div class="panel-body">
    <ul class="list-group" runat="server" id="Ul2">
   <li class="list-group-item">
       <span class="input-group-btn-lg">
              <asp:button id="Button1" runat="server" OnClick="btnupdate_Click" class="btn btn-primary btn-lg" type="button" Text="  Update a Book  "></asp:button>     

                </span>
   </li>
  <li class="list-group-item"><h3>or</h3> </li>
        <li class="list-group-item">
            <span class="input-group-btn-lg">
              <asp:button id="btndel" runat="server" OnClick="btndel_Click" class="btn btn-default btn-lg" type="button" Text="  Delete a Book  "></asp:button>     

                </span>
        </li>
  </ul>
      
  </div> 
        </div>
 </div>       
   <div class="col-md-4">         <div class="panel panel-primary">
  <div class="panel-heading">
    <h3 class="panel-title">Update/Delete an User</h3>
  </div>
  <div class="panel-body">
    <ul class="list-group" runat="server" id="Ul1">
   <li class="list-group-item">
       <span class="input-group-btn-lg">
              <asp:button id="btnusrupdate" runat="server" OnClick="btnusrupdate_Click" class="btn btn-primary btn-lg" type="button" Text="  Update an User "></asp:button>     

                </span>
   </li>
  <li class="list-group-item"><h3>or</h3> </li>
        <li class="list-group-item">
            <span class="input-group-btn-lg">
              <asp:button id="btndelete" runat="server" OnClick="btndelete_Click" class="btn btn-default btn-lg" type="button" Text="  Delete an User  "></asp:button>     

                </span>
        </li>
  </ul>
      
  </div>
</div>
       </div>
   
 </div>
</asp:Content>
