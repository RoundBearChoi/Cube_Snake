using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class CameraControl : MonoBehaviour
    {
        public Animator cameraAnimator;
        private Coroutine ShakeRoutine;

        private void Start()
        {
            cameraAnimator = GetComponent<Animator>();
        }

        public void ShakeCamera()
        {
            if (ShakeRoutine != null)
            {
                StopCoroutine(ShakeRoutine);
            }

            ShakeRoutine = StartCoroutine(_ShakeCamera());
        }

        IEnumerator _ShakeCamera()
        {
            cameraAnimator.SetBool("CameraShake", true);

            yield return new WaitForSeconds(0.125f);

            cameraAnimator.SetBool("CameraShake", false);
            ShakeRoutine = null;
        }
    }
}