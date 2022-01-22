using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Management;
using System.Windows.Forms;
using System.Xml;

namespace LicenceCreator
{
    class LicenceCreator
    {
        public string getProcessId()
        {
            string cpuInfo = string.Empty;
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                cpuInfo = managObj.Properties["processorID"].Value.ToString();
                break;
            }

            //cpuInfo = "178BFBFF00660F51";

            return cpuInfo;

        }

        public String getHashed(String str_salt, String password)
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
    }
}
