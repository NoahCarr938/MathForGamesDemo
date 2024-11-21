using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathForGamesDemo;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class ProjectileActor : Actor
    {
        public float projectileSpeed = 300;
        public float projectileCount = 100;
        public Color _colorCollision = Color.Green;
        public bool bulletIsAlive = false;

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // Movement for the projectile
            Transform.Translate(Transform.Forward * projectileSpeed * (float)deltaTime);

            // Spawns projectiles from the top of the turret
            Raylib.DrawCircleV(Transform.LocalPosition, 10, _colorCollision);
            
            // Removing the projectiles once they get out of view
            if (Transform.LocalPosition.x > Raylib.GetScreenWidth()
                || Transform.LocalPosition.y > Raylib.GetScreenHeight()
                ) 
            { 
                Game.CurrentScene.RemoveActor(this); 
            }

            if (Transform.LocalPosition.x <= 0
                || Transform.LocalPosition.y <= 0
                ) 
            { 
                Game.CurrentScene.RemoveActor(this); 
            }
            
            
        }

        public override void OnCollision(Actor other)
        {
            
            if (other is PlayerActor)
            {
                return;
            }
            else if (other is AsteroidActor)
            {
                _colorCollision = Color.Red;
                Game.CurrentScene.RemoveActor(this);
            }


        }
    }
}
