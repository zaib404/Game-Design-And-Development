using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    // Stores the current gamestate (are you in level setup? the menu? what's the score? did you click a button?)
    public class GameState
    {
        #region datamembers
        // ints to keep track of what's going on (how far in game starting you are)
        public int stage, count;
        // stores if you picked a valid location (for displaying text)
        public bool incorcheck;
        // Scene Manager storing entities
        private SceneManager mSceneManager;
        // boolean to check if you clicked an exit button
        protected bool mexit;
        //check the score
        private int mscore;
        // check if you clicked the pause button
        public bool pause;

        //getters for exit/score (assigning is only done internally so no setters)
        public bool exit
        {
            get
            {
                return mexit;
            }
        }
        public int score
        {
            get
            { return mscore;
            }
        }
        #endregion

        public GameState(SceneManager pMan) {
            // initialise/store variables
            mSceneManager = pMan;
            mexit = false;
            mscore = 300;
            stage = 0;
            count = 0;
            pause = false;
        }

        private void shiftpause() {
            //change pause's state to the opposite of the current one
            if (pause == true) pause = false; else pause = true;

        }

        // mouse listener
        public virtual void OnNewInput(object source, MouseEventArgs args)
        {
            //reacts differently depending in how far through the game start you are
            switch (stage)
            {
                // case 0 is the main menu. 2 buttons: start and exit
                case 0:
                    //if statement for start button
                    if (args.Mouse.Position.X > 570 && args.Mouse.Position.X < 986)
                    {
                        if (args.Mouse.Position.Y > 406 && args.Mouse.Position.Y < 524)
                        {
                            stage = 1;
                        }
                    }
                    //if statement for end button
                    if (args.Mouse.Position.X > 570 && args.Mouse.Position.X < 986)
                    {
                        if (args.Mouse.Position.Y > 582 && args.Mouse.Position.Y < 700)
                        {
                            mexit = true;
                        }
                    }
                    break;
                    // case 1 is the initial level creation. Options are the turret creation button or exit button
                case 1:
                    //check pressed on turret button
                    if (args.Mouse.Position.X > 1231 && args.Mouse.Position.X < 1339)
                    {
                        if (args.Mouse.Position.Y > 222 && args.Mouse.Position.Y < 325)
                        {
                            // get rid of the text telling you you placed the turret wrong (if it's active)
                            incorcheck = false;
                            stage = 2;
                        }
                    }
                    //if statent for end button
                    if (args.Mouse.Position.X > 1525 && args.Mouse.Position.X < 1583)
                    {
                        if (args.Mouse.Position.Y > 833 && args.Mouse.Position.Y < 873)
                        {
                            mexit = true;
                        }
                    }                    
                    break;
                    // case 2 is placing the turret. Needs to check you haven't put it in the wrong place. Also check for exit button
                case 2:
                    //call against track
                    bool check1 = checktrack(args);
                    //call against other turrets
                    bool check2 = checkdistance(args);
                    if (check1 == true && check2 == true)
                    {
                        // if you got a valid location, put one of the 3 turrets there and contine on
                        Vector2 pass = new Vector2(args.Mouse.Position.X, args.Mouse.Position.Y);
                        mSceneManager.placeturret(count, pass);
                        stage = 1;
                        count += 1;
                        mscore = mscore - 100;
                        // after the 3rd placed turret the game starts
                        if (count == 3) stage = 3;
                    }
                    else
                    {
                        incorcheck = true;
                        stage = 1;
                    }
                    //if statent for end button
                    if (args.Mouse.Position.X > 1525 && args.Mouse.Position.X < 1583)
                    {
                        if (args.Mouse.Position.Y > 833 && args.Mouse.Position.Y < 873)
                        {
                            mexit = true;
                        }
                    }
                    break;
                    // case 3 is the game is going. Has code for exit button and pause button.
                    // later versions will have turret placements mid level provided you have the score for it
                case 3:
                    //if statent for end button
                    if (args.Mouse.Position.X > 1525 && args.Mouse.Position.X < 1583)
                    {
                        if (args.Mouse.Position.Y > 833 && args.Mouse.Position.Y < 873)
                        {
                            mexit = true;
                        }
                    }
                    //if statement for pause button
                    if (args.Mouse.Position.X > 1221 && args.Mouse.Position.X < 1376)
                    {
                        if (args.Mouse.Position.Y > 833 && args.Mouse.Position.Y < 873)
                        {
                            shiftpause();
                        }
                    }
                    break;
            }
        }

        private bool checkdistance(MouseEventArgs args)
        {
            Vector2 pass = new Vector2(args.Mouse.Position.X, args.Mouse.Position.Y);
            // check position against the position of other turrets in the scenemanager
            return mSceneManager.checkturret(count, pass); ;
        }

        private bool checktrack(MouseEventArgs args)
        {
            // check the turret is in a valid space on the screen. It can't be on top of the track
            // or on the sidebar UI, etc

            //left/right of screen
            if (args.Mouse.Position.X < 60 || args.Mouse.Position.X > 1140)
            {
                return false;
            }
            //top/bottom of screen
            if (args.Mouse.Position.Y < 60 || args.Mouse.Position.Y > 840)
            {
                return false;
            }
            //first branch of track
            if (args.Mouse.Position.X > 194 && args.Mouse.Position.X < 314)
            {
                if (args.Mouse.Position.Y > 675)
                {
                    return false;
                }
            }
            //branch 2
            if (args.Mouse.Position.X > 194 && args.Mouse.Position.X < 795)
            {
                if (args.Mouse.Position.Y > 635 && args.Mouse.Position.Y < 755)
                {
                    return false;
                }
            }
            //3
            if (args.Mouse.Position.X > 675 && args.Mouse.Position.X < 795)
            {
                if (args.Mouse.Position.Y > 375 && args.Mouse.Position.Y < 755)
                {
                    return false;
                }
            }
            //4
            if (args.Mouse.Position.X > 440 && args.Mouse.Position.X < 795)
            {
                if (args.Mouse.Position.Y > 415 && args.Mouse.Position.Y < 535)
                {
                    return false;
                }
            }
            //5
            if (args.Mouse.Position.X > 440 && args.Mouse.Position.X < 560)
            {
                if (args.Mouse.Position.Y > 150 && args.Mouse.Position.Y < 535)
                {
                    return false;
                }
            }
            //6
            if (args.Mouse.Position.X > 440 && args.Mouse.Position.X < 970)
            {
                if (args.Mouse.Position.Y > 150 && args.Mouse.Position.Y < 270)
                {
                    return false;
                }
            }
            //7
            if (args.Mouse.Position.X > 810 && args.Mouse.Position.X < 930)
            {
                if (args.Mouse.Position.Y < 270)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
