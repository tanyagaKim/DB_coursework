using System;

namespace LicenceCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "licence.xml";

            XML_WR xml_mr = new XML_WR();
            xml_mr.createXML(filename, "licence");

            LicenceCreator creator = new LicenceCreator();
            string processorID = creator.getProcessId();
            string keyValue = creator.getHashed("", processorID);

            xml_mr.AppendAttribute(filename, "licenceId", "key", "123456");
        }
    }
}
