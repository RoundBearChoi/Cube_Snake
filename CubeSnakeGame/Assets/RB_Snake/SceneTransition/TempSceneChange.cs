using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class TempSceneChange : MonoBehaviour
    {
        public string NextScene;

        UITransitionCanvas transitionCanvas;

        private void Start()
        {
            // keep only one copy
            UITransitionCanvas[] arr = FindObjectsOfType<UITransitionCanvas>();

            transitionCanvas = arr[0];

            foreach(UITransitionCanvas c in arr)
            {
                if (c != transitionCanvas)
                {
                    Destroy(c.gameObject);
                }
            }

            // turn off transition ui in the beginning of a scene
            if (transitionCanvas != null)
            {
                transitionCanvas.TransitionUIAnimator.SetBool("TurnOnTransitionUI", false);
            }
        }

        private void Update()
        {
            //trigger a scene transition
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (transitionCanvas != null)
                {
                    transitionCanvas.NextScene = NextScene;
                    transitionCanvas.TransitionUIAnimator.SetBool("TurnOnTransitionUI", true);
                }
            }
        }
    }
}