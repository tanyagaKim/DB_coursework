using System;
using System.Xml;
using System.Management;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Staff_database
{
    public class LicenceChecker
    {
        private string getHashed(string str_salt, string password)
        {
            byte[] salt = Convert.FromBase64String(str_salt);

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        private string getSalt()
        {
            string salt = string.Empty;

            XmlTextReader reader = null;

            try
            {
                //reader = new XmlTextReader(@"C:/Users/Татьяна/Desktop/Институт/бд курсач/Staff_database/Staff_database/src/licence.xml");
                reader = new XmlTextReader(@"licence.xml");

                reader.ReadToFollowing("saltId");
                reader.MoveToFirstAttribute();
                salt = reader.Value;
            }

            catch
            {
                throw new Exception("Licence open error");
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return salt;
        }

        private string getLicenceId()
        {
            string licenceId = string.Empty;

            XmlTextReader reader = null;

            try
            {
                //reader = new XmlTextReader(@"C:/Users/Татьяна/Desktop/Институт/бд курсач/Staff_database/Staff_database/src/licence.xml");
                reader = new XmlTextReader(@"licence.xml");

                reader.ReadToFollowing("licenceId");
                reader.MoveToFirstAttribute();
                licenceId = reader.Value;
            }

            catch
            {
                throw new Exception("Licence open error");
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return licenceId;
        }

        private string getProcessId()
        {
            string cpuInfo = string.Empty;
            
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                cpuInfo = managObj.Properties["processorID"].Value.ToString();
                break;
            }

            return cpuInfo;
            
        }

        public bool checkProcess()
        {
            bool flag = false;

            string salt = getSalt();
            string cpuInfo = getProcessId();
            string generateId = getHashed(salt, cpuInfo);

            string licenceId = getLicenceId();

            if (licenceId == string.Empty)
            {
                throw new Exception("Wrong licence");
            }

            if (licenceId != string.Empty && generateId == licenceId) flag = true;
            
            return flag;
        }

    }
}
