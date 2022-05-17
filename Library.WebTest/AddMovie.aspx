<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMovie.aspx.cs" Inherits="Library.WebTest.AddMovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link type="text/css" href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            Saisissez un film
        </h1>

        <div class="divForm">
            <asp:Label ID="lblTitle" runat="server" />
            <asp:TextBox ID="tbTitle" runat="server" />
        </div>
        <div class="divForm">
            <asp:Label ID="lblDate" runat="server" />
            <asp:TextBox ID="tbDate" runat="server" />
        </div>
        <div class="divForm">
            <asp:Label ID="lblImageUrl" runat="server" />
            <asp:TextBox ID="tbImageUrl" runat="server" />
        </div>

        <div class="divForm">
            <asp:Label ID="lblGenre" runat="server" Text="Genres : " />
            <asp:ListBox ID="lbxGenres" runat="server" SelectionMode="Multiple" Height="200" />
        </div>

        <div class="divForm">
            <asp:Button ID="btValidate" runat="server" Text="Ajouter" OnClick="btValidate_Click" />
        </div>

        <div>
            <asp:Label ID="lblMessage" runat="server" />
        </div>
    </form>
</body>
</html>
