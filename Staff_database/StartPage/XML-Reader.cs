using System;
using System.Xml;

namespace Staff_database
{
    public class XML_Reader : IReader
    {
        public string readAttribute(string name, string item=null, string attribute=null)
        {
            string value = string.Empty;
            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(name);
            }
            catch
            {
                throw new Exception("Error open file");
            }

            try
            {
                if (attribute != null)
                {
                    reader.ReadToFollowing(attribute);
                }

                reader.MoveToContent();
                value = reader.GetAttribute(item);
            }

            catch
            {
                throw new Exception("Error get attribute "+ item + " from node " + attribute +" from file " + name);
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return value;
        }
    }
}
