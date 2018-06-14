using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    public class TDLevelManager
    {
        #region Data Members

        // Insert Data Members 
        // managers that it needs access to
        private SceneManager mSceneManager;
        private CollisionManager mCollManager;
        private EntityManager mEntityManager;
        private ContentManager mContent;
        private MouseManager mMouseManager;
        // size of the screen for reference (it's set to 1600/900, but that could change easily)
        private int mScreenWidth, mScreenHeight;
        // list of entities in the current level (generally identical to the one in the scenegraph, but not always due to turrets potentially persisting through waves)
        private IList<iEntity> mCurrentLevel;

        #endregion
        public TDLevelManager(SceneManager pScene, CollisionManager pColl, EntityManager pEntity, ContentManager pContent, int pScreenWidth, int pScreenHeight, MouseManager pMouse) {
            // instantiate variables
            mSceneManager = pScene;
            mCollManager = pColl;
            mEntityManager = pEntity;
            mContent = pContent;
            mScreenWidth = pScreenWidth;
            mScreenHeight = pScreenHeight;
            mMouseManager = pMouse;
            mCurrentLevel = new List<iEntity>();
        }

        public void addlevel1()
        {       // spawn enemies for prototype level
            for (int i = 0; i < 30; i++)
            {                                       // Spawn enemies
                //call entity manager
                ProtoCholera chole = mEntityManager.CreateInstance<ProtoCholera>();
                // grant entities their textures 
                chole.Texture = mContent.Load<Texture2D>("Assets/cholera.png");
                //add to scene manager
                // their initial location variance means they differ in when they come on screen
                mSceneManager.Spawn(chole, 254, 1000 + (100 * i));
                // moving elements, so they use addmobile method
                mCollManager.addmobile(chole);
                mCurrentLevel.Add(chole);
                if (i == 5) i = i + 5;
                if (i == 16) i = i + 5;
            }
            for (int i = 0; i < 3; i++)
            {
                //call entity manager
                BasicWhiteBC WBC = mEntityManager.CreateInstance<BasicWhiteBC>();
                // grant entities their textures 
                WBC.Texture = mContent.Load<Texture2D>("Assets/Eosinophil Bound.png");
                //add to scene manager
                // spawned off screen and moved on when needed
                // will be changed in later versions of prototype
                mSceneManager.Spawn(WBC, 2000, 340);
                // static elements, so they use addstatic method
                mCollManager.addstatic(WBC);
                mCurrentLevel.Add(WBC);
            }
        }

        // clear the current level
        public void removelevel1() {
            foreach (iEntity entity in mCurrentLevel)
            {   // remove all things from this list from the scenegraph
                mSceneManager.Remove(entity);
            }   // they don't NEED to be removed from collision management, but it would be a good idea to do so
        }       // for now that's missed out though (due to seperation of static/mobile lists making this harder)

        // example methods for later. Unused for now
        public void addlevel2()
        {
        }
        public void removelevel2()
        {
        }
        //more methods later
    }
}
