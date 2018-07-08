using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;

namespace G_Clinic.Miscelaneos_y_Recursos
{
    class RecoveryXMLFile
    {
        public void Consultas_CreateRecoveryXMLFile(string pDetalleConsulta, string pDiagnostico, string pTratamiento,
                                                    ArrayList pExamenes, ArrayList pDetalleExamenes, ArrayList pGabinete, ArrayList pDetalleGabinete, 
                                                    ArrayList pImagenes, ArrayList pVideos)
        {
            string path = Metodos_Globales.crearCarpetaAppdata("\\RecoveryFiles");

            int nodeCount = 0;
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlRoot, xmlNode;

            string PathXml = path + "\\Recovery.xml";

            if (!File.Exists(PathXml.Trim()))
            {
                xmlRoot = xmldoc.CreateElement("Main");
                nodeCount = 0;
            }
            else
            {
                xmldoc.Load(PathXml.Trim());
                xmlRoot = xmldoc.SelectSingleNode("/Main");
                nodeCount = xmldoc.ChildNodes.Count;
            }

            nodeCount++;

            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("DetalleConsulta");
            xmlRoot.AppendChild(xmlNode);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(pDetalleConsulta.Trim());

            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("Diagnostico");
            xmlRoot.AppendChild(xmlNode);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(pDiagnostico.Trim());

            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("Tratamiento");
            xmlRoot.AppendChild(xmlNode);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(pTratamiento.Trim());


            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("Examenes");
            xmlRoot.AppendChild(xmlNode);
            string examenes = "";
            foreach (string oString in pExamenes) 
                 examenes = oString + "/";
            if (examenes.EndsWith("/"))
                examenes = examenes.Substring(0, examenes.Length - 1);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(examenes);

            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("DetalleExamenes");
            xmlRoot.AppendChild(xmlNode);
            string detalle_examenes = "";
            foreach (string oString in pDetalleExamenes)
                detalle_examenes = oString + "/";
            if (detalle_examenes.EndsWith("/"))
                detalle_examenes = detalle_examenes.Substring(0, detalle_examenes.Length - 1);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(detalle_examenes);


            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("Gabinete");
            xmlRoot.AppendChild(xmlNode);
            string gabinete = "";
            foreach (string oString in pGabinete)
                gabinete = oString + "/";
            if (gabinete.EndsWith("/"))
                gabinete = gabinete.Substring(0, gabinete.Length - 1);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(gabinete);

            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("DetalleGabinete");
            xmlRoot.AppendChild(xmlNode);
            string detalle_gabinete = "";
            foreach (string oString in pDetalleGabinete)
                detalle_gabinete = oString + "/";
            if (detalle_gabinete.EndsWith("/"))
                detalle_gabinete = detalle_gabinete.Substring(0, detalle_gabinete.Length - 1);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(detalle_gabinete);



            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("Imagenes");
            xmlRoot.AppendChild(xmlNode);
            string imagenes = "";
            foreach (string oString in pImagenes)
                imagenes = oString + "|";
            if (imagenes.EndsWith("|"))
                imagenes = imagenes.Substring(0, imagenes.Length - 1);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(imagenes.Trim());

            xmldoc.AppendChild(xmlRoot);
            xmlNode = xmldoc.CreateElement("Videos");
            xmlRoot.AppendChild(xmlNode);
            string videos = "";
            foreach (string oString in pVideos)
                videos = oString + "|";
            if (videos.EndsWith("|"))
                videos = videos.Substring(0, videos.Length - 1);
            xmlNode.InnerText = Encrypt_Decrypt.Encriptar(videos.Trim());
            
            xmldoc.Save(PathXml.Trim());
        }
    }
}
