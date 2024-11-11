using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class ProjectileComponent : Component
    {
        public float playerBullets = 100;
        public float projectileSpeed = 100;
        private Raylib_cs.Color _color = Raylib_cs.Color.Red;
        Vector2 v1 = new Vector2(100, 100);
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            Vector2 projectileLaunch = new Vector2();
            projectileLaunch.y -= Raylib.IsKeyDown(KeyboardKey.Space);
            Vector2 deltaMovement = projectileLaunch.Normalized * projectileSpeed * (float)deltaTime;

            Raylib.DrawCircleV(v1, 5, _color);
            // Need to spawn the projectile from the TurretActor
            // Need to spawn the projectile when (Space) is pressed
            // Need a way of regaining bullets
        }
    }
}
