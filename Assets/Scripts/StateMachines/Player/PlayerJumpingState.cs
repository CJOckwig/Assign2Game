using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    #region Animation Data
    readonly int JumpHash = Animator.StringToHash("Jump");
Vector3 _momentum;
#endregion
    public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {

    _stateMachine.ForceReceiver.AddJumpForce(_stateMachine.JumpForce);    
    _momentum = _stateMachine.CharacterController.velocity;
    _momentum.y = 0.0f;
    //_stateMachine.Animator.CrossFadeInFixedTime(JumpHash, CrossFadeDuration); 
    }

    public override void Exit()
    {
    }

    public override void Tick(float deltaTime)
    {
        Move(_momentum, deltaTime);
        FaceTarget();
        if(_stateMachine.CharacterController.velocity.y <=0.0f);
        {
            _stateMachine.SwitchState(new PlayerFallingState(_stateMachine));
            return;
        }
    }

}
