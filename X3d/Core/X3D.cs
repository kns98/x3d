using System;
using System.Xml;

namespace X3d.Core
{
    public class X3D : SceneGraphStructureNodeType
    {
        public const string ElementName = "X3D";

        public const string VersionAttributeName = "version";

        public const string ProfileAttributeName = "profile";

        private Scene scene;

        public X3D()
        {
            Head = null;
            Scene = new Scene();
            Version = X3DVersion.X3D_3_2;
            Profile = ProfileNames.Core;
        }

        public Head Head { get; set; }

        public Scene Scene
        {
            get => scene;

            set
            {
                if (value == null) throw new NullReferenceException();

                scene = value;
            }
        }


        public X3DVersion Version { get; set; }

        public ProfileNames Profile { get; set; }

        public void Write(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            writer.WriteAttributeString(VersionAttributeName,
                X3DVersionConverter.ToString(Version));

            writer.WriteAttributeString(ProfileAttributeName,
                ProfileNamesConverter.ToString(Profile));

            if (Head != null) Head.Write(writer);

            Scene.Write(writer);

            writer.WriteEndElement();
        }
    }
}