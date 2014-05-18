<%@ Page Title="Update an user" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="updateuser.aspx.cs" Inherits="LibraryManager.updateuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header"> <h1>
        Update an user
    </h1></div>
    <div class="row">
        <div class="col-lg-6">

        .<asp:Label ID="Label1" runat="server" Text="Select the username:" style="font-family: 'Segoe Script'"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="uname" DataValueField="uname" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:libman_dbConnectionString %>" SelectCommand="SELECT [uname] FROM [Users]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:librarymanagerConnectionString %>" SelectCommand="SELECT [uname] FROM [Users]"></asp:SqlDataSource>
            <ul class="list-group" runat="server" id="book_details">
   
  <li class="list-group-item">Password:<input type="text" runat="server" id="pass" class="form-control"></li>
  <li class="list-group-item">Book Id:<input type="text" runat="server" id="bid" class="form-control" disabled="disabled"></li>
  <li class="list-group-item">Address:<input type="text" runat="server" id="addr" class="form-control"></li>
  <li class="list-group-item">Contact:<input type="text" runat="server" id="contact" class="form-control"></li>
  
  <li class="list-group-item">Date of Borrowing:<input type="text" runat="server" id="doi" class="form-control"></li>
  <li class="list-group-item">Date of Submission:<input type="text" runat="server" id="dos" class="form-control"></li>
  
        <li class="list-group-item"><span class="input-group-btn-lg">
              <asp:button id="btnupdate" runat="server" OnClick="btnupdate_Click" class="btn btn-primary btn-lg" type="button" Text="  Update this User  "></asp:button>     

                </span><span class="input-group-btn-lg">
                <asp:button id="btndel" runat="server" OnClick="btndel_Click" class="btn btn-primary btn-lg" type="button" Text="  Delete this User "></asp:button>     

                </span></li>
         <li class="list-group-item">
        <div class="bs-callout bs-callout-warning" id="foot">
                        <h4>   <asp:label id="error" runat="server" Enabled="false" Text="Please update an user!"></asp:label>
                      </h4> </div></li>
  </ul>
    </div></div>
</asp:Content>
