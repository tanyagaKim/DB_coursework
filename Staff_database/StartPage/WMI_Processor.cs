using System.Management;

namespace Staff_database
{
    public class WMI_Processor : IWMI
    {
        public string getProcessId()
        {
            string processorID = string.Empty;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                processorID = obj["processorID"].ToString();
            }

            return processorID;

        }
    }
}
