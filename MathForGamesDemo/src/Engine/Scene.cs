using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (Actor actor in _actors)
            {
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
                                    DisplayMainMenu();
                                }
                            }

                            void DisplayMainMenu()
                            {
                                int input = GetInput("Do you want to play again?", "Yes", "No");

                                if (input == 1)
                                {
                                    gameOver = false;
                                    playerIsAlive = true;
                                }
                                else if (input == 2)
                                {
                                    gameOver = true;
                                }
                            }

                            int GetInput(string description, string option1, string option2)
                            {
                                string input = "";
                                int inputReceived = 0;

                                // Input loop
                                while (inputReceived != 1 && inputReceived != 2)
                                {
                                    // Print options
                                    Console.WriteLine(description);
                                    Console.WriteLine("1. " + option1);
                                    Console.WriteLine("2. " + option2);
                                    Console.Write("> ");

                                    // Get input from player
                                    input = Console.ReadLine();

                                    // If player selected the first option
                                    if (input == "1" || input == option1)
                                    {
                                        // Set inputReceived to be the first option
                                        inputReceived = 1;
                                    }
                                    // Otherwise if the player selected the second option
                                    else if (input == "2" || input == option2)
                                    {
                                        // Set inputReceived to be the second option
                                        inputReceived = 2;
                                    }
                                    // If neither are true
                                    else
                                    {
                                        // Display error message
                                        Console.WriteLine("Invalid Input");
                                        Console.ReadKey();
                                    }
                                }
                                Console.Clear();
                                return inputReceived;
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
