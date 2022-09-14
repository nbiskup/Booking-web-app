<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="Adminstration.App_UserControls.WebUserControl1" %>
<div class="container py-4">
        <!-- PANEL PORUKA -->
        <asp:Panel ID="PanelIspis" CssClass="container mt-5" runat="server" Visible="False">
            <div class='alert alert-danger' role='alert'>
                <asp:Label ID="lblErrorLogin" runat="server" Text="Check the entered data again!"></asp:Label>
            </div>
        </asp:Panel>
        <!-- // -->

        <asp:Panel ID="PanelForma" runat="server" Visible="True">
            <!-- FORM -->
            <fieldset class="p-4">                
                <h2>Login</h2>
                <div class="mb-3">
                    <asp:Label ID="lblUsername"  class="form-label" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUsername" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red">* Username field is empty!</asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPassword" class="form-label" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red">* Password field is empty!</asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnLogin_Click" />
            </fieldset>
            <!-- // -->
        </asp:Panel>
    </div>