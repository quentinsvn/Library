<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="moviesBinding.aspx.cs" Inherits="Library.WebTest.MoviesBinding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link type="text/css" href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="movies-box-container">
            <asp:Repeater ID="rptMovies" runat="server"
                OnItemDataBound="rptMovies_ItemDataBound" >
                
                <ItemTemplate>
                    <div class="movie-box">
                        <asp:Label runat="server" ID="lblMovieTitle" />

                        <asp:Image runat="server" ID="imgMovieImage" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageUrl") %>' />

                        <div class="movie-genre">
                            <asp:Repeater ID="rptMovieGenres" runat="server"
                                OnItemDataBound="rptMovieGenres_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Label ID="lblGenreTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' />
                                    <%-- <asp:Label ID="lblGenreTitle" runat="server" /> --%>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
