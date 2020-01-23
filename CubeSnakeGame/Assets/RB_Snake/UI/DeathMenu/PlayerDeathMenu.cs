using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RBSnake
{
    public class PlayerDeathMenu : MonoBehaviour
    {
        [SerializeField]
        Animator animator;

        [SerializeField]
        List<TextMeshProUGUI> Buttons = new List<TextMeshProUGUI>();

        private Coroutine ShowRoutine = null;

        private void Start()
        {
            TurnOffButtons();
            UIManager.Instance.DeathMenu = this;
        }

        void ToggleMenu(bool toggle)
        {
            animator.SetBool("DeathMenuOn", toggle);
        }

        public bool DeathMenuIsOn()
        {
            if (ShowRoutine != null)
            {
                return true;
            }

            return animator.GetBool("DeathMenuOn");
        }

        public void ShowDeathMenu()
        {
            Debug.Log("showing death menu..");
            
            if (ShowRoutine == null)
            {
                ShowRoutine = StartCoroutine(_ShowMenu());
            }
        }

        IEnumerator _ShowMenu()
        {
            yield return new WaitForSeconds(1f);
            ToggleMenu(true);
        }

        public void TurnOffButtons()
        {
            foreach(TextMeshProUGUI t in Buttons)
            {
                t.enabled = false;
            }
        }

        public void TurnOnButtons()
        {
            foreach (TextMeshProUGUI t in Buttons)
            {
                t.enabled = true;
            }
        }
    }
}