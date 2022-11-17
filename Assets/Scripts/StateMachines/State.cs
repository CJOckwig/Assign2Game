using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{

    const string AttackingAnimationTag = "Attack";
    protected float GetNormalizedTime(Animator animator)
    {
        AnimatorStateInfo currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextStateInfo = animator.GetNextAnimatorStateInfo(0);
        if(animator.IsInTransition(0) && nextStateInfo.IsTag(AttackingAnimationTag))
        {
            return nextStateInfo.normalizedTime;
        }
        if(!animator.IsInTransition(0) && currentStateInfo.IsTag(AttackingAnimationTag))
        {
            return currentStateInfo.normalizedTime;
        }
        return 0.0f;
    }
    public abstract void Enter();
    public abstract void Tick(float deltaTime);
    public abstract void Exit();



}
