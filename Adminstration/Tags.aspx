<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="Adminstration.Tags" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">


    <asp:Panel ID="pnlAddNewTag" runat="server">
        <fieldset class="p-4">
            <h2>Add new tag</h2>
            <div class="form-group col-xs-3">
                <asp:Label ID="lblTagType" class="form-label" runat="server" Text="Type: "></asp:Label>
                <asp:DropDownList ID="ddlTagType" CssClass="form-control" AutoPostBack="true" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group col-xs-3">
                <asp:Label ID="lblTagName" class="form-label" runat="server" Text="Tag name: "></asp:Label>
                <asp:TextBox ID="tbTagName" class="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTagName" runat="server" ControlToValidate="tbTagName" ValidationGroup="AddNewTag" Display="Dynamic" ForeColor="Red">Insert value!</asp:RequiredFieldValidator>
            </div>
            <br />
            <div >
                <asp:Button ID="btnAddNewTag" OnClick="btnAddNewTag_Click" runat="server" CssClass="btn btn-success" ValidationGroup="AddNewTag" Text="Add new tag" />
            </div>
        </fieldset>
    </asp:Panel>

    <asp:Panel ID="pnlTagExists" runat="server" Visible="false">
        <div role="alert" class="alert alert-danger d-flex justify-content-center"> Tag exists! </div>
    </asp:Panel>

    <div class="container mb-5">
        <div>
            <div >
                <asp:Repeater ID="rptTags" runat="server">
                    <HeaderTemplate>
                        <table id="myTable" class="table">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Name</th>
                                    <th scope="col">Tag type name</th>
                                    <th scope="col">Used</th>
                                    <th scope="col"></th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <th scope="row"><%# Eval(nameof(RwaLib.MODELS.Tag.Id)) %></th>
                            <td><%# Eval(nameof(RwaLib.MODELS.Tag.NameEng)) %></td>
                            <td><%# Eval(nameof(RwaLib.MODELS.Tag.TagTypeNameEng)) %></td>
                            <td><%# Eval(nameof(RwaLib.MODELS.Tag.Used)) %></td>
                            <td>
                                <asp:Button ID="btnShowDeleteModal" CssClass="btn btn-danger" OnClick="btnShowDeleteModal_Click" Visible='<%# Convert.ToInt32(Eval("Used")) == 0 %>' CommandArgument="<%# Eval(nameof(RwaLib.MODELS.Tag.Id)) %>" Text="Delete" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <%--Popup za brisanje taga--%>

            <asp:Panel ID="pnlShowDeleteModal" runat="server" Visible="false">
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
                                <p>Do you want to delete this tag?</p>
                            </div>
                            <div class="modal-footer">
                                <asp:Button class="btn btn-primary" ID="btnDeleteTag" runat="server" Text="Delete" OnClick="btnDeleteTag_Click" />
                                <button type="button" onclick="CloseModal()" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>



        </div>
    </div>

    <script>
        function CloseModal() {
            $('.modal').hide();
        }
    </script>
</asp:Content>
