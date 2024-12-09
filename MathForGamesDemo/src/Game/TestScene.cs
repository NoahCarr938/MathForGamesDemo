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
        public override void Start()
        {
            base.Start();

            Raylib.SetTargetFPS(60);


            Actor Asteroid = new AsteroidActor();
            Asteroid.Transform.LocalPosition = new Vector2(100, 100);
            AddActor(Asteroid);
            Actor _theAsteroid = Actor.Instantiate(new Actor("Asteroid"), null, new Vector2(100, 100), 0);
            Asteroid.Collider = new CircleCollider(Asteroid, 50);


            Actor Asteroid2 = new AsteroidActor();
            Asteroid2.Transform.LocalPosition = new Vector2(600, 300);
            AddActor(Asteroid2);
            Actor _theAsteroid2 = Actor.Instantiate(new Actor("Asteroid"), null, new Vector2(600, 300), 0);
            Asteroid2.Collider = new CircleCollider(Asteroid2, 50);

            Actor Asteroid3 = new AsteroidActor();
            Asteroid3.Transform.LocalPosition = new Vector2(450, 400);
            AddActor(Asteroid3);
            Actor _theAsteroid3 = Actor.Instantiate(new Actor("Asteroid"), null, new Vector2(450, 400), 0);
            Asteroid3.Collider = new CircleCollider(Asteroid3, 50);


            // The bottom
            // Instantiate is used to add the actor to the scene.
            Actor _thePlayer = Actor.Instantiate(new PlayerActor(), null, new Vector2(300, 300), 0);
            // The collider circle for the spaceship
            _thePlayer.Collider = new CircleCollider(_thePlayer, 60);


            Actor _theTurret = Actor.Instantiate(new TurretActor(), _thePlayer.Transform);

            // To add a component
            //Component comp1 = _thePlayer.AddComponent(new HealthComponent(_thePlayer, "1"));

            // To remove a component
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
