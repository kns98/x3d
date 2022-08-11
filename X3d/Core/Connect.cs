using System;
using System.Xml;

namespace X3d.Core
{
    public class Connect : SceneGraphStructureNodeType
    {
        public const string ElementName = "connect";

        public const string NodeFieldAttributeName = "nodeField";

        public const string ProtoFieldAttributeName = "protoField";

        private string nodeField;

        private string protoField;

        public Connect()
        {
            NodeField = string.Empty;
            ProtoField = string.Empty;
        }

        public string NodeField
        {
            get => nodeField;

            set
            {
                if (value == null) throw new NullReferenceException();

                nodeField = value;
            }
        }

        public string ProtoField
        {
            get => protoField;

            set
            {
                if (value == null) throw new NullReferenceException();

                protoField = value;
            }
        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            writer.WriteAttributeString(NodeFieldAttributeName, NodeField);
            writer.WriteAttributeString(ProtoFieldAttributeName, ProtoField);

            writer.WriteEndElement();
        }
    }
}