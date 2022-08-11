﻿using System;

namespace X3d.Core
{
    public enum MetaDirectionValues
    {
        RightToLeft,
        LeftToRight
    }

    public static class MetaDirectionValuesConverter
    {
        public static readonly string RightToLeftString = "rtl";
        public static readonly string LeftToRightString = "ltr";

        public static MetaDirectionValues FromString(string str)
        {
            if (str.Equals(RightToLeftString))
                return MetaDirectionValues.RightToLeft;
            if (str.Equals(RightToLeftString))
                return MetaDirectionValues.LeftToRight;
            throw new FormatException();
        }

        public static string ToString(MetaDirectionValues? value)
        {
            switch (value)
            {
                case MetaDirectionValues.RightToLeft:
                    return RightToLeftString;

                case MetaDirectionValues.LeftToRight:
                    return LeftToRightString;

                default:
                    throw new FormatException();
            }
        }
    }
}