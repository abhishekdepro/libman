<%@ Page Title="Confirm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Address.aspx.cs" Inherits="LibraryManager.Address" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="page-header"> <h1>
        Confirm your address <i class="fa fa-home"></i>
    </h1></div>
    <div class="row">
        <div class="col-lg-6">
            <div class="well well-lg">
                <h3>Choose existing address: </h3>
               <asp:Button OnClick="addr_Click" runat="server" CssClass="btn btn-primary btn-lg" Text="Address:" ID="addr"></asp:Button>

                
            </div>

            
    </div>
         <div class="col-lg-6">
            <div class="well well-lg">
                <h3>Selected address/ New address:</h3>
                
               <input type="text" runat="server" id="address" class="form-control input-lg" style="width:650px">
                 
            </div>

            
    </div>

    </div>
    <div class="row">
        <div class="col-lg-4"></div>
        <div class="col-lg-4">

<asp:Button OnClick="confirm_Click" runat="server" CssClass="btn btn-primary btn-lg" Text="Confirm" ID="confirm"></asp:Button>

        </div>
    </div>
    
    <div class="row">
    <div class="bs-callout bs-callout-info" id="foot">
                           <asp:label id="error" runat="server" Enabled="false" Text=""></asp:label>
                       </div></div>
</asp:Content>

