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

            SaveManager.Instance.LoadData();

            foreach(SnakeBody s in arr)
            {
                s.InitBodyOnCheckPoint();

                if (s.Back == null)
                {
                    s.RegisterBody();
                    continue;
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
                    if (Bodies[i].CheckPointLoaded)
                    {
                        Bodies[i].UpdateBody();
                    }
                }

                UIManager.Instance.ARROW_KEYS_UI.UpdateArrows();
                UIManager.Instance.ARROW_KEYS_UI.UpdateLastArrow();
            }
            else
            {
                if (PLAYER.IsDrowning)
                {
                    foreach(SnakeBody body in Bodies)
                    {
                        //Debug.Log("drowning body: " + body.gameObject.name);
                        if (body.Front != null)
                        {
                            body.transform.position = body.Front.transform.position;
                        }
                        else
                        {
                            if (body.transform.position.y > -0.1f)
                            {
                                GameObject water = PoolManager.Instance.GetObject(PoolObjectType.VFX_WATER);
                                water.transform.position = body.transform.position;
                                water.gameObject.SetActive(true);

                                CameraManager.Instance.CAMERA_CONTROL.ZoomInAndOut(0.15f, 0.25f);
                            }

                            body.transform.position += Vector3.down;
                        }
                    }

                    PLAYER.IsDrowning = false;
                }
            }
        }
    }
}