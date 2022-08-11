using System;
using System.Xml;

namespace X3d.Core
{
    public class Meta : SceneGraphStructureNodeType
    {
        public const string ElementName = "meta";

        public const string NameAttributeName = "name";

        public const string ContentAttributeName = "content";

        public const string DirectionAttributeName = "dir";

        public const string HttpEquivalantAttributeName = "http-equiv";

        public const string LanguageAttributeName = "lang";

        public const string SchemeAttributeName = "scheme";

        private SFString content;

        public Meta()
        {
            Name = null;
            Content = string.Empty;
            Direction = null;
            HttpEquivalant = null;
            Language = null;
            Scheme = null;
        }

        public SFString Name { get; set; }

        public SFString Content
        {
            get => content;

            set
            {
                if (value == null) throw new NullReferenceException();

                content = value;
            }
        }

        public MetaDirectionValues? Direction { get; set; }

        public SFString HttpEquivalant { get; set; }

        public SFString Language { get; set; }

        public SFString Scheme { get; set; }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            if (Name != null) writer.WriteAttributeString(NameAttributeName, Name);

            writer.WriteAttributeString(ContentAttributeName, Content);

            if (Direction != null)
                writer.WriteAttributeString(DirectionAttributeName, MetaDirectionValuesConverter.ToString(Direction));

            if (HttpEquivalant != null) writer.WriteAttributeString(HttpEquivalantAttributeName, HttpEquivalant);

            if (Language != null) writer.WriteAttributeString(LanguageAttributeName, Language);

            if (Scheme != null) writer.WriteAttributeString(SchemeAttributeName, Scheme);

            writer.WriteEndElement();
        }
    }
}