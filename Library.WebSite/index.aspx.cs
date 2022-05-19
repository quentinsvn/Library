using Library.DAO.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Library.WebSite
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitUI();
            }
        }

        #region Methods
        private void InitUI()
        {
            using (LibraryContext context = new LibraryContext())
            {
                // nb movies
                long nbMovies = context.Movies.LongCount();
                litNbMovies.Text = nbMovies + " " + (nbMovies > 1 ? "movies" : "movie") + " !";

                // nb genres
                long nbGenres = context.Genres.LongCount();
                litNbGenres.Text = nbGenres + " " + (nbGenres > 1 ? "genres" : "genre") + " !";

                // latest movies
                rptLatestMovies.DataSource = context.Movies
                    .Where(m => !string.IsNullOrEmpty(m.ImageUrl))
                    .OrderByDescending(m => m.Date)
                    .Take(8)
                    .ToList();
                rptLatestMovies.DataBind();
            }            
        }
        #endregion

        #region Events

        #endregion
    }
}