using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    public PlayerMovementState(PlayerStateMachine stateMachine) : base(stateMachine)    {    }
    public override void Enter() 
    {  
        _stateMachine.InputReader.JumpEvent += OnJump;
        _stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTree, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        if(_stateMachine.InputReader.IsAttacking)
        {
            _stateMachine.SwitchState(new PlayerAttackState(_stateMachine, 0));
        }
        if(_stateMachine.InputReader.MovementValue == Vector2.zero)
        {
        _stateMachine.Animator.SetFloat("MovementSpeed", 0.0f, AnimationDamping, deltaTime);
        return;
        }
        Vector3 movement = MoveWithCamera();
        _stateMachine.CharacterController.Move(movement * _stateMachine.MovementSpeed * deltaTime);
        _stateMachine.transform.rotation = Quaternion.LookRotation(movement);
        _stateMachine.Animator.SetFloat("MovementSpeed", 1.0f, AnimationDamping, deltaTime );
        Move(movement * _stateMachine.MovementSpeed, deltaTime);
        Rotate(movement, deltaTime);
    }
    Vector3 MoveWithCamera()
    {
        Vector3 forward = _stateMachine.MainCameraTransform.forward;
        Vector3 right = _stateMachine.MainCameraTransform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        forward.Normalize();
        right.Normalize();
        return forward * _stateMachine.InputReader.MovementValue.y +
         right * _stateMachine.InputReader.MovementValue.x;
    }
    void Rotate(Vector3 movement, float deltaTime)
    {
        _stateMachine.transform.rotation = Quaternion.Lerp(
            _stateMachine.transform.rotation,
            Quaternion.LookRotation(movement),
            RotationDamping* deltaTime
        );
    }
    void OnJump()
    {
        _stateMachine.SwitchState(new PlayerJumpingState(_stateMachine));
    }
    public override void Exit()
    {
        _stateMachine.InputReader.JumpEvent -= OnJump;
    }

}
