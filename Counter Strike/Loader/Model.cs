using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Loader
{
    class Model:Counter_Strike.Obj
    {
        int texture=0;
        MeshData meshData;
        OpenTK.Vector3 scale;
        OpenTK.Vector3 pos;
        OpenTK.Vector3 rotVector;
        float rotAngle=0;
        OpenTK.Vector3 downLeftCorner;
        OpenTK.Vector3 upRightCorner;

        public Model(OpenTK.Vector3 pos, OpenTK.Vector3 scale, string path, string objFile)
        {
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.Texture2D);
            this.meshData = new Loader.ObjLoader().LoadFile(@path + objFile);
            this.scale = scale;
            this.pos = pos;
        }

        public Model(OpenTK.Vector3 pos, OpenTK.Vector3 scale, string path, string objFile, string texture)
        : this(pos, scale, path, objFile)
        {
            this.texture = Loader.TexLoader.LoadFile(@path + texture);
        }
        public Model(OpenTK.Vector3 pos, OpenTK.Vector3 scale, float rotAngle, OpenTK.Vector3 rotVector, string path, string objFile, string texture)
        :this(pos,scale,path,objFile,texture)
        {
            this.rotVector = rotVector;
            this.rotAngle = rotAngle;
        }
        public Model(OpenTK.Vector3 pos, OpenTK.Vector3 scale,OpenTK.Vector3 downLeftCorner, OpenTK.Vector3 upRightCorner, string path, string objFile, string texture)
        : this(pos, scale, path, objFile, texture)
        {
            this.downLeftCorner = downLeftCorner;
            this.upRightCorner = upRightCorner;
        }
        public Model(OpenTK.Vector3 pos, OpenTK.Vector3 scale, OpenTK.Vector3 downLeftCorner, OpenTK.Vector3 upRightCorner, string path, string objFile)
            : this(pos, scale, path, objFile)
        {
            this.downLeftCorner = downLeftCorner;
            this.upRightCorner = upRightCorner;
        }
        public override void Draw()
        {
            GL.PushMatrix();
            GL.Translate(pos);
            GL.Scale(scale);
            if (rotAngle != 0)
            {
                GL.Rotate(rotAngle, rotVector);
            }
            if (texture!=0)
                GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.Begin(BeginMode.Triangles);
            foreach (Tri t in meshData.Tris)
            {
                foreach (Point p in t.Points())
                {
                    Vector3 v = meshData.Vertices[p.Vertex];
                    Vector3 n = meshData.Normals[p.Normal];
                    Vector2 tc = meshData.TexCoords[p.TexCoord];
                    GL.Normal3(n.X, n.Y, n.Z);
                    GL.TexCoord2(tc.X, 1 - tc.Y);
                    GL.Vertex3(v.X, v.Y, v.Z);
                }
            }
            GL.End();
            GL.PopMatrix();
            
        }
        public void setPos(OpenTK.Vector3 pos)
        {
            this.pos = pos;
        }
        public void setRot(float rotAngle, OpenTK.Vector3 rotVector)
        {
            this.rotVector = rotVector;
            this.rotAngle = rotAngle;
        }
        public override bool CheckCollision(Counter_Strike.BoundingBox targetBoundingBox)
        {
            foreach (OpenTK.Vector3 targetPoint in targetBoundingBox.pointsList)
            {
                if ((targetPoint.X >= downLeftCorner.X && targetPoint.X <= upRightCorner.X) && (targetPoint.Y >= downLeftCorner.Y && targetPoint.Y <= upRightCorner.Y) && (targetPoint.Z <= downLeftCorner.Z && targetPoint.Z >= upRightCorner.Z))
                    return true;
            }
            return false;
        }
    }
}
