using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo
{
    internal class Actor
    {
        private bool _started = false;

        public bool Started { get => _started; }
        public Transform2D Transform { get; set; }

        public Actor()
        {
            Transform = new Transform2D(this);
        }
        public virtual void Start() 
        {
            _started = true;
            Transform = new Transform2D(this);
        }

        public virtual void Update(double deltaTime) 
        {

        }

        public virtual void End() { }
    }
}
