namespace X3d.Core
{
    /// <summary>
    ///     The SFRotation field specifies one arbitrary rotation. An SFRotation is
    ///     written to the X3D file as four floating point values. The allowable
    ///     form for a floating point number is defined in the specific encoding.
    ///     The first three values specify a normalized rotation axis vector about
    ///     which the rotation takes place. The fourth value specifies the amount
    ///     of right-handed rotation about that axis in radians.
    /// </summary>
    public class SFRotation : SFVec3f
    {
        public SFFloat Angle { get; set; }

        #region String Compatibility

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", X, Y, Z, Angle);
        }

        #endregion String Compatibility

        #region Constructors

        public SFRotation()
            : this(0, 0, 1, 0)
        {
        }

        public SFRotation(SFFloat x, SFFloat y, SFFloat z, SFFloat angel)
            : base(x, y, z)
        {
            Angle = new SFFloat(angel);
        }

        #endregion Constructors

        #region Object Equality

        public override int GetHashCode()
        {
            var angel = Angle.GetHashCode() * HashTablePrimeNumbers[3];

            return base.GetHashCode() ^ angel;
        }

        public override bool Equals(object obj)
        {
            if (obj is SFRotation)
            {
                var casted = (SFRotation)obj;

                return X.Equals(casted.X)
                       && Y.Equals(casted.Y)
                       && Z.Equals(casted.Z)
                       && Angle.Equals(casted.Angle);
            }

            return false;
        }

        #endregion Object Equality
    }
}