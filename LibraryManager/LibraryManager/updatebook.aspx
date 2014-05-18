<%@ Page Title="Update" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updatebook.aspx.cs" Inherits="LibraryManager.updatebook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header"> <h1>
        Update a book
    </h1></div>
    <div class="row">
        <div class="col-lg-6">

        <asp:Label ID="Label1" runat="server" Text="Select the ISBN:" style="font-family: 'Segoe Script'"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="isbn" DataValueField="isbn" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:libman_dbConnectionString %>" SelectCommand="SELECT [isbn] FROM [Book]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:librarymanagerConnectionString %>" SelectCommand="SELECT [isbn] FROM [Book]"></asp:SqlDataSource>
            <ul class="list-group" runat="server" id="book_details">
   
  <li class="list-group-item">Book Name:<input type="text" runat="server" id="bname" class="form-control"></li>
  <li class="list-group-item">Author Name:<input type="text" runat="server" id="author" class="form-control"></li>
  <li class="list-group-item">Publisher Name:<input type="text" runat="server" id="publisher" class="form-control"></li>
  <li class="list-group-item">Year of publication:<input type="text" runat="server" id="year" class="form-control"></li>
  <li class="list-group-item">

      <div class="input-group">
      <span class="input-group-addon">
        <input runat="server" id="available" type="checkbox" disabled="disabled" >
      </span>
      <input type="text" value="Available" class="form-control" style="width:245px">
    </div><!-- /input-group -->
  </li>
        <li class="list-group-item"><span class="input-group-btn-lg">
              <asp:button id="btnupdate" runat="server" OnClick="btnupdate_Click" class="btn btn-primary btn-lg" type="button" Text="  Update this Book  "></asp:button>     

                </span><span class="input-group-btn-lg">
                <asp:button id="btndel" runat="server" OnClick="btndel_Click" class="btn btn-primary btn-lg" type="button" Text="  Delete this Book  "></asp:button>     

                </span></li>
         <li class="list-group-item">
        <div class="bs-callout bs-callout-warning" id="foot">
                        <h4>   <asp:label id="error" runat="server" Enabled="false" Text="Please update a Book!"></asp:label>
                      </h4> </div></li>
  </ul>
    </div></div>
</asp:Content>
