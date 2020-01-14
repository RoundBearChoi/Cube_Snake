using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class UIManager : Singleton<UIManager>
    {
        private ArrowKeys arrowKeysUI;
        private TouchImage touchImageUI;

        public ArrowKeys ARROW_KEYS_UI
        {
            get
            {
                if (arrowKeysUI == null)
                {
                    arrowKeysUI = FindObjectOfType<ArrowKeys>();
                }
                return arrowKeysUI;
            }
        }

        public TouchImage TOUCH_IMAGE_UI
        {
            get
            {
                if (touchImageUI == null)
                {
                    touchImageUI = FindObjectOfType<TouchImage>();
                }
                return touchImageUI;
            }
        }
    }
}
