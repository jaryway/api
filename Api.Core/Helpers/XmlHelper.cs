using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Api.Core.Helpers
{
    /// <summary>
    /// xml帮助类，用于对象/xml转换，注意：对象必须加XmlRoot标记
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T Deserialize<T>(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            return Deserialize<T>(reader.ReadToEnd());
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">反序列化目标对象</typeparam>
        /// <param name="source">序列化的字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string source)
        {
            var stringReader = new StringReader(source);
            var serializer = new XmlSerializer(typeof(T));
            T result = (T)serializer.Deserialize(stringReader);
            stringReader.Dispose();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(Stream stream)
        {
            var doc = XDocument.Load(stream);
            return doc.Elements().Elements().ToDictionary(k => k.Name.LocalName, v => v.Value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(string xml)
        {
            var doc = XDocument.Parse(xml);
            return doc.Elements().Elements().ToDictionary(k => k.Name.LocalName, v => v.Value);
        }

        /// <summary>
        /// 序列化成字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="removeNamespace">是否是仅元素，true则只包含属性标签，不包含root节点</param>
        /// <returns></returns>
        public static string Serialize<T>(T source, bool removeNamespace = true)
        {
            var stream = SerializeObject<T>(source);
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);

            if (removeNamespace)
                return RemoveAllNamespaces(XElement.Parse(xmlDoc.InnerXml)).ToString();
            else
                return xmlDoc.InnerXml;

        }

        /// <summary>
        /// 序列化成Stream
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Stream SerializeObject<T>(T source)
        {
            var serializer = new XmlSerializer(typeof(T));

            Stream stream = new MemoryStream();
            serializer.Serialize(stream, source);
            stream.Position = 0;
            return stream;
        }
        /// <summary>
        /// 移除命名空间
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        public static string RemoveAllNamespaces(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));
            return xmlDocumentWithoutNs.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }
    }
}
