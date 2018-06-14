using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class CholeraBehaviour : iBehaviour
    {
        #region Datamembers
        // body associated with mind
        protected iEntity mBody;
        // phase and shake track the current state of the enemy (along with the bodies hp)
        private int phase;
        private int shake;

        public iEntity Body
        {
            get { return mBody; }
        }
        #endregion

        public CholeraBehaviour(ProtoCholera pChol)
        {
            //store associated entity
            mBody = pChol;
            phase = 0;
            shake = 0;
        }

        #region methods
        // Collide method to be called if you're in range of a cell
        public void collide(iCollide pcollider)
        {
            ProtoCholera tempBod = (ProtoCholera)mBody;
            //reduce enemy hp
            tempBod.HP = tempBod.HP - 1;
            // add visual indicator of taking damage (shaking back and forth)
            switch (shake)
            {
                // cycles through several states to make it move in a repeating shaking pattern
                case 0:
                    mBody.Position += new Vector2(-1, 0);
                    shake = 1;
                    break;
                case 1:
                    mBody.Position += new Vector2(0, -1);
                    shake = 2;
                    break;
                case 2:
                    mBody.Position += new Vector2(1, 0);
                    shake = 3;
                    break;
                case 3:
                    mBody.Position += new Vector2(0, 1);
                    shake = 4;
                    break;
                case 4:
                    mBody.Position += new Vector2(1, 0);
                    shake = 5;
                    break;
                case 5:
                    mBody.Position += new Vector2(0, 1);
                    shake = 6;
                    break;
                case 6:
                    mBody.Position += new Vector2(-1, 0);
                    shake = 7;
                    break;
                case 7:
                    mBody.Position += new Vector2(0, -1);
                    shake = 0;
                    break;
            }
        }

        public void checkpath() {
            // make sure you're following the path
            switch (phase) {
                case 0:
                    mBody.Velocity = new Vector2(0,-3);
                    if (mBody.Position.Y < 695) {
                        phase = 1;
                    }
                    break;
                case 1:
                    mBody.Velocity = new Vector2(3, 0);
                    if (mBody.Position.X > 735)
                    {
                        phase = 2;
                    }
                    break;
                case 2:
                    mBody.Velocity = new Vector2(0, -3);
                    if (mBody.Position.Y < 475)
                    {
                        phase = 3;
                    }
                    break;
                case 3:
                    mBody.Velocity = new Vector2(-3, 0);
                    if (mBody.Position.X < 500)
                    {
                        phase = 4;
                    }
                    break;
                case 4:
                    mBody.Velocity = new Vector2(0, -3);
                    if (mBody.Position.Y < 210)
                    {
                        phase = 5;
                    }
                    break;
                case 5:
                    mBody.Velocity = new Vector2(3, 0);
                    if (mBody.Position.X > 870)
                    {
                        phase = 6;
                    }
                    break;
                case 6:
                    mBody.Velocity = new Vector2(0, -3);
                    if (mBody.Position.Y < -100)
                    {
                        phase = 7;
                    }
                    break;
                case 7:
                    // once you're off the screen then stop
                    mBody.Velocity = new Vector2(0, 0);
                    break;
            }
            // velocity updates in order to follow the path above
        }

        // can't be triggered by outside (automatic for enemies)
        private void checkhp() {
            ProtoCholera tempBod = (ProtoCholera)mBody;
            // if they drop too low in hp, they get moved to a storage area off screen to keep track of killed enemies
            // since it's at a individual level, different locations can be used for different enemy types later
            if (tempBod.HP <= 0)
            {
                // more off screen, and register as at the end of the track
                mBody.Position = new Vector2(-100, -100);
                phase = 7;                
            }
        }

        public void update()
        {
            // check states of behaviour
            checkhp();
            checkpath();
            //update position
            mBody.Position += mBody.Velocity;
        }
        #endregion
    }
}
