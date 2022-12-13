using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine)   
    {
    _attack = _stateMachine.Attacks[attackIndex];
    }
    Attack _attack;
    float _previousAnimationFrameTime = 0.0f;
    bool _forceApplied = false;


    public override void Enter()
    {
        _stateMachine.Weapon.SetAttackData(_attack.Damage, _attack.Knockback);
        _stateMachine.Animator.CrossFadeInFixedTime(_attack.AnimationName, _attack.TransitionTime);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        FaceTarget();
        float normalizedTime = GetNormalizedTime(_stateMachine.Animator);
        if (normalizedTime >= _previousAnimationFrameTime && normalizedTime < 1.0f)
        {
            if(_stateMachine.InputReader.IsAttacking)
            {
              //  TryComboAttack(normalizedTime);
            }
            if(normalizedTime >= _attack.ForceTime)
            {
              TryApplyForce();
            }
            if(_stateMachine.InputReader.IsAttacking)
            {
                TryComboAttack(normalizedTime);
            }
        //combo attack
        } else
        {
            if(_stateMachine.Targeter.CurrentTarget == null)
            {
                _stateMachine.SwitchState(new PlayerMovementState(_stateMachine));
            }//else
         //transition to another state
        }
        //_previousAnimationFrameTime = normailzedTime;
        if(_stateMachine.Targeter.CurrentTarget == null)
        {
            _stateMachine.SwitchState(new PlayerMovementState(_stateMachine));
        }
    }
    public override void Exit()
    {
    }
    void TryComboAttack(float normalizedTime)
    {
        if(_attack.ComboIndex == -1 || normalizedTime < _attack.ComboTime) { return; }
        _stateMachine.SwitchState(new PlayerAttackState(_stateMachine, _attack.ComboIndex));

    }
    void TryApplyForce()
    {
        if(_forceApplied){ return; }
        _stateMachine.ForceReceiver.AddForce(_stateMachine.transform.forward * _attack.Force);
        _forceApplied = true;
    }

}
