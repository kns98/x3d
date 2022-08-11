namespace X3d.Core
{
    /// <summary>
    ///     X3DPrimitiveField is the abstract non-generic field type inherited by
    ///     generic version of this class. This is needed to group all the instantiated
    ///     classes such as <see cref="SFBool" />, <see cref="SFDouble" />,
    ///     <see cref="SFFloat" /> and <see cref="SFInt32" /> are primitive data
    ///     field types.
    /// </summary>
    public abstract class X3DPrimitiveField : X3DField
    {
    }

    /// <summary>
    ///     X3DPrimitiveField is the abstract generic field type from which all primitive
    ///     field types are derived. <see cref="SFBool" />, <see cref="SFDouble" />,
    ///     <see cref="SFFloat" />, <see cref="SFInt32" /> and <see cref="SFTime" />
    ///     are primitive data field types.
    /// </summary>
    /// <typeparam name="TPrimitive">.NET Framework equivalent primitive data type</typeparam>
    public abstract class X3DPrimitiveField<TPrimitive> : X3DPrimitiveField
        where TPrimitive : struct
    {
        protected TPrimitive Primitive { get; set; }

        #region String Compatibility

        public override string ToString()
        {
            return Primitive.ToString();
        }

        #endregion String Compatibility

        #region Object Equality

        public override int GetHashCode()
        {
            return Primitive.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is X3DPrimitiveField<TPrimitive>)
                return Primitive.Equals(((X3DPrimitiveField<TPrimitive>)obj).Primitive);
            if (obj is TPrimitive)
                return Primitive.Equals((TPrimitive)obj);
            return false;
        }

        #endregion Object Equality
    }
}