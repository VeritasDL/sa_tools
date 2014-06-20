xof 0303txt 0032
template ColorRGBA {
 <35ff44e0-6c7c-11cf-8f52-0040333594a3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
 FLOAT alpha;
}

template ColorRGB {
 <d3e16e81-7835-11cf-8f52-0040333594a3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
}

template Material {
 <3d82ab4d-62da-11cf-ab39-0020af71e433>
 ColorRGBA faceColor;
 FLOAT power;
 ColorRGB specularColor;
 ColorRGB emissiveColor;
 [...]
}

template Frame {
 <3d82ab46-62da-11cf-ab39-0020af71e433>
 [...]
}

template Matrix4x4 {
 <f6f23f45-7686-11cf-8f52-0040333594a3>
 array FLOAT matrix[16];
}

template FrameTransformMatrix {
 <f6f23f41-7686-11cf-8f52-0040333594a3>
 Matrix4x4 frameMatrix;
}

template Vector {
 <3d82ab5e-62da-11cf-ab39-0020af71e433>
 FLOAT x;
 FLOAT y;
 FLOAT z;
}

template MeshFace {
 <3d82ab5f-62da-11cf-ab39-0020af71e433>
 DWORD nFaceVertexIndices;
 array DWORD faceVertexIndices[nFaceVertexIndices];
}

template Mesh {
 <3d82ab44-62da-11cf-ab39-0020af71e433>
 DWORD nVertices;
 array Vector vertices[nVertices];
 DWORD nFaces;
 array MeshFace faces[nFaces];
 [...]
}

template MeshMaterialList {
 <f6f23f42-7686-11cf-8f52-0040333594a3>
 DWORD nMaterials;
 DWORD nFaceIndexes;
 array DWORD faceIndexes[nFaceIndexes];
 [Material <3d82ab4d-62da-11cf-ab39-0020af71e433>]
}

template VertexElement {
 <f752461c-1e23-48f6-b9f8-8350850f336f>
 DWORD Type;
 DWORD Method;
 DWORD Usage;
 DWORD UsageIndex;
}

template DeclData {
 <bf22e553-292c-4781-9fea-62bd554bdd93>
 DWORD nElements;
 array VertexElement Elements[nElements];
 DWORD nDWords;
 array DWORD data[nDWords];
}


Material z_material {
 0.000000;0.000000;1.000000;1.000000;;
 9.999999;
 0.000000;0.000000;0.000000;;
 0.000000;0.000000;0.000000;;
}

