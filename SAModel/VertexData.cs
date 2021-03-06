﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SonicRetro.SAModel
{
    /// <summary>
    /// This is a standard tri mesh representation of a BasicAttach or ChunkAttach.
    /// </summary>
	public class MeshInfo
	{
		public Material Material { get; private set; }
		public Poly[] Polys { get; private set; }
		public VertexData[] Vertices { get; private set; }
		public bool HasUV { get; private set; }
		public bool HasVC { get; private set; }

		public MeshInfo(Material material, Poly[] polys, VertexData[] vertices, bool hasUV, bool hasVC)
		{
			Material = material;
			Polys = polys;
			Vertices = vertices;
			HasUV = hasUV;
			HasVC = hasVC;
		}

		public ushort[] ToTriangles()
		{
			List<ushort> tris = new List<ushort>();
			foreach (Poly poly in Polys)
				if (poly is Triangle)
					tris.AddRange(poly.Indexes);
				else if (poly is Quad)
				{
					tris.Add(poly.Indexes[0]);
					tris.Add(poly.Indexes[1]);
					tris.Add(poly.Indexes[2]);
					tris.Add(poly.Indexes[2]);
					tris.Add(poly.Indexes[1]);
					tris.Add(poly.Indexes[3]);
				}
				else if (poly is Strip)
				{
					bool flip = !((Strip)poly).Reversed;
					for (int k = 0; k < poly.Indexes.Length - 2; k++)
					{
						flip = !flip;
						if (!flip)
						{
							tris.Add(poly.Indexes[k]);
							tris.Add(poly.Indexes[k + 1]);
							tris.Add(poly.Indexes[k + 2]);
						}
						else
						{
							tris.Add(poly.Indexes[k + 1]);
							tris.Add(poly.Indexes[k]);
							tris.Add(poly.Indexes[k + 2]);
						}
					}
				}
			return tris.ToArray();
		}
	}

    public struct VertexData : IEquatable<VertexData>
    {
        public Vertex Position;
        public Vertex Normal;
        public Color? Color;
        public UV UV;

        public VertexData(Vertex position)
            : this(position, null, null, null)
        { }

        public VertexData(Vertex position, Vertex normal)
            : this(position, normal, null, null)
        { }

        public VertexData(Vertex position, Vertex normal, Color? color, UV uv)
        {
            Position = position;
            Normal = normal ?? Vertex.UpNormal;
            Color = color;
            UV = uv;
        }

		public override bool Equals(object obj)
		{
			if (obj is VertexData)
				return Equals((VertexData)obj);
			return false;
		}

		public override int GetHashCode()
		{
			return Position.GetHashCode() ^ Normal.GetHashCode() ^ Color.GetHashCode() ^ (UV == null ? 0 : UV.GetHashCode());
		}

		public bool Equals(VertexData other)
		{
			return Position.Equals(other.Position) && Normal.Equals(other.Normal) && Color == other.Color && (UV == null ? other.UV == null : UV.Equals(other.UV));
		}
	}
}