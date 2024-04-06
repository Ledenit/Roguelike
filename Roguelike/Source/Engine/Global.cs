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
    public class Global
    {
        public static int screenWidth, screenHeight;

        public static ContentManager contet;
        public static SpriteBatch spriteBatch;

        public static GameKeyboard keyboard;
        public static GameMouseControl mouse;

        public static float GetDistance(Vector2 position, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y - target.Y, 2));
        }

        public static float RotateTowards(Vector2 position, Vector2 focus)
        {
            return (float)Math.Atan2(position.Y - focus.Y, position.X - focus.X) - MathHelper.PiOver2;
        }
    }
}
