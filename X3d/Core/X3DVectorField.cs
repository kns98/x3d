namespace X3d.Core
{
    /// <summary>
    ///     X3DVec2Field represents the second dimensional vector data structure.
    /// </summary>
    /// <typeparam name="TPrimitive">Vector element type</typeparam>
    public abstract class X3DVec2Field<TPrimitive> : X3DField
        where TPrimitive : X3DPrimitiveField, new()
    {
        protected static readonly int[] HashTablePrimeNumbers
            = { 73856093, 19349663, 83492791, 39916801 };

        #region Constructors

        protected X3DVec2Field()
        {
            Elements = new TPrimitive[2];
        }

        protected X3DVec2Field(TPrimitive x, TPrimitive y)
            : this()
        {
            Elements[0] = x;
            Elements[1] = y;
        }

        #endregion Constructors

        #region Vector Element Accessors

        public TPrimitive[] Elements { get; protected set; }

        public TPrimitive X
        {
            get => Elements[0];

            set => Elements[0] = value;
        }

        public TPrimitive Y
        {
            get => Elements[1];

            set => Elements[1] = value;
        }

        #endregion Vector Element Accessors

        #region Object Equality

        public override int GetHashCode()
        {
            var x = X.GetHashCode() * HashTablePrimeNumbers[0];
            var y = Y.GetHashCode() * HashTablePrimeNumbers[1];

            return x ^ y;
        }

        public override bool Equals(object obj)
        {
            if (obj is X3DVec2Field<TPrimitive>)
            {
                var casted = (X3DVec2Field<TPrimitive>)obj;

                return X.Equals(casted.X) && Y.Equals(casted.Y);
            }

            return false;
        }

        #endregion Object Equality

        #region String Compatibility

        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }

        public override void FromString(string str)
        {
            var delimiter = new[] { ' ' };
            var tokens = str.Split(delimiter);

            X.FromString(tokens[0]);
            Y.FromString(tokens[1]);
        }

        #endregion String Compatibility
    }

    public abstract class X3DVec3Field<TPrimitive> : X3DVec2Field<TPrimitive>
        where TPrimitive : X3DPrimitiveField, new()
    {
        #region Vector Element Accessors

        public TPrimitive Z
        {
            get => Elements[2];

            set => Elements[2] = value;
        }

        #endregion Vector Element Accessors

        #region Constructors

        protected X3DVec3Field()
        {
            Elements = new TPrimitive[3];
        }

        protected X3DVec3Field(TPrimitive x, TPrimitive y, TPrimitive z)
            : this()
        {
            Elements[0] = x;
            Elements[1] = y;
            Elements[2] = z;
        }

        #endregion Constructors

        #region Object Equality

        public override int GetHashCode()
        {
            var z = Z.GetHashCode() * HashTablePrimeNumbers[2];

            return base.GetHashCode() ^ z;
        }

        public override bool Equals(object obj)
        {
            if (obj is X3DVec3Field<TPrimitive>)
            {
                var casted = (X3DVec3Field<TPrimitive>)obj;

                return X.Equals(casted.X)
                       && Y.Equals(casted.Y)
                       && Z.Equals(casted.Z);
            }

            return false;
        }

        #endregion Object Equality

        #region String Compatibility

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", X, Y, Z);
        }

        public override void FromString(string str)
        {
            var delimiter = new[] { ' ' };
            var tokens = str.Split(delimiter);

            X.FromString(tokens[0]);
            Y.FromString(tokens[1]);
            Y.FromString(tokens[2]);
        }

        #endregion String Compatibility
    }

    public abstract class X3DVec4Field<TPrimitive> : X3DVec3Field<TPrimitive>
        where TPrimitive : X3DPrimitiveField, new()
    {
        #region Vector Element Accessors

        public TPrimitive Homegeneous
        {
            get => Elements[3];

            set => Elements[3] = value;
        }

        #endregion Vector Element Accessors

        #region Constructors

        protected X3DVec4Field()
        {
            Elements = new TPrimitive[4];
        }

        protected X3DVec4Field(TPrimitive x, TPrimitive y, TPrimitive z, TPrimitive h)
            : this()
        {
            Elements[0] = x;
            Elements[1] = y;
            Elements[2] = z;
            Elements[3] = h;
        }

        #endregion Constructors

        #region Object Equality

        public override int GetHashCode()
        {
            var h = Homegeneous.GetHashCode() * HashTablePrimeNumbers[3];

            return base.GetHashCode() ^ h;
        }

        public override bool Equals(object obj)
        {
            if (obj is X3DVec4Field<TPrimitive>)
            {
                var casted = (X3DVec4Field<TPrimitive>)obj;

                return X.Equals(casted.X)
                       && Y.Equals(casted.Y)
                       && Z.Equals(casted.Z)
                       && Homegeneous.Equals(casted.Homegeneous);
            }

            return false;
        }

        #endregion Object Equality

        #region String Compatibility

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", X, Y, Z, Homegeneous);
        }

        public override void FromString(string str)
        {
            var delimiter = new[] { ' ' };
            var tokens = str.Split(delimiter);

            X.FromString(tokens[0]);
            Y.FromString(tokens[1]);
            Y.FromString(tokens[2]);
            Y.FromString(tokens[3]);
        }

        #endregion String Compatibility
    }
}