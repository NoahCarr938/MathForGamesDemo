using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{

    internal class Scene
    {
        private List<Actor> _actors;
        public float playerHealth = 3;
        public bool gameOver = false;
        public bool playerIsAlive = true;
        public bool hit = false;



        public void AddActor(Actor actor)
        {
            if (!_actors.Contains(actor))
                _actors.Add(actor);
        }

        public bool RemoveActor(Actor actor)
        {
            return _actors.Remove(actor);
        }


        public virtual void Start()
        {

            _actors = new List<Actor>();
            Actor bob = new Actor("Bob");
            //bob.AddComponent<HealthComponent>();
        }

        public virtual void Update(double deltaTime)
        {
            // Update actors
            for (int i = 0; i < _actors.Count; i++)
            {
                Actor actor = _actors[i];

                if (!actor.Started)
                    actor.Start();

                actor.Update(deltaTime);
                if (actor.Collider != null)
                    actor.Collider.Draw();

            }

            // Check for collision
            for (int row = 0; row < _actors.Count; row++)
            {
                for (int column = row; column < _actors.Count; column++)
                {
                    // Don't check collision against self
                    if (row == column)
                        continue;

                    // If both colliders are valid
                    if (_actors[row].Collider != null && _actors[column].Collider != null)
                    {
                        // Check collision
                        if (_actors[row].Collider.CheckCollision(_actors[column]))
                        {
                            _actors[row].OnCollision(_actors[column]);
                            _actors[column].OnCollision(_actors[row]);

                            if (playerHealth == 0)
                            {
                                playerIsAlive = false;
                            }

                            while (!gameOver)
                            {
                                if (playerIsAlive = false)
                                {
                                    gameOver = true;
                                }
                            }
                            
                        }
                    }
                }
            }
            // Add a border
            // If the player is a little bit less than screen width then dont let them go past it
            
        }

        public virtual void End()
        {
            foreach (Actor actor in _actors)
            {
                actor.End();
            }

        }

        public virtual void DrawGameOver()
        {
            Raylib.DrawText("Game Over!", 200, 200, 20, Color.White);
        }

        public virtual void DrawGamePaused()
        {
            Raylib.DrawText("The Game Is Paused, Click to resume or escape to quit", 200, 200, 20, Color.White);
        }

        public virtual void DrawMainMenu()
        {
            Raylib.DrawText("Click to play or escape to quit", 200, 200, 20, Color.White);
            if (Raylib.IsKeyPressed(KeyboardKey.Escape))
            {
                gameOver = true;
            }
        }

    }
}
