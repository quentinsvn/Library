using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Library.DAL.Test
{
    [TestClass]
    public class UnitTest_Movie
    {
        [TestMethod]
        public void TestSetMovie()
        {
            int id = -1;
            string title = "MovieTitle";
            DateTime date = DateTime.Now;

            using (SqlLibrary sqlLibrary = new SqlLibrary())
            {
                id = sqlLibrary.Set_Movie(id, title, date, null);
            }

            Assert.AreNotEqual(-1, id, "id == -1");
        }
    }
}
