using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RBSnake
{
    public class SnakeBodyManager : Singleton<SnakeBodyManager>
    {
        public List<SnakeBody> Bodies = new List<SnakeBody>();
        public float BigUpdateTime;
        public bool FirstUpdate;

        SnakePlayer player;
        float BigUpdateInterval = 0.165f;

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

        private void LateUpdate()
        {
            if (PLAYER.snakeTime != null)
            {
                if (BigUpdateInterval != PLAYER.snakeTime.sTime)
                {
                    BigUpdateInterval = PLAYER.snakeTime.sTime;
                }

                BigUpdateTime += Time.deltaTime;

                if (BigUpdateTime >= BigUpdateInterval)
                {
                    FirstUpdate = false;
                    UpdateSnake();
                    BigUpdateTime = 0f;
                }
            }
        }
        
        public void DebugNextGround(KeyCode key)
        {
            Ground nextGround = PLAYER.GetNextGround(key);

            if (nextGround != null)
            {
                Debug.Log("next ground: " + nextGround.gameObject.name);
                Debug.DrawLine(Bodies[Bodies.Count - 1].transform.position + Vector3.up,
                    nextGround.transform.position + (Vector3.up * 2f),
                    Color.red,
                    600f);
            }
            else
            {
                Debug.Log("no next ground!");
            }
        }

        public void UpdateSnake()
        {
            if (!PLAYER.IsDead)
            {
                for (int i = 0; i < Bodies.Count; i++)
                {
                    if (Bodies[i].CheckPointLoaded)
                    {
                        Bodies[i].UpdateSnakeCube();
                    }
                }

                UIManager.Instance.ARROW_KEYS_UI.UpdateArrows();
                UIManager.Instance.ARROW_KEYS_UI.UpdateLastArrow();
            }
            else
            {
                if (PLAYER.IsDrowning)
                {
                    foreach (SnakeBody body in Bodies)
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