using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenceCreator
{
    class Program
    {
        static void Main(string[] args)
        {

            //string filename = @"C:/Users/Татьяна/Desktop/Институт/бд курсач/Staff_database/Staff_database/src/licence.xml";
            string filename = @"licence.xml";

            XML_WR xml_mr = new XML_WR();
            xml_mr.createXML(filename, "licence");

            LicenceCreator creator = new LicenceCreator();

            string salt = creator.generateSalt();
            string licence = creator.generateLicence(salt, creator.getProcessId());

            xml_mr.AppendAttribute(filename, "saltId", "salt", salt);
            xml_mr.AppendAttribute(filename, "licenceId", "licence", licence);
        }
    }
}
