using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class LineEmptyBoxAnswer
    {
        private int index;
        private List<GameObject> gameObjects;
        private int count;
        private bool isChecked;

        public LineEmptyBoxAnswer(int index, List<GameObject> gameObjects)
        {
            this.index = index;
            this.gameObjects = gameObjects;
            this.count = gameObjects.Count;
            this.isChecked = false;
        }

        //public bool compareNumberChar(int count)
        //{
        //    return this.count == count;
        //}

        public List<GameObject> getGameObjects()
        {
            return this.gameObjects;
        }

        public bool getChecked()
        {
            return isChecked;
        }

        public void setChecked(bool state)
        {
            this.isChecked = state;
        }
    }
}
