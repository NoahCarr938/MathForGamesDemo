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
        public Actor _thePlayer;
        public Actor _theTurret;
        public Actor _theAsteroid;
        public Actor _theAsteroid2;
        public Actor _theAsteroid3;
        public Actor _theBullet;
        public float projectileSpeed = 200.0f;

        public override void Start()
        {
            base.Start();

            Raylib.SetTargetFPS(60);

            // Large Asteroid
            // Adding the actor
            Actor Asteroid = new AsteroidActor();
            // Where the actor is located
            Asteroid.Transform.LocalPosition = new Vector2(100, 100);
            AddActor(Asteroid);
            Actor _theAsteroid = Actor.Instantiate(new Actor("Asteroid"), null, new Vector2(100, 100), 0);
            Asteroid.Collider = new CircleCollider(Asteroid, 60);
            // Adding the actor to the scene
            
            // The collider for the asteroid

            Actor Asteroid2 = new AsteroidActor();
            Asteroid2.Transform.LocalPosition = new Vector2(600, 300);
            AddActor(Asteroid2);
            Actor _theAsteroid2 = Actor.Instantiate(new Actor("Asteroid"), null, new Vector2(600, 300), 0);

            Asteroid2.Collider = new CircleCollider(Asteroid2, 60);
            
            Actor Asteroid3 = new AsteroidActor();
            Asteroid3.Transform.LocalPosition = new Vector2(450, 400);
            AddActor(Asteroid3);
            Actor _theAsteroid3 = Actor.Instantiate(new Actor("Asteroid"), null, new Vector2(450, 400), 0);
            Asteroid3.Collider = new CircleCollider(Asteroid3, 60);
           


            // Adding the actor
            Actor actor = new PlayerActor();
            // Where the actor is located
            actor.Transform.LocalPosition = new Vector2(300, 300);
            AddActor(actor);
            // The collider circle for the spaceship
            actor.Collider = new CircleCollider(actor, 60);
            // Instantiate is used to add the actor to the scene.
            Actor _thePlayer = Actor.Instantiate(new Actor("The Player"), null, new Vector2(100, 100), 0);
            // A test for the collider
            //_thePlayer.Collider = new CircleCollider(_thePlayer, 50);

            Actor turretActor = new TurretActor();
            turretActor.Transform.LocalPosition = new Vector2(300, 300);
            AddActor(turretActor);
            Actor _theTurret = Actor.Instantiate(new Actor("The Turret"), _thePlayer.Transform);

            //Actor _thebullet = new ProjectileActor();
            //AddActor(_thebullet);
            
            //Actor _theBullet = Actor.Instantiate(new Actor("Bullet"), null, new Vector2(100, 100), 0);
            

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
