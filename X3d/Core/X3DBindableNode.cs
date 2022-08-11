using System;

namespace X3d.Core
{
    /// <summary>
    ///     X3DBindableNode is the abstract base type for all bindable children
    ///     nodes, including Background, TextureBackground, Fog, NavigationInfo
    ///     and Viewpoint.
    /// </summary>
    public abstract class X3DBindableNode : X3DChildNode
    {
        protected X3DBindableNode()
        {
            IsBound = false;
            BindTime = -1;
        }

        public SFTime BindTime { get; protected set; }

        public SFBool IsBound { get; protected set; }

        public void SetBind(SFBool obj)
        {
            if (obj == true)
            {
                IsBound = true;
                BindTime = DateTime.Now;
            }
            else
            {
                IsBound = false;
                BindTime = -1;
            }
        }
    }
}