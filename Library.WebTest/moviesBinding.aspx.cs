using Library.DAO.Context;
using Library.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.WebTest
{
    public partial class MoviesBinding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (false == IsPostBack)
            {
                InitRepeaterMovies();
            }
        }

        private void InitRepeaterMovies()
        {
            using (LibraryContext context = new LibraryContext())
            {
                rptMovies.DataSource = context.Movies.OrderBy(m => m.Title).ToList();
                rptMovies.DataBind();
            }
        }

        protected void rptMovies_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Movie movie = (Movie)e.Item.DataItem;

                Label lblTitle = (Label)e.Item.FindControl("lblMovieTitle");
                lblTitle.Text = movie.Title;

                Repeater rptMovieGenre = (Repeater)e.Item.FindControl("rptMovieGenres");
                rptMovieGenre.DataSource = movie.Genres.OrderBy(g=>g.Name).ToList();
                rptMovieGenre.DataBind();
            }
        }

        protected void rptMovieGenres_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item 
                || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Genre genre = (Genre)e.Item.DataItem;

                Label lblGenreTitle = (Label)e.Item.FindControl("lblGenreTitle");
                lblGenreTitle.Text = genre.Name;
            }
        }
    }
}