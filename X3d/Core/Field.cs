using System;
using System.Collections.Generic;
using System.Xml;

namespace X3d.Core
{
    public class Field : SceneGraphStructureNodeType
    {
        public const string ElementName = "field";
        public const string NameAttributeName = "name";
        public const string AccessTypeAttributeName = "accessType";
        public const string TypeAttributeName = "type";
        public const string ValueAttributeName = "value";
        public const string AppInfoAttributeName = "appinfo";
        public const string DocumentationAttributeName = "documentation";

        private List<SceneGraphFragmentContentModel> childNodes;

        private string name;

        public Field()
        {
            ChildNodes = new List<SceneGraphFragmentContentModel>();
            Name = string.Empty;
            AccessType = AccessTypeNames.InputOutput;
            Type = FieldTypeName.SFBool;
            Value = null;
            AppInfo = null;
            Documentation = null;
        }

        public List<SceneGraphFragmentContentModel> ChildNodes
        {
            get => childNodes;

            set
            {
                if (value == null) throw new FormatException();

                childNodes = value;
            }
        }

        public string Name
        {
            get => name;

            set
            {
                if (value == null) throw new FormatException();

                name = value;
            }
        }

        public AccessTypeNames AccessType { get; set; }

        public FieldTypeName Type { get; set; }

        public SFString Value { get; set; }

        public SFString AppInfo { get; set; }

        public SFString Documentation { get; set; }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            writer.WriteAttributeString(NameAttributeName, Name);
            writer.WriteAttributeString(AccessTypeAttributeName, AccessType.ToString("g"));
            writer.WriteAttributeString(TypeAttributeName, FieldTypeNameConverter.ToString(Type));

            if (Value != null) writer.WriteAttributeString(ValueAttributeName, Value.ToString());

            if (AppInfo != null) writer.WriteAttributeString(AppInfoAttributeName, AppInfo.ToString());

            if (Documentation != null)
                writer.WriteAttributeString(DocumentationAttributeName, Documentation.ToString());

            foreach (var item in ChildNodes) ((X3DNode)item).Write(writer);

            writer.WriteEndElement();
        }
    }
}