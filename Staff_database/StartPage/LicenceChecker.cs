using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Staff_database
{
    public class LicenceChecker
    {
        private readonly IReader _reader;
        private readonly IWMI _wmi;

        public LicenceChecker(IReader reader, IWMI wmi)
        {
            _reader = reader;
            _wmi = wmi;
        }

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
            string filename = @"C:/Users/Татьяна/Desktop/Институт/бд курсач/Staff_database/Staff_database/src/licence.xml";

            try
            {
                salt = _reader.readAttribute(filename, "salt", "saltId");
            }

            catch
            {
                throw new Exception("Licence open error");
            }

            return salt;
        }

        private string getLicenceId()
        {
            string licenceId = string.Empty;
            string filename = @"C:/Users/Татьяна/Desktop/Институт/бд курсач/Staff_database/Staff_database/src/licence.xml";

            try
            {
                licenceId = _reader.readAttribute(filename, "licence", "licenceId"); 
            }

            catch
            {
                throw new Exception("Licence open error");
            }

            return licenceId;
        }

        private string getProcessId()
        {
            return _wmi.getProcessId();            
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
