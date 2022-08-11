﻿using System.Collections.Generic;
using System.Xml;

namespace X3d.Core
{
    /// <summary>
    ///     The metadata provided by this node is contained in the metadata nodes of
    ///     the value field.
    /// </summary>
    public class MetadataSet : X3DMetadataObject<List<ChildContentModelCore>>, ChildContentModelCore
    {
        public const string ElementName = "MetadataSet";

        protected override void WriteChildElements(XmlWriter writer)
        {
            base.WriteChildElements(writer);

            foreach (var item in Value) ((X3DMetadataObject)item).Write(writer);
        }

        public override void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            base.Write(writer);

            writer.WriteEndElement();
        }
    }
}