using NUnit.Framework;
using System.Windows.Forms;
using System.Xml;
using System.Management;

namespace Tests
{
    [TestFixture]
    public class LicenceCheckerTest
    {
        // Проверка на некоректных данных входа в БД

        [Test]
        public void TestCheckProcess()
        {
            Staff_database.LicenceChecker instance = new Staff_database.LicenceChecker();
            Assert.True(instance.checkProcess());
        }
    }
}
