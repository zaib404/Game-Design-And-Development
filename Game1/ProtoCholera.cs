using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public class ProtoCholera : TDEnemy
    {
        #region Data Members

        // Insert Data Members 

        #endregion
        public ProtoCholera()
        {
            // generate a cholera behavior
            mHP = 450;
            mcoll = 30;
            mBehaviour = new CholeraBehaviour(this);
        }

        #region methods
        // Call methods in behaviour
        public override void collide(iCollide pcollider)
        {
            // Call behaviours collide method
            mBehaviour.collide(pcollider);
        }

        public override void Update()
        {
            mBehaviour.update();
        }
        #endregion
    }
}
