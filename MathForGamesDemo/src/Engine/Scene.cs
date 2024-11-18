﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            // Change this into a for loop
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
        }

        public virtual void End()
        {
            foreach (Actor actor in _actors)
            {
                actor.End();
            }
        }

    }
}
