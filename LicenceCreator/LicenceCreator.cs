using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Management;
using System.Xml;

// Критерии выобра параметров для привязки: неизменяемость, уникальность, доступность.

namespace LicenceCreator
{
    class LicenceCreator
    {
        public string generateSalt()
        {
            string str_salt = string.Empty;

            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            str_salt = Convert.ToBase64String(salt);

            return str_salt;
        }

		// WMI - набор программных средств, обеспечивающих управление системой.
		
		// WMIC (Windows Management Instrumentation Command) - утилита команлной строки.
		// Используется для получения информации о системе и оборудовании.
		// (серийные номера, объем памяти, производитель, название устройств и прочие)
		// [ Также можно исп. для изменения настроек системы. ]
		
        public string getProcessId()
        {
            string cpuInfo = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                cpuInfo = obj["processorID"].ToString();
                //Console.WriteLine(cpuInfo);
                //Console.ReadLine();
            }

            return cpuInfo;

        }

        public String generateLicence(String str_salt, String password)
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
