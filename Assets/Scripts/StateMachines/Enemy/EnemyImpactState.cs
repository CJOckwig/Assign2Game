using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpactState : EnemyBaseState
{
    [SerializeField] float _impactDuration = 1.0f;
    public EnemyImpactState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    // Start is called before the first frame update
    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Tick(float deltaTime)
    {
        _impactDuration -= deltaTime;
        if(_impactDuration <= 0.0f)
        {
            _stateMachine.SwitchState(new EnemyIdleState(_stateMachine));
        }
        Move(deltaTime);
    }
}
