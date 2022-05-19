<%@ Page Title="" Language="C#" MasterPageFile="~/library.Master" AutoEventWireup="true" CodeBehind="movies.aspx.cs" Inherits="Library.WebSite.movies" %>

<%@ MasterType VirtualPath="~/library.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="js/jquery-ui/jquery-ui.min.css" type="text/css" rel="stylesheet" />
    <script src="js/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="allMyMovies" class="padding100">
        <div class="container">
            <div class="row">
                <h2 class="background double animated wow fadeInUp" data-wow-delay="0.2s">
                    <span><strong>All</strong> my movies</span>
                </h2>
            </div>
            <!-- ./ end row -->
            
            <div class="row">  
                <asp:UpdatePanel ID="upAddMovie" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <%-- Add LinkButton here --%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            
            <asp:UpdatePanel ID="upMovies" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <asp:Repeater ID="rptMovies" runat="server"
                        OnItemDataBound="rptMovies_ItemDataBound">
                        <ItemTemplate>
                            <div class="row movieDisplay animated wow fadeInUp" data-wow-delay="0.3s">
                                <%-- affiche --%>
                                <div class="col-md-2">
                                    <asp:Image ID="imgMovie" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageUrl") %>' AlternateText="screens" CssClass="img-responsive" Height="250px" />
                                </div>
                                <%-- données --%>
                                <div class="col-md-10">
                                    <%-- titre --%>
                                    <div class="row rowMovieTitle">
                                        <h2 class="backgroundTitle">
                                            <asp:Label ID="lblTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' />
                                        </h2>
                                    </div>
                                    <%-- genre --%>
                                    <div class="row rowMovieInfo rowMovieGenres">
                                        <asp:Repeater ID="rptGenres" runat="server">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGenre" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <%-- date --%>
                                    <div class="row rowMovieInfo rowMovieDate">
                                        <asp:Label ID="lblDate" runat="server" />
                                    </div>
                                    <%-- action --%>
                                    <div class="row rowMovieInfo rowMovieAction">
                                        <asp:LinkButton ID="lbEditMovie" runat="server" CssClass="btn btn-default" OnCommand="lbAddEditMovie_Command">
                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                            Editer
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="lbDeleteMovie" runat="server" CssClass="btn btn-danger" OnCommand="lbDeleteMovie_Command">
                                            <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                            Supprimer
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>

    <div id="divAddEditMoviePopup" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="upAddEditMovie" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblAddEditMovieTitle" runat="server" />
                            </h4>
                        </div>
                        <div class="modal-body">
                            <%-- title --%>
                            <div class="row">
                                <%-- titre --%>
                                <div class="col-md-12 verticalPadding5">
                                    <div class="input-group">
                                        <span class="input-group-addon" id="editTitle">Titre</span>
                                        <asp:TextBox ID="tbEditTitle" runat="server" CssClass="form-control" 
                                            placeholder="Titre" aria-label="Titre" aria-describedby="editTitle" />
                                    </div>
                                </div>
                                <%-- date --%>
                                <div class="col-md-12 verticalPadding5">
                                    <div class="input-group">
                                        <span class="input-group-addon" id="editDate">Date</span>
                                        <asp:TextBox ID="tbEditDate" runat="server" CssClass="form-control" 
                                            placeholder="jj/mm/aaaa" aria-label="Date" aria-describedby="editDate" />                                  
                                    </div>
                                </div>
                                <%-- image --%>
                                <div class="col-md-12 verticalPadding5">
                                    <div class="input-group">
                                        <span class="input-group-addon" id="editImageUrl">Url image</span>
                                        <asp:TextBox ID="tbEditImageUrl" runat="server" CssClass="form-control" 
                                            placeholder="Url image" aria-label="Url image" aria-describedby="editImageUrl" />
                                    </div>
                                </div>
                                <%-- genre --%>
                                <div class="col-md-12 verticalPadding5">
                                    <div class="input-group">
                                        <span class="input-group-addon" id="editGenre">Genre</span>
                                        <asp:ListBox ID="lbxEditGenres" runat="server" SelectionMode="Multiple" Height="150" CssClass="form-control" 
                                            DataTextField="Name" DataValueField="Id" aria-label="Genre" aria-describedby="editGenre" />
                                    </div>
                                </div>
                                <%-- message --%>
                                <div class="col-md-12 verticalPadding5">
                                    <asp:UpdatePanel ID="upEditMessage" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Label ID="lblEditMessage" runat="server" CssClass="label label-danger" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Fermer</button>
                            <asp:Button ID="btAddEditMovieValidate" runat="server" CssClass="btn btn-success" OnCommand="btAddEditMovieValidate_Command" Text="Sauvegarder" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="rptMovies" />
                    </Triggers>
                </asp:UpdatePanel>
            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
</asp:Content>
