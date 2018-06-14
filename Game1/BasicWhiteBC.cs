using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    // The basic white blood cell. In later versions, could be upgraded to specialise more against certain types of enemies
    class BasicWhiteBC : TDTurret
    {
        // Constructor
        public BasicWhiteBC()
        {
            // set position, speed and initialise behaviour
            setPosition(mPosition.X, mPosition.Y);
            mcoll = 175;
            mSpeed = 0;

            mBehaviour = new BasWBCBehaviour(this);
        }

        #region methods
        //Call methods from behaviour that control the entity
        public override void collide(iCollide pcollider)
        {
            // Call behaviours collide method
            mBehaviour.collide(pcollider);
        }

        public override void Update()
        {            
            // update the behaviour
            mBehaviour.update();
        }        
        #endregion
    }
}
