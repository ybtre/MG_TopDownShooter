using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


using var game = new MG_TopDownShooter.Main();
game.Run();

namespace MG_TopDownShooter
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;

        World world;


        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.sprite_batch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content herea
            world = new World();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            world.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            Globals.sprite_batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            // DRAW hERE

            world.Draw();


            Globals.sprite_batch.End();


            base.Draw(gameTime);
        }
    }
}
