using Library.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Collection
{
    /// <summary>
    /// Class representing a collection of <see cref="Movie"/>
    /// </summary>
    public class MovieCollection : List<Movie>
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MovieCollection()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Get all existing <see cref="Movie"/>
        /// </summary>
        /// <returns>true if success</returns>
        public bool GetAll()
        {
            bool returnValue;

            DataSet dataSet = new DataSet();

            try
            {
                using (SqlLibrary sqlLibrary = new SqlLibrary())
                {
                    dataSet = sqlLibrary.Get_Movie_All();
                }

                if (dataSet.Tables.Count == 1
                    && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow tmpDr in dataSet.Tables[0].Rows)
                    {
                        this.Add(new Movie(tmpDr));
                    }
                }

                returnValue = true;
            }
            catch
            {
                // Handle error
                returnValue = false;
            }

            return returnValue;
        }

        /// <summary>
        /// Get all existing <see cref="Movie"/> having the <see cref="Genre"/> whose id is in parameter
        /// </summary>
        /// <param name="genreId">id of the <see cref="Genre"/></param>
        /// <returns>true if success</returns>
        public bool Get_ByGenreId(int genreId)
        {
            bool returnValue;

            DataSet dataSet = new DataSet();

            try
            {
                using (SqlLibrary sqlLibrary = new SqlLibrary())
                {
                    dataSet = sqlLibrary.Get_Movie_ByGenreId(genreId);
                }

                if (dataSet.Tables.Count == 1
                    && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow tmpDr in dataSet.Tables[0].Rows)
                    {
                        this.Add(new Movie(tmpDr));
                    }
                }

                returnValue = true;
            }
            catch
            {
                // Handle error
                returnValue = false;
            }

            return returnValue;
        }
        #endregion
    }
}