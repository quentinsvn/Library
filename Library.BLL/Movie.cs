using Library.BLL.Collection;
using Library.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL
{
    public class Movie
    {

        #region Properties
        //private int id = -1;

        /*public int Id
        {
            get { return id; }
            private set { id = value; }
        }*/

        public int Id { get; private set; } = -1;

        //private string title;

        /*public string Title
        {
            get { return title; }
            private set { title = value; }
        }*/

        public string Title { get; set; } = null;

        public DateTime Date { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Retrives all genre of the <see cref="Movie"/>
        /// </summary>
        private void RetrieveGenres()
        {
            genres = new GenreCollection();
            genres.Get_ByMovieId(Id);
        }

        #endregion

        #region Constructors

        public Movie()
        {

        }

        public Movie(DataRow dr)
        {
            FillFromDataRow(dr);
        }

        #endregion

        #region Methods

        public bool GetById(int id)
        {
            using(SqlLibrary sqlLibrary = new SqlLibrary())
            {
                DataSet ds = sqlLibrary.Get_Movie_ById(id);

                if(ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 1)
                {
                    FillFromDataRow(ds.Tables[0].Rows[0]);
                    return true;
                }
            }

            return false;
        }

        private GenreCollection genres = null;
        public GenreCollection Genres
        {
            get
            {
                if (genres == null)
                {
                    RetrieveGenres();
                }

                return genres;
            }
            set { genres = value; }
        }


        public bool SetMovie()
        {
            using (SqlLibrary sqlLibrary = new SqlLibrary())
            {
                Id = sqlLibrary.Set_Movie(Id, Title, Date, null);
            }

            return Id != -1;
        }

        public bool Delete()
        {
            using (SqlLibrary sqlLibrary = new SqlLibrary())
            {
                return sqlLibrary.Delete_Movie_ById(Id);
            }
            /*
            SqlLibrary sqlLibrary;
            try
            {
                sqlLibrary = new SqlLibrary();
                return sqlLibrary.Delete_Movie_ById(Id);
            }
            finally
            {
                sqlLibrary.Dispose();
            }
            */
        }

        private void FillFromDataRow(DataRow dr)
        {
            Id = (int)dr["id"];
            //Title = (string)dr["title"];
            Title = dr.Field <string>("Title");
            Date = dr["Date"] == DBNull.Value ? DateTime.MinValue : (DateTime)dr["date"];
            // ImageUrl = dr["imageUrl"] == DBNull.Value ? null : (string)dr["imageUrl"];
        }

        #endregion
    }
}
