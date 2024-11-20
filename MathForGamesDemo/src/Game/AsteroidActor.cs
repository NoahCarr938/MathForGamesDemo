using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class AsteroidActor : Actor
    {
        public float _asteroidSpeed = 20;
        public float RotationSpeed = 20;
        public Color _color = Color.White;
        public Color _colorCollison = Color.Red;
        Vector2 v2 = new Vector2(100, 100);
        public bool hit = false;

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Vector2 movementInput = new Vector2();
            movementInput.y -= Raylib.IsKeyPressed(KeyboardKey.W);
            movementInput.y += Raylib.IsKeyPressed(KeyboardKey.S);
            movementInput.x -= Raylib.IsKeyPressed(KeyboardKey.A);
            movementInput.x += Raylib.IsKeyPressed(KeyboardKey.D);
            Vector2 deltaMovement = movementInput.Normalized * _asteroidSpeed * (float)deltaTime;

            if (deltaMovement.Magnitude != 0)
                Transform.LocalPosition += (deltaMovement);

            // The biggest asteroid
            Raylib.DrawCircleV(v2, 50, _color);

            // Rotation
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {

                Transform.Rotate(RotationSpeed * -1 * (float)deltaTime);
            }

            if (Raylib.IsKeyDown(KeyboardKey.Down))
            {

                Transform.Rotate(RotationSpeed * 1 * (float)deltaTime);
            }


        }
        public virtual void Shrink(Actor other)
        {
            if (hit == true)
            {
                Raylib.DrawCircleV(v2, 25, _color);
            }
        }
        public override void OnCollision(Actor other)
        {
            _colorCollison = Color.Red;
            hit = true;
        }
    }
}
