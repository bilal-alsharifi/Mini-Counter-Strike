using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;

namespace Counter_Strike
{
    class Environment : Obj
    {
        public Box front_fence;
        public Box back_fence;
        public Box right_fence;
        public Box left_fence;
        public Box skyBox;
        public Box floor;
        float skyBox_length;
        float skyBox_width;
        float skyBox_height;
        float floor_thikness;
        float fence_thikness;
        public Environment(float shyBox_length, float shyBox_width, float shyBox_height, float floor_thikness, float fence_thikness, float fence_height, string path, string front_tex, string back_tex, string right_tex, string left_tex, string top_tex, string down_tex, string fence_tex)
        {
            this.skyBox_length = shyBox_length;
            this.skyBox_width = shyBox_width;
            this.skyBox_height = shyBox_height;
            this.fence_thikness = fence_thikness;
            this.floor_thikness = floor_thikness;
            skyBox = new Box(0, -skyBox_height / 2, 0, 0, Vector3.Zero, this.skyBox_length, this.skyBox_width, this.skyBox_height, -1, 1, 1, path, front_tex, back_tex, right_tex, left_tex, top_tex, down_tex);
            floor = new Box(0, -floor_thikness, 0, 0, Vector3.Zero, this.skyBox_length, this.skyBox_width, this.floor_thikness, 1, 50, 50, path, down_tex);
            front_fence = new Box(0, 0, 0, 0, Vector3.Zero, this.skyBox_length, this.fence_thikness, fence_height, 1, 1, 1, path, fence_tex);
            objList.Add(front_fence);
            back_fence = new Box(0, 0, -skyBox_width + fence_thikness, 0, Vector3.Zero, this.skyBox_length, this.fence_thikness, fence_height, 1, 1, 1, path, fence_tex);
            objList.Add(back_fence);
            left_fence = new Box(0, 0, 0, 0, Vector3.Zero, this.fence_thikness, this.skyBox_width, fence_height, 1, 1, 1, path, fence_tex);
            objList.Add(left_fence);
            right_fence = new Box(skyBox_length - fence_thikness, 0, 0, 0, Vector3.Zero, this.fence_thikness, this.skyBox_width, fence_height, 1, 1, 1, path, fence_tex);
            objList.Add(right_fence);
        }
        public void Draw(Vector3 translationVector)
        {
            GL.Disable(EnableCap.DepthTest);
            GL.PushMatrix();
            GL.Translate(translationVector);
            skyBox.Draw();
            GL.PopMatrix();
            GL.Enable(EnableCap.DepthTest);
            floor.Draw();
            DrawFence();
        }
        public override void Draw()
        {
    
        }
        public void DrawFence()
        {
            front_fence.Draw();
            back_fence.Draw();
            left_fence.Draw();
            right_fence.Draw();
        }
    }
}
