using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public abstract class TDEntity : Entity, iCollide
    {
        #region Data Members

        // Insert Data Members

        // Texture2D
        protected Texture2D mTexture2D;

        // Rectangle
        protected Rectangle mRectangle;

        protected float mcoll;

        // HitBox getter return new rectangle
        public Rectangle HitBox
        {
            get
            {
                return mRectangle = new Rectangle((int)Position.X,
              (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        // Insert Properties
        public float collisionrange
        {
            get { return mcoll; }
            set { mcoll = value; }
        }
        #endregion

        #region Methods             

        public virtual void collide(iCollide pcollider)
        {

        }

        #endregion
    }
}
