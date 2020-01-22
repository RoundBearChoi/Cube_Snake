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
            transitionCanvas = FindObjectOfType<UITransitionCanvas>();

            if (transitionCanvas != null)
            {
                transitionCanvas.TransitionUIAnimator.SetBool("TurnOnTransitionUI", false);
            }
        }

        private void Update()
        {
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