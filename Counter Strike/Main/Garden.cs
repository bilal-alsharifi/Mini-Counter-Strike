using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;

namespace Counter_Strike
{
    class Garden : Obj
    {
        float xPos;
        float yPos;
        float zPos;
        float length;
        float width;
        float garden_fence_height;
        Box grass;
        Box fence1;
        Box fence2;
        Box fence3;
        Box door;
        Box lake_wall_front;
        Box lake_wall_back;
        Box lake_wall_right;
        Box lake_wall_left;
        Box lake_wall_dawn;
        Box roaster_base;
        Box roaster_middle1;
        Box roaster_middle2;
        Box roaster_middle3;
        Box roaster_middle4;
        Box roaster_smokestack;
        Lamp lamp1;
        Lamp lamp2;
        Lamp lamp3;
        Lamp lamp4;
        float height_of_lake = 15;
        float thickness_of_lake = 15;
        float thickness_of_roaster = 40;
        float environmentFenceThikness;
        int tex;
        string garden_fence_tex;
        string path;
        int part = 0;
        private float time = 0;
        Water dw;
        public Garden(float xPos, float yPos, float zPos, float length, float width, float garden_fence_height, float environmentFenceThikness, string path, string grass_tex, string garden_fence_tex, string fence_tex, string black_tex, string lake_tex, string roaster_tex, string candle_tex, string ball_tex, string lamp_Tex, string rock_tex)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.length = length;
            this.width = width;
            this.garden_fence_height = garden_fence_height;
            this.garden_fence_tex = fence_tex;
            this.path = path;
            dw = new Water(new Vector3(this.xPos + 2 * this.length / 5, this.yPos + 4 * this.thickness_of_lake / 5, this.zPos - 2 * this.width / 3), this.width/3);
            this.environmentFenceThikness = environmentFenceThikness;

