<%@ Page Title="ApartmentsPage" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="ApartmentPage.aspx.cs" Inherits="Adminstration.ApartmentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div class="row p-5">
        <div class="col-md-6">

            <div class="form-group col-lg-6">
                <asp:Label ID="lblApartmentsName" runat="server" Text="Apartments name:"></asp:Label>
                <asp:TextBox class="form-control" ID="txtApartmentsName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApartmentName" ControlToValidate="txtApartmentsName" runat="server" ErrorMessage="Apartment name is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-lg-6">
                <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
                <div class="input-group">
                    <span class="input-group-addon" id="sizing-addon1">€</span>
                    <asp:TextBox ID="txtPrice" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPrice" ControlToValidate="txtPrice" runat="server" ErrorMessage="Price is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group col-lg-6">
                <label>Owner</label>
                <asp:DropDownList ID="ddlApartmentOwner" runat="server" OnSelectedIndexChanged="ddlApartmentOwner_SelectedIndexChanged" CssClass="form-control" DataValueField="Id" DataTextField="Name"></asp:DropDownList>
            </div>

            <div class="form-group col-lg-6">
                <label>Number of children</label>
                <asp:TextBox ID="txtChildren" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvChildren" ControlToValidate="txtChildren" runat="server" ErrorMessage="Number of children is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-lg-6">
                <asp:Label ID="lblNumberOfRooms" runat="server" Text="Number of rooms:"></asp:Label>
                <asp:TextBox class="form-control" TextMode="Number" ID="txtNumberOfRooms" runat="server" aria-describedby="inputGroupPrepend"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRooms" ControlToValidate="txtNumberOfRooms" runat="server" ErrorMessage="Number of rooms is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-lg-6">
                <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
                <asp:DropDownList class="form-control" ID="ddlStatus" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" runat="server" DataValueField="Id" DataTextField="NameEng" AutoPostBack="true"></asp:DropDownList>
            </div>

            <div class="form-group col-lg-6">
                <asp:Label ID="lblAdult" runat="server" Text="Adult:"></asp:Label>
                <asp:TextBox class="form-control" TextMode="Number" ID="txtAdult" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAdult" ControlToValidate="txtAdult" runat="server" ErrorMessage="Number of adults is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-lg-6">
                <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
                <asp:TextBox class="form-control" ID="txtAddress" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" ControlToValidate="txtAddress" runat="server" ErrorMessage="Address is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-lg-6">
                <asp:Label ID="lblBeachDistance" runat="server" Text="Beach distance:"></asp:Label>
                <div class="input-group">
                    <span class="input-group-addon" id="sizing-addon2">m</span>
                    <asp:TextBox class="form-control" TextMode="Number" ID="txtBeachDistance" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvBeachDistance" ControlToValidate="txtBeachDistance" runat="server" ErrorMessage="Beach distance is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>



            <%--Registrirani korisnik--%>                       
            <asp:Panel Visible="false" runat="server" ID="pnlRegisteredUser">
                
                <asp:Label ID="lblAddUser" runat="server"><h3><span class="label label-default">Apartment user</span></h3></asp:Label>

                <div class="form-group col-lg-6">
                    <label>User</label>
                    <asp:DropDownList ID="ddlRegisteredUsers" runat="server" CssClass="form-control" DataValueField="Id" DataTextField="UserName"></asp:DropDownList>
                </div>
                <div class="form-group col-lg-10">
                        <label>Details</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtDetailsReg" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDetails" ControlToValidate="txtDetailsReg" runat="server" ErrorMessage="Details field is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>               
            </asp:Panel>


            <%--Neregistrirani korisnik--%>            
            <asp:Panel runat="server" Visible="false" ID="pnlUnregisteredUser">
                <div class="form-group col-lg-6">
                    <asp:Label ID="lblUnRegUser" runat="server"><h3><span class="label label-default">Apartment user</span></h3></asp:Label>
                    <div class="form-group col-lg-6">
                        <label>Username</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsername" ControlToValidate="txtUsername" runat="server" ErrorMessage="Username is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-lg-6">
                        <label>Address</label>
                        <asp:TextBox ID="txtUserAddress" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserAddress" ControlToValidate="txtUserAddress" runat="server" ErrorMessage="Address is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-lg-6">
                        <label>Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-lg-6">
                        <label>Phonenumber</label>
                        <asp:TextBox ID="txtPhoneNumber" TextMode="Phone" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPhoneNumber" ControlToValidate="txtPhoneNumber" runat="server" ErrorMessage="Phone number is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-lg-10">
                        <label>Details</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtDetailsUnreg" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtDetailsUnreg" ControlToValidate="txtDetailsUnreg" runat="server" ErrorMessage="Details field is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>                
            </asp:Panel>



            <%--odabir slike--%>
            <div class="container">
                <div class="form-group">
                    <asp:FileUpload ID="uplImages" Accept=".jpeg,.png,.jpg" runat="server" />
                    <br />
                    <asp:Button ID="btnAddPicture" Text="Add/Show picture" runat="server" CssClass="btn btn-primary" OnClick="btnAddPicture_Click" />
                </div>
            </div>

            <%--prikazivanje odabrane slike--%>
            <asp:Repeater ID="rptApartmentPictures" runat="server">
                <ItemTemplate>
                    <div>
                        <img src="<%# Eval(nameof(RwaLib.MODELS.ApartmentPicture.Path)) %>" style="width: 400px; height: 300px; padding:10px">
                        <asp:Button Text="Representative" ID="btnRepresentative" OnClick="btnRepresentative_Click" CommandArgument="<%# Eval(nameof(RwaLib.MODELS.ApartmentPicture.Id)) %>" CssClass="btn btn-primary" runat="server" />
                        <asp:Button Text="Delete" ID="btnShowDeleteImageModal" OnClick="btnShowDeleteImageModal_Click" CommandArgument="<%# Eval(nameof(RwaLib.MODELS.ApartmentPicture.Id)) %>" CssClass="btn btn-danger" runat="server" />
                        <br />
                    </div>
                </ItemTemplate>
            </asp:Repeater>



            <%--Popup za brisanje slike--%>

            <asp:Panel ID="pnlShowDeleteImgModal" runat="server" Visible="false">
                <div class="modal" style="display: block" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Image delete</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="CloseModal()">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <p>Do you want to delete this image?</p>
                            </div>
                            <div class="modal-footer">
                                <asp:Button class="btn btn-primary" ID="btnDeleteImage" runat="server" Text="Delete" OnClick="btnDeleteImage_Click" />
                                <button type="button" onclick="CloseModal()" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <br />
            <br />
            <br />
        </div>

        <div class="col-md-6">

            <%--Lista tagova--%>

            <asp:Panel ID="pnlApartmentTags" runat="server" CssClass="table d-flex justify-content-center">
                <asp:Repeater ID="rptApartmentTags" runat="server">
                    <HeaderTemplate>
                        <table class="table-striped" id="" style="width: 450px">
                            <thead>
                                <tr>
                                    <th scope="col">Tag name</th>
                                    <th scope="col">Tag type</th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval(nameof(RwaLib.MODELS.Tag.NameEng))%></td>
                            <td><%#Eval(nameof(RwaLib.MODELS.Tag.TagTypeNameEng))%></td>
                            <td>
                                <asp:Button ID="btnShowDeleteTagModal" OnClick="btnShowDeleteTagModal_Click" CommandArgument="<%# Eval(nameof(RwaLib.MODELS.Tag.Id)) %>" Text="Delete" runat="server" CssClass="btn btn-danger" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
            </asp:Panel>


            <%--dodavanje novog taga --%>

            <asp:Button ID="btnShowAddNewTagModal" OnClick="btnShowAddNewTagModal_Click" runat="server" Text="Add new tag" class="btn btn-primary" />
            <asp:Button ID="btnCloseRptAddNewTag" OnClick="btnCloseRptAddNewTag_Click" runat="server" Text="Close new tags table" CssClass="btn btn-danger" />

            <asp:Panel ID="pnlAddNewTagToApartment" runat="server" CssClass="table d-flex justify-content-center" Visible="false">
                <asp:Repeater ID="rptAddNewTagToApartment" runat="server">
                    <HeaderTemplate>
                        <table class="table-striped" id="" style="width: 450px">
                            <thead>
                                <tr>
                                    <th scope="col">Tag name</th>
                                    <th scope="col">Tag type</th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval(nameof(RwaLib.MODELS.Tag.NameEng))%></td>
                            <td><%#Eval(nameof(RwaLib.MODELS.Tag.TagTypeNameEng))%></td>
                            <td>
                                <asp:Button ID="btnAddNewTagOnApartment" OnClick="btnAddNewTagOnApartment_Click" CommandArgument="<%# Eval(nameof(RwaLib.MODELS.Tag.Id)) %>" Text="Add" runat="server" CssClass="btn btn-success" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
            </asp:Panel>

            <br />
            <br />


            <%--Modal za brisanje apartmana--%>

            <asp:Panel ID="pnlShowDeleteApartmentModal" runat="server" Visible="false">
                <div class="modal" style="display: block" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Apartment delete</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="CloseModal()">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <p>Do you want to delete this apartment?</p>
                            </div>
                            <div class="modal-footer">
                                <asp:Button class="btn btn-primary" ID="btnDeleteApartment" runat="server" Text="Delete" OnClick="btnDeleteApartment_Click" />
                                <button type="button" onclick="CloseModal()" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <%--brisanje tagova--%>

            <asp:Panel ID="pnlDeleteTag" runat="server" Visible="false">
                <div class="modal" style="display: block" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Tag delete</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="CloseModal()">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <p>Do you want to delete this tag from this apartment?</p>
                            </div>
                            <div class="modal-footer">
                                <asp:Button class="btn btn-primary" ID="btnDelteTag" runat="server" Text="Delete" OnClick="btnDelteTag_Click" />
                                <button type="button" onclick="CloseModal()" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Button CssClass="btn btn-success" type="submit" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button CssClass="btn btn-danger" ID="btnShowDeleteApartmentModal" runat="server" Text="Delete apartment" CommandArgument="<%# Eval(nameof(RwaLib.MODELS.Apartment.Id)) %>" OnClick="btnShowDeleteApartmentModal_Click" />

        </div>

    </div>

    <script>
        function CloseModal() {
            $('.modal').hide();
        }
    </script>

</asp:Content>
