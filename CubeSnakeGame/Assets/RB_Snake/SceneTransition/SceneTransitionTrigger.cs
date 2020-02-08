using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class SceneTransitionTrigger : MonoBehaviour
    {
        public void TriggerTransition()
        {
            UITransitionCanvas canvas = this.GetComponentInParent<UITransitionCanvas>();
            canvas.TriggerSceneTransition();
        }
    }
}