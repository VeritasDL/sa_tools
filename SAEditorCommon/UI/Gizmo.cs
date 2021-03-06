﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;

//using SonicRetro.SAModel.SAEditorCommon.DataTypes;
//using SonicRetro.SAModel.Direct3D;

namespace SonicRetro.SAModel.SAEditorCommon.UI
{
	/// <summary>
	/// Houses elements common to several kinds of gizmos / helpers.
	/// </summary>
	public static class Gizmo
	{
		// 'null' meshes - for when no transforms are available, but users still want to know that something *is* selected
		public static Microsoft.DirectX.Direct3D.Mesh XNullMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh YNullMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh ZNullMesh { get; set; }

		// movement meshes - used for both display and mouse picking
		public static Microsoft.DirectX.Direct3D.Mesh XMoveMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh YMoveMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh ZMoveMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh XYMoveMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh ZXMoveMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh ZYMoveMesh { get; set; }

		// rotation meshes - used for both display and mouse picking
		public static Microsoft.DirectX.Direct3D.Mesh XRotateMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh YRotateMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh ZRotateMesh { get; set; }

		// scale meshes - used for both display and mouse picking
		public static Microsoft.DirectX.Direct3D.Mesh XScaleMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh YScaleMesh { get; set; }
		public static Microsoft.DirectX.Direct3D.Mesh ZScaleMesh { get; set; }

		// box mesh - you know, just in case you need one.
		public static Microsoft.DirectX.Direct3D.Mesh BoxMesh { get; set; }

		// materials for rendering the above meshes
		public static Material XMaterial { get; set; }
		public static Material YMaterial { get; set; }
		public static Material ZMaterial { get; set; }
		public static Material DoubleAxisMaterial { get; set; }
		public static Material HighlightMaterial { get; set; }

		public static Material StandardMaterial { get; set; }

		public static Texture ATexture { get; set; }
		public static Texture BTexture { get; set; }

