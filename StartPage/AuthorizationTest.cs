using NUnit.Framework;
using System.Data.SqlClient;
using Moq;

namespace Tests
{
    [TestFixture]
    public class AuthorizationTests
    {
        // �������� �� ����������� ���� ������ ��� �����

        [TestCase(null, null)]
        public void EmptyTestLoginDB(string login, string password)
        {
            Staff_database.Authorization entry = new Staff_database.Authorization();

            Assert.False(entry.loginDB(login, password));
        }

        // �������� �� ����������� ���� ������ ��� �����

        [TestCase("root", "root")]
        public void NegativeTestLoginDB(string login, string password)
        {
            Staff_database.Authorization entry = new Staff_database.Authorization();

            Assert.False(entry.loginDB(login, password));
        }

        // �������� �� �������� ����

        [TestCase("zero", "zero")]
        public void PositiveTestLoginDB(string login, string password)
        {
            Staff_database.Authorization entry = new Staff_database.Authorization();

            Assert.True(entry.loginDB(login, password));
        }
    }
}
 