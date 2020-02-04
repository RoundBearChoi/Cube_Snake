using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class CameraControl : MonoBehaviour
    {
        public Animator cameraAnimator;
        private Coroutine ShakeRoutine = null;
        private Coroutine ZoomInOutRoutine = null;

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

            yield return new WaitForSeconds(0.11f);

            cameraAnimator.SetBool("CameraShake", false);
            ShakeRoutine = null;
        }

        public void ZoomInAndOut(float timeScale, float time)
        {
            if (ZoomInOutRoutine != null)
            {
                StopCoroutine(ZoomInOutRoutine);
            }

            ZoomInOutRoutine = StartCoroutine(_ZoomInAndOut(timeScale, time));
        }

        IEnumerator _ZoomInAndOut(float timeScale, float time)
        {
            cameraAnimator.SetBool("Zoom", true);
            Time.timeScale = timeScale;

            yield return new WaitForSeconds(time);

            Time.timeScale = 1f;
            cameraAnimator.SetBool("Zoom", false);
            ZoomInOutRoutine = null;
        }
    }
}