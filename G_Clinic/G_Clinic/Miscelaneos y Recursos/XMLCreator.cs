using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    class XMLCreator
    {
        XmlDocument xmldoc = null;
        XmlNode xmlRoot, xmlNode;

        string pathXml = "";
        public string PathXml
        {
            get { return pathXml; }
            set { pathXml = value; }
        }

        int nodeCount = 0;

        public void CreateXMLDocument(string pPath, string primaryNode)
        {
            xmldoc = new XmlDocument();

            pathXml = pPath;
            nodeCount = 0;

            if (!File.Exists(pPath.Trim()))
            {
                xmlRoot = xmldoc.CreateElement(primaryNode);
                nodeCount = 0;
            }
            else
            {
                xmldoc.Load(pathXml.Trim());
                xmlRoot = xmldoc.SelectSingleNode("/" + primaryNode);
                nodeCount = xmldoc.ChildNodes.Count;
            }
        }

        public void AddChildNodes(string pChildNodeName, string pValue)
        {
            nodeCount++;

            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement(pChildNodeName);
            xmlRoot.AppendChild(xmlNode);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(pValue);

            xmldoc.Save(pathXml.Trim());
        }

        public string ReadNodes(string pSelectedNodes)
        {
            string node = "";

            if (File.Exists(pathXml.Trim()))
            {
                xmldoc = new XmlDocument();
                XmlNodeList m_nodelist = null;

                xmldoc.Load(pathXml.Trim());

                m_nodelist = xmldoc.SelectNodes(pSelectedNodes);//"/Logins/User");

                foreach (XmlNode Nodo in m_nodelist)
                    node = Encrypt_Decrypt.Desencriptar(Nodo.ChildNodes.Item(0).Value.ToString());
            }

            return node;
        }
    }
}
