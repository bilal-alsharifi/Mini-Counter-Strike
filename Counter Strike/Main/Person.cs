using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using System.Collections.Generic;

namespace Counter_Strike
{
    class Person
    {
        public BoundingBox boundingBox;
        Vector3 pos;
        float rotAngle;
        OpenTK.Vector3 rotVector;
        float length;
        float width;
        float height;
        public Loader.Model model;
        public Person(Vector3 pos, Vector3 scale, float rotAngle, OpenTK.Vector3 rotVector,float length, float width, float height, string path, string objFile, string texture)
        {
            this.pos = pos;
            this.rotAngle = rotAngle;
            this.rotVector = rotVector;
            this.length = length;
            this.width = width;
            this.height = height;
            boundingBox = new BoundingBox(this.pos, this.length, this.width, this.height);
            model = new Loader.Model(this.pos, scale, this.rotAngle, this.rotVector, path, objFile, texture);
        }
        public void setPos(Vector3 pos)
        {
            this.pos = pos;
            this.boundingBox.SetCenter(pos);
            this.model.setPos(pos);
        }
        public Vector3 getPos()
        {
            return this.pos;
        }
        public void Draw(float rotAngle, Vector3 rotVector)
        {
            this.rotAngle = rotAngle;
            this.rotVector = rotVector;
            model.setRot(this.rotAngle, this.rotVector);
            model.Draw();
        }
    }
}
