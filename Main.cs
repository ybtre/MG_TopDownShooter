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

        Gameplay gameplay;

        Basic2d cursor;


        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = Globals.screen_width;
            _graphics.PreferredBackBufferHeight = Globals.screen_height;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = false;
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

            // TODO: use this.Content to load your game content here

            Globals.keyboard = new HvKeyboard();
            Globals.mouse = new HvMouseControl();

            cursor = new Basic2d("2D\\MISC\\crosshair038", Vector2.Zero, new Vector2(64, 64));
            
            gameplay = new Gameplay();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Globals.delta_time = gameTime;
            Globals.keyboard.Update();
            Globals.mouse.Update();


           gameplay.Update(); 


            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            // TODO: Add your drawing code here

            Globals.sprite_batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            // DRAW hERE

            gameplay.Draw();
            
            cursor.Draw(Globals.mouse.newMousePos);
            Globals.sprite_batch.End();


            base.Draw(gameTime);
        }
    }
}
