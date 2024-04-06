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
    public class Basic2D
    {
        public float rotation;

        public Vector2 position, dimension;
        public Texture2D model;

        public Basic2D(string Path, Vector2 Postion, Vector2 Dimension)
        {
            position = Postion;
            dimension = Dimension;

            model = Global.contet.Load<Texture2D>(Path);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(Vector2 Offset)
        {
            Global.spriteBatch.Draw(
                model, 
                new Rectangle((int)(position.X + Offset.X), (int)(position.Y + Offset.Y), (int)dimension.X, (int)dimension.Y), 
                null, 
                Color.White, 
                rotation, 
                new Vector2(model.Bounds.Width/2, model.Bounds.Height/2), 
                new SpriteEffects(), 
                0);
        }

        public virtual void Draw(Vector2 Offset, Vector2 Origin)
        {
            Global.spriteBatch.Draw(
                model,
                new Rectangle((int)(position.X + Offset.X), (int)(position.Y + Offset.Y), (int)dimension.X, (int)dimension.Y),
                null,
                Color.White,
                rotation,
                new Vector2(Origin.X, Origin.Y), 
                new SpriteEffects(),
                0);
        }
    }
}
