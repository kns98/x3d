using System;
using System.Xml;

namespace X3d.Core
{
    public class Export : SceneGraphStructureNodeType, ChildContentModelSceneGraphStructure
    {
        public const string ElementName = "IMPORT";

        public const string LocalDEFAttributeName = "localDEF";

        public const string ASAttributeName = "AS";

        private string localDEF;

        public Export()
        {
            LocalDEF = string.Empty;
            AS = null;
        }

        public string LocalDEF
        {
            get => localDEF;

            set
            {
                if (value == null) throw new FormatException();

                localDEF = value;
            }
        }

        public string AS { get; set; }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            writer.WriteAttributeString(LocalDEFAttributeName, LocalDEF);

            if (AS != null) writer.WriteAttributeString(ASAttributeName, AS);

            writer.WriteEndElement();
        }
    }
}