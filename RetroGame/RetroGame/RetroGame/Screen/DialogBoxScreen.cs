// DialogBoxScreen.cs

#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion


namespace RetroGame.Screen
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    class DialogBoxScreen : GameScreen
    {
        #region Fields

        string speakerName;
        string text;
        Vector2 dialogBoxSize = new Vector2(350, 150);
        int borderSize = 5;
        Vector2 drawPoint = new Vector2(100, 100);

        #endregion

        #region Properties


        public Color TextColor
        {
            get;
            set;
        }
        private Color textColor;


        public Color BorderColor
        {
            get;
            set;
        }
        private Color borderColor;


        public Color BackgroundColor
        {
            get;
            set;
        }
        private Color backgroundColor;


        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public DialogBoxScreen(string speakerName, string text)
        {
            this.speakerName = speakerName;
            this.text = text;
            borderColor = Color.Red;
            backgroundColor = Color.Blue;
        }


        #endregion

        #region Handle Input


        public override void HandleInput(InputState input)
        {
            PlayerIndex playerIndex;

            if (input.IsMenuSelect(ControllingPlayer, out playerIndex))
            {
                OnDialogContinue();
            }
            base.HandleInput(input);
        }

        protected virtual void OnDialogContinue()
        {

        }


        #endregion

        #region Update and Draw




        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice graphics = ScreenManager.GraphicsDevice;
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;

            spriteBatch.Begin();

            // Draw the border rectangle
            spriteBatch.Draw(new Texture2D(graphics, (int)dialogBoxSize.X + (borderSize * 2),
                                                     (int)dialogBoxSize.Y + (borderSize * 2)),
                             new Rectangle((int)drawPoint.X - borderSize,
                                           (int)drawPoint.Y - borderSize,
                                           (int)dialogBoxSize.X + borderSize,
                                           (int)dialogBoxSize.Y + borderSize),
                             borderColor);

            // Draw the background rectangle
            spriteBatch.Draw(new Texture2D(graphics, (int)dialogBoxSize.X,
                                                     (int)dialogBoxSize.Y),
                             new Rectangle((int)drawPoint.X,
                                           (int)drawPoint.Y,
                                           (int)dialogBoxSize.X,
                                           (int)dialogBoxSize.Y),
                             backgroundColor);

            spriteBatch.End();
        }

        #endregion
    }
}