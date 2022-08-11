using System;
using System.Collections.Generic;
using System.Xml;

namespace X3d.Core
{
    public class ProtoInterface : SceneGraphStructureNodeType
    {
        public const string ElementName = "ProtoInterface";

        private List<Field> fields;

        public ProtoInterface()
        {
            Fields = new List<Field>();
        }

        public List<Field> Fields
        {
            get => fields;

            set
            {
                if (value == null) throw new FormatException();

                fields = value;
            }
        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            foreach (var item in Fields) item.Write(writer);

            writer.WriteEndElement();
        }
    }
}