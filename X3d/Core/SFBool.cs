using System;

namespace X3d.Core
{
    /// <summary>
    ///     The SFBool field specifies a single Boolean value. Each Boolean value
    ///     represents either TRUE or FALSE. How these values are represented is
    ///     encoding dependent.
    /// </summary>
    public class SFBool : X3DPrimitiveField<bool>
    {
        public static readonly string TrueString = "true";

        public static readonly string FalseString = "false";

        #region Constructors

        public SFBool()
        {
            Primitive = false;
        }

        public SFBool(bool value)
        {
            Primitive = value;
        }

        public SFBool(SFBool obj)
        {
            Primitive = obj.Primitive;
        }

        #endregion Constructors

        #region Boolean Compatibility

        public static implicit operator SFBool(bool value)
        {
            return new SFBool { Primitive = value };
        }

        public static implicit operator bool(SFBool obj)
        {
            return obj.Primitive;
        }

        #endregion Boolean Compatibility

        #region String Compatiblity

        public override string ToString()
        {
            return Primitive ? TrueString : FalseString;
        }

        public override void FromString(string str)
        {
            if (str.Equals(TrueString))
                Primitive = true;
            else if (str.Equals(FalseString))
                Primitive = false;
            else
                throw new FormatException(string.Format("Invalid Boolean string [{0}]", str));
        }

        #endregion
    }
}