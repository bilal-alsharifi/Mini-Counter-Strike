using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using System.Collections.Generic;

namespace Counter_Strike
{
    static class Helper
    {
        public static Vector3 RotatePosition(Vector3 pos, float rotAngle,Vector3 axis ,Vector3 origin)
        {
            Matrix4 m = Matrix4.CreateTranslation(-origin) * Matrix4.CreateFromAxisAngle(axis, MathHelper.DegreesToRadians(rotAngle)) * Matrix4.CreateTranslation(origin);
            return Vector3.Transform(pos, m);
        }
        public static Vector3 GetPositionFromModelViewMatrix(Matrix4 modelViewMatrix, Matrix4 rotMatrix)
        {
            Matrix4 mat = modelViewMatrix * Matrix4.Invert(rotMatrix);
            Vector3 r = new Vector3();
            r.X = -mat.M41;
            r.Y = -mat.M42;
            r.Z = -mat.M43;
            return r;
        }
        public static void EnableFog(float density)
        {
            if (density > 0)
            {
                GL.Enable(EnableCap.Fog);
                float[] color = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
                GL.Fog(FogParameter.FogColor, color);
                GL.Fog(FogParameter.FogMode, 1);
                GL.Fog(FogParameter.FogDensity, density);
                GL.Hint(HintTarget.FogHint, HintMode.Nicest);
                GL.Fog(FogParameter.FogStart, 1.0f);
                GL.Fog(FogParameter.FogEnd, 10.0f);
            }
            else
            {
                GL.Disable(EnableCap.Fog);
            }
        }
    }
}
