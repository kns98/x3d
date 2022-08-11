using System;
using System.Xml;

namespace X3d.Core
{
    public class Import : SceneGraphStructureNodeType, ChildContentModelSceneGraphStructure
    {
        public const string ElementName = "IMPORT";

        public const string InlineDEFAttributeName = "inlineDEF";

        public const string ImportedDEFAttributeName = "importedDEF";

        public const string ASAttributeName = "AS";

        private string importedDEF;

        private string inlineDEF;

        public Import()
        {
            InlineDEF = string.Empty;
            ImportedDEF = string.Empty;
            AS = null;
        }

        public string InlineDEF
        {
            get => inlineDEF;

            set
            {
                if (value == null) throw new FormatException();

                inlineDEF = value;
            }
        }

        public string ImportedDEF
        {
            get => importedDEF;

            set
            {
                if (value == null) throw new FormatException();

                importedDEF = value;
            }
        }

        public string AS { get; set; }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            writer.WriteAttributeString(InlineDEFAttributeName, InlineDEF);
            writer.WriteAttributeString(ImportedDEFAttributeName, ImportedDEF);

            if (AS != null) writer.WriteAttributeString(ASAttributeName, AS);

            writer.WriteEndElement();
        }
    }
}