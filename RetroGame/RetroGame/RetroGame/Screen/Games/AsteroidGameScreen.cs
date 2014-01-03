#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace RetroGame.Screen
{
    class AsteroidGameScreen : GameScreen
    {
        #region Fields

        /// <summary>
        /// A screen-specific content manager.
        /// </summary>
        public ContentManager content;

        #endregion

        #region Initialization
        
        /// <summary>
        /// The constructor for the Asteroid game screen
        /// </summary>
        public AsteroidGameScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }


        /// <summary>
        /// Loads game content.  Contains its own content manager to keep
        /// the game lightweight.
        /// </summary>
        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            base.LoadContent();
        }


        /// <summary>
        /// Unloads game content.  Make sure to close up any files and
        /// free up any resources before exiting.
        /// </summary>
        public override void UnloadContent()
        {
            base.UnloadContent();
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Handles the input for this screen.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            base.HandleInput(input);
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// The screen's update loop.  Place any update logic here.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }


        /// <summary>
        /// The screen's draw loop.  Draw all artifacts here.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;


            spriteBatch.Begin();

            spriteBatch.DrawString(ScreenManager.Font, "There will be asteroids here soon...", new Vector2 (0, 0), Color.White);

            spriteBatch.End();


            base.Draw(gameTime);
        }


        #endregion
    }
}
