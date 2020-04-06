using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class CheckPoint : MonoBehaviour
    {
        public int Index;

        private void Start()
        {
            if (!CheckPointManager.Instance.PointsList.Contains(this))
            {
                CheckPointManager.Instance.PointsList.Add(this);
            }
        }
    }
}