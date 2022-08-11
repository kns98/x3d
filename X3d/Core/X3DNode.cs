using System.Xml;

namespace X3d.Core
{
    /// <summary>
    ///     This abstract node type is the base type for all nodes in the X3D system.
    /// </summary>
    public abstract class X3DNode
    {
        public const string ISElementName = "IS";

        public const string MetadataElementName = "metadata";

        public const string DEFAttributeName = "DEF";

        public const string USEAttributeName = "USE";

        public const string ContainerNameAttrubuteName = "containerField";

        protected X3DNode()
        {
            IS = null;
            Metadata = null;
            DEF = null;
            USE = null;
            ContainerField = null;
        }

        public IS IS { get; set; }

        public ChildContentModelCore Metadata { get; set; }

        public SFString DEF { get; set; }

        public SFString USE { get; set; }

        public SFString ContainerField { get; set; }

        protected virtual void WriteAttributes(XmlWriter writer)
        {
            if (DEF != null) writer.WriteAttributeString(DEFAttributeName, DEF.ToString());

            if (USE != null) writer.WriteAttributeString(USEAttributeName, USE.ToString());

            if (ContainerField != null)
                writer.WriteAttributeString(ContainerNameAttrubuteName, ContainerField.ToString());
        }

        protected virtual void WriteChildElements(XmlWriter writer)
        {
            if (IS != null) IS.Write(writer);

            if (Metadata != null) ((X3DMetadataObject)Metadata).Write(writer);
        }

        public virtual void Write(XmlWriter writer)
        {
            WriteAttributes(writer);
            WriteChildElements(writer);
        }
    }
}