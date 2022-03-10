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
        private SqlConnection sqlConnection = null;


        #region constructor
        public SqlLibrary()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString);
            sqlConnection.Open();
        }
        #endregion

        #region Methods
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
        #endregion

        #region IDisposable
        public void Dispose()
        {
            sqlConnection?.Close();
            
            /*if (sqlConnection != null)
            {
                sqlConnection.Close();
            }*/
        }
        #endregion
    }
}
