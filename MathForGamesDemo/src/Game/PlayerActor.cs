using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class PlayerActor : Actor
    {
        public float Speed { get; set; } = 200;
        public float playerHealth = 3;

        const float SCALE_MULTIPLIER = 80;


        //Vector2 v1 = new Vector2(150, 0);
        //Vector2 v2 = new Vector2(0, 50);
        //Vector2 v3 = new Vector2(100, 80);

        private Color _color = Color.White;

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            // Movement
            Vector2 movementInput = new Vector2();
            movementInput.y -= Raylib.IsKeyDown(KeyboardKey.W);
            movementInput.y += Raylib.IsKeyDown(KeyboardKey.S);
            movementInput.x -= Raylib.IsKeyDown(KeyboardKey.A);
            movementInput.x += Raylib.IsKeyDown(KeyboardKey.D);
            Vector2 deltaMovement = movementInput.Normalized * Speed * (float)deltaTime;

            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement);

            // Creating the Rectangle or "Player"
            Rectangle rec = new Rectangle(Transform.LocalPosition, Transform.LocalScale * SCALE_MULTIPLIER);

            // Drawing the Rectangle or "Player"
            Raylib.DrawRectanglePro(rec, new Vector2 (SCALE_MULTIPLIER/2, SCALE_MULTIPLIER/2), (float)(Transform.LocalRotationAngle * 180 / Math.PI), _color);
            // Shows the direction that you are facing.
            Raylib.DrawLineV(Transform.GlobalPosition, Transform.GlobalPosition + Transform.Forward * 60, Color.Red);

            // Need to add a child to the "Player"
            // The child will be used for the projectiles and rotations
            // Rotation for the "Player"
            

            
        }

        public override void OnCollision(Actor other)
        {
            playerHealth -= 3;
            Console.WriteLine(playerHealth);
            _color = Color.Red;
        }

    }
}
