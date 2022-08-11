using System;
using System.Collections.Generic;
using System.Xml;

namespace X3d.Core
{
    public class ProtoBody : SceneGraphStructureNodeType
    {
        public const string ElementName = "ProtoBody";

        private List<SceneGraphFragmentWithPrototypeDeclarationsContentModel> childNodes;

        public ProtoBody()
        {
            ChildNodes = new List<SceneGraphFragmentWithPrototypeDeclarationsContentModel>();
        }

        public List<SceneGraphFragmentWithPrototypeDeclarationsContentModel> ChildNodes
        {
            get => childNodes;

            set
            {
                if (value == null) throw new FormatException();

                childNodes = value;
            }
        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            foreach (var item in ChildNodes) ((X3DNode)item).Write(writer);

            writer.WriteEndElement();
        }
    }
}