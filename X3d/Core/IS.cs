using System.Collections.Generic;
using System.Xml;

namespace X3d.Core
{
    public class IS : SceneGraphStructureNodeType
    {
        public const string ElementName = "IS";

        public IS()
        {
            Connections = new List<Connect>();
        }

        public List<Connect> Connections { get; set; }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            foreach (var item in Connections) item.Write(writer);

            writer.WriteEndElement();
        }
    }
}