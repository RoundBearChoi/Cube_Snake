using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class SnakePlayer : MonoBehaviour
    {
        public bool IsDead;

        private void Awake()
        {
            IsDead = false;
        }

        private void Update()
        {
            ToggleDeathMenu();
        }

        void ToggleDeathMenu()
        {
            if (IsDead)
            {
                if (UIManager.Instance.DeathMenu != null)
                {
                    if (!UIManager.Instance.DeathMenu.DeathMenuIsOn())
                    {
                        UIManager.Instance.DeathMenu.ShowDeathMenu();
                    }
                }
            }
        }
    }
}