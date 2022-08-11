﻿using System.Xml;

namespace X3d.Core
{
    /// <summary>
    ///     This abstract interface is the basis for all metadata nodes. The
    ///     interface is inherited by all metadata nodes. The specification
    ///     of the reference field is optional. If provided, it identifies
    ///     the metadata standard or other specification that defines the name
    ///     field. If the reference field is not provided or is empty, the
    ///     meaning of the name field is considered implicit to the characters
    ///     in the string.
    /// </summary>
    public abstract class X3DMetadataObject : X3DNode, ChildContentModelCore
    {
        public const string NameAttributeName = "name";

        public const string ReferenceAttributeName = "reference";

        protected X3DMetadataObject()
        {
            ContainerField = new SFString("metadata");
            Name = null;
            Reference = null;
        }

        public SFString Name { get; set; }

        public SFString Reference { get; set; }

        protected override void WriteAttributes(XmlWriter writer)
        {
            base.WriteAttributes(writer);

            if (Name != null) writer.WriteAttributeString(NameAttributeName, Name);

            if (Reference != null) writer.WriteAttributeString(ReferenceAttributeName, Reference);
        }
    }

    public abstract class X3DMetadataObject<MetadataType> : X3DMetadataObject
        where MetadataType : new()
    {
        public const string ValueAttributeName = "value";

        protected X3DMetadataObject()
        {
            Value = new MetadataType();
        }

        public MetadataType Value { get; set; }
    }
}