using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        _stateMachine.NavMeshAgent.velocity = Vector3.zero;
    }

    public override void Tick(float deltaTime)
    {
        if(!IsInChaseRange())
        {
            _stateMachine.SwitchState(new EnemyIdleState(_stateMachine));
            return;
        }
        if(IsInAttackRange())
        {
            //_stateMachine.SwitchState(new EnemyAttackingState(_stateMachine));
            return;
        }
        MoveTowardsPlayer(deltaTime);
        FacePlayer();
        
    }
    void MoveTowardsPlayer(float deltaTime)
        {
            if(_stateMachine.NavMeshAgent.isOnNavMesh)
            {
                _stateMachine.NavMeshAgent.destination = _stateMachine.Player.transform.position;
                Move(_stateMachine.NavMeshAgent.desiredVelocity.normalized * _stateMachine.MovementSpeed, deltaTime);
            }
            _stateMachine.NavMeshAgent.velocity = _stateMachine.CharacterController.velocity;
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
