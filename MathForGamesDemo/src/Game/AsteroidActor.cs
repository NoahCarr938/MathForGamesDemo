using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class AsteroidActor : Actor
    {
        public float _asteroidSpeed = 40;
        public float RotationSpeed = 20;
        public Color _color = Color.White;
        public Color _colorCollision = Color.Red;
        public float asteroidSize = 50;
        
        public bool hit = false;

        public override void Update(double deltaTime)
        {
            // Making a random number generator
            Random rng = new Random();
            float rand1 = rng.Next(100);
            // Once the asteroids go out of view, respawn at random location
            Vector2 asteroidSpawnPoint = new Vector2(rand1, rand1);

            base.Update(deltaTime);

            // Draw the asteroid
            Raylib.DrawCircleV(Transform.LocalPosition, asteroidSize, _color);

            // Move the asteroid forward
            Transform.Translate(Transform.Forward * _asteroidSpeed * (float)deltaTime);

            // If the asteroid is hit shrink and remove the asteroid
            if (hit)
            {
                Shrink();
            }

            // If the player goes out of bounds, respawn them at the spawnpoint
            if (Transform.LocalPosition.x > Raylib.GetScreenWidth()
                || Transform.LocalPosition.y > Raylib.GetScreenHeight()
                )
            {
                // Spawn the vector back at spawnpoint
                Transform.LocalPosition = asteroidSpawnPoint;
            }

        }
        // Shrinks the asteroid and then removes it 
        public virtual void Shrink()
        {
            if (asteroidSize > 10)
            {
                asteroidSize *= 0.9f;
            }
            else if (asteroidSize < 10)
            {
                Game.CurrentScene.RemoveActor(this);
            }

        }
        // Collision for the asteroid
        public override void OnCollision(Actor other)
        {
            if (other is ProjectileActor)
            {
                hit = true;
                _color = Color.Red;
                Actor Explosion = Actor.Instantiate(new ExplosionActor(), null, Transform.GlobalPosition, 0, "Explosion");
                Game.CurrentScene.AddActor(Explosion);

                Game.CurrentScene.RemoveActor(this);

            }
            else if (other is PlayerActor)
            {
                _color = Color.Red;
            }
            
        }
    }
}
