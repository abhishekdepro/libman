<%@ Page Title="My Library" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LibraryManager.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
  <h2>My Library <small>Return a book and browse the catalogue</small>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;User ID:&nbsp;
           <asp:Label ID="Label2" runat="server" Text="uid"></asp:Label>
        </h2>
</div>
    <div class="row">
    
             
  <asp:Table ID="myTable" CssClass="table" runat="server" Width="100%"> 
    <asp:TableRow>
        <asp:TableCell CssClass="h4">ISBN</asp:TableCell>
        <asp:TableCell CssClass="h4">Name</asp:TableCell>
        <asp:TableCell CssClass="h4">Author</asp:TableCell>
        <asp:TableCell CssClass="h4">Publisher</asp:TableCell>
        
        <asp:TableCell CssClass="h4">Year</asp:TableCell>
    <asp:TableCell CssClass="h4">Date of Issue</asp:TableCell>
        <asp:TableCell CssClass="h4">Date of Submission</asp:TableCell>
    </asp:TableRow>

</asp:Table>  <div class="row">
    
       
    <div class="col-md-4">
        <span class="input-group-btn-lg">
              <asp:button id="btnborrowbook" runat="server" OnClick="btnborrowbook_Click"  class="btn btn-primary btn-lg" type="button" Text=" Return this Book ➤ "></asp:button>     

                </span>
        
    </div></div><br />
    <div class="row">
        <div class="alert alert-info alert-info">
  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
  <strong>Warning: License Information</strong> Every book in here is a propieratory license of either the author(s) or the publisher(s) or both. Redistribution is a severe offence. Fine beyond stipuldated date is charged at Rs 5 per day!
</div>

    </div>
    
  <div class="row">
      <div class="bs-callout bs-callout-info" id="foot">
                           <asp:label id="error" runat="server" Enabled="false" Text="Fine Due = ₹ 0.00"></asp:label>
                       </div>
  </div>
 </div>
</asp:Content>
