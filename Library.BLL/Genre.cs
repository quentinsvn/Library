using Library.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL
{
    /// <summary>
    /// Class representing a <see cref="Genre"/> of a <see cref="Movie"/> <see cref="Genre"/>
    /// </summary>
    public class Genre
    {
        #region Properties
        /// <summary>
        /// <see cref="Genre"/> id
        /// </summary>
        public int Id { get; set; } = -1;

        /// <summary>
        /// <see cref="Genre"/> name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Genre()
        {

        }

        /// <summary>
        /// Constructor with data from db
        /// </summary>
        /// <param name="dataRow"><see cref="DataRow"/> comming from db</param>
        public Genre(DataRow dataRow)
        {
            FillFromDataRow(dataRow);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the <see cref="Genre"/> by its id
        /// </summary>
        /// <param name="id">Id of the <see cref="Genre"/></param>
        /// <returns>true if success</returns>
        public bool GetById(int id)
        {
            using (SqlLibrary sqlLibrary = new SqlLibrary())
            {
                DataSet ds = sqlLibrary.Get_Genre_ById(id);

                if (ds.Tables.Count == 1
                    && ds.Tables[0].Rows.Count == 1)
                {
                    DataTable dt = ds.Tables[0];
                    DataRow dr = dt.Rows[0];

                    FillFromDataRow(dr);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Save or update the <see cref="Genre"/>
        /// </summary>
        /// <returns>true if success</returns>
        public bool Set()
        {
            using (SqlLibrary sqlLibrary = new SqlLibrary())
            {
                Id = sqlLibrary.Set_Genre(Id, Name);
            }

            return Id != -1;
        }

        /// <summary>
        /// Delete the <see cref="Genre"/>
        /// </summary>
        /// <returns>true if success</returns>
        public bool Delete()
        {
            using (SqlLibrary sqlLibrary = new SqlLibrary())
            {
                return sqlLibrary.Delete_Genre_ById(Id);
            }
        }

        /// <summary>
        /// Hydrate the <see cref="Genre"/> with data in parameter
        /// </summary>
        /// <param name="dr"><see cref="DataRow"/> comming from db</param>
        private void FillFromDataRow(DataRow dr)
        {
            Id = (int)dr["Id"];
            Name = (string)dr["Name"];
        }
        #endregion
    }
}