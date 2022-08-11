using System;
using System.Xml;

namespace X3d.Core
{
    public class Route : SceneGraphStructureNodeType, ChildContentModelSceneGraphStructure
    {
        public const string ElementName = "ROUTE";
        public const string FromNodeAttributeName = "fromNode";
        public const string FromFieldAttributeName = "fromField";
        public const string ToNodeAttributeName = "toNode";
        public const string ToFieldAttributeName = "toField";

        private string fromField;

        private string fromNode;

        private string toField;

        private string toNode;

        public string FromNode
        {
            get => fromNode;

            set
            {
                if (fromNode == null) throw new FormatException();

                fromNode = value;
            }
        }

        public string FromField
        {
            get => fromField;

            set
            {
                if (fromField == null) throw new FormatException();

                fromField = value;
            }
        }

        public string ToNode
        {
            get => toNode;

            set
            {
                if (toNode == null) throw new FormatException();

                toNode = value;
            }
        }

        public string ToField
        {
            get => toField;

            set
            {
                if (toField == null) throw new FormatException();

                toField = value;
            }
        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            writer.WriteAttributeString(FromNodeAttributeName, FromNode);
            writer.WriteAttributeString(FromFieldAttributeName, FromField);
            writer.WriteAttributeString(ToNodeAttributeName, ToNode);
            writer.WriteAttributeString(ToFieldAttributeName, ToField);

            writer.WriteEndElement();
        }
    }
}