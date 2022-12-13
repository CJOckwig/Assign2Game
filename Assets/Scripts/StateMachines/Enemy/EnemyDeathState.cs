using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{

    const float DestroyTime = 5.0f;
    public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        GameObject.Destroy(_stateMachine.gameObject, DestroyTime);
    }

    public override void Exit()
    {
    }

    public override void Tick(float deltaTime)
    {
    }
}
