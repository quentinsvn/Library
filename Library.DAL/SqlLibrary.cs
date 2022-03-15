using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class SqlLibrary : IDisposable
    {
        #region Vars
        private SqlConnection sqlConnection = null;
        #endregion

        #region Constructor
        public SqlLibrary()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString);
            sqlConnection.Open();
        }
        #endregion

        #region Methods
        #region Movie
        public int Set_Movie(int id, string title, DateTime date, string imageUrl)
        {
            int returnValue;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Set_Movie", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Title", title);

                if (date == DateTime.MinValue)
                    sqlCommand.Parameters.AddWithValue("@Date", DBNull.Value);
                else
                    sqlCommand.Parameters.AddWithValue("@Date", date);


                if (string.IsNullOrEmpty(imageUrl))
                    sqlCommand.Parameters.AddWithValue("@ImageUrl", DBNull.Value);
                else
                    sqlCommand.Parameters.AddWithValue("@ImageUrl", imageUrl);

                sqlCommand.Parameters.Add("@OutputId", SqlDbType.Int);
                sqlCommand.Parameters["@OutputId"].Direction = ParameterDirection.Output;

                sqlCommand.ExecuteNonQuery();

                returnValue = (int)sqlCommand.Parameters["@OutputId"].Value;
            }
            catch (Exception e)
            {
                // Do something
                returnValue = -1;
            }

            return returnValue;
        }

        public bool Delete_Movie_ById(int id)
        {
            bool returnValue;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Delete_Movie_ById", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);

                sqlCommand.ExecuteNonQuery();

                returnValue = true;
            }
            catch
            {
                // Handle error
                returnValue = false;
            }

            return returnValue;
        }

        public DataSet Get_Movie_All()
        {
            DataSet returnValue = new DataSet();

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Get_Movie_All", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(returnValue);
            }
            catch
            {
                // Handle error
                returnValue = new DataSet();
            }

            return returnValue;
        }

        public DataSet Get_Movie_ByGenreId(int genreId)
        {
            DataSet returnValue = new DataSet();

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Get_Movie_ByGenreId", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@GenreId", genreId);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(returnValue);
            }
            catch
            {
                // Handle error
                returnValue = new DataSet();
            }

            return returnValue;
        }

        public DataSet Get_Movie_ById(int id)
        {
            DataSet returnValue = new DataSet();

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Get_Movie_ById", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", id);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(returnValue);
            }
            catch
            {
                // Handle error
                returnValue = new DataSet();
            }

            return returnValue;
        }
        #endregion

        #region Genre
        public int Set_Genre(int id, string name)
        {
            int returnValue;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Set_Genre", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Name", name);

                sqlCommand.Parameters.Add("@OutputId", SqlDbType.Int);
                sqlCommand.Parameters["@OutputId"].Direction = ParameterDirection.Output;

                sqlCommand.ExecuteNonQuery();

                returnValue = (int)sqlCommand.Parameters["@OutputId"].Value;
            }
            catch
            {
                // Do something
                returnValue = -1;
            }

            return returnValue;
        }

        public bool Delete_Genre_ById(int id)
        {
            bool returnValue;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Delete_Genre_ById", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);

                sqlCommand.ExecuteNonQuery();

                returnValue = true;
            }
            catch
            {
                // Handle error
                returnValue = false;
            }

            return returnValue;
        }

        public DataSet Get_Genre_All()
        {
            DataSet returnValue = new DataSet();

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Get_Genre_All", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(returnValue);
            }
            catch
            {
                // Handle error
                returnValue = new DataSet();
            }

            return returnValue;
        }

        public DataSet Get_Genre_ByMovieId(int movieId)
        {
            DataSet returnValue = new DataSet();

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Get_Genre_ByMovieId", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@MovieId", movieId);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(returnValue);
            }
            catch
            {
                // Handle error
                returnValue = new DataSet();
            }

            return returnValue;
        }

        public DataSet Get_Genre_ById(int id)
        {
            DataSet returnValue = new DataSet();

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Get_Genre_ById", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@id", id);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(returnValue);
            }
            catch
            {
                // Handle error
                returnValue = new DataSet();
            }

            return returnValue;
        }
        #endregion

        #region Link_MovieGenre
        public bool Set_Link_MovieGenre(int movieId, int genreId)
        {
            bool returnValue;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Set_Link_MovieGenre", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@MovieId", movieId);
                sqlCommand.Parameters.AddWithValue("@GenreId", genreId);

                sqlCommand.ExecuteNonQuery();

                returnValue = true;
            }
            catch
            {
                // Do something
                returnValue = false;
            }

            return returnValue;
        }

        public bool Delete_Link_MovieGenre_ByMovieId(int movieId)
        {
            bool returnValue;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("Delete_Link_MovieGenre_ByMovieId", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@MovieId", movieId);

                sqlCommand.ExecuteNonQuery();

                returnValue = true;
            }
            catch
            {
                // Do something
                returnValue = false;
            }

            return returnValue;
        }


        #endregion
        #endregion

        #region IDisposable
        /// <summary>
        /// Dispose object
        /// </summary>
        public void Dispose()
        {
            sqlConnection?.Dispose();

            /*if (mSqlConection != null)
            {
                mSqlConection.Dispose();
            }*/
        }
        #endregion
    }
}