using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class TouchControl : MonoBehaviour
    {
        public Vector2 TouchPos;

        private Touch FirstTouch;
        private float TouchAngle;
        private KeyCode TouchKey;
        private Control SnakeController;

        private void Start()
        {
            SnakeController = FindObjectOfType<Control>();
        }

        void Update()
        {
            if (SnakeBodyManager.Instance.PLAYER.IsDead)
            {
                return;
            }

            if (Input.touchCount != 0)
            {
                FirstTouch = Input.GetTouch(0);
                TouchPos = FirstTouch.position;
                UIManager.Instance.TOUCH_IMAGE_UI.ProcTouchAnimation();
                SetTouchDirection();
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                TouchPos = Input.mousePosition;
                UIManager.Instance.TOUCH_IMAGE_UI.ProcTouchAnimation();
                SetTouchDirection();
            }
        }

        void SetTouchDirection()
        {
            Vector2 angle = TouchPos - UIManager.Instance.TOUCH_IMAGE_UI.GetCenterPos();
            TouchAngle = Get360Degree(angle);

            TouchKey = KeyCode.None;

            if (TouchAngle >= 0f &&
                TouchAngle < 45f)
            {
                TouchKey = KeyCode.UpArrow;
            }
            else if (TouchAngle >= 45f &&
                TouchAngle < 90f)
            {
                TouchKey = KeyCode.RightArrow;
            }
            else if (TouchAngle >= 90f &&
                TouchAngle < 135f)
            {
                TouchKey = KeyCode.RightArrow;
            }
            else if (TouchAngle >= 135f &&
                TouchAngle < 180f)
            {
                TouchKey = KeyCode.DownArrow;
            }
            else if (TouchAngle >= 180f &&
                TouchAngle < 225f)
            {
                TouchKey = KeyCode.DownArrow;
            }
            else if (TouchAngle >= 225f &&
                TouchAngle < 270f)
            {
                TouchKey = KeyCode.LeftArrow;
            }
            else if (TouchAngle >= 270f &&
                TouchAngle < 315f)
            {
                TouchKey = KeyCode.LeftArrow;
            }
            else if (TouchAngle >= 315f &&
                TouchAngle <= 360f)
            {
                TouchKey = KeyCode.UpArrow;
            }
            
            if (SnakeController.KeyPresses.Count > 1)
            {
                SnakeController.KeyPresses.Clear();
            }

            if (!SnakeController.IsReverse(TouchKey))
            {
                if (SnakeController.KeyPresses.Count == 0)
                {
                    SnakeController.KeyPresses.Add(TouchKey);
                }

                SnakeController.KeyPresses[0] = TouchKey;
                SnakeController.LastPress = TouchKey;
            }
            else
            {
                SnakeController.KeyPresses.Clear();
            }
        }

        float Get360Degree(Vector2 vec)
        {
            float value = Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg;

            if (value < 0)
            {
                value += 360f;
            }

            return value;
        }
    }
}