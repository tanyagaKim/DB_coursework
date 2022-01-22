using System;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStartPage
{
    [TestClass]
    public class UnitTestAuthorization
    {
        [TestMethod]
        public void TestGetHashed()
        {
            // arange
            string salt = "";
            string password = "root";
            string expected = "";

            // act
            Staff_database.Authorization login = new Staff_databaseAuthorization();
            string actual = login.getHashed(salt, password);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
