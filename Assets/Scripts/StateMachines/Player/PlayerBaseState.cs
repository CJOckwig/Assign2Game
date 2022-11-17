using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    // Start is called before the first frame update
    #region Animator Hash Data
    protected readonly int MovementSpeedHash = Animator.StringToHash("MovementSpeed");
    protected readonly int MovementBlendTree = Animator.StringToHash("MovementBlendTree");
    #endregion

    #region Damping Data
    protected const float AnimationDamping = 0.1f;
    protected const float RotationDamping = 10.0f;
    protected const float CrossFadeDuration = 1.0f;

    #endregion
    protected PlayerStateMachine _stateMachine;
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }
    protected void Move(Vector3 movement, float deltaTime)
    {
        _stateMachine.CharacterController.Move((movement+_stateMachine.ForceReceiver.Movement) *deltaTime);
    }
    protected void FaceTarget()
    {
        if(_stateMachine.Targeter.CurrentTarget == null)
        {
            return;
        }
        Vector3 lookPosition = _stateMachine.Targeter.CurrentTarget.transform.position - _stateMachine.transform.position;
        lookPosition.y = 0.0f;
        _stateMachine.transform.rotation = Quaternion.LookRotation(lookPosition);
    }
}