		public static void InitGizmo(Device d3dDevice)
		{
			#region Creating Streams From Resources
			MemoryStream x_NullStream = new MemoryStream(Properties.Resources.x_null);
			MemoryStream y_NullStream = new MemoryStream(Properties.Resources.y_null);
			MemoryStream z_NullStream = new MemoryStream(Properties.Resources.z_null);
			MemoryStream x_MoveStream = new MemoryStream(Properties.Resources.x_move);
			MemoryStream y_MoveStream = new MemoryStream(Properties.Resources.y_move);
			MemoryStream z_MoveStream = new MemoryStream(Properties.Resources.z_move);
			MemoryStream xy_MoveStream = new MemoryStream(Properties.Resources.xy_move);
			MemoryStream zx_MoveStream = new MemoryStream(Properties.Resources.zx_move);
			MemoryStream zy_MoveStream = new MemoryStream(Properties.Resources.zy_move);

			MemoryStream x_RotationStream = new MemoryStream(Properties.Resources.x_rotation);
			MemoryStream y_RotationStream = new MemoryStream(Properties.Resources.y_rotation);
			MemoryStream z_RotationStream = new MemoryStream(Properties.Resources.z_rotation);

			MemoryStream x_ScaleStream = new MemoryStream(Properties.Resources.x_scale);
			MemoryStream y_ScaleStream = new MemoryStream(Properties.Resources.y_scale);
			MemoryStream z_ScaleStream = new MemoryStream(Properties.Resources.z_scale);
			#endregion

			#region Temporary ExtendedMaterials
			Microsoft.DirectX.Direct3D.ExtendedMaterial[] xMaterials;
			Microsoft.DirectX.Direct3D.ExtendedMaterial[] yMaterials;
			Microsoft.DirectX.Direct3D.ExtendedMaterial[] zMaterials;
			Microsoft.DirectX.Direct3D.ExtendedMaterial[] doubleAxisMaterials;
			#endregion

			#region Loading Meshes and Materials from Streams
			XMoveMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(x_MoveStream, MeshFlags.Managed, d3dDevice, out xMaterials);
			YMoveMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(y_MoveStream, MeshFlags.Managed, d3dDevice, out yMaterials);
			ZMoveMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(z_MoveStream, MeshFlags.Managed, d3dDevice, out zMaterials);

			XNullMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(x_NullStream, MeshFlags.Managed, d3dDevice);
			YNullMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(y_NullStream, MeshFlags.Managed, d3dDevice);
			ZNullMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(z_NullStream, MeshFlags.Managed, d3dDevice);

			XYMoveMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(xy_MoveStream, MeshFlags.Managed, d3dDevice, out doubleAxisMaterials);
			ZXMoveMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(zx_MoveStream, MeshFlags.Managed, d3dDevice);
			ZYMoveMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(zy_MoveStream, MeshFlags.Managed, d3dDevice);

			XRotateMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(x_RotationStream, MeshFlags.Managed, d3dDevice);
			YRotateMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(y_RotationStream, MeshFlags.Managed, d3dDevice);
			ZRotateMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(z_RotationStream, MeshFlags.Managed, d3dDevice);

			XScaleMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(x_ScaleStream, MeshFlags.Managed, d3dDevice);
			YScaleMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(y_ScaleStream, MeshFlags.Managed, d3dDevice);
			ZScaleMesh = Microsoft.DirectX.Direct3D.Mesh.FromStream(z_ScaleStream, MeshFlags.Managed, d3dDevice);

			BoxMesh = Microsoft.DirectX.Direct3D.Mesh.Box(d3dDevice, 1, 1, 1);

			Microsoft.DirectX.Direct3D.Mesh TexturedBox = BoxMesh.Clone(BoxMesh.Options.Value,
				VertexFormats.Position | VertexFormats.Normal | VertexFormats.Texture0 |
				VertexFormats.Texture1, BoxMesh.Device);

			//The following code makes the assumption that the vertices of the box are
			// generated the same way as they are in the April 2005 SDK
			using (VertexBuffer vb = TexturedBox.VertexBuffer)
			{
				CustomVertex.PositionNormalTextured[] verts =
					(CustomVertex.PositionNormalTextured[])vb.Lock(0,
					 typeof(CustomVertex.PositionNormalTextured), LockFlags.None,
					TexturedBox.NumberVertices);
				try
				{
					for (int i = 0; i < verts.Length; i += 4)
					{
						verts[i + 0].Tu = 0.0f;
						verts[i + 0].Tv = 0.0f;
						verts[i + 1].Tu = 1.0f;
						verts[i + 1].Tv = 0.0f;
						verts[i + 2].Tu = 1.0f;
						verts[i + 2].Tv = 1.0f;
						verts[i + 3].Tu = 0.0f;
						verts[i + 3].Tv = 1.0f;
					}
				}
				finally
				{
					vb.Unlock();
				}
			}

			BoxMesh = TexturedBox;

			XMaterial = new SAModel.Material() { DiffuseColor = xMaterials[0].Material3D.Diffuse, Exponent = 0f, UseTexture = false, IgnoreLighting = true, IgnoreSpecular = true };
			YMaterial = new SAModel.Material() { DiffuseColor = yMaterials[0].Material3D.Diffuse, Exponent = 0f, UseTexture = false, IgnoreLighting = true, IgnoreSpecular = true };
			ZMaterial = new SAModel.Material() { DiffuseColor = zMaterials[0].Material3D.Diffuse, Exponent = 0f, UseTexture = false, IgnoreLighting = true, IgnoreSpecular = true };
			DoubleAxisMaterial = new SAModel.Material() { DiffuseColor = doubleAxisMaterials[0].Material3D.Diffuse, Exponent = 0f, UseTexture = false, IgnoreLighting = true, IgnoreSpecular = true };
			HighlightMaterial = new Material() { DiffuseColor = System.Drawing.Color.LightGoldenrodYellow, Exponent = 0f, UseTexture = false, IgnoreLighting = true, IgnoreSpecular = true };

			ATexture = Texture.FromBitmap(d3dDevice, Properties.Resources.PointATexture, Usage.AutoGenerateMipMap, Pool.Managed);
			BTexture = Texture.FromBitmap(d3dDevice, Properties.Resources.PointBTexture, Usage.AutoGenerateMipMap, Pool.Managed);
			StandardMaterial = new Material() { DiffuseColor = System.Drawing.Color.Gray, IgnoreLighting = true, IgnoreSpecular = true, UseAlpha = false, UseTexture = true, Exponent = 100f };
			#endregion

			#region Cleanup
			x_NullStream.Close();
			y_NullStream.Close();
			z_NullStream.Close();

			x_MoveStream.Close();
			y_MoveStream.Close();
			z_MoveStream.Close();

			x_RotationStream.Close();
			y_RotationStream.Close();
			z_RotationStream.Close();
			#endregion
		}
	}
}
