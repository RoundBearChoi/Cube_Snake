using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class SceneChanger : MonoBehaviour
    {
        public string NextScene;

        UITransitionCanvas transitionCanvas;

        private void Start()
        {
            // keep only one copy
            UITransitionCanvas[] arr = FindObjectsOfType<UITransitionCanvas>();

            if (arr.Length > 0)
            {
                transitionCanvas = arr[0];

                foreach (UITransitionCanvas c in arr)
                {
                    if (c != transitionCanvas)
                    {
                        Destroy(c.gameObject);
                    }
                }
            }

            // turn off transition ui in the beginning of a scene
            if (transitionCanvas != null)
            {
                if (transitionCanvas != null)
                {
                    transitionCanvas.TransitionUIAnimator.SetBool("TurnOnTransitionUI", false);
                }
            }
        }

        public void ChangeScene()
        {
            if (transitionCanvas != null)
            {
                transitionCanvas.NextScene = NextScene;
                transitionCanvas.TransitionUIAnimator.SetBool("TurnOnTransitionUI", true);
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(NextScene);
            }
        }
    }
}