#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
#endregion

namespace Roguelike
{
    public class Hero : Basic2D
    {
        public float speed;

        public Hero(string Path, Vector2 Postion, Vector2 Dimension) : base(Path, Postion, Dimension)
        {
            speed = 10.0f;
        }

        public override void Update()
        {   
            if (Global.keyboard.GetPress("A"))
                position = new Vector2(position.X - speed, position.Y);
            if (Global.keyboard.GetPress("D"))
                position = new Vector2(position.X + speed, position.Y);
            if (Global.keyboard.GetPress("W"))
                position = new Vector2(position.X, position.Y - speed);
            if (Global.keyboard.GetPress("S"))
                position = new Vector2(position.X, position.Y + speed);

            rotation = Global.RotateTowards(position, new Vector2(Global.mouse.newMousePosition.X, Global.mouse.newMousePosition.Y));

            base.Update();
        }

        public override void Draw(Vector2 Offset)
        {
            base.Draw(Offset);
        }
    }
}
