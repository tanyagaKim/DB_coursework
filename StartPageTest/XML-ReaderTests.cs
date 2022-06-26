using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class XML_ReaderTests
    {
        // Проверка на null-файл
        [TestCase(null, null, null)]
        public void NullTestXMLReader(string filename, string item, string attribute)
        {
            Staff_database.XML_Reader reader = new Staff_database.XML_Reader();
              
            var ex = Assert.Throws<System.Exception>(() => reader.readAttribute(filename, item, attribute));

            Assert.That(ex.Message, Is.EqualTo("Error open file"));
        }

        // Проверка на несуществующий файл
        [TestCase(@"C:/Users/Татьяна/empty.xml", null, null)]
        public void EmptyTestXMLReader(string filename, string item, string attribute)
        {
            Staff_database.XML_Reader reader = new Staff_database.XML_Reader();

            var ex = Assert.Throws<System.Exception>(() => reader.readAttribute(filename, item, attribute));

            Assert.That(ex.Message, Is.EqualTo("Error get attribute  from node  from file C:/Users/Татьяна/empty.xml"));
        }

        // Проверка на успешное чтение
        [TestCase(@"C:/Users/Татьяна/Desktop/Институт/бд курсач/Staff_database/StartPageTest/src/noItem.xml", "name", "item")]
        public void PositiveTestXMLReader(string filename, string item, string attribute)
        {
            Staff_database.XML_Reader reader = new Staff_database.XML_Reader();

            var result = reader.readAttribute(filename, item, attribute);

            Assert.AreEqual("root", result);
        }
    }
}
