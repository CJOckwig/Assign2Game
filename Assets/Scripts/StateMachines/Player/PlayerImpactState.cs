using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpactState : PlayerBaseState
{
    [SerializeField] float _impactDuration = 1.0f;
    public PlayerImpactState(PlayerStateMachine stateMachine) : base(stateMachine)    {    }

    public override void Enter()    {    }

    public override void Exit()    {    }

    public override void Tick(float deltaTime)
    {
        _impactDuration -= deltaTime;
        if(_impactDuration <= .0f)
        {
            _stateMachine.SwitchState(new PlayerMovementState(_stateMachine));
            return;
        }
        Move(deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
