using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;


namespace Counter_Strike
{
    class House2 : Obj
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
        Box back_wall_part;
        Box front_wall_part1;
        Box front_wall_part2;
        public Box door;
        Box front_wall_part3;
        Box roof;
        Box right_room_wall1;
        Box right_room_wall2;
        Box right_room_wall3;
        Box right_room_wall4;
        Box right_room_wall5;
        Box right_room_wall6;
        Box left_room_wall1;
        Box left_room_wall2;

        public House2(float xPos, float yPos, float zPos, float length, float width, float height, string path, string house_texture, string metal_fence_tex, string door_tex, string bridge_tex, string box_tex, string cylinder_tex, float thickness_of_wall)
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
            back_wall_part = new Box(xPos, yPos, zPos - width + thickness_of_wall, 0, Vector3.Zero, length, thickness_of_wall, height, 1, 1, 1, path, house_tex);
            objList.Add(back_wall_part);
            front_wall_part1 = new Box(xPos, yPos, zPos, 0, Vector3.Zero, 4 * length / 9, thickness_of_wall, height, 1, 1, 1, path, house_tex);
            objList.Add(front_wall_part1);
            front_wall_part2 = new Box(xPos + ((4 * length) / 9), yPos + 3*(height / 4), zPos, 0, Vector3.Zero, length / 9, thickness_of_wall, height / 4, 1, 1, 1, path, house_tex);
            front_wall_part3 = new Box(xPos + ((5 * length) / 9), yPos, zPos, 0, Vector3.Zero, 4 * length / 9, thickness_of_wall, height, 1, 1, 1, path, house_tex);
            objList.Add(front_wall_part3);
            door = new Box(xPos + (4 * length) / 9, yPos, zPos, 0, Vector3.Zero, length / 9, thickness_of_wall, 3 * height / 4, 1, 1, 1, path, door_tex);
            roof = new Box(xPos, yPos + this.height, zPos, 0, Vector3.Zero, this.length, this.width, this.thickness_of_wall, 1, 1, 1, path, house_tex);
            left_room_wall1 = new Box(this.xPos, this.yPos, this.zPos - width / 2, 0, Vector3.Zero, 3 * this.length / 9, this.thickness_of_wall, this.height, 1, 1, 1, path, house_tex);
            objList.Add(left_room_wall1);
            left_room_wall2 = new Box(this.xPos + 3 * this.length / 9, this.yPos, this.zPos - this.width / 15, 0, Vector3.Zero, this.thickness_of_wall, 13 * this.width / 15, this.height, 1, 1, 1, path, house_tex);
            objList.Add(left_room_wall2);
            right_room_wall1 = new Box(this.xPos + 6 * this.length / 9, this.yPos, this.zPos - this.width / 4, 0, Vector3.Zero, 3 * this.length / 9, this.thickness_of_wall, this.height, 1, 1, 1, path, house_tex);
            objList.Add(right_room_wall1);
            right_room_wall3 = new Box(this.xPos + 6 * this.length / 9, this.yPos, this.zPos - this.width / 2, 0, Vector3.Zero, 3 * this.length / 9, this.thickness_of_wall, this.height, 1, 1, 1, path, house_tex);
            objList.Add(right_room_wall3);
            right_room_wall5 = new Box(this.xPos + 6 * this.length / 9, this.yPos, this.zPos - 3 * this.width / 4, 0, Vector3.Zero, 3 * this.length / 9, this.thickness_of_wall, this.height, 1, 1, 1, path, house_tex);
            objList.Add(right_room_wall5);
            right_room_wall2 = new Box(this.xPos + 6 * this.length / 9, this.yPos, this.zPos - this.width / 10, 0, Vector3.Zero, this.thickness_of_wall, this.width / 5, this.height, 1, 1, 1, path, house_tex);
            objList.Add(right_room_wall2);
            right_room_wall4 = new Box(this.xPos + 6 * this.length / 9, this.yPos, this.zPos - 4 * this.width / 10, 0, Vector3.Zero, this.thickness_of_wall, this.width / 5, this.height, 1, 1, 1, path, house_tex);
            objList.Add(right_room_wall3);
            right_room_wall6 = new Box(this.xPos + 6 * this.length / 9, this.yPos, this.zPos - 7 * this.width / 10, 0, Vector3.Zero, this.thickness_of_wall, this.width / 5, this.height, 1, 1, 1, path, house_tex);
            objList.Add(right_room_wall6);
        }
        public override void Draw()
        {
            left_wall.Draw();
            right_wall.Draw();
            back_wall_part.Draw();
            front_wall_part1.Draw();
            front_wall_part2.Draw();
            front_wall_part3.Draw();
            door.Draw();
            roof.Draw();
            left_room_wall1.Draw();
            left_room_wall2.Draw();
            right_room_wall1.Draw();
            right_room_wall3.Draw();
            right_room_wall5.Draw();
            right_room_wall2.Draw();
            right_room_wall4.Draw();
            right_room_wall6.Draw();
        }
    }
}
