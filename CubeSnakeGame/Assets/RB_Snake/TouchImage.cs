using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class TouchImage : MonoBehaviour
    {
        private TouchControl touchControl;
        public RuntimeAnimatorController TouchAnimator;
        public Animator animator;

        private void Start()
        {
            touchControl = FindObjectOfType<TouchControl>();   
        }

        void Update()
        {
            this.transform.position = touchControl.TouchPos;
        }

        public void ProcTouchAnimation()
        {
            if (!animator.gameObject.activeInHierarchy)
            {
                animator.gameObject.SetActive(true);
            }

            StartCoroutine(_ProcTouchAnimation());
        }

        IEnumerator _ProcTouchAnimation()
        {
            yield return new WaitForEndOfFrame();
            animator.runtimeAnimatorController = null;
            animator.runtimeAnimatorController = TouchAnimator;
        }
    }
}