            grass = new Box(this.xPos, this.yPos, this.zPos, 0, Vector3.Zero, this.length, this.width, 0.1f, 1, 10, 5, path, grass_tex);
            lake_wall_front = new Box(this.xPos + 2 * this.length / 5, this.yPos, zPos - this.width / 3, 0, Vector3.Zero, this.width / 3, thickness_of_lake, height_of_lake, 1, 1, 1, path, lake_tex);
            objList.Add(lake_wall_front);
            lake_wall_back = new Box(this.xPos + 2 * this.length / 5, this.yPos, zPos - 2 * this.width / 3 + thickness_of_lake, 0, Vector3.Zero, this.width / 3, thickness_of_lake, height_of_lake, 1, 1, 1, path, lake_tex);
            objList.Add(lake_wall_back);
            lake_wall_left = new Box(this.xPos + 2 * this.length / 5 , this.yPos, zPos - this.width / 3, 0, Vector3.Zero, thickness_of_lake, this.width / 3, height_of_lake, 1, 1, 1, path, lake_tex);
            objList.Add(lake_wall_left);
            lake_wall_right = new Box(this.xPos + 2 * this.length / 5 + width/3 - this.thickness_of_lake, this.yPos, zPos - this.width / 3, 0, Vector3.Zero, thickness_of_lake, this.width / 3, height_of_lake, 1, 1, 1, path, lake_tex);
            objList.Add(lake_wall_right);
            lake_wall_dawn = new Box(this.xPos + 2 * this.length / 5, this.yPos, zPos - this.width / 3, 0, Vector3.Zero, this.width / 3, this.width / 3, 0.2f, 1, 4, 4, path, rock_tex);
            roaster_base = new Box(this.xPos + this.length - thickness_of_roaster -environmentFenceThikness, yPos, zPos - this.width / 3, 0, Vector3.Zero, thickness_of_roaster, thickness_of_roaster, thickness_of_roaster/2, 1, 1, 1, path, roaster_tex);
            objList.Add(roaster_base);
            roaster_middle1 = new Box(this.xPos + this.length - thickness_of_roaster - environmentFenceThikness, yPos + thickness_of_roaster / 2, zPos - this.width / 3, 0, Vector3.Zero, thickness_of_roaster, 4, thickness_of_roaster / 2, 1, 1, 1, path, roaster_tex);
            roaster_middle2 = new Box(this.xPos + this.length - thickness_of_roaster - environmentFenceThikness, yPos + thickness_of_roaster / 2, zPos - this.width / 3 - thickness_of_roaster + 4, 0, Vector3.Zero, thickness_of_roaster, 4, thickness_of_roaster / 2, 1, 1, 1, path, roaster_tex);
            roaster_middle3 = new Box(this.xPos + this.length - thickness_of_roaster - environmentFenceThikness, yPos + thickness_of_roaster, zPos - this.width / 3, 0, Vector3.Zero, thickness_of_roaster, thickness_of_roaster, 4, 1, 1, 1, path, roaster_tex);
            roaster_middle4 = new Box(this.xPos + this.length - environmentFenceThikness - 4, yPos + thickness_of_roaster / 2, zPos - this.width / 3, 0, Vector3.Zero, 4, thickness_of_roaster, thickness_of_roaster / 2, 1, 1, 1, path, roaster_tex);
            roaster_smokestack = new Box(this.xPos + this.length - 3 * thickness_of_roaster / 4 - environmentFenceThikness, yPos + thickness_of_roaster, zPos - this.width / 3 - thickness_of_roaster / 4, 0, Vector3.Zero, thickness_of_roaster / 2, thickness_of_roaster / 2, thickness_of_roaster/2, 1, 1, 1, path, roaster_tex);
            tex = Loader.TexLoader.LoadFile(@path + candle_tex);
            lamp1 = new Lamp(this.xPos + this.length / 5, this.yPos, this.zPos - width / 4, 0, Vector3.Zero, 40, 1, path, lamp_Tex, ball_tex);
            objList.Add(lamp1);
            lamp2 = new Lamp(this.xPos + this.length / 5, this.yPos, this.zPos - 3 * width / 4, 0, Vector3.Zero, 40, 1, path, lamp_Tex, ball_tex);
            objList.Add(lamp2);
            lamp3 = new Lamp(this.xPos + 4 * this.length / 5, this.yPos, this.zPos - width / 4, 0, Vector3.Zero, 40, 1, path, lamp_Tex, ball_tex);
            objList.Add(lamp3);
            lamp4 = new Lamp(this.xPos + 4 * this.length / 5, this.yPos, this.zPos - 3 * width / 4, 0, Vector3.Zero, 40, 1, path, lamp_Tex, ball_tex);
            objList.Add(lamp4);
            fence1 = new Box(this.xPos, this.yPos, this.zPos - this.width, 0, Vector3.Zero, this.length, 10, garden_fence_height, 1, 15, 1, path, fence_tex, black_tex, black_tex, black_tex, black_tex, black_tex);
            objList.Add(fence1);
            fence2 = new Box(this.xPos, this.yPos, this.zPos, 0, Vector3.UnitY, 10, this.width / 3, garden_fence_height, 1, 5, 1, path, black_tex, black_tex, black_tex, fence_tex, black_tex, black_tex);
            objList.Add(fence2);
            fence3 = new Box(this.xPos, this.yPos, this.zPos - 2 * this.width / 3, 0, Vector3.UnitY, 10, this.width / 3, garden_fence_height, 1, 5, 1, path, black_tex, black_tex, black_tex, fence_tex, black_tex, black_tex);
            objList.Add(fence3);
            door = new Box(this.xPos, this.yPos, this.zPos - this.width / 3, 75, Vector3.UnitY, 10, this.width / 3, garden_fence_height, 1, 5, 1, path, black_tex, black_tex, black_tex, fence_tex, black_tex, black_tex);
            objList.Add(door);
        }
        public override void Draw()
        {

            grass.Draw();
            lake_wall_front.Draw();
            lake_wall_back.Draw();
            lake_wall_left.Draw();
            lake_wall_right.Draw();
            lake_wall_dawn.Draw();
            roaster_base.Draw();
            roaster_middle1.Draw();
            roaster_middle2.Draw();
            roaster_middle3.Draw();
            roaster_middle4.Draw();
            roaster_smokestack.Draw();
            dw.Draw_Water(time);
            time += 0.05f;
            lamp1.Draw();
            lamp2.Draw();
            lamp3.Draw();
            lamp4.Draw();
            Draw_Fire();
            GL.Enable(EnableCap.Blend);
            GL.DepthMask(false);
            GL.BlendFunc(BlendingFactorSrc.OneMinusConstantAlpha, BlendingFactorDest.SrcAlpha);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            fence1.Draw();
            fence2.Draw();
            fence3.Draw();
            door.Draw();
            GL.Disable(EnableCap.Blend);
            GL.DepthMask(true);


            
            
        }
        public void Draw_Fire()
        {
            GL.PushMatrix();
            GL.Translate(this.xPos + this.length - environmentFenceThikness - thickness_of_roaster / 2, +thickness_of_roaster / 2 + 6, zPos - this.width / 3 - thickness_of_roaster / 2);
            GL.Scale(5, 2, 2);
            GL.Rotate(180, Vector3.UnitZ);
            GL.Rotate(90, Vector3.UnitY);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, tex);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.OneMinusConstantAlpha, BlendingFactorDest.SrcAlpha);
            if (part % 4 == 0)
            {
                GL.Begin(BeginMode.Quads);
                GL.TexCoord2(0.5, 0); GL.Vertex3(5, -5, 0);
                GL.TexCoord2(0.5, 0.5); GL.Vertex3(5, 5, 0);
                GL.TexCoord2(0, 0.5); GL.Vertex3(-5, 5, 0);
                GL.TexCoord2(0, 0); GL.Vertex3(-5, -5, 0);
                GL.End();
            }
            else if (part % 4 == 1)
            {
                GL.Begin(BeginMode.Quads);
                GL.TexCoord2(1, 0); GL.Vertex3(5, -5, 0);
                GL.TexCoord2(1, 0.5); GL.Vertex3(5, 5, 0);
                GL.TexCoord2(0.5, 0.5); GL.Vertex3(-5, 5, 0);
                GL.TexCoord2(0.5, 0); GL.Vertex3(-5, -5, 0);
                GL.End();
            }
            else if (part % 4 == 2)
            {
                GL.Begin(BeginMode.Quads);
                GL.TexCoord2(1, 0.5); GL.Vertex3(5, -5, 0);
                GL.TexCoord2(1, 1); GL.Vertex3(5, 5, 0);
                GL.TexCoord2(0.5, 1); GL.Vertex3(-5, 5, 0);
                GL.TexCoord2(0.5, 0.5); GL.Vertex3(-5, -5, 0);
                GL.End();
            }
            else if (part % 4 == 3)
            {
                GL.Begin(BeginMode.Quads);
                GL.TexCoord2(0.5, 0.5); GL.Vertex3(5, -5, 0);
                GL.TexCoord2(0.5, 1); GL.Vertex3(5, 5, 0);
                GL.TexCoord2(0, 1); GL.Vertex3(-5, 5, 0);
                GL.TexCoord2(0, 0.5); GL.Vertex3(-5, -5, 0);
                GL.End();
            }
            part++;
            GL.Disable(EnableCap.Blend);
            GL.PopMatrix();
        }
    }
}
