using System.Xml;

namespace X3d.Core
{
    public class ProtoDeclare : X3DPrototype, ChildContentModelSceneGraphStructure
    {
        public const string ElementName = "ProtoDeclare";

        public const string AppInfoAttributeName = "appinfo";

        public const string DocumentationAttributeName = "documentation";

        public ProtoDeclare()
        {
            Interface = null;
            Body = null;
            AppInfo = null;
            Documentation = null;
        }

        public ProtoInterface Interface { get; set; }

        public ProtoBody Body { get; set; }

        public SFString AppInfo { get; set; }

        public SFString Documentation { get; set; }

        protected override void WriteAttributes(XmlWriter writer)
        {
            base.WriteAttributes(writer);

            if (AppInfo != null) writer.WriteAttributeString(AppInfoAttributeName, AppInfo.ToString());

            if (Documentation != null)
                writer.WriteAttributeString(DocumentationAttributeName, Documentation.ToString());
        }

        protected override void WriteChildElements(XmlWriter writer)
        {
            base.WriteChildElements(writer);

            if (Interface != null) Interface.Write(writer);

            if (Body != null) Body.Write(writer);
        }

        public override void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            base.Write(writer);

            writer.WriteEndElement();
        }
    }
}