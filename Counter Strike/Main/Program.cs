// Released to the public domain. Use, modify and relicense at will.

using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using OpenTK.Input;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Counter_Strike
{
    class Game : GameWindow
    {
        Environment environment;
        float environmentLength = 1500;
        float environmentWidth = 2500;
        float environmentHeight = 2000;
        float environmentFenceThikness = 10;
        float environmentFloorThikness = 10;
        float environmentFenceHeight = 75;
        Person person;
        Box shootingBox1;
        Box shootingBox2;
        Box shootingBox3;
        Box shootingBox4;
        Box shootingBox5;
        Cylinder shootTarget1;
        Cylinder shootTarget2;
        Cylinder shootTarget3;
        Cylinder shootTarget4;
        Cylinder shootTarget5;
        Cylinder shootTarget6;
        Cylinder shootTarget7;
        Cylinder shootTarget8;
        Box building1;
        Box building2;
        Box building3;
        float yRot = 0;
        float shootGunYRot = 0;
        float xRot = 0;
        float rotStep = 0.02f;
        float xTranslation = 0;
        float yTranslation = 0;
        float zTranslation = 0;
        float translationStep = 5;
        float initialXPos = 1200;
        float initialYPos = 30;
        float initialZPos = -1100; 
        Vector3 pos;
        Vector3 prevPos;
        Vector3 bulletPos;
        float lookDistance = 3;
        float fogDensity = 0;
        float fogDensityStep = 0.0001f;
        Matrix4 xRotMatrix = Matrix4.Identity;
        Matrix4 yRotMatrix = Matrix4.Identity;
        Matrix4 totalYRotMatrix = Matrix4.Identity;
        Matrix4 translatationMatrix = Matrix4.Identity;
        Matrix4 PrevModelviewMatrixWithoutXRot = Matrix4.Identity;
        Matrix4 modelviewMatrixWithoutXRot = Matrix4.Identity;
        Matrix4 modelviewMatrixWithXRot = Matrix4.Identity;
        List<Obj> objList = new List<Obj>();
        List<Obj> BulletObjList = new List<Obj>();
        Vector3 translationVector;
        Loader.WavLoader shootSound;
        bool playShootSound = true;
        Loader.WavLoader goSound;
        Loader.WavLoader doorSound;
        Loader.WavLoader winSound;
        bool playDoor1Sound = true;
        bool playDoor2Sound = true;
        bool playWinSound = true;
        BoundingBox bullet;
        bool bulletThrown = false;
        Loader.WavLoader bulletSound;
        Matrix4 bulletMatrix=Matrix4.Identity;
        House1 house1;
        House2 house2;
        Garden garden;
        Lamp lamp1;
        Lamp lamp2;
        Lamp lamp3;
        Lamp lamp4;
        bool lightingEnabled=false;
        Loader.Model utility_truck;
        Loader.Model army_truck;
        Loader.Model tree1;
        Loader.Model tree2;



        /// <summary>Creates a 800x600 window with the specified title.</summary>
        public Game(): base(1024, 648, GraphicsMode.Default, "Counter Strike")
        {
            VSync = VSyncMode.On;
        }

        /// <summary>Load resources here.</summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);



            modelviewMatrixWithoutXRot = Matrix4.LookAt(new Vector3(initialXPos, initialYPos, initialZPos), new Vector3(initialXPos, initialYPos, initialZPos - lookDistance), Vector3.UnitY);         
            person = new Person(new Vector3(initialXPos, initialYPos, initialZPos), new Vector3(0.5f, 0.5f, 0.5f),shootGunYRot,Vector3.UnitY, 10, 10, 2 * initialYPos,"Media/Models/", "Shotgun.obj", "Shotgun.png");

            environment = new Environment(environmentLength, environmentWidth, environmentHeight, environmentFloorThikness, environmentFenceThikness, environmentFenceHeight, "Media/Environment Texture/", "front.jpg", "back.jpg", "right.jpg", "left.jpg", "top.jpg", "down.jpg","fence.jpg");
            objList.Add(environment);
            house1 = new House1(environmentFenceThikness+30, 0, -600, 300, 1000, 300, "Media/House Texture/", "houseTex1.jpg", "fenceHouseTex.jpg", "doorTex.jpg", "bridge.jpg", "boxTex.jpg", "cylinderTex.jpg", 6);
            objList.Add(house1);
            house2 = new House2(1050, 0, -650, 400, 700, 100, "Media/House Texture/", "houseTex2.jpg", "fenceHouseTex.jpg", "doorTex.jpg", "bridge.jpg", "boxTex.jpg", "cylinderTex.jpg", 6);
            objList.Add(house2);
            building1 = new Box(100, 0, -2100, 0, Vector3.Zero, 350, 350, 800, 1,1, 3, "Media/Box Texture/", "b1.jpg", "r1.jpg");
            objList.Add(building1);
            building2 = new Box(550, 0, -2100, 0, Vector3.Zero, 350, 350, 900, 1, 1, 1, "Media/Box Texture/", "b2.jpg", "r2.jpg");
            objList.Add(building2);
            building3 = new Box(1000, 0, -2100, 0, Vector3.Zero, 350, 350, 800, 1, 1, 1, "Media/Box Texture/", "b3.jpg", "r3.jpg");
            objList.Add(building3);
            lamp1 = new Lamp(50, 0, -2200, 0, Vector3.Zero, 100, 2, "Media/Lamp Texture/", "Tex.jpg", "ball_tex.jpg");
            objList.Add(lamp1);
            lamp2 = new Lamp(500, 0, -2200, 0, Vector3.Zero, 100, 2, "Media/Lamp Texture/", "Tex.jpg", "ball_tex.jpg");
            objList.Add(lamp2);
            lamp3 = new Lamp(950, 0, -2200, 0, Vector3.Zero, 100, 2, "Media/Lamp Texture/", "Tex.jpg", "ball_tex.jpg");
            objList.Add(lamp3); 
            lamp4 = new Lamp(1450, 0, -1800, 0, Vector3.Zero, 100, 2, "Media/Lamp Texture/", "Tex.jpg", "ball_tex.jpg");
            objList.Add(lamp4);

            shootingBox1 = new Box(500, 0, -900, 0, new Vector3(0, 0, 0), 200f, 100f, 25f, 1, 1, 1, "Media/Box Texture/", "tex.jpg");
            objList.Add(shootingBox1);
            shootTarget1 = new Cylinder(600, 25, -950, -90, Vector3.UnitX, 2, 7, "Media/Cylinder Texture/", "CocaCola.jpg");
            BulletObjList.Add(shootTarget1);
            objList.Add(shootTarget1);
            shootTarget2 = new Cylinder(610, 25, -950, -90, Vector3.UnitX, 2, 7, "Media/Cylinder Texture/", "ugaritCola.jpg");
            BulletObjList.Add(shootTarget2);
            objList.Add(shootTarget2);
            shootTarget3 = new Cylinder(620, 25, -950, -90, Vector3.UnitX, 2, 7, "Media/Cylinder Texture/", "bebsiCola.jpg");
            BulletObjList.Add(shootTarget3);
            objList.Add(shootTarget3);


            shootingBox2 = new Box(500, 0, -1400, 0, new Vector3(0, 0, 0), 200f, 100f, 25f, 1, 1, 1, "Media/Box Texture/", "tex.jpg");
            objList.Add(shootingBox2);
            shootingBox3 = new Box(500, 25, -1400, 0, new Vector3(0, 0, 0), 70f, 90f, 25f, 1, 1, 1, "Media/Box Texture/", "tex.jpg");
            objList.Add(shootingBox3);
            shootingBox4 = new Box(630, 25, -1400, 0, new Vector3(0, 0, 0), 70f, 90f, 25f, 1, 1, 1, "Media/Box Texture/", "tex.jpg");
            objList.Add(shootingBox4);
            shootTarget4 = new Cylinder(590, 25, -1440, -90, Vector3.UnitX, 2, 7, "Media/Cylinder Texture/", "CocaCola.jpg");
            BulletObjList.Add(shootTarget4);
            objList.Add(shootTarget4);
            shootTarget5 = new Cylinder(610, 25, -1440, -90, Vector3.UnitX, 2, 7, "Media/Cylinder Texture/", "ugaritCola.jpg");
            BulletObjList.Add(shootTarget5);
            objList.Add(shootTarget5);


            shootingBox5 = new Box(1000, 0, -10, 0, new Vector3(0, 0, 0), 200f, 5f, 75f, 1, 1, 1, "Media/Box Texture/", "tex.jpg");
            objList.Add(shootingBox5);
            shootTarget6 = new Cylinder(1050, 30, -15, -180, Vector3.UnitX, 10, 2, "Media/Cylinder Texture/", "shootingTarget.jpg");
            BulletObjList.Add(shootTarget6);
            objList.Add(shootTarget6);
            shootTarget7 = new Cylinder(1100, 30, -15, -180, Vector3.UnitX, 10, 2, "Media/Cylinder Texture/", "shootingTarget.jpg");
            BulletObjList.Add(shootTarget7);
            objList.Add(shootTarget7);
            shootTarget8 = new Cylinder(1150, 30, -15, -180, Vector3.UnitX, 10, 2, "Media/Cylinder Texture/", "shootingTarget.jpg");
            BulletObjList.Add(shootTarget8);
            objList.Add(shootTarget8);

            utility_truck = new Loader.Model(new Vector3(200, 0, -1100), new Vector3(1.0f, 1.0f, 1.0f), new Vector3(160, 0, -990), new Vector3(240, 100, -1210), "Media/Models/", "utility_truck.obj", "utility_truck.png");
            objList.Add(utility_truck);
            army_truck = new Loader.Model(new Vector3(1420, 0, -2350), new Vector3(0.2f, 0.2f, 0.2f), new Vector3(1390, 0, -2240), new Vector3(1450, 0, -2430), "Media/Models/", "army_truck.obj", "army_truck.png");
            objList.Add(army_truck);
            tree1 = new Loader.Model(new Vector3(1450, 0, -380), new Vector3(10f, 10f, 10f), new Vector3(1425, 0, -360), new Vector3(1475, 100, -400), "Media/Models/", "tree1.obj", "tree1.png");
            objList.Add(tree1);
            tree2 = new Loader.Model(new Vector3(525, 0, -380), new Vector3(1f, 1f, 1f), new Vector3(500, 0, -360), new Vector3(540, 100, -390), "Media/Models/", "tree2.obj", "tree2.png");
            objList.Add(tree2);

            garden = new Garden(environmentLength / 4, 0, -environmentFenceThikness + 10, 3 * environmentLength / 4, environmentWidth / 6, environmentFenceHeight, environmentFenceThikness, "Media/Garden Texture/", "grass.png", "garden_fence.jpg", "fence.png", "black.png", "lake.JPG", "roaster.jpg", "candle.png", "ball_tex.jpg", "lamp_Tex.jpg", "rock.jpg");
            objList.Add(garden);


            bullet = new BoundingBox(new Vector3(initialXPos, initialYPos, initialZPos), 5, 5, 5);

            shootSound = new Loader.WavLoader("Media/Audio/", "Shoot.wav");
            doorSound = new Loader.WavLoader("Media/Audio/", "Door.wav");
            goSound = new Loader.WavLoader("Media/Audio/", "GoGoGo.wav");
            goSound.play();
            bulletSound = new Loader.WavLoader("Media/Audio/", "bullet.wav");
            winSound = new Loader.WavLoader("Media/Audio/", "win.wav");

            

       

        }

        /// <summary>
        /// Called when your window is resized. Set your viewport here. It is also
        /// a good place to set up your projection matrix (which probably changes
        /// along when the aspect ratio of your window).
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 0.1f, 3000.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        /// <summary>
        /// Called when it is time to setup the next frame. Add you game logic here.
        /// </summary>
        /// <param name="e">Contains timing information for framerate independent logic.</param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            Helper.EnableFog(fogDensity);
            ProcessKeyboard();
            UpdateCamera();
            PlaySounds();
            if ((BulletObjList.Count == 0)&&(playWinSound))
            {
                winSound.play();
                playWinSound = false;
            }

        }

        /// <summary>
        /// Called when it is time to render the next frame. Add your rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


 

            environment.Draw(translationVector);
            EnableLighting();
            person.Draw(shootGunYRot, Vector3.UnitY);
            foreach (Obj obj in objList)
            {
                obj.Draw();
            }
            foreach (Obj target in BulletObjList)
            {
                target.Draw();
            }
            DisableLighting();





            SwapBuffers();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // The 'using' idiom guarantees proper resource cleanup.
            // We request 30 UpdateFrame events per second, and unlimited
            // RenderFrame events (as fast as the computer can handle).
            using (Game game = new Game())
            {
                game.Run(30.0);
            }
        }


        private void ProcessKeyboard()
        {
            yRot = 0;
            xTranslation = 0;
            yTranslation = 0;
            zTranslation = 0;

            if (Keyboard[Key.Escape])
                Exit();
            else if (Keyboard[Key.S])
                xRot += rotStep;
            else if (Keyboard[Key.W])
                xRot -= rotStep;
            else if (Keyboard[Key.A])
                yRot -= rotStep;
            else if (Keyboard[Key.D])
                yRot += rotStep;
            else if (Keyboard[Key.Down])
                zTranslation += translationStep;
            else if (Keyboard[Key.Up])
                zTranslation -= translationStep;
            else if (Keyboard[Key.Left] )
                xTranslation -= translationStep;
            else if (Keyboard[Key.Right])
                xTranslation += translationStep;

            if (Keyboard[Key.U])
                yTranslation += translationStep;
            else if (Keyboard[Key.J])
                yTranslation -= translationStep;

            if (Keyboard[Key.F])
                fogDensity += fogDensityStep;
            else if (Keyboard[Key.G])
            {
                fogDensity -= fogDensityStep;
                if (fogDensity < 0)
                    fogDensity = 0;
            }

            if (Keyboard[Key.Space])
            {
                bulletThrown = true;
                if (playShootSound)
                {
                    shootSound.play();
                    playShootSound = false;
                }
            }
            else
            {
                playShootSound = true;
            }

            if (Keyboard[Key.L])
            {
                lightingEnabled = true;
            }
            else if (Keyboard[Key.K])
            {
                lightingEnabled = false;
            }
        }
        private void UpdateCamera()
        {
            PrevModelviewMatrixWithoutXRot = modelviewMatrixWithoutXRot;
            xRotMatrix = Matrix4.CreateRotationX(xRot);
            yRotMatrix = Matrix4.CreateRotationY(yRot);
            shootGunYRot -= MathHelper.RadiansToDegrees(yRot);
            totalYRotMatrix *= yRotMatrix;
            translatationMatrix = Matrix4.CreateTranslation(-xTranslation, -yTranslation, -zTranslation);
            modelviewMatrixWithoutXRot *= yRotMatrix * translatationMatrix;
            prevPos = pos;
            pos = Helper.GetPositionFromModelViewMatrix(modelviewMatrixWithoutXRot, totalYRotMatrix);
            person.setPos(pos);
            if (!bulletThrown)
            {
                bulletPos = pos;
                bullet.SetCenter(bulletPos);
                bulletMatrix = modelviewMatrixWithoutXRot;
            }
            else
            {
                bulletMatrix *= Matrix4.CreateTranslation(new Vector3(0, 0, +10));
                bulletPos = Helper.GetPositionFromModelViewMatrix(bulletMatrix, totalYRotMatrix);
                bullet.SetCenter(bulletPos);
            }
            if (CheckCollision(person.boundingBox))
            {
                modelviewMatrixWithoutXRot = PrevModelviewMatrixWithoutXRot;
                pos = prevPos;
                person.setPos(pos);
                if (!bulletThrown)
                {
                    bulletPos = pos;
                    bullet.SetCenter(bulletPos);
                }
            }
            else
            {
                translationVector = pos - new Vector3(initialXPos, initialYPos, initialZPos);
            }
            ThrowBullet();

            modelviewMatrixWithXRot = modelviewMatrixWithoutXRot * xRotMatrix;


            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelviewMatrixWithXRot);
        }

        private bool CheckCollision(BoundingBox targetBoundingBox)
        {
            for (int i = 0; i < objList.Count; i++)
            {
                if (objList[i].CheckCollision(targetBoundingBox))
                    return true;
            }
            return false;
        }
        private bool CheckBulletCollision(BoundingBox targetBoundingBox)
        {
            for (int i = 0; i < BulletObjList.Count; i++)
            {
                if (BulletObjList[i].CheckCollision(targetBoundingBox))
                {
                    objList.Remove(BulletObjList[i]);
                    BulletObjList.Remove(BulletObjList[i]);
                    return true;
                }
            }
            return false;
        }
        private void ThrowBullet()
        {
            if (CheckBulletCollision(bullet)&& bulletThrown)
            {
                bulletSound.play();
                bulletThrown = false;               
            }
            if (CheckCollision(bullet))
            {
                bulletThrown = false;
            }
        }
        private void PlaySounds()
        {
            if ((house1.door.CheckCollision(person.boundingBox)) && (playDoor1Sound))
            {
                doorSound.play();
                playDoor1Sound = false;
            }
            else if (!(house1.door.CheckCollision(person.boundingBox)))
            {
                playDoor1Sound = true;
            }

            if ((house2.door.CheckCollision(person.boundingBox)) && (playDoor2Sound))
            {
                doorSound.play();
                playDoor2Sound = false;
            }
            else if (!(house2.door.CheckCollision(person.boundingBox)))
            {
                playDoor2Sound = true;
            }
        }
        private void EnableLighting()
        {
            Vector3 lightingPos = pos;
            float[] m_ambi = { 0.1f, 0.1f, 0.1f, 1.0f };
            float[] m_diff = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] m_spec = { 1.0f, 1.0f, 1.0f, 1.0f };
            float m_shin = 0f;
            float[] l_ambi = { 1.0f, 1.0f, 1.0f, 0.0f };
            float[] l_diff = { 1.0f, 1.0f, 1.0f, 0.0f };
            float[] l_spec = { 1.0f, 1.0f, 1.0f, 0.0f };
            float[] l_pos = { lightingPos.X, lightingPos.Y,lightingPos.Z, 1};

            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Ambient, m_ambi);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Diffuse, m_diff);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, m_spec);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, m_shin);
            GL.Light(LightName.Light0, LightParameter.Ambient, l_ambi);
            GL.Light(LightName.Light0, LightParameter.Diffuse, l_diff);
            GL.Light(LightName.Light0, LightParameter.Specular, l_spec);
            GL.Light(LightName.Light0, LightParameter.Position, l_pos);


            if (lightingEnabled)
            {
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
            }
        }
        private void DisableLighting()
        {
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.Light0);
        }


    }
}


