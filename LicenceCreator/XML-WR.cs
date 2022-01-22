using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace LicenceCreator
{
    class XML_WR
    {
        public void createXML(string name, string root)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement(root);

            xmlDoc.AppendChild(rootNode);
            xmlDoc.Save(name);
        }

        public XmlNode getRootNode(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(name);
            return xmlDoc.DocumentElement;
        }

        public void AppendAttribute(string name, string item, string attribute, string value, string innerText = null)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(name);
            XmlNode rootNode = xmlDoc.DocumentElement;

            XmlNode node = xmlDoc.CreateElement(item);
            XmlAttribute attr = xmlDoc.CreateAttribute(attribute);
            attr.Value = value;

            node.Attributes.Append(attr);
            node.InnerText = innerText;

            rootNode.AppendChild(node);
            xmlDoc.Save(name);
        }
    }
}
