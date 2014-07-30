using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;

namespace Counter_Strike
{
    class House1 : Obj
    {
        float xPos;
        float yPos;
        float zPos;
        float length;
        float width;
        float height;
        float thickness_of_wall;
        Box left_wall;
        Box right_wall;
        Box back_wall_part1;
        Box back_wall_part2;
        Box back_wall_part3;
        Box back_wall_part4;
        Box front_wall_part1;
        Box front_wall_part2;
        public Box door;
        Box front_wall_part3;
        Box second_floor1;
        Box wall_side1;
        Box wall_side2;
        Box second_floor2;
        Box floor_left;
        Box floor_right;
        Box roof;
        Box box1;
        Box box2;
        Box box3;
        Box box4;
        Cylinder cylinder1;
        Cylinder cylinder2;
        Cylinder cylinder3;
        Cylinder cylinder4;

        public House1(float xPos, float yPos, float zPos, float length, float width, float height, string path, string house_texture, string metal_fence_tex, string door_tex, string bridge_tex, string box_tex, string cylinder_tex, float thickness_of_wall)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.length = length;
            this.width = width;
            this.height = height;
            this.thickness_of_wall = thickness_of_wall;
            int house_tex = Loader.TexLoader.LoadFile(@path + house_texture);


            left_wall = new Box(xPos, yPos, zPos, 0, Vector3.Zero, thickness_of_wall, width, height, 1, 1, 1, path, house_tex);
            objList.Add(left_wall);
            right_wall = new Box(xPos + length - thickness_of_wall, yPos, zPos, 0, Vector3.Zero, thickness_of_wall, width, height, 1, 1, 1, path, house_tex);
            objList.Add(right_wall);
            back_wall_part1 = new Box(xPos, yPos, zPos - width + thickness_of_wall, 0, Vector3.Zero, length / 4, thickness_of_wall, height, 1, 1, 1, path, house_tex);
            objList.Add(back_wall_part1);
            back_wall_part2 = new Box(xPos + (length / 4), yPos + ((3 * height) / 5), zPos - width + thickness_of_wall, 0, Vector3.Zero, length / 2, thickness_of_wall, (2 * height) / 5, 1, 1, 1, path, house_tex);
            back_wall_part3 = new Box(xPos + (length / 4), yPos + ((2 * height) / 5), zPos - width + thickness_of_wall, 0, Vector3.Zero, length / 2, thickness_of_wall, height / 5, 1, 1, 1, path, metal_fence_tex);
            back_wall_part4 = new Box(xPos + (3 * length) / 4, yPos, zPos - width + thickness_of_wall, 0, Vector3.Zero, length / 4, thickness_of_wall, height, 1, 1, 1, path, house_tex);
            objList.Add(back_wall_part4);
            front_wall_part1 = new Box(xPos, yPos, zPos, 0, Vector3.Zero, 2 * length / 8, thickness_of_wall, height, 1, 1, 1, path, house_tex);
            objList.Add(front_wall_part1);
            front_wall_part2 = new Box(xPos + ((2 * length) / 8), yPos + (height / 4), zPos, 0, Vector3.Zero, length / 8, thickness_of_wall, 3 * height / 4, 1, 1, 1, path, house_tex);
            front_wall_part3 = new Box(xPos + ((3 * length) / 8), yPos, zPos, 0, Vector3.Zero, 5 * length / 8, thickness_of_wall, height, 1, 1, 1, path, house_tex);
            objList.Add(front_wall_part3);
            door = new Box(xPos + ((2 * length) / 8), yPos, zPos, 0, Vector3.Zero, length / 8, thickness_of_wall, height / 4, 1, 1, 1, path, door_tex);
            second_floor1 = new Box(xPos + ((7 * length) / 8), yPos + height / 4 + thickness_of_wall / 2 * (float)Math.Sin(45), zPos - thickness_of_wall, 0, Vector3.Zero, length / 8 - thickness_of_wall, (width - (height / 4)) / 2 - thickness_of_wall + height / 4, thickness_of_wall, 1, 1, 1, path, house_tex);
            wall_side1 = new Box(xPos + ((7 * length) / 8), yPos + height / 4 + thickness_of_wall / 2 * (float)Math.Sin(45), zPos - thickness_of_wall, 0, Vector3.Zero, thickness_of_wall, (width - (height / 4)) / 2 - thickness_of_wall + height / 4, height / 4, 1, 1, 1, path, house_tex);
            wall_side2 = new Box(xPos + ((7 * length) / 8), yPos + height / 2, zPos - (width - (height / 4)) / 6 - thickness_of_wall, 0, Vector3.Zero, thickness_of_wall, (width - (height / 4)) / 2 - thickness_of_wall + height / 4 - (width - (height / 4)) / 6, height / 2, 1, 1, 1, path, house_tex);
            second_floor2 = new Box(xPos + length / 4 + thickness_of_wall, height / 2, zPos - thickness_of_wall, 0, Vector3.Zero, 5 * length / 8, (width - (height / 4)) / 2 - thickness_of_wall + height / 4, thickness_of_wall + thickness_of_wall / 2 * (float)Math.Sin(45), 1, 1, 1, path, house_tex);
            box1 = new Box(xPos + 2 * thickness_of_wall, yPos + thickness_of_wall, zPos - 2 * thickness_of_wall, 0, Vector3.Zero, height / 10, height / 10, height / 10, 1, 1, 1, path, box_tex);
            objList.Add(box1);
            box2 = new Box(xPos + 2 * thickness_of_wall, yPos + thickness_of_wall, zPos - 2 * thickness_of_wall - 3 * width / 4, 0, Vector3.Zero, height / 10, height / 10, height / 10, 1, 1, 1, path, box_tex);
            objList.Add(box2);
            cylinder1 = new Cylinder(xPos + 2 * thickness_of_wall + height / 18, yPos + thickness_of_wall, zPos - 3 * thickness_of_wall - height / 10 - height / 18, -90, Vector3.UnitX, height / 18, height / 8, path, cylinder_tex);
            objList.Add(cylinder1);
            cylinder2 = new Cylinder(xPos + 2 * thickness_of_wall + height / 18, yPos + thickness_of_wall, zPos - 2 * thickness_of_wall - 3 * width / 4 + height / 10, -90, Vector3.UnitX, height / 18, height / 8, path, cylinder_tex);
            objList.Add(cylinder2);
            box3 = new Box(xPos + length - height / 4 + thickness_of_wall, yPos + thickness_of_wall, zPos - 2 * thickness_of_wall, 0, Vector3.Zero, height / 10, height / 10, height / 10, 1, 1, 1, path, box_tex);
            objList.Add(box3);
            box4 = new Box(xPos + length - height / 4 + thickness_of_wall, yPos + thickness_of_wall, zPos - 2 * thickness_of_wall - 3 * width / 4 + 3 * height / 10, 0, Vector3.Zero, height / 10, height / 10, height / 10, 1, 1, 1, path, box_tex);
            objList.Add(box4);
            cylinder3 = new Cylinder(xPos + length - height / 4 + height / 18, yPos + thickness_of_wall, zPos - 3 * thickness_of_wall - height / 10 - height / 18, -90,Vector3.UnitX, height / 18, height / 8, path, cylinder_tex);
            objList.Add(cylinder3);
            cylinder4 = new Cylinder(xPos + length - height / 4 + height / 18, yPos + thickness_of_wall, zPos - 2 * thickness_of_wall - 3 * width / 4 + height / 10,-90,Vector3.UnitX, height / 18, height / 8, path, cylinder_tex);
            objList.Add(cylinder4);
            floor_left = new Box(xPos+this.thickness_of_wall, yPos, zPos-this.thickness_of_wall, 0, Vector3.Zero, this.length / 4-this.thickness_of_wall, this.width-2*this.thickness_of_wall, thickness_of_wall, 1, 1, 1, path, bridge_tex);
            floor_right = new Box(xPos + 3 * this.length / 4, yPos, zPos - this.thickness_of_wall, 0, Vector3.Zero, this.length / 4 - this.thickness_of_wall, this.width - 2 * this.thickness_of_wall, thickness_of_wall, 1, 1, 1, path, bridge_tex);
            roof = new Box(xPos, yPos + this.height, zPos, 0, Vector3.Zero, this.length, this.width, this.thickness_of_wall, 1, 1, 1, path, house_tex);
        }
        public override void Draw()
        {
            left_wall.Draw();
            right_wall.Draw();
            back_wall_part1.Draw();
            back_wall_part2.Draw();
            back_wall_part3.Draw();
            back_wall_part4.Draw();
            front_wall_part1.Draw();
            front_wall_part2.Draw();
            front_wall_part3.Draw();
            door.Draw();
            second_floor1.Draw();
            wall_side1.Draw();
            wall_side2.Draw();
            second_floor2.Draw();
            box1.Draw();
            box2.Draw();
            cylinder1.Draw();
            cylinder2.Draw();
            box3.Draw();
            box4.Draw();
            cylinder3.Draw();
            cylinder4.Draw();
            floor_left.Draw();
            floor_right.Draw();
            roof.Draw();
        }
    }
}
