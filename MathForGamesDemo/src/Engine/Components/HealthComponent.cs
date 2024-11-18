using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class HealthComponent : Component
    {
       // private Texture2D _texture;
        private string _path;
        private float Health = 100.0f;
       public HealthComponent(Actor owner, string path = "") : base(owner)
       {
            _path = path;
       }

        public override void Start()
        {
            base.Start();
            //_texture = Raylib.LoadTexture(_path);
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            //Vector2 offset = new Vector2(_texture.Width / 2, _texture.Height / 2);
            //Raylib.DrawTextureV(_texture, Owner.Transform.GlobalPosition - offset, Color.White);
        }

        public override void End()
        {
            base.End();
            //Raylib.UnloadTexture(_texture);
        }


    }
}
