using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class SceneManager : iSceneManager
    {

        #region Data Members

        // Insert Data Members
        public int score;

        // List
        private SceneGraph mSceneGraph;
        
        #endregion

        public SceneManager()
        {
            // Initialize mIEntityList to a List
            mSceneGraph = new SceneGraph();
        }

        #region methods
        public void Spawn(iEntity pIEntity, float xPos, float yPos)
        {
            // Set entity position to = the position passed in
            pIEntity.setPosition(xPos,yPos);
            // add to scene graph
            mSceneGraph.addobject(pIEntity);
        }

        public void Remove(iEntity pIEntity)
        {
            // Remove Entity from scene
            this.mSceneGraph.removeobject(pIEntity);
        }

        public void Draw(SpriteBatch spriteBatch){
            // Add the sprites from the scenegraph to the spritebatch
            foreach (iEntity entity in mSceneGraph.getList())
            {
                entity.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            // Update the entities in the scenegraph
            foreach (iEntity entity in mSceneGraph.getList())
            {
                entity.Update();
            }
            checkscore();
        }

        #region not part of original engine
        // update the score (current number of dead enemies X 5)
        public void checkscore() {
            score = 0;
            foreach (iEntity entity in mSceneGraph.getList())
            {
                if (entity.Position.X == -100 && entity.Position.Y == - 100){
                    score = score + 5;
                }
            }
        }

        // test the target location against the other previously placed turrets
        public bool checkturret(int pcount, Vector2 pos) {
            IList<iEntity> templist = mSceneGraph.getList();
            // you only need to test if there's been one placed already
            if (pcount > 0) {
                for (int i = 0; i < pcount; i++)
                {       // make sure they're not to close to each other
                    if (Math.Sqrt((templist[20 + i].Position.X - pos.X)* (templist[20 + i].Position.X - pos.X) + (templist[20 + i].Position.Y - pos.Y)*(templist[20 + i].Position.Y - pos.Y)) <120)
                    {
                        return false;
                    }
                }       // return true if it's a position that will work, or false otherwise
            }
            return true;
        }

        // place the turret in the target location (or move it there as the case may be)
        public void placeturret(int pcount, Vector2 pos) {
            IList<iEntity> templist = mSceneGraph.getList();
            templist[20 + pcount].setPosition(pos.X, pos.Y);
        }
        #endregion

        #endregion
    }
}
