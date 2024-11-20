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
        Actor _theAsteroid;
        Actor _theBullet;
        public float projectileSpeed = 200.0f;

        public override void Start()
        {
            base.Start();

            Raylib.SetTargetFPS(60);

            // Large Asteroid
            // Adding the actor
            Actor Asteroid = new AsteroidActor();
            // Where the actor is located
            Asteroid.Transform.LocalPosition = new Vector2(200, 200);
            AddActor(Asteroid);
            // Adding the actor to the scene
            Actor _theAsteroid = Actor.Instantiate(new Actor("Asteroid"), null, new Vector2(100, 100), 0);
            // The collider for the asteroid
            _theAsteroid.Collider = new CircleCollider(_theAsteroid, 50);


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
