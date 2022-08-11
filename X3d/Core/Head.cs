using System;
using System.Collections.Generic;
using System.Xml;

namespace X3d.Core
{
    public class Head : SceneGraphStructureNodeType
    {
        public const string ElementName = "head";

        private List<Component> components;

        private List<Meta> meta;

        public Head()
        {
            Components = new List<Component>();
            Meta = new List<Meta>();
        }

        public List<Component> Components
        {
            get => components;

            set
            {
                if (value == null) throw new NullReferenceException();

                components = value;
            }
        }

        public List<Meta> Meta
        {
            get => meta;

            set
            {
                if (value == null) throw new NullReferenceException();

                meta = value;
            }
        }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            foreach (var item in components) item.Write(writer);

            foreach (var item in meta) item.Write(writer);

            writer.WriteEndElement();
        }
    }
}