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
        public Color _colorCollision = Color.Red;

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
            Transform.Translate(Transform.Forward * projectileSpeed * (float)deltaTime);

            Raylib.DrawCircleV(Transform.LocalPosition, 10, _colorCollision);
            // Above code is to spawn projectiles from the top of the turret
            // Need to spawn the projectile when (Space) is pressed
            // Need a way of regaining bullets
        }

        public override void OnCollision(Actor other)
        {
            _colorCollision = Color.Red;
        }
    }
}
