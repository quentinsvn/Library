using Library.DAO.Context;
using Library.DAO.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Library.WebSite
{
    public partial class movies : System.Web.UI.Page
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
                rptMovies.DataSource = context.Movies.OrderBy(m => m.Title).ToList();
                rptMovies.DataBind();
            }
        }
        #endregion

        #region Events
        protected void rptMovies_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item
                || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Movie movie = (Movie)e.Item.DataItem;

                // movie genres
                Repeater rptGenres = (Repeater)e.Item.FindControl("rptGenres");
                rptGenres.DataSource = movie.Genres.OrderBy(g => g.Name);
                rptGenres.DataBind();

                // movie date
                Label lblDate = (Label)e.Item.FindControl("lblDate");
                lblDate.Text = movie.Date?.ToShortDateString();
                
                // movie actions
                LinkButton lbEditMovie = (LinkButton)e.Item.FindControl("lbEditMovie");
                lbEditMovie.CommandArgument = movie.Id.ToString();
                ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lbEditMovie);

                LinkButton lbDeleteMovie = (LinkButton)e.Item.FindControl("lbDeleteMovie");
                lbDeleteMovie.CommandArgument = movie.Id.ToString();
                lbDeleteMovie.OnClientClick = "return confirm('Êtes-vous sûr(e) de vouloir supprimer \"" + movie.Title + "\" ?');";
            }
        }

        protected void lbDeleteMovie_Command(object sender, CommandEventArgs e)
        {
            int movieId = int.Parse(e.CommandArgument.ToString());

            using (LibraryContext context = new LibraryContext())
            {
                Movie movie = new Movie
                {
                    Id = movieId
                };
                context.Entry(movie).State = EntityState.Deleted;

                /*Movie movie = context.Movie.First(m => m.Id == movieId);
                context.Movie.Remove(movie);*/
                
                context.SaveChanges();
            }

            // réinit films
            InitUI();
            upMovies.Update();
            Master.InitCarousel();
        }

        protected void lbAddEditMovie_Command(object sender, CommandEventArgs e)
        {
            using (LibraryContext context = new LibraryContext())
            {
                lbxEditGenres.Items.Clear();
                lbxEditGenres.DataSource = context.Genres.OrderBy(g => g.Name).ToList();
                lbxEditGenres.DataBind();
            }

            int movieId = int.Parse(e.CommandArgument.ToString());
            
            using (LibraryContext context = new LibraryContext())
            {
                Movie movie = context.Movies.FirstOrDefault(m => m.Id == movieId);

                // popup
                lblAddEditMovieTitle.Text = movie.Title;

                // titre
                tbEditTitle.Text = movie.Title;

                // date
                CultureInfo ci = CultureInfo.CreateSpecificCulture("fr");
                tbEditDate.Text = movie.Date.HasValue ? movie.Date.Value.ToString("d", ci) : string.Empty;

                // url image
                tbEditImageUrl.Text = movie.ImageUrl;

                // genre
                foreach (ListItem li in lbxEditGenres.Items)
                {
                    li.Selected = movie.Genres.Any(g => g.Id.ToString() == li.Value);
                }

                // message
                lblEditMessage.Text = string.Empty;

                btAddEditMovieValidate.CommandArgument = movie.Id.ToString();
            }

            // maj champs
            upAddEditMovie.Update();

            // js
            StringBuilder sbJs = new StringBuilder();
            sbJs.AppendLine("$('#divAddEditMoviePopup').modal();");
            sbJs.AppendLine("$('#" + tbEditDate.ClientID + "').datepicker({");
            sbJs.AppendLine("dateFormat: 'dd/mm/yy'");
            sbJs.AppendLine("});");
            ScriptManager.RegisterClientScriptBlock(this, GetType(), Guid.NewGuid().ToString(), sbJs.ToString(), true);
        }

        protected void btAddEditMovieValidate_Command(object sender, CommandEventArgs e)
        {
            Movie movie = null;
            
            using (LibraryContext context = new LibraryContext())
            {
                movie = context.Movies.FirstOrDefault(m => m.Id.ToString() == e.CommandArgument.ToString());
            }

            bool error = false;
            string message = string.Empty;

            DateTime dt = DateTime.MinValue;
            Uri uriImage = null;

            #region Validation saisie
            // titre obligatoire
            if (string.IsNullOrEmpty(tbEditTitle.Text))
            {
                error = true;
                message = "Le titre est obligatoire.";
            }
            else if (movie == null) // film déjà existant
            {
                using (LibraryContext context = new LibraryContext())
                {
                    if (context.Movies.Any(m => m.Title == tbEditTitle.Text))
                    {
                        error = true;
                        message = "Le film est déjà présent en base de données.";
                    }
                }
            }

            // format de la date
            if (!error
                && !string.IsNullOrEmpty(tbEditDate.Text))
            {
                CultureInfo ci = CultureInfo.CreateSpecificCulture("fr");
                if (!DateTime.TryParse(tbEditDate.Text, ci, DateTimeStyles.None, out dt))
                {
                    error = true;
                    message = "La date doit être de la forme jj/mm/aaaa.";
                }
            }

            // url image valide
            if (!error
                && !string.IsNullOrEmpty(tbEditImageUrl.Text))
            {
                if (!(Uri.TryCreate(tbEditImageUrl.Text, UriKind.Absolute, out uriImage)
                    && (uriImage.Scheme == Uri.UriSchemeHttp || uriImage.Scheme == Uri.UriSchemeHttps)))
                {
                    error = true;
                    message = "Le format de l'url de l'image est incorrect.";
                }

                if (!error)
                {
                    try
                    {
                        HttpWebRequest request = WebRequest.Create(uriImage) as HttpWebRequest;
                        request.Method = "HEAD";
                        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                        response.Close();
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            error = true;
                            message = "Pas d'image à cette adresse.";
                        }
                    }
                    catch
                    {
                        error = true;
                        message = "Pas d'image à cette adresse.";
                    }
                }
            }
            #endregion

            if (!error)
            {
                #region Sauvegarde en BDD
                using (LibraryContext context = new LibraryContext())
                {
                    context.Movies.Attach(movie);
                    context.Entry(movie).State = EntityState.Modified;

                    movie.Title = tbEditTitle.Text;
                    movie.ImageUrl = uriImage != null ? uriImage.AbsoluteUri : null;

                    if (dt != DateTime.MinValue)
                    {
                        movie.Date = dt;
                    }

                    #region Genres
                    foreach (ListItem li in lbxEditGenres.Items)
                    {
                        if (li.Selected)
                        {
                            movie.Genres.Add(context.Genres.FirstOrDefault(g => g.Id.ToString() == li.Value));
                        }
                    }
                    #endregion

                    context.SaveChanges();
                }

                // réinit films
                InitUI();
                upMovies.Update();
                Master.InitCarousel();

                // js
                StringBuilder sbJs = new StringBuilder();
                sbJs.AppendLine("$('#divAddEditMoviePopup').modal('hide');");
                ScriptManager.RegisterClientScriptBlock(this, GetType(), Guid.NewGuid().ToString(), sbJs.ToString(), true);
                #endregion
            }
            else
            {
                #region Affichage du message
                lblEditMessage.CssClass = error ? "label label-danger" : "label label-success";
                lblEditMessage.Text = message;
                upEditMessage.Update();
                #endregion
            }
        }        
        #endregion
    }
}