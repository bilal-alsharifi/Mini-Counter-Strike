using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using System.Collections.Generic;

namespace Counter_Strike
{
    class BoundingBox
    {
        public List<Vector3> pointsList;
        public Vector3 center;
        float length;
        float width;
        float height;
        public BoundingBox(Vector3 center, float length, float width, float height)
        {
            pointsList = new List<Vector3>();
            this.center = center;
            this.length = length;
            this.width = width;
            this.height = height;
            SetCenter(this.center);
        }
        public void SetCenter(Vector3 center)
        {
            this.center = center;
            pointsList.Clear();
            pointsList.Add(center);
            pointsList.Add(center + new Vector3(-length / 2, 0, 0));
            pointsList.Add(center + new Vector3(+length / 2, 0, 0));
            pointsList.Add(center + new Vector3(0, 0, +width / 2));
            pointsList.Add(center + new Vector3(0, 0, -width / 2));
            pointsList.Add(center + new Vector3(0, +height / 2, 0));
            pointsList.Add(center + new Vector3(0, -height / 2, 0));
            pointsList.Add(center + new Vector3(-length / 2, -height / 2, +width / 2));
            pointsList.Add(center + new Vector3(-length / 2, -height / 2, -width / 2));
            pointsList.Add(center + new Vector3(+length / 2, -height / 2, +width / 2));
            pointsList.Add(center + new Vector3(+length / 2, -height / 2, -width / 2));
            pointsList.Add(center + new Vector3(-length / 2, +height / 2, +width / 2));
            pointsList.Add(center + new Vector3(-length / 2, +height / 2, -width / 2));
            pointsList.Add(center + new Vector3(+length / 2, +height / 2, +width / 2));
            pointsList.Add(center + new Vector3(+length / 2, +height / 2, -width / 2));
        }
    }
}
