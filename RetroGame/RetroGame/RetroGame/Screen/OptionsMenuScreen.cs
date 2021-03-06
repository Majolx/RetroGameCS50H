﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RetroGame.Screen;
using Microsoft.Xna.Framework;

namespace RetroGame.Screen
{
    class OptionsMenuScreen : MenuScreen
    {
        #region Initialization


        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public OptionsMenuScreen()
            : base("Options")
        {
            // Create our menu entries.
            MenuEntry displayMenuEntry = new MenuEntry("Display");
            MenuEntry debugMenuEntry = new MenuEntry("Debug");
            MenuEntry backMenuEntry = new MenuEntry("Go Back");

            // Hook up menu event handlers.
            displayMenuEntry.Selected += DisplayMenuEntrySelected;
            debugMenuEntry.Selected += DebugMenuEntrySelected;
            backMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(displayMenuEntry);
            MenuEntries.Add(debugMenuEntry);
            MenuEntries.Add(backMenuEntry);
        }


        #endregion

        #region Handle Input

        void DisplayMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new DisplayMenuScreen(), e.PlayerIndex);
        }


        void DebugMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new DebugScreen(), e.PlayerIndex);
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
