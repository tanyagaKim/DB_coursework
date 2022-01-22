using System;
using System.Management;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine("cpuInfo");

            Console.ReadLine();
        }
    }
}
