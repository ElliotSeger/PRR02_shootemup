using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShootEmUp.Collectibles;
using ShootEmUp.Libraries;
using ShootEmUp.Objects;
using ShootEmUp.Objects.Creatures;
using ShootEmUp.Objects.Creatures.Enemies;
using ShootEmUp.Objects.Creatures.Player;
using ShootEmUp.Objects.PowerUps;
using ShootEmUp.UI;
using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static List<GameObject> myObjects;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 1024;
            graphics.ApplyChanges();

            IsMouseVisible = true;
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

            myObjects = new List<GameObject>
            {
                new PlayerShip(),
                new EnemyShipAlpha(),
                new ScoreUI(),
                // new HealthPowerUp(),
                // new SpeedPowerUp(),
                //new EnemyCargoShip(),
                new EnemyShipBeta(),
                new Coin(),
                new Player(),
            };
            myObjects.Add(new HealthUI());
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            TextureLibrary.LoadTextures(Content);
            FontLibrary.LoadFont(Content);
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
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < myObjects.Count; ++i)
            {
                myObjects[i].Update(gameTime);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.Begin();
            foreach (GameObject gameObject in myObjects)
            {
                gameObject.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
