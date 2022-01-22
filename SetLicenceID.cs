using System;
using System.Management;

void setLicenceId()
{

    bool flag = false;
    string cpuInfo = string.Empty;
    ManagementClass managClass = new ManagementClass("win32_processor");
    ManagementObjectCollection managCollec = managClass.GetInstances();

    foreach (ManagementObject managObj in managCollec)
    {
        cpuInfo = managObj.Properties["processorID"].Value.ToString();
        break;
    }

    Console.WriteLine(cpuInfo);

}

setLicenceId();