using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace _3D_Game
{
    class SpinningEnemy : BasicModel
    {

        public Vector3 modelPosition { get; protected set; }
        Vector3 modelDirection;
        Vector3 modelUp;

        float speed = 2;

        public SpinningEnemy(Model m, Vector3 pos, Vector3 target, Vector3 up)
            : base(m)
        {
            modelPosition = pos;
            modelDirection = target - pos;
            modelDirection.Normalize();
            modelUp = up;
            CreateTranslation();
        }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                modelPosition += modelDirection * speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                modelPosition -= modelDirection * speed;
            }
            CreateTranslation();

        }

        public override Matrix GetWorld()
        {
            return world * Matrix.CreateTranslation(0, 10, 0);
        }
        private void CreateTranslation()
        {
            world = Matrix.CreateTranslation(modelPosition);
        } 
    }
}