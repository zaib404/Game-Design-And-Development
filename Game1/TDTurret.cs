using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public abstract class TDTurret : TDEntity
    {
        #region datamembers
        /*protected int mdamage;
        public int damage
        {
            get{
                return mdamage;
            }
        }*/
        // Used when more enemies are implemented. Allows certain turrets to deal more/less damage per hit
        #endregion
    }
}
