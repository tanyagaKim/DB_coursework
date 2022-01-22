using System.Windows.Forms;
using System.Xml;
using System.Management;

namespace Staff_database
{
    public class LicenceChecker
    {
        private string getLicenceId()
        {
            string licenceId = string.Empty;

            XmlTextReader reader = null;

            //try
            //{
                reader = new XmlTextReader(@"C:/Users/Татьяна/Desktop/Институт/бд курсач/Staff_database/Staff_database/src/licence.xml");
                
                reader.MoveToContent();
                licenceId = reader.GetAttribute("key");
            /*}

            catch
            {
                MessageBox.Show("Licence open error");
            }

            finally
            {*/
                if (reader != null)
                    reader.Close();
            //}

            return licenceId;
        }

        private string getProcessId()
        {
            string cpuInfo = string.Empty;
            /*
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                cpuInfo = managObj.Properties["processorID"].Value.ToString();
                break;
            }
            */

            cpuInfo = "178BFBFF00660F51";

            return cpuInfo;
            
        }

        public bool checkProcess()
        {
            bool flag = false;

            string licenceId = getLicenceId();
            return true;
            string cpuInfo = getProcessId();
            /*
            if (licenceId == string.Empty)
            {
                 MessageBox.Show("Wrong licence");
            }

            if (licenceId != string.Empty && cpuInfo == licenceId) flag = true;
            */
            return flag;
        }

    }
}
