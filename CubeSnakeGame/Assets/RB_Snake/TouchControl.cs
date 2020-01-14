using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class TouchControl : MonoBehaviour
    {
        private Touch FirstTouch;
        public Vector2 TouchPos;

        void Update()
        {
            if (Input.touchCount > 0)
            {
                FirstTouch = Input.GetTouch(0);
                TouchPos = FirstTouch.position;
                UIManager.Instance.TOUCH_IMAGE_UI.ProcTouchAnimation();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                TouchPos = Input.mousePosition;
                UIManager.Instance.TOUCH_IMAGE_UI.ProcTouchAnimation();
            }
        }
    }
}