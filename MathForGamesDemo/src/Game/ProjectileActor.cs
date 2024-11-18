using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathForGamesDemo;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDeme
{
    internal class ProjectileActor : Actor
    {
        public float playerBullets = 100;
        public float projectileSpeed = 100;
        private Raylib_cs.Color _color = Raylib_cs.Color.Green;
        private Color _colorCollision = Color.Red;
        Vector2 v1 = new Vector2(150, 150);

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Raylib.DrawCircleV(v1, 10, _color);
            Transform.Translate(Transform.Forward * projectileSpeed * (float)deltaTime);
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
