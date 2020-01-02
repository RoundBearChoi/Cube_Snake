using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class SnakeBodyManager : Singleton<SnakeBodyManager>
    {
        public List<SnakeBody> Bodies = new List<SnakeBody>();
        public float BigUpdateTime;
        public float BigUpdateInterval = 0.15f;

        private SnakeBody snakehead = null;
        public SnakeBody SnakeHead
        {
            get
            {
                if (snakehead == null)
                {
                    snakehead = GetSnakeHead();
                }
                return snakehead;
            }
        }

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

        SnakeBody GetSnakeHead()
        {
            foreach(SnakeBody body in Bodies)
            {
                if (body.Front == null)
                {
                    return body;
                }
            }

            return null;
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