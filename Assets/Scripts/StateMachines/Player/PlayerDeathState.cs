using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public PlayerDeathState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Tick(float deltaTime)
    {
    }
}
