﻿namespace X3d.Core
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class Scene : SceneGraphStructureNodeType
    {
        public const string ElementName = "Scene";

        public Scene()
        {
            this.ChildNodes = new List<SceneChildContentModel>();    
        }

        public List<SceneChildContentModel> ChildNodes { get; set; }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            foreach (var item in ChildNodes)
            {
                ((X3DNode)item).Write(writer);
            }

            writer.WriteEndElement();
        }
    }
}
