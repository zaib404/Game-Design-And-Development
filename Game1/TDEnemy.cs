using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public abstract class TDEnemy : TDEntity
    {
        #region datamembers
        // HP values to keep track of if they're dead or alive
        protected int mHP;
        public int HP
        {
            get
            {
                return mHP;
            }
            set
            {
                mHP = value;
            }
        }
        #endregion
    }
}
