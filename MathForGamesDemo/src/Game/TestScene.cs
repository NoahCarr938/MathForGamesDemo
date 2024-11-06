using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class TestScene : Scene
    {
        Actor _theBoi;
        Actor _theSpaceship;


        Vector2 v1 = new Vector2(150, 0);
        Vector2 v2 = new Vector2(0, 50);
        Vector2 v3 = new Vector2(100, 80);
        public override void Start()
        {
            base.Start();
            Raylib.SetTargetFPS(60);

            // Add our cool actor
            Actor actor = new TestActor();
            // Where the actor is located
            actor.Transform.LocalPosition = new Vector2(200, 200);
            AddActor(actor);
            // The size of the collider for the circle.
            actor.Collider = new CircleCollider(actor, 50);


           Actor actor2 = new PlayerActor();
            actor2.Transform.LocalPosition = new Vector2(300, 300);
            AddActor(actor2);
            actor.Collider = new CircleCollider(actor, 50);

            // Making our main player.
            _theBoi = Actor.Instantiate(new Actor("The Boi"), null, new Vector2(100, 100), 0);
            _theBoi.Collider = new CircleCollider(_theBoi, 50);
            //_theBoi.AddComponent(new HealthComponent("res/Doge.jpg"));


            _theSpaceship = Actor.Instantiate(new Actor("The Spaceship"), null, new Vector2(100, 100), 0);
            _theSpaceship.Collider = new CircleCollider(_theSpaceship, 50);

            AddActor(_theSpaceship);
        }

        public override void Update(double deltaTime)
        {
            // Making another circle
            base.Update(deltaTime);
            Raylib.DrawCircleV(_theBoi.Transform.GlobalPosition, 50, Color.White);

            base.Update(deltaTime);
            Raylib.DrawTriangle(v1, v2, v3, Color.White);

            //base.Update(deltaTime);
            //Raylib.DrawRectangle(200, 200, 100, 100, Color.Green);
        }
    }
}
