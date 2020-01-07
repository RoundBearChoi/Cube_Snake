using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class Control : MonoBehaviour
    {
        public List<KeyCode> KeyPresses = new List<KeyCode>();
        public KeyCode LastPress;

        bool IsReverse(KeyCode key)
        {
            if (LastPress == KeyCode.LeftArrow)
            {
                if (key == KeyCode.RightArrow)
                {
                    return true;
                }
            }

            if (LastPress == KeyCode.RightArrow)
            {
                if (key == KeyCode.LeftArrow)
                {
                    return true;
                }
            }

            if (LastPress == KeyCode.UpArrow)
            {
                if (key == KeyCode.DownArrow)
                {
                    return true;
                }
            }

            if (LastPress == KeyCode.DownArrow)
            {
                if (key == KeyCode.UpArrow)
                {
                    return true;
                }
            }

            return false;
        }

        bool IsSame(KeyCode key)
        {
            if (key == LastPress)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void Update()
        {
            if (SnakeBodyManager.Instance.IsDead)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!IsReverse(KeyCode.LeftArrow) &&
                    !IsSame(KeyCode.LeftArrow))
                {
                    KeyPresses.Add(KeyCode.LeftArrow);
                    UIManager.Instance.ARROW_KEYS_UI.UpdateArrows();
                    UIManager.Instance.ARROW_KEYS_UI.UpdateLastArrow();
                    LastPress = KeyCode.LeftArrow;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!IsReverse(KeyCode.RightArrow) &&
                    !IsSame(KeyCode.RightArrow))
                {
                    KeyPresses.Add(KeyCode.RightArrow);
                    UIManager.Instance.ARROW_KEYS_UI.UpdateArrows();
                    UIManager.Instance.ARROW_KEYS_UI.UpdateLastArrow();
                    LastPress = KeyCode.RightArrow;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!IsReverse(KeyCode.UpArrow) &&
                    !IsSame(KeyCode.UpArrow))
                {
                    KeyPresses.Add(KeyCode.UpArrow);
                    UIManager.Instance.ARROW_KEYS_UI.UpdateArrows();
                    UIManager.Instance.ARROW_KEYS_UI.UpdateLastArrow();
                    LastPress = KeyCode.UpArrow;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!IsReverse(KeyCode.DownArrow) &&
                    !IsSame(KeyCode.DownArrow))
                {
                    KeyPresses.Add(KeyCode.DownArrow);
                    UIManager.Instance.ARROW_KEYS_UI.UpdateArrows();
                    UIManager.Instance.ARROW_KEYS_UI.UpdateLastArrow();
                    LastPress = KeyCode.DownArrow;
                }
            }
        }
    }
}