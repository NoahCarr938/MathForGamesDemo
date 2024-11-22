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
        Vector2 spawnPoint = new Vector2(250, 250);


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
                _theBullet.Collider = new CircleCollider(_theBullet, 10);
           }

            // Creating the Rectangle or "Player"
            Rectangle rec = new Rectangle(Transform.LocalPosition, Transform.GlobalScale * SCALE_MULTIPLIER);

            // Drawing the Rectangle or "Player"
            Raylib.DrawRectanglePro(rec, new Vector2(SCALE_MULTIPLIER / 2, SCALE_MULTIPLIER / 2), (float)(Transform.LocalRotationAngle * 180 / Math.PI), _colorTurret);
            // Shows the direction that you are facing.
            Raylib.DrawLineV(Transform.GlobalPosition, Transform.GlobalPosition + Transform.Forward * 60, Color.Red);

            // If the player goes out of bounds respawn at spawnpoint
            if (Transform.LocalPosition.x > Raylib.GetScreenWidth()
                || Transform.LocalPosition.y > Raylib.GetScreenHeight()
                )
            {
                // Spawn the vector back at spawnpoint
                Transform.LocalPosition = spawnPoint;
            }

            if (Transform.LocalPosition.x <= 0
                || Transform.LocalPosition.y <= 0
                )
            {
                Transform.LocalPosition = spawnPoint;
            }
        }
        public override void OnCollision(Actor other)
        {
            _colorCollision = Color.Red;

        }

    }
}
