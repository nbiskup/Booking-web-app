<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="AddNewApartment.aspx.cs" Inherits="Adminstration.AddNewApartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div class="row p-5">
        <div class="col-md-6">

            <%--Prvi dio kreiranja apartmana--%>

            <div class="text-center">
                <asp:Label ID="lblFirstPart" runat="server"> <h3><span class="label label-default">First part:</span></h3></asp:Label>
            </div>
            <div class="form-group col-lg-6">
                <label>Status</label>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" DataValueField="Id" DataTextField="NameEng"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvStatus" ControlToValidate="ddlStatus" runat="server" ErrorMessage="You need to select status to save new apartment!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-lg-6">
                <label>Owner</label>
                <asp:DropDownList ID="ddlApartmentOwner" runat="server" CssClass="form-control" DataValueField="Id" DataTextField="Name"></asp:DropDownList>
            </div>
            <div class="form-group col-lg-6">
                <label>Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvApartmentName" ControlToValidate="txtName" runat="server" ErrorMessage="Insert apartment name!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-lg-6">
                <label>Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" ControlToValidate="txtAddress" runat="server" ErrorMessage="Insert address!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-lg-6">
                <label>City</label>
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" DataValueField="Id" DataTextField="Name"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="ddlCity" runat="server" ErrorMessage="You need to select status to save new apartment!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-lg-6">
                <label>Price</label>
                <div class="input-group">
                    <span class="input-group-addon" id="spanEuro">€</span>
                    <asp:TextBox ID="txtPrice" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPrice" ControlToValidate="txtPrice" runat="server" ErrorMessage="Insert price!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group col-lg-6">
                <label>Number of adults</label>
                <asp:TextBox ID="txtMaxAdults" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMaxAdults" ControlToValidate="txtMaxAdults" runat="server" ErrorMessage="Insert number of adults!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-lg-6">
                <label>Number of children</label>
                <asp:TextBox ID="txtMaxChildren" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMaxChildren" ControlToValidate="txtMaxChildren" runat="server" ErrorMessage="Insert number of children!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-lg-6">
                <label>Total rooms</label>
                <asp:TextBox ID="txtTotalRooms" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTotalRooms" ControlToValidate="txtTotalRooms" runat="server" ErrorMessage="Insert number of rooms!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-lg-6">
                <label>Beach distance</label>
                <div class="input-group">
                    <span class="input-group-addon" id="spanMeter">m</span>
                    <asp:TextBox ID="txtBeachDistance" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvBeachDistance" ControlToValidate="txtBeachDistance" runat="server" ErrorMessage="Insert beach distance!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="text-center">
                <asp:LinkButton ID="lnkSaveTxt" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="lnkSaveTxt_Click" />
            </div>


            <%--Drugi dio kreiranja apartmana--%>

            <asp:Panel ID="pnlUser" Visible="false" runat="server">

                <asp:Label ID="lblAddUser" runat="server"><h3><span class="label label-default">Second part: Apartment user</span></h3></asp:Label>

                <br />
                <%--Registrirani korisnik--%>
                <asp:Button ID="btnRegisteredUser" runat="server" Text="Registered user" OnClick="btnRegisteredUser_Click" CssClass="btn btn-primary" />

                <asp:Panel Visible="false" runat="server" ID="pnlRegisteredUser">
                    <div class="form-group col-lg-6">
                        <label>User</label>
                        <asp:DropDownList ID="ddlRegisteredUsers" runat="server" CssClass="form-control" DataValueField="Id" DataTextField="UserName"></asp:DropDownList>
                    </div>
                    <div class="form-group col-lg-6">
                        <label>Details</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtDetailsReg" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDetails" ControlToValidate="txtDetailsReg" runat="server" ErrorMessage="Details field is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:Button ID="btnSaveRegisteredUser" runat="server" Text="Add user" OnClick="btnSaveRegisteredUser_Click" CssClass="btn btn-success" />
                </asp:Panel>


                <%--Neregistrirani korisnik--%>

                <asp:Button ID="btnUnRegisteredUser" runat="server" Text="Unregistered user" OnClick="btnUnRegisteredUser_Click" CssClass="btn btn-primary" />

                <asp:Panel Visible="false" runat="server" ID="pnlUnRegisteredUser">
                    <div class="form-group col-lg-6">
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
                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-lg-6">
                            <label>Phonenumber</label>
                            <asp:TextBox ID="txtPhoneNumber" runat="server" TextMode="Phone" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPhoneNumber" ControlToValidate="txtPhoneNumber" runat="server" ErrorMessage="Phone number is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group col-lg-10">
                            <label>Details</label>
                            <div class="input-group">
                                <asp:TextBox ID="txtDetailsUnReg" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDetailsUnReg" ControlToValidate="txtDetailsUnReg" runat="server" ErrorMessage="Details field is empty!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btnSaveUnRegisteredUser" runat="server" Text="Add user" OnClick="btnSaveUnRegisteredUser_Click" CssClass="btn btn-success" />
                </asp:Panel>
            </asp:Panel>



        </div>

        <div class="col-md-6">

            <%--Treci dio spremanja--%>

            <asp:Panel ID="pnlImgTags" runat="server" Visible="false">

                <div class="text-center">
                    <asp:Label ID="lblThirdPart" runat="server"> <h3><span class="label label-default">Third part:</span></h3></asp:Label>
                    <asp:Label ID="lblSecondPart" Visible="false" runat="server"> <h3><span class="label label-default">Second part:</span></h3></asp:Label>
                </div>


                <div class="form-group">
                    <label>Odabir tagova</label>
                    <asp:DropDownList ID="ddlTags" runat="server" CssClass="form-control" DataValueField="Id" DataTextField="NameEng"
                        OnSelectedIndexChanged="ddlTags_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTags" ControlToValidate="ddlTags" runat="server" ErrorMessage="You need to select at least one tag to save new apartment!" Font-Bold="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <%--Lista odabranih tagova--%>
                <asp:Repeater ID="repTags" runat="server">
                    <HeaderTemplate>
                        <ul class="list-group">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="list-group-item">
                            <asp:HiddenField runat="server" ID="hidTagId" Value='<%# Eval("Id") %>' />
                            <asp:Label runat="server" ID="txtTagNameEng" Text='<%# Eval("NameEng") %>' />
                            <asp:LinkButton runat="server" ID="lnkDeleteSelectedTag" CssClass="btn" OnClick="lnkDeleteSelectedTag_Click">
                                <span class="glyphicon glyphicon-trash"></span>
                            </asp:LinkButton>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>



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
                            <img src="<%# Eval(nameof(RwaLib.MODELS.ApartmentPicture.Path)) %>" style="width: 400px; height: 300px">
                            <asp:Button Text="Representative" ID="btnRepresentative" OnClick="btnRepresentative_Click" CommandArgument="<%# Eval(nameof(RwaLib.MODELS.ApartmentPicture.Id)) %>" CssClass="btn btn-primary" runat="server" />
                            <asp:Button Text="Delete" ID="btnShowDeleteImageModal" OnClick="btnShowDeleteImageModal_Click" CommandArgument="<%# Eval(nameof(RwaLib.MODELS.ApartmentPicture.Id)) %>" CssClass="btn btn-danger" runat="server" />
                            <br />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <br />
                <div>
                    <asp:LinkButton ID="lnkSaveImgTags" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="lnkSaveImgTags_Click" />
                </div>
            </asp:Panel>


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


            <div class="text-center">
                <asp:Label ID="lblNoTags" runat="server" Visible="false"> <h3><span class="bg-danger text-black p-3">You need to select at least one tag to save new apartment!</span></h3></asp:Label>
            </div>

        </div>
    </div>

    <script>
        function CloseModal() {
            $('.modal').hide();
        }
    </script>
</asp:Content>
