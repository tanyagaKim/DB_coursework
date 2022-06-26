using NUnit.Framework;
using Moq;
using System.Windows.Forms;
using System.Xml;
using System.Management;

namespace Tests
{
    [TestFixture]
    public class LicenceCheckerTest
    {
        // Проверка функции тестирования лицензии

        [Test]
        public void TestCheckProcess()
        {
            string filename = @"C:/Users/Татьяна/Desktop/Институт/бд курсач/Staff_database/Staff_database/src/licence.xml";

            var mockReader = new Mock<Staff_database.IReader>();
            mockReader.Setup(read => read.readAttribute(filename, "salt", "saltId")).Returns("gVY5hsxgC2tPsHHgjG3Ecg==");
            mockReader.Setup(read => read.readAttribute(filename, "licence", "licenceId")).Returns("WYtGw5uaM2dmJCICc/q6dizwqSjG7WIve+ZlOIjqHPo=");

            var mockWMI = new Mock<Staff_database.IWMI>();
            mockWMI.Setup(wmi => wmi.getProcessId()).Returns("178BFBFF00660F51");

            var licenceChecker = new Staff_database.LicenceChecker(mockReader.Object, mockWMI.Object);

            Assert.True(licenceChecker.checkProcess());
        }
    }
}
