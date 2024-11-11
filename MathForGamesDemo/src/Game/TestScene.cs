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
        //Actor _theBoi;
        Actor _theSpaceship;
        Actor _theTurret;

        public override void Start()
        {
            base.Start();

            Raylib.SetTargetFPS(60);

            //// Add our cool actor
            //Actor actor = new TestActor();
            //// Where the actor is located
            //actor.Transform.LocalPosition = new Vector2(200, 200);
            //AddActor(actor);
            //// The size of the collider for the circle.
            //actor.Collider = new CircleCollider(actor, 50);

            // Adding the actor
           Actor actor = new PlayerActor();
            // Where the actor is located
            actor.Transform.LocalPosition = new Vector2(300, 300);
            AddActor(actor);
            // The size of the collider for the circle
            actor.Collider = new CircleCollider(actor, 60);

            Actor actor2 = new TurretActor();
            actor2.Transform.LocalPosition = new Vector2(300, 300);
            AddActor(actor2);

            Transform2D t1 = new Transform2D(_theTurret);
            t1.Rotate(0.5f * Raylib.GetFrameTime());

            // Instantiate is used to add the actor to the scene.
            _theSpaceship = Actor.Instantiate(new Actor("The Spaceship"), null, new Vector2(100, 100), 0);
            _theSpaceship.Collider = new CircleCollider(_theSpaceship, 50);

            _theTurret = Actor.Instantiate(new Actor("The Turret"), _theSpaceship.Transform);

            Component comp1 = _theTurret.AddComponent(new ProjectileComponent(_theTurret, "1"));
            //Component comp2 = _theTurret.AddComponent(new SpriteComponent(_theTurret, "2"));
            //Component comp3 = _theTurret.AddComponent(new SpriteComponent(_theTurret, "3"));
            //Component comp4 = _theTurret.AddComponent(new SpriteComponent(_theTurret, "4"));

            //_theSpaceship.RemoveComponent(comp2);
            //_theSpaceship.RemoveComponent(comp3);
        }

        public override void Update(double deltaTime)
        {
            //base.Update(deltaTime);
            //Raylib.DrawCircleV(_theBoi.Transform.GlobalPosition, 50, Color.White);

            base.Update(deltaTime);
            Raylib.DrawRectangleV(_theSpaceship.Transform.GlobalPosition, _theSpaceship.Transform.GlobalScale, Color.Green);

        }
    }
}