Frame z_scale {
 

 FrameTransformMatrix {
  1.000000,0.000000,0.000000,0.000000,0.000000,1.000000,0.000000,0.000000,0.000000,0.000000,1.000000,0.000000,0.000000,0.000000,0.000000,1.000000;;
 }

 Mesh z_scale {
  60;
  0.050785;0.000000;0.000000;,
  0.047722;0.017369;0.000000;,
  0.047722;0.017369;1.591550;,
  0.050785;-0.000000;1.591550;,
  0.038904;0.032644;0.000000;,
  0.038904;0.032644;1.591550;,
  0.025393;0.043981;0.000000;,
  0.025393;0.043981;1.591550;,
  0.008819;0.050013;0.000000;,
  0.008819;0.050013;1.591550;,
  -0.008819;0.050013;0.000000;,
  -0.008819;0.050013;1.591550;,
  -0.025393;0.043981;0.000000;,
  -0.025393;0.043981;1.591550;,
  -0.038904;0.032644;0.000000;,
  -0.038904;0.032644;1.591550;,
  -0.047722;0.017370;0.000000;,
  -0.047722;0.017369;1.591550;,
  -0.050785;0.000000;0.000000;,
  -0.050785;-0.000000;1.591550;,
  -0.047722;-0.017369;0.000000;,
  -0.047722;-0.017370;1.591550;,
  -0.038904;-0.032644;0.000000;,
  -0.038904;-0.032644;1.591550;,
  -0.025393;-0.043981;0.000000;,
  -0.025393;-0.043981;1.591550;,
  -0.008819;-0.050013;0.000000;,
  -0.008819;-0.050013;1.591550;,
  0.008819;-0.050013;0.000000;,
  0.008819;-0.050013;1.591550;,
  0.025392;-0.043981;0.000000;,
  0.025392;-0.043981;1.591550;,
  0.038904;-0.032644;0.000000;,
  0.038904;-0.032644;1.591550;,
  0.047722;-0.017370;0.000000;,
  0.047722;-0.017370;1.591550;,
  0.118228;-0.118228;1.473322;,
  0.118228;0.118228;1.473322;,
  0.118228;0.118228;1.709778;,
  0.118228;-0.118228;1.709778;,
  -0.118228;-0.118228;1.473322;,
  -0.118228;-0.118228;1.709778;,
  -0.118228;0.118228;1.709778;,
  -0.118228;0.118228;1.473322;,
  0.118228;-0.118228;1.473322;,
  0.118228;-0.118228;1.709778;,
  -0.118228;-0.118228;1.709778;,
  -0.118228;-0.118228;1.473322;,
  0.118228;-0.118228;1.709778;,
  0.118228;0.118228;1.709778;,
  -0.118228;0.118228;1.709778;,
  -0.118228;-0.118228;1.709778;,
  0.118228;0.118228;1.709778;,
  0.118228;0.118228;1.473322;,
  -0.118228;0.118228;1.473322;,
  -0.118228;0.118228;1.709778;,
  0.118228;0.118228;1.473322;,
  0.118228;-0.118228;1.473322;,
  -0.118228;-0.118228;1.473322;,
  -0.118228;0.118228;1.473322;;
  48;
  3;0,1,2;,
  3;2,3,0;,
  3;1,4,5;,
  3;5,2,1;,
  3;4,6,7;,
  3;7,5,4;,
  3;6,8,9;,
  3;9,7,6;,
  3;8,10,11;,
  3;11,9,8;,
  3;10,12,13;,
  3;13,11,10;,
  3;12,14,15;,
  3;15,13,12;,
  3;14,16,17;,
  3;17,15,14;,
  3;16,18,19;,
  3;19,17,16;,
  3;18,20,21;,
  3;21,19,18;,
  3;20,22,23;,
  3;23,21,20;,
  3;22,24,25;,
  3;25,23,22;,
  3;24,26,27;,
  3;27,25,24;,
  3;26,28,29;,
  3;29,27,26;,
  3;28,30,31;,
  3;31,29,28;,
  3;30,32,33;,
  3;33,31,30;,
  3;32,34,35;,
  3;35,33,32;,
  3;34,0,3;,
  3;3,35,34;,
  3;36,37,38;,
  3;38,39,36;,
  3;40,41,42;,
  3;42,43,40;,
  3;44,45,46;,
  3;46,47,44;,
  3;48,49,50;,
  3;50,51,48;,
  3;52,53,54;,
  3;54,55,52;,
  3;56,57,58;,
  3;58,59,56;;

  MeshMaterialList {
   1;
   48;
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0,
   0;
   { z_material }
  }

  DeclData {
   1;
   2;0;3;0;;
   180;
   1065353216,
   3029727591,
   2928659938,
   1064341426,
   1051663684,
   831065270,
   1064341426,
   1051663685,
   830731877,
   1065353216,
   3031083277,
   781175360,
   1061428093,
   1059360187,
   839075049,
   1061428092,
   1059360187,
   838808656,
   1056964608,
   1063105495,
   841159478,
   1056964610,
   1063105494,
   842062788,
   1043452105,
   1065098333,
   841769627,
   1043452110,
   1065098333,
   842672938,
   3190935778,
   1065098332,
   842672940,
   3190935782,
   1065098332,
   841769625,
   3204448257,
   1063105495,
   842062789,
   3204448258,
   1063105494,
   841159475,
   3208911740,
   1059360188,
   838808656,
   3208911740,
   1059360188,
   839075050,
   3211825074,
   1051663686,
   830731877,
   3211825074,
   1051663685,
   831065271,
   3212836864,
   847842208,
   781175862,
   3212836864,
   0,
   2928659473,
   3211825075,
   3199147325,
   2978548912,
   3211825076,
   3199147324,
   2978215517,
   3208911744,
   3206843831,
   2986558693,
   3208911744,
   3206843831,
   2986292298,
   3204448260,
   3210589141,
   2988643123,
   3204448259,
   3210589141,
   2989546437,
   3190935794,
   3212581979,
   2989253275,
   3190935788,
   3212581979,
   2990156587,
   1043452082,
   3212581982,
   2990156590,
   1043452077,
   3212581982,
   2989253278,
   1056964594,
   3210589147,
   2989546442,
   1056964590,
   3210589148,
   2988643130,
   1061428086,
   3206843843,
   2986292316,
   1061428086,
   3206843843,
   2986558703,
   1064341423,
   3199147350,
   2978215538,
   1064341423,
   3199147350,
   2978548930,
   1065353216,
   860118484,
   873678429,
   1065353216,
   860118482,
   873678429,
   1065353216,
   860118484,
   873678429,
   1065353216,
   860118482,
   873678429,
   3212836864,
   0,
   3024379345,
   3212836864,
   0,
   3024379345,
   3212836864,
   0,
   3024379345,
   3212836864,
   0,
   3024379345,
   860118482,
   3212836864,
   671089572,
   860118482,
   3212836864,
   669118386,
   860118482,
   3212836864,
   671585280,
   860118482,
   3212836864,
   672571340,
   0,
   0,
   1065353216,
   0,
   0,
   1065353216,
   0,
   0,
   1065353216,
   0,
   0,
   1065353216,
   3007602132,
   1065353216,
   2818573220,
   3007602130,
   1065353216,
   2816602034,
   3007602132,
   1065353216,
   2819068929,
   3007602130,
   1065353216,
   2820054988,
   0,
   0,
   3212836864,
   0,
   0,
   3212836864,
   0,
   0,
   3212836864,
   0,
   0,
   3212836864;
  }
 }
}