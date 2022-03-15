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
    /// Class representing a collection of <see cref="Genre"/>
    /// </summary>
    public class GenreCollection : List<Genre>
    {
        #region Constructor
        public GenreCollection()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Get all existing <see cref="Genre"/>
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
                    dataSet = sqlLibrary.Get_Genre_All();
                }

                if (dataSet.Tables.Count == 1
                    && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow tmpDr in dataSet.Tables[0].Rows)
                    {
                        this.Add(new Genre(tmpDr));
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
        /// Gets all existing <see cref="Genre"/> having the <see cref="Movie"/> whose id is in parameter
        /// </summary>
        /// <param name="movieId">id of the <see cref="Movie"/></param>
        /// <returns>true if success</returns>
        public bool Get_ByMovieId(int movieId)
        {
            bool returnValue;
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlLibrary sqlLibrary = new SqlLibrary())
                {
                    dataSet = sqlLibrary.Get_Genre_ByMovieId(movieId);
                }

                if (dataSet.Tables.Count == 1
                    && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow tmpDr in dataSet.Tables[0].Rows)
                    {
                        this.Add(new Genre(tmpDr));
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