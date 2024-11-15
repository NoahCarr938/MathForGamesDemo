using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo
{
    
    internal class Collider
    {
        public Actor Owner { get; protected set; }
        public Component Owner2 { get; protected set; }

        public Collider(Actor owner)
        {
            Owner = owner;
        }

        public Collider (Component owner)
        {
            Owner2 = owner;
        }

        public bool CheckCollision(Actor other)
        {
            if (other.Collider != null && other.Collider is CircleCollider)
                return CheckCollisionCircle((CircleCollider)other.Collider);
            return false;
        }

        public bool CheckCollision(Component other)
        {
            if (other.Collider != null && other.Collider is CircleCollider)
                return CheckCollisionCircle((CircleCollider)other.Collider);
            return false;
        }

        public virtual bool CheckCollisionCircle(CircleCollider collider)
        {
            return false;
        }

        

        public virtual void Draw() { }
    }
}
