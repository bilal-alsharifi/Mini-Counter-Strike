using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using System.Collections.Generic;

namespace Counter_Strike
{
    class Box : Obj
    {
        int front_tex;
        int back_tex;
        int right_tex;
        int left_tex;
        int top_tex;
        int down_tex;
        int x_tex_factor;
        int y_tex_factor;
        float xPos;
        public float yPos;
        float zPos;
        float rotAngle;
        Vector3 rotVector;
        float length;
        float width;
        public float height;
        int normals_factor;
        public Vector3 downLeftCorner;
        public Vector3 upRightCorner;
        Vector3 origin;

        public Box(float xPos, float yPos, float zPos,float rotAngle,Vector3 rotVector,float length, float width, float height, int normals_factor,int x_tex_factor,int y_tex_factor, string path, string front_tex, string back_tex, string right_tex, string left_tex, string top_tex, string down_tex)
        {
            GL.Enable(EnableCap.Texture2D);
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.rotAngle = rotAngle;
            this.rotVector = rotVector;
            this.length = length;
            this.width = width;
            this.height = height;
            this.normals_factor = normals_factor;
            this.x_tex_factor = x_tex_factor;
            this.y_tex_factor = y_tex_factor;
            this.front_tex = Loader.TexLoader.LoadFile(@path + front_tex);
            this.back_tex = Loader.TexLoader.LoadFile(@path + back_tex);
            this.right_tex = Loader.TexLoader.LoadFile(@path + right_tex);
            this.left_tex = Loader.TexLoader.LoadFile(@path + left_tex);
            this.top_tex = Loader.TexLoader.LoadFile(@path + top_tex);
            this.down_tex = Loader.TexLoader.LoadFile(@path + down_tex);
            SetCorners();

        }
        public Box(float xPos, float yPos, float zPos,float rotAngle,Vector3 rotVector, float length, float width, float height, int normals_factor,int x_tex_factor,int y_tex_factor, string path, string tex)
        {
            GL.Enable(EnableCap.Texture2D);
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.rotAngle = rotAngle;
            this.rotVector = rotVector;
            this.length = length;
            this.width = width;
            this.height = height;
            this.normals_factor = normals_factor;
            this.x_tex_factor = x_tex_factor;
            this.y_tex_factor = y_tex_factor;
            int texture = Loader.TexLoader.LoadFile(@path + tex);
            this.front_tex = texture;
            this.back_tex = texture;
            this.right_tex = texture;
            this.left_tex = texture;
            this.top_tex = texture;
            this.down_tex = texture;
            SetCorners();
        }
        public Box(float xPos, float yPos, float zPos, float rotAngle, Vector3 rotVector, float length, float width, float height, int normals_factor, int x_tex_factor, int y_tex_factor, string path, int tex)
        {
            GL.Enable(EnableCap.Texture2D);
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.rotAngle = rotAngle;
            this.rotVector = rotVector;
            this.length = length;
            this.width = width;
            this.height = height;
            this.normals_factor = normals_factor;
            this.x_tex_factor = x_tex_factor;
            this.y_tex_factor = y_tex_factor;
            this.front_tex = tex;
            this.back_tex = tex;
            this.right_tex = tex;
            this.left_tex = tex;
            this.top_tex = tex;
            this.down_tex = tex;
            SetCorners();
        }
        public Box(float xPos, float yPos, float zPos, float rotAngle, Vector3 rotVector, float length, float width, float height, int normals_factor, int x_tex_factor, int y_tex_factor, string path, string tex, string top_tex)
        {
            GL.Enable(EnableCap.Texture2D);
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.rotAngle = rotAngle;
            this.rotVector = rotVector;
            this.length = length;
            this.width = width;
            this.height = height;
            this.normals_factor = normals_factor;
            this.x_tex_factor = x_tex_factor;
            this.y_tex_factor = y_tex_factor;
            int texture = Loader.TexLoader.LoadFile(@path + tex);
            this.front_tex = texture;
            this.back_tex = texture;
            this.right_tex = texture;
            this.left_tex = texture;
            this.top_tex = this.top_tex = Loader.TexLoader.LoadFile(@path + top_tex);
            this.down_tex = texture;
            SetCorners();
        }
        public override void Draw()
        {
            GL.PushMatrix();
            GL.Translate(xPos, yPos, zPos);
            GL.Rotate(rotAngle, rotVector);

            // draw front face
            GL.BindTexture(TextureTarget.Texture2D, front_tex);
            GL.Begin(BeginMode.Quads);
            GL.Normal3(0, 0, normals_factor);
            GL.TexCoord2(0, y_tex_factor);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.TexCoord2(x_tex_factor, y_tex_factor);
            GL.Vertex3(length, 0.0f, 0.0f);
            GL.TexCoord2(x_tex_factor, 0);
            GL.Vertex3(length, height, 0.0f);
            GL.TexCoord2(0, 0);
            GL.Vertex3(0.0f, height, 0.0f);
            GL.End();
            // draw back face
            GL.BindTexture(TextureTarget.Texture2D, back_tex);
            GL.Begin(BeginMode.Quads);
            GL.Normal3(0, 0, -normals_factor);
            GL.TexCoord2(0, y_tex_factor);
            GL.Vertex3(length, 0.0f, -width);
            GL.TexCoord2(x_tex_factor, y_tex_factor);
            GL.Vertex3(0.0f, 0.0f, -width);
            GL.TexCoord2(x_tex_factor, 0);
            GL.Vertex3(0.0f, height, -width);
            GL.TexCoord2(0, 0);
            GL.Vertex3(length, height, -width);
            GL.End();
            // draw right face
            GL.BindTexture(TextureTarget.Texture2D, right_tex);
            GL.Begin(BeginMode.Quads);
            GL.Normal3(normals_factor, 0, 0);
            GL.TexCoord2(0, y_tex_factor);
            GL.Vertex3(length, 0.0f, 0.0f);
            GL.TexCoord2(x_tex_factor, y_tex_factor);
            GL.Vertex3(length, 0.0f, -width);
            GL.TexCoord2(x_tex_factor, 0);
            GL.Vertex3(length, height, -width);
            GL.TexCoord2(0, 0);
            GL.Vertex3(length, height, 0.0f);
            GL.End();
            // draw left face
            GL.BindTexture(TextureTarget.Texture2D, left_tex);
            GL.Begin(BeginMode.Quads);
            GL.Normal3(-normals_factor, 0, 0);
            GL.TexCoord2(0, y_tex_factor);
            GL.Vertex3(0.0f, 0.0f, -width);
            GL.TexCoord2(x_tex_factor, y_tex_factor);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.TexCoord2(x_tex_factor, 0);
            GL.Vertex3(0.0f, height, 0.0f);
            GL.TexCoord2(0, 0);
            GL.Vertex3(0.0f, height, -width);
            GL.End();
            // draw up face
            GL.BindTexture(TextureTarget.Texture2D, top_tex);
            GL.Begin(BeginMode.Quads);
            GL.Normal3(0, normals_factor, 0);
            GL.TexCoord2(0, y_tex_factor);
            GL.Vertex3(0.0f, height, 0.0f);
            GL.TexCoord2(x_tex_factor, y_tex_factor);
            GL.Vertex3(length, height, 0.0f);
            GL.TexCoord2(x_tex_factor, 0);
            GL.Vertex3(length, height, -width);
            GL.TexCoord2(0, 0);
            GL.Vertex3(0.0f, height, -width);
            GL.End();
            // draw down face
            GL.BindTexture(TextureTarget.Texture2D, down_tex);
            GL.Begin(BeginMode.Quads);
            GL.Normal3(0, -normals_factor, 0);
            GL.TexCoord2(0, y_tex_factor);
            GL.Vertex3(0.0f, 0.0f, -width);
            GL.TexCoord2(x_tex_factor, y_tex_factor);
            GL.Vertex3(length, 0.0f, -width);
            GL.TexCoord2(x_tex_factor, 0);
            GL.Vertex3(length, 0.0f, 0.0f);
            GL.TexCoord2(0, 0);
            GL.Vertex3(0.0f, 0.0f, 0.0f);
            GL.End();

            GL.PopMatrix();

        }
        public void SetCorners()
        {
            Vector3 downLeftCornerBeforeRotation = new Vector3(this.xPos, this.yPos, this.zPos);
            Vector3 upRightCornerBeforeRotation = new Vector3(this.xPos + this.length, this.yPos + this.height, this.zPos - this.width);
            origin = downLeftCornerBeforeRotation;
            if (rotAngle != 0)
            {
                Vector3 v1 = downLeftCornerBeforeRotation;
                Vector3 v2 = Helper.RotatePosition(upRightCornerBeforeRotation, rotAngle, rotVector, origin);
                downLeftCorner = new Vector3(Math.Min(v1.X, v2.X), Math.Min(v1.Y, v2.Y), Math.Max(v1.Z, v2.Z));
                upRightCorner = new Vector3(Math.Max(v1.X, v2.X), Math.Max(v1.Y, v2.Y), Math.Min(v1.Z, v2.Z));
            }
            else
            {
                downLeftCorner = downLeftCornerBeforeRotation;
                upRightCorner = upRightCornerBeforeRotation;
            }
        }
        public override bool CheckCollision(BoundingBox targetBoundingBox)
        {
            foreach (Vector3 targetPoint in targetBoundingBox.pointsList)
            {
                if ((targetPoint.X >= downLeftCorner.X && targetPoint.X <= upRightCorner.X) && (targetPoint.Y >= downLeftCorner.Y && targetPoint.Y <= upRightCorner.Y) && (targetPoint.Z <= downLeftCorner.Z && targetPoint.Z >= upRightCorner.Z))
                    return true;
            }
            return false;
        }
    }
}
