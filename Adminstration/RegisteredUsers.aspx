<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="RegisteredUsers.aspx.cs" Inherits="Adminstration.RegisteredUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">


     <div class="container mb-5">
        <div>
            <div >
                <asp:Repeater ID="rptUsers" runat="server">
                    <HeaderTemplate>
                        <table id="myTable" class="table">
                            <thead>
                                <tr>
                                    <th scope="col">ID</th>
                                    <th scope="col">Username</th>
                                    <th scope="col">First name</th>
                                    <th scope="col">Last name</th>
                                    <th scope="col">Address</th>
                                    <th scope="col">Email</th>
                                    <th scope="col">Phonenumber</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%# Eval(nameof(RwaLib.MODELS.User.Id)) %></th>
                            <td><%# Eval(nameof(RwaLib.MODELS.User.UserName)) %></td>
                            <td><%# Eval(nameof(RwaLib.MODELS.User.FirstName)) %></td>
                            <td><%# Eval(nameof(RwaLib.MODELS.User.LastName)) %></td>
                            <td><%# Eval(nameof(RwaLib.MODELS.User.Address)) %></td>
                            <td><%# Eval(nameof(RwaLib.MODELS.User.Email)) %></td>
                            <td><%# Eval(nameof(RwaLib.MODELS.User.PhoneNumber)) %></td>                            
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <br />
            <br />
            <br />
            <br />
        </div>      

    </div>


</asp:Content>
