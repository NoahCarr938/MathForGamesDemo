using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class AsteroidActor : Actor
    {
        private float _asteroidSpeed = 20;
        //public Raylib_cs.Color _color = Color.White;
        Vector2 v2 = new Vector2(100, 100);

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Actor _asteroidActor = new Actor();
            Transform2D t2 = new Transform2D(_asteroidActor);

            // Create all three size asteroids
            // The biggest asteroid
            Raylib.DrawCircleV(v2, 20, Color.White);
            // The second asteroid
            Raylib.DrawCircleV(v2, 10, Color.White);
            // The smallest asteroid
            Raylib.DrawCircleV(v2, 5, Color.White);
        }
    }
    //internal struct Asteroid
    //{
    //    Vector2 position;
    //    Vector2 speed;
    //    float radius;
    //    bool active;
    //    Color color;
        
    //}

    
}
