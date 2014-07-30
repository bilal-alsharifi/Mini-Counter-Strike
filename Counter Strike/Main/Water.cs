using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;


namespace Counter_Strike
{
    class Water
    {
        int water = Loader.TexLoader.LoadFile(@"Media/Garden Texture/SummerTime.bmp");
        float xPos;
        float yPos;
        float zPos;
        float length;
        Box box;
        public Water(Vector3 vec,float length)
        {
            this.xPos = vec.X;
            this.yPos = vec.Y;
            this.zPos = vec.Z;
            this.length = length;
        }
        public void Draw_Water(float time)
        {
            
            GL.PushMatrix();
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.DepthMask(false);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusConstantAlpha);
            GL.BindTexture(TextureTarget.Texture2D, water);
            
            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(this.xPos, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos);
            GL.TexCoord2(1, 0);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos);
            GL.TexCoord2(1, 1);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + (this.length) / 3);
            GL.TexCoord2(0, 1);
            GL.Vertex3(this.xPos, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + (this.length) / 3);
            GL.End();

            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos);
            GL.TexCoord2(1, 0);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos);
            GL.TexCoord2(1, 1);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + (this.length) / 3);
            GL.TexCoord2(0, 1);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + (this.length) / 3);
            GL.End();

            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos);
            GL.TexCoord2(1, 0);
            GL.Vertex3(this.xPos + this.length, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos);
            GL.TexCoord2(1, 1);
            GL.Vertex3(this.xPos + this.length, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + (this.length) / 3);
            GL.TexCoord2(0, 1);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + (this.length) / 3);
            GL.End();

            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(this.xPos, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + (this.length) / 3);
            GL.TexCoord2(1, 0);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + (this.length) / 3);
            GL.TexCoord2(1, 1);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + 2 * (this.length) / 3);
            GL.TexCoord2(0, 1);
            GL.Vertex3(this.xPos, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + 2 * (this.length) / 3);
            GL.End();

            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time-0.3), this.zPos + (this.length) / 3);
            GL.TexCoord2(1, 0);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time -0.3), this.zPos + (this.length) / 3);
            GL.TexCoord2(1, 1);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time -0.3), this.zPos + 2 * (this.length) / 3);
            GL.TexCoord2(0, 1);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time -0.3), this.zPos + 2 * (this.length) / 3);
            GL.End();

            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + (this.length) / 3);
            GL.TexCoord2(1, 0);
            GL.Vertex3(this.xPos + this.length, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + (this.length) / 3);
            GL.TexCoord2(1, 1);
            GL.Vertex3(this.xPos + this.length, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + 2 * (this.length) / 3);
            GL.TexCoord2(0, 1);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + 2 * (this.length) / 3);
            GL.End();


            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(this.xPos, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + 2 * (this.length) / 3);
            GL.TexCoord2(1, 0);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + 2 * (this.length) / 3);
            GL.TexCoord2(1, 1);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + 3 * (this.length) / 3);
            GL.TexCoord2(0, 1);
            GL.Vertex3(this.xPos, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + 3 * (this.length) / 3);
            GL.End();

            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + 2 * (this.length) / 3);
            GL.TexCoord2(1, 0);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + 2 * (this.length) / 3);
            GL.TexCoord2(1, 1);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + 3 * (this.length) / 3);
            GL.TexCoord2(0, 1);
            GL.Vertex3(this.xPos + (this.length) / 3, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + 3 * (this.length) / 3);
            GL.End();

            GL.Begin(BeginMode.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + 2 * (this.length) / 3);
            GL.TexCoord2(1, 0);
            GL.Vertex3(this.xPos + this.length, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + 2 * (this.length) / 3);
            GL.TexCoord2(1, 1);
            GL.Vertex3(this.xPos + this.length, this.yPos + 0.4 * Math.Sin(time - 0.3), this.zPos + 3 * (this.length) / 3);
            GL.TexCoord2(0, 1);
            GL.Vertex3(this.xPos + 2 * (this.length) / 3, this.yPos + 0.4 * Math.Sin(time + 1), this.zPos + 3 * (this.length) / 3);
            GL.End();

            GL.Disable(EnableCap.Blend);
            GL.DepthMask(true);
            GL.PopMatrix();   
        }
    } 
  }  

