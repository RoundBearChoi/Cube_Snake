using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class SceneTransitionState : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UITransitionCanvas canvas = animator.GetComponentInParent<UITransitionCanvas>();
            canvas.TriggerSceneTransition();
        }
    }
}
