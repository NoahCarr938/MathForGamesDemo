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
        private float RotationSpeed { get; set; } = 2;
        const float SCALE_MULTIPLIER = 80;
        Vector2 spawnPoint = new Vector2(250, 250);
        public bool gameOver = false;


        //Vector2 v1 = new Vector2(150, 0);
        //Vector2 v2 = new Vector2(0, 50);
        //Vector2 v3 = new Vector2(100, 80);

        private Color _color = Color.Beige;

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

            // Rotation
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {

                Transform.Rotate(RotationSpeed * -1 * (float)deltaTime);
            }

            if (Raylib.IsKeyDown(KeyboardKey.Down))
            {

                Transform.Rotate(RotationSpeed * 1 * (float)deltaTime);
            }

            // Creating the Rectangle or "Player"
            Rectangle rec = new Rectangle(Transform.LocalPosition, Transform.GlobalScale * SCALE_MULTIPLIER);

            // Drawing the Rectangle or "Player"
            Raylib.DrawRectanglePro(rec, new Vector2 (SCALE_MULTIPLIER/2, SCALE_MULTIPLIER/2), (float)(Transform.LocalRotationAngle * 180 / Math.PI), _color);
            // Shows the direction that you are facing.
            Raylib.DrawLineV(Transform.GlobalPosition, Transform.GlobalPosition + Transform.Forward * 60, Color.Red);

            //Component comp1 = PlayerActor.AddComponent(new HealthComponent(PlayerActor, "1"));

            // If the player goes out of bounds, respawn them at the spawnpoint
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
            if (other is ProjectileActor)
            {
                return;
            }
            else if (other is AsteroidActor)
            {
                _color = Color.Red;
                Game.CurrentScene = Game.GetScene(0);
            }
        }

        
    }
}
