using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class MainMenu : Scene
    {
        public override void Start()
        {
            base.Start();
        }

        // Intro to the game
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Game.CurrentScene = Game.GetScene(0);
            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                Game.CurrentScene = Game.GetScene(1);
            }

            Raylib.DrawText(" Welcome to Asteroids", 240, 120, 30, Color.White);
            Raylib.DrawText(" Press Enter to Play", 240, 150, 30, Color.White);
            Raylib.DrawText(" * ", 15, 70, 100, Color.White);
            Raylib.DrawText(" * ", 450, 240, 100, Color.White);
            Raylib.DrawText(" * ", 150, 50, 100, Color.White);
            Raylib.DrawText(" * ", 100, 200, 100, Color.White);
            Raylib.DrawText(" * ", 350, 20, 100, Color.White);
            Raylib.DrawText(" * ", 550, 350, 100, Color.White);
            Raylib.DrawText(" * ", 380, 400, 100, Color.White);
            
        }
    }
}
