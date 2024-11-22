using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class ExplosionActor : Actor
    {
        public float Speed { get; set; } = 200;
        public bool gameOver = false;
        public float Size = 40.0f;
        public float maxSize = 200.0f;
        public float growthRate = 250.0f;
        public override void Start()
        {
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            
                if (Size < maxSize)
                {
                    Size += Transform.LocalScale.x * (growthRate * (float)deltaTime);
                }
                else if (Size >= maxSize)
                {
                    Game.CurrentScene.RemoveActor(this);
                }
            
            base.Update(deltaTime);

            // Creating the Rectangle or "Explosion"
            Raylib_cs.Rectangle rec = new Raylib_cs.Rectangle(Transform.LocalPosition, new Vector2(Size, Size));

            // Drawing the Rectangle or "Explosion"
            Raylib.DrawRectanglePro(rec, new Vector2(Size / 2, Size/ 2), 0, Raylib_cs.Color.Red);

            
        }

        public override void End()
        {
            base.End();
        }
    }
}
