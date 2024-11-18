using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class TurretActor : Actor
    {
        public float ProjectileSpeed { get; set; } = 200;

        public float TurretSpeed { get; set; } = 200;
        public float RotationSpeed { get; set; } = 3;
        const float SCALE_MULTIPLIER = 50;
        private Color _colorTurret = Color.DarkBlue;
        private Color _colorBullet = Color.Green;
        private Color _colorCollision = Color.Red;
        Vector2 projectileLaunch = new Vector2(100, 100);

        Vector2 v1 = new Vector2(150, 150);


        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Actor _theTurret = new Actor();
            Transform2D t1 = new Transform2D(_theTurret);

            // Movement
            Vector2 movementInput = new Vector2();
            movementInput.y -= Raylib.IsKeyDown(KeyboardKey.W);
            movementInput.y += Raylib.IsKeyDown(KeyboardKey.S);
            movementInput.x -= Raylib.IsKeyDown(KeyboardKey.A);
            movementInput.x += Raylib.IsKeyDown(KeyboardKey.D);
            Vector2 deltaMovement = movementInput.Normalized * TurretSpeed * (float)deltaTime;

            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement);



            // Rotation
            if (Raylib.IsKeyDown(KeyboardKey.Left))
           {

                Transform.Rotate(RotationSpeed * -1 * (float)deltaTime);
           }

           if (Raylib.IsKeyDown(KeyboardKey.Right))
           {

                Transform.Rotate(RotationSpeed * 1 * (float)deltaTime);
           }

           // Shooting mechanic for the turret
           if (Raylib.IsKeyPressed(KeyboardKey.Space))
           {
                Actor _theBullet = Actor.Instantiate(new Actor("The Bullet"), null, new Vector2(100, 100), 0);

           }


            

            // Creating the Rectangle or "Player"
            Rectangle rec = new Rectangle(Transform.LocalPosition, Transform.GlobalScale * SCALE_MULTIPLIER);

            // Drawing the Rectangle or "Player"
            Raylib.DrawRectanglePro(rec, new Vector2(SCALE_MULTIPLIER / 2, SCALE_MULTIPLIER / 2), (float)(Transform.LocalRotationAngle * 180 / Math.PI), _colorTurret);
            // Shows the direction that you are facing.
            Raylib.DrawLineV(Transform.GlobalPosition, Transform.GlobalPosition + Transform.Forward * 60, Color.Red);

            // Add in projectiles
            // Add in asteroids
            // Add a health component
            // Projectiles that delete asteroids
            // Add in a game over and restart function
            // Comment out MathLibraryDemo
            // Document Math Library
            // Submit assignments


        }

        public override void OnCollision(Actor other)
        {
            _colorCollision = Color.Red;

        }

    }
}
