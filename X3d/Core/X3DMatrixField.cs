using System.Text;

namespace X3d.Core
{
    public abstract class X3DMatrixField<TPrimitive> : X3DField
        where TPrimitive : X3DPrimitiveField, new()
    {
        #region Matrix Element Accessors

        public TPrimitive[,] Elements { get; protected set; }

        #endregion Matrix Element Accessors

        #region Object Equality

        public override int GetHashCode()
        {
            var hash = Elements[0, 0].GetHashCode();

            for (var row = 0; row < Elements.GetLength(0); row++)
            for (var col = 0; col < Elements.GetLength(1); col++)
            {
                if (row == 0 && col == 0) continue;

                hash ^= Elements[row, col].GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj is X3DMatrixField<TPrimitive>)
            {
                var casted = (X3DMatrixField<TPrimitive>)obj;

                if (Elements.GetLength(0) == casted.Elements.GetLength(0))
                {
                    for (var row = 0; row < Elements.GetLength(0); row++)
                    for (var col = 0; col < Elements.GetLength(1); col++)
                        if (Elements[row, col] != casted.Elements[row, col])
                            return false;

                    return true;
                }
            }

            return false;
        }

        #endregion Object Equality

        #region String Compatibility

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (var row = 0; row < Elements.GetLength(0); row++)
            for (var col = 0; col < Elements.GetLength(1); col++)
            {
                builder.Append(Elements[row, col]);
                builder.Append(' ');
            }

            return builder.ToString().TrimEnd(' ');
        }

        public override void FromString(string str)
        {
            var delimiter = new[] { ' ' };
            var tokens = str.Split(delimiter);

            for (var row = 0; row < Elements.GetLength(0); row++)
            for (var col = 0; col < Elements.GetLength(1); col++)
                Elements[row, col].FromString(tokens[row * Elements.GetLength(0) + col]);
        }

        #endregion String Compatibility
    }
}