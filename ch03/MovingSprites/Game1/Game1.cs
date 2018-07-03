using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// XNA game lifecycle:
// +----------+     +-----------+
// |Initialize+----->LoadContent|
// +----------+     +--+--------+
//                     |
//                     |
//                  +--v---+         +-------------+
//               +-->Update+--+--+--->UnloadContent|
//               |  +------+  |  |   +-------------+
//               |            |  |
//               |  +----+    |  |
//               +--+Draw<----+  |
//                  +----+       |
//                               +
//                           GameOver

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // Abstraction of GPU access
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Create sprite
        Texture2D logo;
        Texture2D logoTrans;

        // Track positions, initialize to 0,0
        Vector2 pos1 = Vector2.Zero;
        Vector2 pos2 = Vector2.Zero;

        // Determine how far to move each object between frames
        float speed1 = 2f;
        float speed2 = 3f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
		/// Also called if user reset graphics device due to display setting
		/// changes or something similar
		/// Should be used to load all graphics, models, sounds, etc.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            logo = Content.Load<Texture2D>("img/logo");
            logoTrans = Content.Load<Texture2D>("img/logo_trans");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
		/// Note how different this is from even-driven programming: need to
		/// constantly poll for what the state is in order to execute
		/// the proper logic for things that may have happened since last update
		/// 60 FPS by default, same with Draw
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Shut the game down
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            pos1.X += speed1;
            if (pos1.X > Window.ClientBounds.Width - logo.Width || pos1.X < 0)
                speed1 *= -1;

            pos2.Y += speed2;
            if (pos2.Y > Window.ClientBounds.Height - logoTrans.Height || pos2.Y < 0)
                speed2 *= -1;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
		/// NOTE: Do as little as possible here to maximize performance
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            // Let the graphics device know that we are about to send sprite data
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            spriteBatch.Draw(
                logo, 
                pos1,
                null,
                Color.White,
                0,
                Vector2.Zero,
                1.5f,
                SpriteEffects.FlipHorizontally,
                1);

            spriteBatch.Draw(
                logoTrans,
                pos2,
                null,
                Color.White,
                0,
                Vector2.Zero,
                1.5f,
                SpriteEffects.FlipHorizontally,
                0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}