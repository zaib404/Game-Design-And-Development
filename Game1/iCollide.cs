using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Game1
{
    public interface iCollide
    {
        // Various values for calculating if a collision is occuring, or about to
        float collisionrange { get; set; }
        Rectangle HitBox { get; }
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }

        #region methods
        void collide(iCollide pcollider);
        #endregion
    }
}
