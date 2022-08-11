using System;
using System.Xml;

namespace X3d.Core
{
    /*
     * <xs:group name="ChildContentModelSceneGraphStructure">
    <xs:choice>
      <xs:element ref="ProtoDeclare" />
    </xs:choice>
  </xs:group>
     */

    public abstract class X3DPrototype : SceneGraphStructureNodeType
    {
        public const string NameAttributeName = "name";

        private string name;

        protected X3DPrototype()
        {
            name = string.Empty;
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

        protected virtual void WriteAttributes(XmlWriter writer)
        {
            writer.WriteAttributeString(NameAttributeName, Name);
        }

        protected virtual void WriteChildElements(XmlWriter writer)
        {
        }

        public virtual void Write(XmlWriter writer)
        {
            WriteAttributes(writer);
            WriteChildElements(writer);
        }
    }
}