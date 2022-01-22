using System;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestStaffDatabase
{
    [TestFixture]
    public class AuthorizationTest
    {
        // Проверка на некоректных данных входа в БД
        /*
        [TestCase("root", "root")]
        public void TestLoginDB(string login, string password)
        {
            // arange
            //bool expected = true;

            // act
           Staff_database.Authorization entry = new Staff_database.Authorization();
           //bool actual = entry.loginDB(login, password);

            // assert
            Assert.False(entry.loginDB(login, password));
        }
        */
        /*
        [Test]
        public void TestGetServer()
        {
            // arange
            string expected = "localhost";

            // act
            Staff_database.Authorization entry = new Staff_database.Authorization();
            string actual = entry.getServer();

            // assert
            Assert.AreEqual(expected, actual);
        }
        */
        [Test]
        public void TestSum()
        {
            // arange
            int a = 2;
            int b = 10;

            int expected = 12;

            // act
            Staff_database.Authorization entry = new Staff_database.Authorization();
            int actual = entry.sum(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }
        
    }
}
