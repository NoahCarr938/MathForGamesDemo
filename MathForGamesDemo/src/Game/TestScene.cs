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
        Actor _thePlayer;
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
            // The collider circle for the spaceship
            actor.Collider = new CircleCollider(actor, 60);
            //Component.Collider = new CircleCollider()
            Actor actor2 = new TurretActor();
            actor2.Transform.LocalPosition = new Vector2(300, 300);
            AddActor(actor2);

            // Instantiate is used to add the actor to the scene.
            Actor _thePlayer = Actor.Instantiate(new Actor("The Player"), null, new Vector2(100, 100), 0);
            // A test for the collider
            _thePlayer.Collider = new CircleCollider(_thePlayer, 50);

            Actor _theTurret = Actor.Instantiate(new Actor("The Turret"), _thePlayer.Transform);

            //Component comp1 = _thePlayer.AddComponent(new HealthComponent(_thePlayer, "1"));

            //_theSpaceship.RemoveComponent(comp2);
        }

        public override void Update(double deltaTime)
        {
            //base.Update(deltaTime);
            //Raylib.DrawCircleV(_theBoi.Transform.GlobalPosition, 50, Color.White);

            base.Update(deltaTime);
            

        }
    }
}
