using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game1
{
    class BasWBCBehaviour:iBehaviour
    {
        #region datamembers
        protected iEntity mBody;

        public iEntity Body
        {
            get { return mBody; }
        }
        #endregion

        public BasWBCBehaviour(BasicWhiteBC pBody)
        {
            // Store associated body
            mBody = pBody;
        }

        #region methods

        public void collide(iCollide pcollider)
        {
            // blood cell currently doesn't react to firing
            // if the decision was made to have it have cooldown cycle between fires, or be targetting one
            // enemy a turn (rather than everything in range) then that could be done here

            // This is going to change in later versions as more types of turrets are included
        }


        public void update()
        {
            // update
            // doesn't have anything at the moment
            // could add stuff for visuals (rotate around a centrepoint, etc)
        }
        #endregion
    }
}
