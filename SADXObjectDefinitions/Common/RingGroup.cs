﻿using System;
using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using SonicRetro.SAModel.Direct3D;
using SonicRetro.SAModel.SADXLVL2;
using SonicRetro.SAModel.SAEditorCommon.SETEditing;
using SonicRetro.SAModel.SAEditorCommon.DataTypes;

namespace SADXObjectDefinitions.Common
{
	public class RingGroup : ObjectDefinition
	{
		private SonicRetro.SAModel.Object model;
		private Microsoft.DirectX.Direct3D.Mesh[] meshes;

		public override void Init(ObjectData data, string name, Device dev)
		{
			model = ObjectHelper.LoadModel("Objects/Ring/Model.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model, dev);
		}

		public override HitResult CheckHit(SETItem item, Vector3 Near, Vector3 Far, Viewport Viewport, Matrix Projection, Matrix View, MatrixStack transform)
		{
			HitResult result = HitResult.NoHit;
			for (int i = 0; i < Math.Min(item.Scale.X + 1, 8); i++)
			{
				transform.Push();
				if (item.Scale.Z == 1) // circle
				{
					double v4 = i * 360.0;
					Vector3 v7 = new Vector3(
						ObjectHelper.ConvertBAMS((int)(v4 / item.Scale.X * 65536.0 * 0.002777777777777778)) * item.Scale.Y,
						0,
						ObjectHelper.ConvertBAMSInv((int)(v4 / item.Scale.X * 65536.0 * 0.002777777777777778)) * item.Scale.Y);
					transform.Push();
					transform.NJTranslate(item.Position);
					transform.NJRotateObject(item.Rotation);
					Vector3 pos = Vector3.TransformCoordinate(v7, transform.Top);
					transform.Pop();
					transform.NJTranslate(pos);
					result = HitResult.Min(result, model.CheckHit(Near, Far, Viewport, Projection, View, transform, meshes));
				}
				else // line
				{
					transform.Push();
					transform.NJTranslate(item.Position);
					transform.NJRotateObject(item.Rotation);
					double v5;
					if (i % 2 == 1)
						v5 = i * item.Scale.Y * -0.5;
					else
						v5 = Math.Ceiling(i * 0.5) * item.Scale.Y;
					Vector3 pos = Vector3.TransformCoordinate(new Vector3(0, 0, (float)v5), transform.Top);
					transform.Pop();
					transform.NJTranslate(pos);
					result = HitResult.Min(result, model.CheckHit(Near, Far, Viewport, Projection, View, transform, meshes));
				}
				transform.Pop();
			}
			return result;
		}

		public override RenderInfo[] Render(SETItem item, Device dev, EditorCamera camera, MatrixStack transform, bool selected)
		{
			List<RenderInfo> result = new List<RenderInfo>();
			for (int i = 0; i < Math.Min(item.Scale.X + 1, 8); i++)
			{
				transform.Push();
				if (item.Scale.Z == 1) // circle
				{
					double v4 = i * 360.0;
					Vector3 v7 = new Vector3(
						ObjectHelper.ConvertBAMS((int)(v4 / item.Scale.X * 65536.0 * 0.002777777777777778)) * item.Scale.Y,
						0,
						ObjectHelper.ConvertBAMSInv((int)(v4 / item.Scale.X * 65536.0 * 0.002777777777777778)) * item.Scale.Y);
					transform.Push();
					transform.NJTranslate(item.Position);
					transform.NJRotateObject(item.Rotation);
					Vector3 pos = Vector3.TransformCoordinate(v7, transform.Top);
					transform.Pop();
					transform.NJTranslate(pos);
					result.AddRange(model.DrawModelTree(dev, transform, ObjectHelper.GetTextures("OBJ_REGULAR"), meshes));
					if (selected)
						result.AddRange(model.DrawModelTreeInvert(dev, transform, meshes));
				}
				else // line
				{
					transform.Push();
					transform.NJTranslate(item.Position);
					transform.NJRotateObject(item.Rotation);
					double v5;
					if (i % 2 == 1)
						v5 = i * item.Scale.Y * -0.5;
					else
						v5 = Math.Ceiling(i * 0.5) * item.Scale.Y;
					Vector3 pos = Vector3.TransformCoordinate(new Vector3(0, 0, (float)v5), transform.Top);
					transform.Pop();
					transform.NJTranslate(pos);
					result.AddRange(model.DrawModelTree(dev, transform, ObjectHelper.GetTextures("OBJ_REGULAR"), meshes));
					if (selected)
						result.AddRange(model.DrawModelTreeInvert(dev, transform, meshes));
				}
				transform.Pop();
			}
			return result.ToArray();
		}

		public override SonicRetro.SAModel.BoundingSphere GetBounds(SETItem item)
		{
			return base.GetBounds(item);
		}

		public override string Name { get { return "Ring Group"; } }

		private PropertySpec[] customProperties = new PropertySpec[] {
			new PropertySpec("Number of Rings", typeof(byte), "Extended", null, 1, (o) => (byte)Math.Min(o.Scale.X + 1, 8), (o, v) => o.Scale.X = Math.Max(Math.Min((byte)v - 1, 8), 0)),
			new PropertySpec("Size", typeof(float), "Extended", null, null, (o) => o.Scale.Y, (o, v) => o.Scale.Y = (float)v),
			new PropertySpec("Group Type", typeof(RingGroupType), "Extended", null, null, (o) => o.Scale.Z == 1 ? RingGroupType.Circle : RingGroupType.Line, (o, v) => o.Scale.Z = (RingGroupType)v == RingGroupType.Circle ? 1 : 0)
		};

		public override PropertySpec[] CustomProperties { get { return customProperties; } }
	}

	public enum RingGroupType
	{
		Line,
		Circle
	}
}