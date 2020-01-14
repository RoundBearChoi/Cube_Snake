using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RBSnake
{
    public class TouchImage : MonoBehaviour
    {
        [SerializeField]
        private RectTransform CenterRect;

        private TouchControl touchControl;
        public RuntimeAnimatorController TouchAnimator;
        public Animator animator;

        private void Start()
        {
            touchControl = FindObjectOfType<TouchControl>();   
        }

        void Update()
        {
            animator.gameObject.transform.position = touchControl.TouchPos;
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

        public Vector2 GetCenterPos()
        {
            return CenterRect.position;
        }
    }
}