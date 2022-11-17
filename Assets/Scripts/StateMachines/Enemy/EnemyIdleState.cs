using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    // Start is called before the first frame update
    #region 
    [SerializeField] float _idleWaitTime = 2.0f;
    float _idleTimer = 0.0f;

    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        _idleTimer = _idleWaitTime;
        _stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, CrossFadeDuration);
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Tick(float deltaTime)
    {
        _idleTimer-=deltaTime;
        if(_idleTimer<=0.0f)
        {
            if(IsInChaseRange())
            {
                return;
            }else
            {
                return;
            }
        }else 
        {
            Move(deltaTime);
            _stateMachine.Animator.SetFloat(MovementBlendTreeHash, 0.0f, AnimationDamping, deltaTime);
        }
    }
    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
