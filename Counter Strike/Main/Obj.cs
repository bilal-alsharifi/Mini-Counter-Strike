using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using System.Collections.Generic;

namespace Counter_Strike
{
    abstract class Obj
    {
        public List<Obj> objList;
        public Obj()
        {
            objList=new List<Obj>();
        }
        public virtual bool CheckCollision(BoundingBox targetBoundingBox)
        {
            for (int i = 0; i < objList.Count; i++)
            {
                if (objList[i].CheckCollision(targetBoundingBox))
                    return true;
            }
            return false;
        }
        public abstract void Draw();
    }
}
