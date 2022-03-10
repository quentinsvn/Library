using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

        #region DataTestMethod
        public static IEnumerable<object[]> TestSetMovieDataProvider()
        {
            yield return new object[]
            {
                -1,
                "MovieTitle",
                DateTime.Now,
                true,
                "Add new movie"
            };

            yield return new object[]
            {
                9999999,
                "MovieTitle",
                DateTime.Now,
                false,
                "Update not existing movie"
            };
        }

        [DataTestMethod]
        [DynamicData(nameof(TestSetMovieDataProvider), DynamicDataSourceType.Method)]
        public void TestSetMovie2(int id, string title, DateTime date, bool expectedResult, string dataTestName)
        {
            int newId;
            using (SqlLibrary sqlLibrary = new SqlLibrary())
            {
                newId = sqlLibrary.Set_Movie(id, title, date, null);
            }

            Assert.AreEqual(expectedResult, newId != -1, dataTestName);
        }
        #endregion
    }
}
