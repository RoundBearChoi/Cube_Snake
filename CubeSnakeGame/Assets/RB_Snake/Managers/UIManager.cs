using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class UIManager : Singleton<UIManager>
    {
        private ArrowKeys arrowKeysUI;

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
    }
}
