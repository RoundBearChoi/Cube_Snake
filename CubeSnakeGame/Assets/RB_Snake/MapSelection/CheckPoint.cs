using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class CheckPoint : MonoBehaviour
    {
        public SnakeIslandType IslandType;
        public int Index;

        private void Start()
        {
            if (!SaveManager.Instance.PointsList.Contains(this))
            {
                SaveManager.Instance.PointsList.Add(this);
            }
        }
    }
}