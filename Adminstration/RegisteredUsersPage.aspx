<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="RegisteredUsersPage.aspx.cs" Inherits="Adminstration.EditRegisterUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

      <div class="d-flex justify-content-center">
        <div class="col-md-6">
            <div class="form-group">
                <label>Username</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>First name</label>
                <asp:TextBox ID="txtFname" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Last name</label>
                <asp:TextBox ID="txtLname" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
               <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Phone number</label>
                <asp:TextBox ID="txtPhonenumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>           
            
            <div><asp:LinkButton ID="lblBack" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="lblBack_Click" /></div>        
        </div>

    </div>



</asp:Content>
