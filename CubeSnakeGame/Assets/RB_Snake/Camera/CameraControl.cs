using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class CameraControl : MonoBehaviour
    {
        public Animator cameraAnimator;
        private Coroutine ShakeRoutine;
        private Coroutine SlowMotionRoutine = null;

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

        public void TriggerSlowMotion(float timeScale, float time)
        {
            if (SlowMotionRoutine == null)
            {
                Debug.Log("slow motion triggered");
                StartCoroutine(_SlowMotion(timeScale, time));
            }
        }

        IEnumerator _ShakeCamera()
        {
            cameraAnimator.SetBool("CameraShake", true);

            yield return new WaitForSeconds(0.11f);

            cameraAnimator.SetBool("CameraShake", false);
            ShakeRoutine = null;
        }

        IEnumerator _SlowMotion(float timeScale, float time)
        {
            Time.timeScale = timeScale;
            yield return new WaitForSeconds(time);

            Time.timeScale = 1f;

            SlowMotionRoutine = null;
        }
    }
}