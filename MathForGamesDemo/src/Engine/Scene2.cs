using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class Scene2 : Scene
    {
        public Actor _theExplosion;
        public override void Start()
        {
            base.Start();
        }

        // Death Scene
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Game.CurrentScene = Game.GetScene(2);
            Actor TheExplosion = new ExplosionActor();
            TheExplosion.Transform.LocalPosition = new Vector2(250, 250);
            AddActor(TheExplosion);
            Actor _theExplosion = Actor.Instantiate(new Actor("The Explosion"), null, new Vector2(250, 250), 0);

            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                Game.CurrentScene = Game.GetScene(1);
            }
            Raylib.DrawText(" You Have Died", 240, 120, 30, Color.White);
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
