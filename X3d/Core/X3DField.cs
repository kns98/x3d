namespace X3d.Core
{
    /// <summary>
    ///     X3DField is the abstract field type from which all single values field
    ///     types are derived.
    /// </summary>
    public abstract class X3DField
    {
        #region String Compatibility

        public abstract void FromString(string str);

        #endregion String Compatibility
    }
}