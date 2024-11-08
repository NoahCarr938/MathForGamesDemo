using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace MathForGamesDemo
{
    //internal class Player<T>
    //{
    //    public T Health { get; set; }
    //}


    internal class Game
    {
        public bool gameOver = false;
        public bool playerIsAlive = true;
        public float playerHealth = 3;
        private static List<Scene> _scenes;
        private static Scene _currentScene;

        public static Scene CurrentScene
        {
            get => _currentScene;
            set
            {
                if (_currentScene != null)
                    _currentScene.End();
                _currentScene = value;
                _currentScene.Start();
            }
        }
            
 
        public Game()
        {
            // Initialize the scene list
            _scenes = new List<Scene>();
        }

        public static void AddScene(Scene scene)
        {
            if (!_scenes.Contains(scene))
                _scenes.Add(scene);

            if (_currentScene == null)
                CurrentScene = scene;
        }

        public static bool RemoveScene(Scene scene)
        {
            // If scene is removed will go back to first scene
            bool removed = _scenes.Remove(scene);

            if (_currentScene == scene)
                CurrentScene = GetScene(0);

            return removed;
        }

        public static Scene GetScene(int index)
        {
            if (_scenes.Count <= 0 || _scenes.Count <= index || index < 0)
                return null;

            return _scenes[index];
        }

        public void Run()
        {
            Raylib.InitWindow(800, 480, "Hello World");

            // Timing
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long currentTime = 0;
            long lastTime = 0;
            double deltaTime = 1;

            Scene testScene = new TestScene();
            AddScene(testScene);

            //Player<int> intPLayer = new Player<int>();
            //var hp = intPLayer.Health;
            

            while (!Raylib.WindowShouldClose())
            {
                currentTime = stopwatch.ElapsedMilliseconds;

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                CurrentScene.Update(deltaTime);

                Raylib.EndDrawing();
                
                deltaTime = (currentTime - lastTime) / 1000.0;
                lastTime = currentTime;

            }

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

            CurrentScene.End();

            Raylib.CloseWindow();
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
