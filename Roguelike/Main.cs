using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Roguelike
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        World world;

        Basic2D cursor;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {


            base.Initialize();
        }

        protected override void LoadContent()
        {
            Global.contet = this.Content;
            Global.spriteBatch = new SpriteBatch(GraphicsDevice);

            cursor = new Basic2D("C:\\Users\\georg\\C#_Game\\Roguelike\\Roguelike\\Content\\2D\\cursor", new Vector2(0, 0), new Vector2(28, 28));

            Global.keyboard = new GameKeyboard();
            Global.mouse = new GameMouseControl();

            world = new World();


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Global.keyboard.Update();
            Global.mouse.Update();

            world.Update();

            Global.keyboard.UpdateOld();
            Global.mouse.UpdateOld();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            world.Draw(Vector2.Zero);

            cursor.Draw(new Vector2(Global.mouse.newMousePosition.X, Global.mouse.newMousePosition.Y), new Vector2(0, 0));
            Global.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}