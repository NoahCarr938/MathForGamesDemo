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
        private Raylib_cs.Color _color = Raylib_cs.Color.Green;
        Vector2 v1 = new Vector2(150, 150);
        //Vector2 offset = new Vector2(.LocalScale.x * SCALE_MULTIPLIER / 2, t1.LocalScale.y * SCALE_MULTIPLIER / 2);
        private string _path;

        public ProjectileComponent(Actor owner, string path = "") :base(owner)
        {
            _path = path;
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            //Raylib.DrawCircleV(v1, 10, _color);
            //Vector2 projectileLaunch = new Vector2();
            //projectileLaunch.y -= Raylib.IsKeyPressed(KeyboardKey.Space);
            //Vector2 deltaMovement = projectileLaunch.Normalized * projectileSpeed * (float)deltaTime;
            // Need to spawn the projectile from the TurretActor
            // Position + (Forward * Scale) 
            // Above code is to spawn projectiles from the top of the turret
            // Need to spawn the projectile when (Space) is pressed
            // Need a way of regaining bullets
        }
    }
}
