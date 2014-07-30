using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;

namespace Counter_Strike
{
    class Lamp : Obj
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
        Cylinder lamp_culum;
        Cylinder lamp_arm;
        Cylinder lamp_small_culum;

        public Lamp(float xPos, float yPos, float zPos, float rotAngle, Vector3 rotVector, float height, float radius, string path, string textureForColoum, string textureForball)
        {
            GL.Enable(EnableCap.Texture2D);
            this.tex = Loader.TexLoader.LoadFile(@path + textureForball);
            q = Glu.NewQuadric();
            Glu.QuadricTexture(q, true);
            this.radius = radius;
            this.height = height;
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.rotAngle = rotAngle;
            this.rotVector = rotVector;
            lamp_culum = new Cylinder(this.xPos, this.yPos+this.height, this.zPos, 90, Vector3.UnitX, this.radius, this.height, path, textureForColoum);
            objList.Add(lamp_culum);
            lamp_arm = new Cylinder(this.xPos, this.yPos + 2 * this.height / 3, this.zPos, 0, Vector3.Zero, this.radius, this.height / 4, path, textureForColoum);
            objList.Add(lamp_arm);
            lamp_small_culum = new Cylinder(this.xPos, this.yPos + 2 * this.height / 3 + this.height / 8, this.zPos + this.height / 4 - this.radius, 90, Vector3.UnitX, this.radius, this.height / 8, path, textureForColoum);
            objList.Add(lamp_small_culum);
        }

        public override void Draw()
        {
            lamp_culum.Draw();
            lamp_arm.Draw();
            lamp_small_culum.Draw();

            GL.PushMatrix();
            GL.Translate(this.xPos, this.yPos + 2 * this.height / 3 + this.height / 8 + this.radius, this.zPos + this.height / 4 - this.radius);
            GL.Rotate(rotAngle, rotVector);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            Glu.Sphere(q, this.radius, 32, 32);
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Translate(this.xPos, this.yPos + 2 * this.height / 3 + this.height / 8 + 2 * this.radius, this.zPos + this.height / 4 - this.radius);
            GL.Rotate(rotAngle, rotVector);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            GL.Enable(EnableCap.Blend);
            GL.DepthMask(false);
            GL.BlendFunc(BlendingFactorSrc.OneMinusConstantAlpha, BlendingFactorDest.SrcAlpha);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            Glu.Sphere(q, 3 * this.radius, 32, 32);
            GL.Disable(EnableCap.Blend);
            GL.DepthMask(true);
            GL.PopMatrix();        
        }
    }
}
