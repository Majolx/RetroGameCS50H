#region Information

/* Asteroid, a game where a player take vontrol of a spaceship
 * and will try to destroy as much asteriods as it can before
 * crashing to one of the asteriods.
 *      Written by: Norlan Prudente
 *      Date: 01/05/2014
 */
  
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RetroGame;
#endregion

namespace RetroGame.Screen
{
    class AsteroidGameScreen : GameScreen
    {
        #region Fields

        //Texture variables
        Texture2D ship;
        Texture2D smallAsteriod;
        Texture2D mediumAsteriod;
        Texture2D largeAsteriod;
        Texture2D shot;
        
        //ship size
        int shipHeight = 40;
        int shipWidth = 40;

        //asteriod size
        int asteroidHeight;
        int asteriodWidth;

        //ship position
        Vector2 shipPosition;

        //asteroid position
        Vector2[] asteriodPosition;

        //rectangles
        Rectangle shipRectangle = new Rectangle(400, 300, 30, 30);
        Rectangle asteriodRectangle;

        //for rotating the ship
        float rotation;

        //score tracker
        int score = 0;
        
        //array to determine the size of asteriods on screen
        int []onSceenAsteriod;

        //keyboard states
        KeyboardState currentKBState;
        KeyboardState previousKBState;
        
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
            ship = content.Load<Texture2D>("asteroidAssets/ship");
            /*smallAsteriod = content.Load<Texture2D>("asteroidAssets/smallAsteriod");
            mediumAsteriod = content.Load<Texture2D>("asteroidAssets/smallAsteriod");
            largeAsteriod = content.Load<Texture2D>("asteroidAssets/smallAsteriod");
            shot = content.Load<Texture2D>("asteroidAssets/shot");
            */
            //get the center of the screen
            shipPosition = new Vector2(ScreenManager.Game.GraphicsDevice.Viewport.Width / 2,
                ScreenManager.Game.GraphicsDevice.Viewport.Height / 2);

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
            //ship rotation
            if (input.IsKeyDown(Keys.Left))
                rotation += 0.01f;
            if (input.IsKeyDown(Keys.Right))
                rotation -= 0.01f;

            //space to shoot
            if (currentKBState.IsKeyUp(Keys.Space) && previousKBState.IsKeyDown(Keys.Space))
                score++;//place shot calculatoion here 
            
            currentKBState = Keyboard.GetState();
            previousKBState = currentKBState;

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

            //spriteBatch.Draw(ship, shipRectangle, Color.White);
            spriteBatch.DrawString(ScreenManager.Font, "There will be asteroids here soon...", new Vector2 (0, 0), Color.White);

            spriteBatch.End();


            base.Draw(gameTime);
        }


        #endregion
    }
}
