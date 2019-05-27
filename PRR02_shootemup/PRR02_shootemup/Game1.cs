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
using ShootEmUp.UserInterface;
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
        static EnemySpawner[] myLevelSpawners;
        public static int myCurrentLevelIndex = 0;
        public static bool myIsShowingUpgradeMenu = false;
        public static Player AccessPlayer { get; set; }
        UpgradeMenu myUpgradeMenu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1440;
            graphics.PreferredBackBufferHeight = 810;
            graphics.ApplyChanges();
            graphics.IsFullScreen = false;

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

            myLevelSpawners = new[]
            {
                new EnemySpawner // Nivå 1.
                (
                   //(3, new EnemyCargoShip(new Point(-10, 300))),
                   //(0, new EnemyShipGamma(new Point(100, -10))),
                   //(2, new EnemyShipGamma(new Point(500, -10))),
                   //(3, new EnemyShipGamma(new Point(700, -10))),
                   //(2, new EnemyShipGamma(new Point(800, -10))),
                   //(3, new EnemyShipGamma(new Point(1200, -10))),
                   //(2, new EnemyShipBeta(new Point(550, -10))),
                   (4, new EnemyBoss1(new Point(1250, -10)))
                ),

                new EnemySpawner // Nivå 2.
                (
                    (3, new EnemyShipBeta(new Point(400, -10))),
                    (5, new EnemyShipGamma(new Point(700, -10))),
                    (0, new EnemyShipAlpha(new Point(550, -10))),
                    (2, new EnemyShipBeta(new Point(750, -10))),
                    (2, new EnemyShipBeta(new Point(400, -10))),
                    (1, new EnemyShipGamma(new Point(550, -10))),
                    (0, new EnemyCargoShip(new Point(-10, 350))),
                    (1, new EnemyShipGamma(new Point(250, -10))),
                    (1, new EnemyShipGamma(new Point(850, -10))),
                    (1, new EnemyShipGamma(new Point(550, -10))),
                    (6, new EnemyBoss2(new Point(500, -10)))
                ),
            };

            AccessPlayer = new Player();
            myUpgradeMenu = new UpgradeMenu();

            myObjects = new List<GameObject>
            {
                new Background(),
                AccessPlayer,
                new ScoreUI(),
                new DeathUI(),
                new LevelUI(),
                new MoneyUI(),
            };
            myObjects.Add(new HealthUI());
        }

        public static void NextLevel()
        {
            ++myCurrentLevelIndex;
            if (myCurrentLevelIndex >= myLevelSpawners.Length)
            {
                myCurrentLevelIndex = 0;
            }

            Restart();
        }

        public static void Restart()
        {
            myObjects = new List<GameObject>
            {
                // Vid omstart av spelet laddas bakgrund, spelare, poängtext, pengartext, nivåtext och eventuellt dödsmeny åter in.

                new Background(),
                AccessPlayer,
                new ScoreUI(),
                new MoneyUI(),
                new LevelUI(),
                new DeathUI(),
            };
            myObjects.Add(new HealthUI());

            AccessPlayer.AccessHealth = Player.myMaxHealth;

            myLevelSpawners = new[]
            {
                // Nivå 1. 
                new EnemySpawner
                (
                    //(3, new EnemyCargoShip(new Point(-10, 300))),
                   //(0, new EnemyShipGamma(new Point(100, -10))),
                   //(2, new EnemyShipGamma(new Point(500, -10))),
                   //(3, new EnemyShipGamma(new Point(700, -10))),
                   //(2, new EnemyShipGamma(new Point(800, -10))),
                   //(3, new EnemyShipGamma(new Point(1200, -10))),
                   //(2, new EnemyShipBeta(new Point(550, -10))),
                   (4, new EnemyBoss1(new Point(1250, -10)))
                ),
                
                

                // Nivå 2.
                new EnemySpawner
                (
                    (3, new EnemyShipBeta(new Point(400, -10))),
                    (5, new EnemyShipGamma(new Point(700, -10))),
                    (0, new EnemyShipAlpha(new Point(550, -10))),
                    (2, new EnemyShipBeta(new Point(750, -10))),
                    (2, new EnemyShipBeta(new Point(400, -10))),
                    (1, new EnemyShipGamma(new Point(550, -10))),
                    (0, new EnemyCargoShip(new Point(-10, 350))),
                    (1, new EnemyShipGamma(new Point(250, -10))),
                    (1, new EnemyShipGamma(new Point(850, -10))),
                    (1, new EnemyShipGamma(new Point(550, -10))),
                    (6, new EnemyBoss2(new Point(500, -10)))
                ), 

                // Nivå 3.
                new EnemySpawner
                (
                    
                )
            };
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
            SoundLibrary.LoadMusic(Content);
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
            if (!myIsShowingUpgradeMenu)
            {
                for (int i = 0; i < myObjects.Count; ++i)
                {
                    myObjects[i].Update(gameTime);
                }

                myLevelSpawners[myCurrentLevelIndex].Update(gameTime);

                // TODO: Add your update logic here

                base.Update(gameTime);
            }

            else
            {
                myUpgradeMenu.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.Begin();

            if (!myIsShowingUpgradeMenu)
            {
                foreach (GameObject gameObject in myObjects)
                {
                    gameObject.Draw(gameTime, spriteBatch);
                }
            }

            else
            {
                myUpgradeMenu.Draw(spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
