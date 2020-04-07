using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLockIconToDefault : StateMachineBehaviour
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime > 0.99f)
        {
            animator.SetBool("ShakeLock", false);
        }
    }
}
