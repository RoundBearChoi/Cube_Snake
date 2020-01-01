using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class SnakeBodyManager : Singleton<SnakeBodyManager>
    {
        public List<SnakeBody> Bodies = new List<SnakeBody>();
        public float BigUpdateTime;
        public float BigUpdateInterval = 0.25f;

        public void InitSnake()
        {
            SnakeBody[] arr = GameObject.FindObjectsOfType<SnakeBody>();

            foreach(SnakeBody s in arr)
            {
                if (s.Back == null)
                {
                    s.RegisterBody();
                    break;
                }
            }
        }

        private void Update()
        {
            BigUpdateTime += Time.deltaTime;

            if (BigUpdateTime >= BigUpdateInterval)
            {
                UpdateBodies();
                BigUpdateTime = 0f;
            }
        }

        public void UpdateBodies()
        {
            for (int i = 0; i < Bodies.Count; i++)
            {
                Bodies[i].UpdateBody();
            }
        }
    }
}