﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SonicRetro.SAModel
{
	[Serializable]
    [TypeConverter(typeof(VertexConverter))]
    public class Vertex : IEquatable<Vertex>
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public static int Size { get { return 12; } }

        public Vertex() { }

        public Vertex(byte[] file, int address)
        {
            X = ByteConverter.ToSingle(file, address);
            Y = ByteConverter.ToSingle(file, address + 4);
            Z = ByteConverter.ToSingle(file, address + 8);
        }

        public Vertex(string data)
        {
            string[] a = data.Split(',');
            X = float.Parse(a[0], System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo);
            Y = float.Parse(a[1], System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo);
            Z = float.Parse(a[2], System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo);
        }

        public Vertex(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vertex(float[] data)
        {
            X = data[0];
            Y = data[1];
            Z = data[2];
        }

        public byte[] GetBytes()
        {
            List<byte> result = new List<byte>();
            result.AddRange(ByteConverter.GetBytes(X));
            result.AddRange(ByteConverter.GetBytes(Y));
            result.AddRange(ByteConverter.GetBytes(Z));
            return result.ToArray();
        }

        public override string ToString()
        {
            return X.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) + ", " + Y.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) + ", " + Z.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);
        }

        public string ToStruct()
        {
            if (X == 0 && Y == 0 && Z == 0)
                return "{ 0 }";
            else
                return "{ " + X.ToC() + ", " + Y.ToC() + ", " + Z.ToC() + " }";
        }

        public float[] ToArray()
        {
            float[] result = new float[3];
            result[0] = X;
            result[1] = Y;
            result[2] = Z;
            return result;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;
                    case 1:
                        return Y;
                    case 2:
                        return Z;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        return;
                    case 1:
                        Y = value;
                        return;
                    case 2:
                        Z = value;
                        return;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public static readonly Vertex UpNormal = new Vertex(0, 1, 0);

        /// <summary>
        /// Returns the center of a list of Vertex points.
        /// </summary>
        /// <param name="points">List of points to use.</param>
        /// <returns></returns>
        public static Vertex CenterOfPoints(List<Vertex> points)
        {
            Vertex center = new Vertex(0, 0, 0);
            if (points == null) return center;

            if (points.Count == 0) return center;
            else
            {
                float xTotal = 0;
                float yTotal = 0;
                float zTotal = 0;

                foreach (Vertex vertex in points)
                {
                    xTotal += vertex.X;
                    yTotal += vertex.Y;
                    zTotal += vertex.Z;
                }

                center.X = xTotal / points.Count;
                center.Y = yTotal / points.Count;
                center.Z = zTotal / points.Count;

                return center;
            }
        }

		[Browsable(false)]
		public bool IsEmpty { get { return X == 0 && Y == 0 && Z == 0; } }

		public override bool Equals(object obj)
		{
			if (obj is Vertex)
				return Equals((Vertex)obj);
			return false;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
		}

		public bool Equals(Vertex other)
		{
			return X == other.X && Y == other.Y && Z == other.Z;
		}
	}

    public class VertexConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Vertex))
                return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Vertex)
                return ((Vertex)value).ToString();
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
                return new Vertex((string)value);
            return base.ConvertFrom(context, culture, value);
        }
    }
}