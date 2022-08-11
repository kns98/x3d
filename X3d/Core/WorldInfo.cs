using System.Xml;

namespace X3d.Core
{
    /// <summary>
    ///     The WorldInfo node contains information about the world. This node is
    ///     strictly for documentation purposes and has no effect on the visual
    ///     appearance or behavior of the world. The title field is intended to
    ///     store the name or title of the world so that browsers can present this
    ///     to the user (perhaps in the window border). Any other information about
    ///     the world can be stored in the info field, such as author information,
    ///     copyright, and usage instructions.
    /// </summary>
    public class WorldInfo : X3DInfoNode, ChildContentModelInterchange
    {
        public const string ElementName = "WorldInfo";

        public const string InfoAttributeName = "info";

        public const string TitleAttributeName = "title";

        public WorldInfo()
        {
            ContainerField = null;
            Info = null;
            Title = null;
        }

        public MFString Info { get; set; }

        public SFString Title { get; set; }

        protected override void WriteAttributes(XmlWriter writer)
        {
            base.WriteAttributes(writer);

            if (Info != null) writer.WriteAttributeString(InfoAttributeName, Info.ToString());

            if (Title != null) writer.WriteAttributeString(TitleAttributeName, Title.ToString());
        }

        public override void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            base.Write(writer);

            writer.WriteEndElement();
        }
    }
}