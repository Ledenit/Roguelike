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
    public class World
    {
        public Hero hero;

        public World() 
        {
            hero = new Hero("C:\\Users\\georg\\C#_Game\\Roguelike\\Roguelike\\Content\\2D\\hero", new Vector2(300, 300), new Vector2(32,32));
        }

        public virtual void Update() 
        {
            hero.Update();
        }

        public virtual void Draw(Vector2 Offset) 
        {
            hero.Draw(Offset);
        }
    }
}
