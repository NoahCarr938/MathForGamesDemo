using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class TurretActor : Actor
    {
        public float Speed { get; set; } = 200;
        public float Rotate { get; set; } = 50;
        const float SCALE_MULTIPLIER = 50;
        private Color _color = Color.Blue;



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
            Vector2 deltaMovement = movementInput.Normalized * Speed * (float)deltaTime;



            // Rotation

            




            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement);

            // Creating the Rectangle or "Player"
            Rectangle rec = new Rectangle(Transform.LocalPosition, Transform.LocalScale * SCALE_MULTIPLIER);

            // Drawing the Rectangle or "Player"
            Raylib.DrawRectanglePro(rec, new Vector2(SCALE_MULTIPLIER / 2, SCALE_MULTIPLIER / 2), (float)(Transform.LocalRotationAngle * 180 / Math.PI), _color);
            // Shows the direction that you are facing.
            Raylib.DrawLineV(Transform.GlobalPosition, Transform.GlobalPosition + Transform.Forward * 60, Color.Red);

            // Need to add a child to the "Player"
            // The child will be used for the projectiles and rotations
            // Rotation for the "Player"
            // Add a main menu and restart game option.



        }

        public override void OnCollision(Actor other)
        {
            _color = Color.Red;
        }

    }
}
