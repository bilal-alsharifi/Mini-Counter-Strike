using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using System.Collections.Generic;

namespace Counter_Strike
{
    class Cylinder : Obj
    {
        IntPtr q;
        int tex;
        float radius;
        float height;
        float xPos;
        float yPos;
        float zPos;
        float rotAngle;
        Vector3 rotVector;
        Vector3 downLeftCorner;
        Vector3 upRightCorner;
        Vector3 origin;

        public Cylinder(float xPos, float yPos, float zPos,float rotAngle,Vector3 rotVector,float radius, float height,string path,string tex)
        {
            GL.Enable(EnableCap.Texture2D);
            this.tex = Loader.TexLoader.LoadFile(@path + tex);
            q = Glu.NewQuadric();
            Glu.QuadricTexture(q, true);
            this.radius = radius;
            this.height = height;
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.rotAngle = rotAngle;
            this.rotVector = rotVector;
            SetCorners();
        }
        public override void Draw()
        {
            GL.PushMatrix();
            GL.Translate(xPos, yPos, zPos);
            GL.Rotate(rotAngle, rotVector);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            Glu.Cylinder(q, radius, radius, height, 32, 32);
            Glu.Disk(q, 0, radius, 32, 1);
            GL.Translate(0, 0, height);
            Glu.Disk(q, 0, radius, 32, 1);

            GL.PopMatrix();
  
        }
        public void SetCorners()
        {
            Vector3 downLeftCornerBeforeRotation = new Vector3(this.xPos - this.radius, this.yPos - radius, this.zPos + this.height);
            Vector3 upRightCornerBeforeRotation = new Vector3(this.xPos + this.radius, this.yPos + this.radius, this.zPos);
            origin = new Vector3(xPos, yPos, zPos);

            if (rotAngle != 0)
            {
                Vector3 v1 = Helper.RotatePosition(downLeftCornerBeforeRotation, rotAngle, rotVector, origin);
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
