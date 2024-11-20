using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MathForGamesDemo;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class TurretActor : Actor
    {

        Actor _theTurret;
        public float ProjectileSpeed { get; set; } = 200;

        public float TurretSpeed { get; set; } = 200;
        public float RotationSpeed { get; set; } = 3;
        const float SCALE_MULTIPLIER = 50;
        private Color _colorTurret = Color.DarkBlue;
        private Color _colorBullet = Color.Green;
        private Color _colorCollision = Color.Red;

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
                // Multiply GlobalRotationAngle by -1 so that it does not fire in the wrong direction.
                Actor _theBullet = Actor.Instantiate(new ProjectileActor(), null, Transform.GlobalPosition, Transform.GlobalRotationAngle * -1, "The Bullet" );

           }

            // Creating the Rectangle or "Player"
            Rectangle rec = new Rectangle(Transform.LocalPosition, Transform.GlobalScale * SCALE_MULTIPLIER);

            // Drawing the Rectangle or "Player"
            Raylib.DrawRectanglePro(rec, new Vector2(SCALE_MULTIPLIER / 2, SCALE_MULTIPLIER / 2), (float)(Transform.LocalRotationAngle * 180 / Math.PI), _colorTurret);
            // Shows the direction that you are facing.
            Raylib.DrawLineV(Transform.GlobalPosition, Transform.GlobalPosition + Transform.Forward * 60, Color.Red);

            // Add in a transpose function

            // Add in projectiles
            // Need to figure out how to stop shooting when out of ammo

            // Add in asteroids
            // 3 asteroid that change into the other when they are shot, they also need to move.

            // Add a health component
            // Once Health is 0 player should die and bring up respawn menu

            // Add a border
            // If the player is a little bit less than screen width then dont let them go past it
            // Print out current position local to the console

            // Projectiles that delete asteroids
            // On collision asteroid changes, when at smallest asteroid disappear.

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
