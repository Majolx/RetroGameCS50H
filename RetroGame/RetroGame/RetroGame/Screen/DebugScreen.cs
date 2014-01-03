#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RetroGame.Screen;
#endregion

namespace RetroGame.Screen
{
    class DebugScreen : MenuScreen
    {
        #region Initialization


        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public DebugScreen()
            : base("Debug!1")
        {
            // Create our menu entries.
            MenuEntry asteroidMenuEntry = new MenuEntry("Asteroid");
            MenuEntry backMenuEntry = new MenuEntry("Go Back");

            // Hook up menu event handlers.
            asteroidMenuEntry.Selected += AsteroidMenuEntrySelected;
            backMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(asteroidMenuEntry);
            MenuEntries.Add(backMenuEntry);
        }


        #endregion

        #region Handle Input

        void AsteroidMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new AsteroidGameScreen(), e.PlayerIndex);
        }


        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            this.ExitScreen();
        }


        #endregion
    }
}
