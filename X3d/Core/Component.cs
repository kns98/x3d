using System;
using System.Xml;

namespace X3d.Core
{
    public class Component : SceneGraphStructureNodeType
    {
        public const string ElementName = "component";

        public const string NameAttributeName = "name";

        public const string LevelAttributeName = "level";

        private SFInt32 level;

        public Component()
        {
            Name = ComponentNames.Core;
            Level = 1;
        }

        public Component(ComponentNames name, SFInt32 level)
        {
            Name = name;
            Level = level;
        }

        public ComponentNames Name { get; set; }

        public SFInt32 Level
        {
            get => level;

            set
            {
                if (value < 1 || value > 5) throw new FormatException();

                level = value;
            }
        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            writer.WriteAttributeString(NameAttributeName, ComponentNamesConverter.ToString(Name));
            writer.WriteAttributeString(LevelAttributeName, Level.ToString());

            writer.WriteEndElement();
        }
    }
}