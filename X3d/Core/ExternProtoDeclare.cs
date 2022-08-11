using System;
using System.Collections.Generic;
using System.Xml;

namespace X3d.Core
{
    public class ExternProtoDeclare : X3DPrototype, ChildContentModelSceneGraphStructure
    {
        public const string ElementName = "ExternProtoDeclare";

        public const string URLAttributeName = "url";

        public const string AppInfoAttributeName = "appinfo";

        public const string DocumentationAttributeName = "documentation";

        private List<Field> fields;

        private MFString url;

        public ExternProtoDeclare()
        {
            Fields = new List<Field>();
            URL = new MFString();
            AppInfo = null;
            Documentation = null;
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

        public MFString URL
        {
            get => url;

            set
            {
                if (value == null) throw new FormatException();

                url = value;
            }
        }

        public SFString AppInfo { get; set; }

        public SFString Documentation { get; set; }

        protected override void WriteAttributes(XmlWriter writer)
        {
            base.WriteAttributes(writer);

            writer.WriteAttributeString(URLAttributeName, URL.ToString());

            if (AppInfo != null) writer.WriteAttributeString(AppInfoAttributeName, AppInfo.ToString());

            if (Documentation != null)
                writer.WriteAttributeString(DocumentationAttributeName, Documentation.ToString());
        }

        protected override void WriteChildElements(XmlWriter writer)
        {
            base.WriteChildElements(writer);

            foreach (var item in fields) item.Write(writer);
        }

        public override void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            base.Write(writer);

            writer.WriteEndElement();
        }
    }
}