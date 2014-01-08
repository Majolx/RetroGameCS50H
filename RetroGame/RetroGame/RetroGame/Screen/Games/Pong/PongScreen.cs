using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RetroGame;
using RetroGame.Graphics;

namespace RetroGame.Screen
{
    class PongScreen : GameScreen
    {
        #region Fields

        Viewport vp;

        Vector2[] v2Player = new Vector2[2];
        Rectangle[] rPlayer = new Rectangle[2];
        int[] score = { 0, 0 };


        int bound = 30;

        // Paddle
        int paddleHeight = 60;
        int paddleWidth = 30;

        // Ball
        SpriteAnimation ball;
        float speed = 50f;
        Vector2 ballSpeed = new Vector2(.5f, .5f);

        Vector2[] v2Arena = new Vector2[3];
        Rectangle[] rArena = new Rectangle[3];
        Texture2D whiteRectangle;
        Texture2D ballTexture;


        DialogBoxScreen dialog;
        SpriteFont font;

        /// <summary>
        /// A screen-specific content manager.
        /// </summary>
        public ContentManager content;

        #endregion

        #region Initialization


        public PongScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            ballTexture = content.Load<Texture2D>("sprite/ball");


            Initialize();

            base.LoadContent();
        }

        public void Initialize()
        {
            vp = ScreenManager.Game.GraphicsDevice.Viewport;

            // Set up paddles
            v2Player[0] = new Vector2(bound, vp.Height / 2 - (paddleHeight / 2));
            v2Player[1] = new Vector2(vp.Width - bound - paddleWidth, vp.Height / 2 - (paddleHeight / 2));

            rPlayer[0] = new Rectangle((int)v2Player[0].X, (int)v2Player[0].Y, paddleWidth, paddleHeight);
            rPlayer[1] = new Rectangle((int)v2Player[1].X, (int)v2Player[1].Y, paddleWidth, paddleHeight);

            // Set up ball
            ball = new SpriteAnimation(ballTexture);

            ball.AddAnimation("Idle", 0, 0, 300, 297, 1, 0.1f);

            ball.Position = new Vector2(200, 200);
            ball.DrawOffset = new Vector2(0, 0);
            ball.CurrentAnimation = "Idle";
            ball.IsAnimating = true;


            // Set up arena
            v2Arena[0] = new Vector2(0, 0);
            v2Arena[1] = new Vector2(vp.Width / 2 - bound / 2, 0);
            v2Arena[2] = new Vector2(0, vp.Height - bound);

            rArena[0] = new Rectangle((int)v2Arena[0].X, (int)v2Arena[0].Y, vp.Width, bound);
            rArena[1] = new Rectangle((int)v2Arena[1].X, (int)v2Arena[1].Y, bound, vp.Height);
            rArena[2] = new Rectangle((int)v2Arena[2].X, (int)v2Arena[2].Y, vp.Width, bound);

            // Set white texture
            whiteRectangle = new Texture2D(ScreenManager.Game.GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the score, paddle positions, and ball position.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            // Update paddle position
            for (int i = 0; i < rPlayer.Length; i++)
            {
                rPlayer[i].Y = (int)v2Player[i].Y;
            }

            // Update ball position
            float ballX = MathHelper.Clamp(
                ball.Position.X, 0 + ball.DrawOffset.X, ScreenManager.GraphicsDevice.Viewport.Width);
            float ballY = MathHelper.Clamp(
                ball.Position.Y, 0 + ball.DrawOffset.Y, ScreenManager.GraphicsDevice.Viewport.Height);

            ball.Position += ballSpeed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            int maxX = (int)(ScreenManager.GraphicsDevice.Viewport.Width - ball.Width * Camera.scale.X);
            int maxY = (int)(ScreenManager.GraphicsDevice.Viewport.Height - ball.Height * Camera.scale.Y);

            // Check for bounce
            if (ball.Position.X > maxX || ball.Position.X < 0)
                ballSpeed.X *= -1;
            if (ball.Position.Y > maxY || ball.Position.Y < 0)
                ballSpeed.Y *= -1;

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }


        /// <summary>
        /// Handles paddle movement and options menu selection
        /// </summary>
        /// <param name="input"></param>
        public override void HandleInput(InputState input)
        {
            // Get player input
            if (input.IsKeyDown(Keys.S) && v2Player[0].Y < vp.Height - bound - rPlayer[0].Height)
                v2Player[0].Y += speed;

            if (input.IsKeyDown(Keys.W) && v2Player[0].Y > bound)
                v2Player[0].Y -= speed;

            if (input.IsKeyDown(Keys.P))
                popupDialogScreen();
            

            base.HandleInput(input);
        }


        protected virtual void popupDialogScreen()
        {
            ScreenManager.AddScreen(new DialogBoxScreen("Mat", "Hey, this is a test!"), null);
        }


        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = ScreenManager.SpriteBatch;

            sb.Begin();

            // Draw the arena
            for (int i = 0; i < v2Arena.Length; i++)
                sb.Draw(whiteRectangle, rArena[i], Color.White);

            // Draw the paddles
            sb.Draw(whiteRectangle, rPlayer[0], Color.White);
            sb.Draw(whiteRectangle, rPlayer[1], Color.White);

            // Draw the ball
            ball.Draw(sb, Camera.DisplayOffset.X, Camera.DisplayOffset.Y, Camera.scale);

            // If the dialog box screen exists, draw it.
            if (dialog != null)
            {
                dialog.Draw(gameTime);
            }

            sb.End();

            base.Draw(gameTime);
        }
        #endregion
    }
}
