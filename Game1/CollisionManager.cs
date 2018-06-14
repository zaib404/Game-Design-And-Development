using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class CollisionManager
    {
        #region datamembers
        // list for moving entities
        private IList<iCollide> mMobile;
        // list for entities that aren't moving
        private IList<iCollide> mStatic;
        #endregion 

        public CollisionManager() {
            // initialise lists
            mMobile = new List<iCollide>();
            mStatic = new List<iCollide>();
        }

        #region methods
        // add a moving element
        public void addmobile(iCollide piCollide)
        {
            // If entity is not part of mobile object list
            if (!mMobile.Contains(piCollide))
            {   //Add it to the list
                mMobile.Add(piCollide);
            }
        }

        // remove a moving element
        public void removemobile(iCollide piCollide)
        {
            // Remove Entity from list
            this.mMobile.Remove(piCollide);
        }

        // add a static element
        public void addstatic(iCollide piCollide)
        {
            // If entity is not part of mobile object list
            if (!mStatic.Contains(piCollide))
            {   //Add it to the list
                mStatic.Add(piCollide);
            }
        }

        // remove a static element
        public void removestatic(iCollide piCollide)
        {
            // Remove Entity from list
            this.mStatic.Remove(piCollide);
        }

        public void colcheck() {
            
            // If there's no moving elements, then don't bother doing collision checks at all
            if (mMobile.Count > 0) {
                #region stationary/moving collisions
                if(mStatic != null)
                {           // Check against static elements (turrets) as long as there ARE stationary elements
                    for (int i = 0; i < mStatic.Count; i++)
                    {
                        for (int j = 0; j < mMobile.Count; j++)
                        {
                            // If they are winthin range, then the enemy has their collide method triggered
                            // check the distance between the two objects
                            #region checkdistance
                            float temp1 = mMobile[j].Position.X - mStatic[i].Position.X;
                            float temp2 = mMobile[j].Position.Y - mStatic[i].Position.Y;
                            temp1 = temp1 * temp1;
                            temp2 = temp2 * temp2;
                            temp1 = temp1 + temp2;
                            double temp3 = Math.Sqrt(temp1);
                            #endregion
                            temp2 = mMobile[j].collisionrange + mStatic[i].collisionrange;
                            // if the 2 objects are closer than their combined collision ranges, then run their collide methods
                            if (temp2 > temp3) {
                                mMobile[j].collide(mStatic[i]);
                                mStatic[i].collide(mMobile[j]);
                            }
                        }
                    }
                }
                #endregion                
            }

            //There are several potential methods for doing collision detection that could be used with the current iCollide interface

            // It has a rectangle hitbox (which is currently being used), it has a float for collision radius (allowing you to draw a sphere
            // around the object, or a wide radius around the object seperate from the actual hitbox), it has velocity and position (to predict
            // if there will be a collision before it happens, and stop it cutting through walls if it's going to fast)


        }
        #endregion
    }
}
