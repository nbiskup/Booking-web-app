<%@ Page Title="Login" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Adminstration.LogIn" %>

<%@ Register Src="~/App_UserControls/LoginControl.ascx" TagPrefix="uc1" TagName="LoginControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <uc1:LoginControl runat="server" id="LoginControl" />


<%--   
        Ako je login preko baze:
            Username: admin admin
            Password: admin

        Ako je hardkodiran login:
            Username: admin
            Password: admin
--%>


</asp:Content>
