using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class AsteroidActor : Actor
    {
        public float _asteroidSpeed = 20;
        public float RotationSpeed = 20;
        public Color _color = Color.White;
        public Color _colorCollison = Color.Red;
        Vector2 v2 = new Vector2(100, 100);
        public bool hit = false;

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Raylib.DrawCircleV(v2, 50, _color);
        }
        public virtual void Shrink(Actor other)
        {
            if (hit == true)
            {
                Raylib.DrawCircleV(v2, 25, _color);
            }
        }
        public override void OnCollision(Actor other)
        {
           
            
            if (hit == true)
            {
                Console.WriteLine("hit");
                _colorCollison = Color.Red;
            }
            //Game.CurrentScene.RemoveActor(this);
        }
    }
}
