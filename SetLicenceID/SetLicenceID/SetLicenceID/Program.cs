using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Text.RegularExpressions;


namespace SetLicenceID
{
    class Program
    {
        static public string getProcessId()
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

        static public string getLicenceProccessId(string path)
        {
            string licID = null;

            string[] readText = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string s in readText)
            {
                bool result = Regex.IsMatch(s, "\\blicenceId\\b");
                if (result)
                {
                    int start = s.IndexOf("\"") + 1;
                    int end = s.LastIndexOf("\"") - 1;
                    licID = s.Substring(start, end - start + 1);
                    break;
                }
            }

            return licID;
        }

        static public void setLicenceProccessId(string path, string licID)
        {
            string text = File.ReadAllText(path);
            text = text.Replace(licID, getProcessId());
            File.WriteAllText(path, text);
        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\Татьяна\Desktop\Институт\бд курсач\Staff_database\SetLicenceID\SetLicenceID\SetLicenceID\Licence.txt";
            string licID = null;

            try
            {
                licID = getLicenceProccessId(path);
                setLicenceProccessId(path, licID);                
            }
            catch
            {
                Console.WriteLine("Error access: must be Licence.txt");
            }
                        
            Console.ReadLine();
        }
    }
}
