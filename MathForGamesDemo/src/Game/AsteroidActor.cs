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
        public Color _colorCollision = Color.Red;
        public float asteroidSize = 50;
        public bool hit = false;

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Raylib.DrawCircleV(Transform.LocalPosition, asteroidSize, _color);

            // If the asteroid is hit shrink and remove the asteroid
            if (hit)
            {
                Shrink();
            }
        }
        // Shrinks the asteroid and then removes it 
        public virtual void Shrink()
        {
            if (asteroidSize > 10)
            {
                asteroidSize *= 0.9f;
            }
            else if (asteroidSize < 10)
            {
                Game.CurrentScene.RemoveActor(this);
            }

        }
        // Collision for the asteroid
        public override void OnCollision(Actor other)
        {
            if (other is ProjectileActor)
            {
                hit = true;
                _color = Color.Red;

            }
            else if (other is PlayerActor)
            {
                _color = Color.Red;
            }
            
        }
    }
}
