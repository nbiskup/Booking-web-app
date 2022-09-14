<%@ Page Title="Apartments" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Apartments.aspx.cs" Inherits="Adminstration.Apartments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div >
        <div >

            <div class="col-sm-2">
                <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" DataValueField="Id" DataTextField="NameEng" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            
            <br />
            <asp:LinkButton ID="lbAddApartment" runat="server" Text="Add apartment" CssClass="btn btn-primary" OnClick="lbAddApartment_Click"></asp:LinkButton>

            <hr />
            <asp:Repeater ID="rptApartments" runat="server">
                <HeaderTemplate>
                    <table class="table" id="myTable">
                        <thead>
                            <tr>
                                <th scope="col">Name</th>
                                <th scope="col">City</th>
                                <th scope="col">Adults</th>
                                <th scope="col">Children</th>
                                <th scope="col">Rooms</th>
                                <th scope="col">Pictures</th>
                                <th scope="col">Price</th>
                                <th scope="col">Beach distance</th>
                                <th scope="col">Status</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td scope="row"><%#Eval(nameof(RwaLib.MODELS.Apartment.NameEng))%></td>
                        <td><%#Eval(nameof(RwaLib.MODELS.Apartment.City))%></td>
                        <td><%#Eval(nameof(RwaLib.MODELS.Apartment.MaxAdults))%></td>
                        <td><%#Eval(nameof(RwaLib.MODELS.Apartment.MaxChildren))%></td>
                        <td><%#Eval(nameof(RwaLib.MODELS.Apartment.TotalRooms))%></td>
                        <td><%#Eval(nameof(RwaLib.MODELS.Apartment.NumberOfPictures))%></td>
                        <td><%#Eval(nameof(RwaLib.MODELS.Apartment.Price))%>€</td>
                        <td><%#Eval(nameof(RwaLib.MODELS.Apartment.BeachDistance))%>m</td>
                        <td><%#Eval(nameof(RwaLib.MODELS.Apartment.Status))%></td>
                        <td>
                            <asp:LinkButton OnClick="LinkButton_Click" CommandArgument="<%# Eval(nameof(RwaLib.MODELS.Apartment.Id)) %>" ID="LinkButton" runat="server">Open</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>

        </div>
    </div>

</asp:Content>



<%-- POPRAVIT
 
    ApartmentsPage.aspx               
        reprezentativna ne radi uvik
    
    AddNewApartment.aspx
        reprezentativna ne radi uvik
        
    Error
        da se za svaki moguci error pojavi moja stranica za errore

--%>