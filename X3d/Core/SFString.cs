namespace X3d.Core
{
    /// <summary>
    ///     The SFString field contain strings encoded with the UTF-8 universal
    ///     character set. Any characters (including linefeeds and '#') may appear
    ///     within the string. The default value of an uninitialized SFString
    ///     outputOnly field is the empty string.
    /// </summary>
    public class SFString : X3DField
    {
        private string Data { get; set; }

        #region Constructors

        public SFString()
        {
            Data = string.Empty;
        }

        public SFString(string data)
        {
            Data = data;
        }

        public SFString(SFString obj)
        {
            Data = obj.Data;
        }

        #endregion Constructors

        #region Object Equality

        public override int GetHashCode()
        {
            return Data.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj as SFString != null) return Data.Equals(((SFString)obj).Data);

            return obj as string != null && Data.Equals(obj);
        }

        #endregion Object Equality

        #region String Compatibility

        public override string ToString()
        {
            return Data;
        }

        public override void FromString(string str)
        {
            Data = str;
        }

        public static implicit operator SFString(string obj)
        {
            if (obj == null)
                return null;
            return new SFString(obj);
        }

        public static implicit operator string(SFString obj)
        {
            if (obj == null)
                return null;
            return obj.Data;
        }

        #endregion String Compatibility
    }
}