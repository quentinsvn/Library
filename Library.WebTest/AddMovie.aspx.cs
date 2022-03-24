using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.WebTest
{
    public partial class AddMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Ajouter un titre : ";
            lblDate.Text = "Date : ";
            lblImageUrl.Text = "Url de l'image : ";
            tbTitle.Text = String.Empty;
        }
    }
}