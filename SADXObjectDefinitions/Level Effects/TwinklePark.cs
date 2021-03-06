﻿using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using SA_Tools;
using SonicRetro.SAModel.Direct3D;
using SonicRetro.SAModel.SADXLVL2;
using SonicRetro.SAModel.SAEditorCommon.SETEditing;

namespace SADXObjectDefinitions.Level_Effects
{
    class TwinklePark : LevelDefinition
    {
        SonicRetro.SAModel.Object model;
        Mesh[] meshes;
        Vector3 Skybox_Scale;
        bool NoRender;

        public override void Init(Dictionary<string, string> data, byte act, Device dev)
        {
            SkyboxScale[] skyboxdata = SkyboxScaleList.Load("Levels/Twinkle Park/Skybox Data.ini");
            if (skyboxdata.Length > act)
                Skybox_Scale = skyboxdata[act].Far.ToVector3();
            model = ObjectHelper.LoadModel("Levels/Twinkle Park/Skybox model.sa1mdl");
            meshes = ObjectHelper.GetMeshes(model, dev);
            NoRender = act == 1;
        }

        public override void Render(Device dev, EditorCamera cam)
        {
            if (NoRender) return;
            MatrixStack transform = new MatrixStack();
            transform.Push();
            transform.NJTranslate(cam.Position);
            transform.NJScale(Skybox_Scale);
            RenderInfo.Draw(model.DrawModelTree(dev, transform, ObjectHelper.GetTextures("BG_SHAREOBJ"), meshes), dev, cam);
            transform.Pop();
        }
    }
}