using System.Xml;

namespace X3d.Core
{
    /// <summary>
    ///     The metadata provided by this node is contained in the double-precision
    ///     floating point numbers of the value field.
    /// </summary>
    public class MetadataDouble : X3DMetadataObject<MFDouble>
    {
        public const string ElementName = "MetadataDouble";

        protected override void WriteAttributes(XmlWriter writer)
        {
            base.WriteAttributes(writer);

            if (Value.Count > 0) writer.WriteAttributeString(ValueAttributeName, Value.ToString());
        }

        public override void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            base.Write(writer);

            writer.WriteEndElement();
        }
    }
}