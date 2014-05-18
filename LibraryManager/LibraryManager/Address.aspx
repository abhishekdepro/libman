<%@ Page Title="Confirm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Address.aspx.cs" Inherits="LibraryManager.Address" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="page-header"> <h1>
        Confirm your address <i class="fa fa-home"></i>
    </h1></div>
    <div class="row">
        <div class="col-lg-6">
            <h3>Choose existing address: </h3>
            <div class="well well-lg">
                
               <h4>   <asp:label id="add" runat="server" Text=""></asp:label>
                      </h4>  
            </div>

            
    </div>
         
         <div class="col-lg-6">
            <h3>Selected address/ New address:</h3>
             <div class="well well-lg">
                
                
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
    <div class="bs-callout bs-callout-info" id="foot"><i class="fa fa-refresh fa-spin"></i>
                           <asp:label id="error" runat="server" Enabled="false" Text=""></asp:label>
                       </div></div>
</asp:Content>

