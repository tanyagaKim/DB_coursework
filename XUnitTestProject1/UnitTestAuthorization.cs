using System;
using Xunit;
using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStartPage
{
    public class UnitTestAuthorization
    {
        [Fact]
        public void TestMockLoginDB()
        {
            Mock<Staff_database.Authorization> mock = new Mock<Staff_database.Authorization>();

            mock.Setup(a => a.loginDB("root", "root")).Returns(true);

            //mock.Setup(a => a.loginDB(It.IsAny<string>(), It.IsAny<string>())).Returns((string login, string password) => login == "root" && password == "root");

            Staff_database.Authorization rep = mock.Object;
            Assert.Equals(rep.loginDB("root", "root"), true);
            /*
            foreach (var p in persons)
            {
                Console.WriteLine(rep.loginDB(p.Login, p.Password));
            }
            */
            Console.ReadLine();
        }
    }
}
