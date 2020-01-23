using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class SnakeBodyManager : Singleton<SnakeBodyManager>
    {
        public List<SnakeBody> Bodies = new List<SnakeBody>();
        public float BigUpdateTime;
        public float BigUpdateInterval = 0.165f;
        public bool FirstUpdate;

        private SnakePlayer player;

        public SnakePlayer PLAYER
        {
            get
            {
                if (player == null)
                {
                    player = FindObjectOfType<SnakePlayer>();
                }
                return player;
            }
        }

        private void Awake()
        {
            FirstUpdate = true;
        }

        public SnakeBody SNAKE_HEAD
        {
            get
            {
                foreach(SnakeBody s in Bodies)
                {
                    if (s.Front == null)
                    {
                        return s;
                    }
                }

                return null;
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

        private void Update()
        {
            BigUpdateTime += Time.deltaTime;

            if (BigUpdateTime >= BigUpdateInterval)
            {
                FirstUpdate = false;
                UpdateBodies();
                BigUpdateTime = 0f;
            }
        }
        
        public void UpdateBodies()
        {
            if (!PLAYER.IsDead)
            {
                for (int i = 0; i < Bodies.Count; i++)
                {
                    Bodies[i].UpdateBody();
                }

                UIManager.Instance.ARROW_KEYS_UI.UpdateArrows();
                UIManager.Instance.ARROW_KEYS_UI.UpdateLastArrow();
            }
        }
    }
}