﻿/*  
* Copyright (c) 2017, Furore (info@furore.com) and contributors 
* See the file CONTRIBUTORS for details. 
*  
* This file is licensed under the BSD 3-Clause license 
* available at https://raw.githubusercontent.com/ewoutkramer/fhir-net-api/master/LICENSE 
*/

using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Utility;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Hl7.Fhir.Serialization
{
    public partial struct XmlDomFhirParser
    {
        public static IElementNavigator Create(XmlReader reader, IModelMetadataProvider metadataProvider)
        {
            if (reader == null) throw Error.ArgumentNull(nameof(reader));
            if (metadataProvider == null) throw Error.ArgumentNull(nameof(metadataProvider));
            XDocument doc = null;

            try
            {
                doc = XDocument.Load(wrapXmlReader(reader));
            }
            catch (XmlException xec)
            {
                throw Error.Format("Cannot parse xml: " + xec.Message);
            }

            return new XmlDomFhirParser(doc.Root, metadataProvider);
        }

        public static IElementNavigator Create(XDocument doc, IModelMetadataProvider metadataProvider)
        {
            if (doc == null) throw Error.ArgumentNull(nameof(doc));
            if (metadataProvider == null) throw Error.ArgumentNull(nameof(metadataProvider));

            return new XmlDomFhirParser(doc.Root, metadataProvider);
        }

        public static IElementNavigator Create(XElement elem, IModelMetadataProvider metadataProvider)
        {
            if (elem == null) throw Error.ArgumentNull(nameof(elem));
            if (metadataProvider == null) throw Error.ArgumentNull(nameof(metadataProvider));

            return new XmlDomFhirParser(elem, metadataProvider);
        }

        public static IElementNavigator Create(string xml, IModelMetadataProvider metadataProvider)
        {
            if (xml == null) throw Error.ArgumentNull(nameof(xml));
            if (metadataProvider == null) throw Error.ArgumentNull(nameof(metadataProvider));

            using (var reader = xmlReaderFromText(xml))
            {
                return Create(reader, metadataProvider);
            }
        }

        private static XmlReader xmlReaderFromText(string xml) =>
            wrapXmlReader(XmlReader.Create(new StringReader(xml)));

        private static XmlReader wrapXmlReader(XmlReader xmlReader)
        {
            var settings = new XmlReaderSettings
            {
                IgnoreProcessingInstructions = true,
                DtdProcessing = DtdProcessing.Prohibit
            };

            return XmlReader.Create(xmlReader, settings);
        }

    }
}
