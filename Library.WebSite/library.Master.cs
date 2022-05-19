using Library.DAO.Context;
using Library.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Library.WebSite
{
    public partial class library : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitCarousel();
            }
        }

        #region Methods
        /// <summary>
        /// Carousel init
        /// </summary>
        public void InitCarousel()
        {
            List<Movie> moviesWithImage;
            using (LibraryContext library = new LibraryContext())
            {
                moviesWithImage = library.Movies
                    .Where(m => !string.IsNullOrEmpty(m.ImageUrl))
                    .ToList();
            }

            if (moviesWithImage.Count > 2)
            {
                rptCarousel.DataSource = moviesWithImage;
                rptCarousel.DataBind();
                phCarousel.Visible = true;
            }
            else
            {
                phCarousel.Visible = false;
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Carousel item binding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptCarousel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item
                || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Movie movie = (Movie)e.Item.DataItem;

                HtmlGenericControl divMovieImage = (HtmlGenericControl)e.Item.FindControl("divMovieImage");
                divMovieImage.Style.Add("background-image", "url(" + movie.ImageUrl + ")");

                if (e.Item.ItemIndex == 0)
                    divMovieImage.Attributes["class"] += " active";

                Label lblMovieTitle = (Label)e.Item.FindControl("lblMovieTitle");
                lblMovieTitle.Text = movie.Title;

                Label lblMovieDate = (Label)e.Item.FindControl("lblMovieDate");
                lblMovieDate.Text = movie.Date?.ToShortDateString();
            }
        }
        #endregion
    }
}