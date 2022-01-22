using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestStartPage
{
    [TestClass]
    class TestAuthorization
    {
        class Person
        {
            public string Login { get; set; }
            public string Password { get; set; }

            public Person()
            {
                Login = "unknow";
                Password = "unknow";
            }
        }

        [TestMethod]
        public void TestMockLoginDB()
        {
            Person[] persons = {
                                    new Person(){Login="root",Password="root" },
                                    new Person(){Login="Ann",Password="qwerty" },
                                    new Person(){Login="1234",Password="12345" },
                                    new Person(){Login="root",Password="qwerty" }
                                  };

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
