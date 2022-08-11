﻿namespace X3d.Core
{
    /// <summary>
    ///     This abstract node type is the base type for all sensors.
    /// </summary>
    public abstract class X3DSensorNode : X3DChildNode
    {
        protected X3DSensorNode()
        {
            Enabled = new SFBool(false);
            IsActive = new SFBool(false);
        }

        public SFBool Enabled { get; set; }

        public SFBool IsActive { get; protected set; }
    }
}