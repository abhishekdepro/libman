<%@ Page Title="Borrow" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="borrow.aspx.cs" Inherits="LibraryManager.borrow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="page-header">
  <h2><i class="fa fa-quote-left pull-left "></i>Borrow a Book <small>from a huge collection </small><i class="fa fa-quote-right "></i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 🔴 available ⃝&nbsp;&nbsp; unavailable</h2>
</div>
    

    <asp:Table ID="myTable" CssClass="table" runat="server" Width="100%"> 
    <asp:TableRow>
        <asp:TableCell Font-Bold="true" CssClass="h4">ISBN</asp:TableCell>
        <asp:TableCell Font-Bold="true" CssClass="h4">Name</asp:TableCell>
        <asp:TableCell Font-Bold="true" CssClass="h4">Author</asp:TableCell>
        <asp:TableCell Font-Bold="true" CssClass="h4">Publisher</asp:TableCell>
        <asp:TableCell Font-Bold="true" CssClass="h4">Copies</asp:TableCell>
        <asp:TableCell Font-Bold="true" CssClass="h4">Availability</asp:TableCell>
    </asp:TableRow>

</asp:Table>  
<hr/><div class="row">
    <div class="col-md-4">
        Select a Book:
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataSourceID="SqlDataSource2" DataTextField="isbn" DataValueField="isbn" ViewStateMode="Enabled">
             <asp:ListItem Value="" Text="" Enabled="false" />

        </asp:DropDownList>
        
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:libman_dbConnectionString %>" SelectCommand="SELECT [isbn] FROM [Book] WHERE ([available] = @available)">
            <SelectParameters>
                <asp:Parameter DefaultValue="yes" Name="available" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:librarymanagerConnectionString %>" SelectCommand="SELECT [isbn] FROM [Book] WHERE ([available] = @available)">
            <SelectParameters>
                <asp:Parameter DefaultValue="yes" Name="available" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div class="col-md-4">
        <span class="input-group-btn-lg">
              <asp:button id="btnborrowbook" runat="server" OnClick="btnborrowbook_Click"  class="btn btn-primary btn-lg" type="button" Text="  Borrow this Book  "></asp:button>     

                </span>
        <span class="input-group-btn-lg" style="margin-left:30px">
              <asp:button id="btncancel" runat="server" OnClick="btncancel_Click"  class="btn btn-default btn-lg" type="button" Text="  Cancel  "></asp:button>     

                </span>
    </div></div><br />
    <div class="row">
        <div class="alert alert-info alert-info">
  <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
  <strong>Warning: License Information</strong> Every book in here is a propieratory license of either the author(s) or the publisher(s) or both. Redistribution is a severe offence. Fine beyond stipuldated date is charged at Rs 5 per day!
</div>

    </div>
    <div class="bs-callout bs-callout-info" id="foot">
                           <asp:label id="error" runat="server" Enabled="false" Text=""></asp:label>
                       </div>

</asp:Content>
