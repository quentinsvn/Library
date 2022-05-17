using Library.DAO.Context;
using Library.DAO.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.WebTest
{
    public partial class AddMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(false == IsPostBack)
            {
                lblTitle.Text = "Ajouter un titre : ";
                lblDate.Text = "Date : ";
                lblImageUrl.Text = "Url de l'image : ";
                tbTitle.Text = String.Empty;
                InitListBoxGenres();
            }
        }

        #region Methodes
        private void InitListBoxGenres()
        {
            lbxGenres.Items.Clear();

            using (LibraryContext context = new LibraryContext())
            {
                /*
                lbxGenres.DataSource = context.Genres.OrderBy(g => g.Name).ToList();
                lbxGenres.DataBind();
                */
                foreach (Genre genre in context.Genres.OrderBy(g => g.Name).ToList())
                {
                    ListItem li = new ListItem(genre.Name, genre.Id.ToString());
                    lbxGenres.Items.Add(li);
                }
            }
        }

        #endregion

        DateTime dt;
        Uri uriImage;

        protected void btValidate_Click(object sender, EventArgs e)
        {

            bool error = false;
            string message = null;

            if (string.IsNullOrEmpty(tbTitle.Text))
            {
                error = true;
                message = "Veuillez saisir un titre";
            }
            else
            {
                // Validation film unique
                using(LibraryContext context = new LibraryContext())
                {
                    if (context.Movies.Any(m => m.Title == tbTitle.Text))
                    {
                        error = true;
                        message = "Le film est déjà présent en base de données.";
                    }
                }
                
            }

            if (false == error && string.IsNullOrEmpty(tbDate.Text) == false)
            {
                // Validation format date
                CultureInfo ci = CultureInfo.CreateSpecificCulture("fr");
                if(false == DateTime.TryParse(tbDate.Text, ci, DateTimeStyles.None, out dt))
                {
                    error = true;
                    message = "La date doit être de la forme jj/mm/aaaa";
                }

            }

            if(false == error && string.IsNullOrEmpty(tbImageUrl.Text) == false)
            {
                // Validation url image
                if (false == (Uri.TryCreate(tbImageUrl.Text, UriKind.Absolute, out uriImage)
                    && (uriImage.Scheme == Uri.UriSchemeHttp || uriImage.Scheme == Uri.UriSchemeHttps)))
                {
                    error = true;
                    message = "Le format de l'url de l'image est incorrect.";
                }

                if (false == error)
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

            if (false == error
                && lbxGenres.Items.Cast<ListItem>().Any(li => li.Selected) == false)
            {
                error = true;
                message = "Pas de genre sélectionné.";
            }

            if (false == error)
            {
                using (LibraryContext context = new LibraryContext())
                {
                    Movie movie = new Movie()
                    {
                        Title = tbTitle.Text,
                        Date = dt == DateTime.MinValue ? null : dt as DateTime?,
                        ImageUrl = uriImage != null ? uriImage.AbsoluteUri : null
                    };

                    #region Genres
                    foreach (ListItem li in lbxGenres.Items)
                    {
                        if (li.Selected)
                        {
                            Genre genre = context.Genres.First(g => g.Id.ToString() == li.Value);
                            movie.Genres.Add(genre);
                        }
                    }
                    #endregion

                    context.Movies.Add(movie);
                    context.SaveChanges();
                }

                // reset
                tbTitle.Text = string.Empty;
                tbDate.Text = string.Empty;
                tbImageUrl.Text = string.Empty;
                InitListBoxGenres();
                message = "Film créé avec succès";
            }

            #region Affichage du message
            lblMessage.ForeColor = error ? Color.Red : Color.Green;
            lblMessage.Text = message;

            lblMessage.CssClass = error ? "red" : "green";
            #endregion
        }
    }
}