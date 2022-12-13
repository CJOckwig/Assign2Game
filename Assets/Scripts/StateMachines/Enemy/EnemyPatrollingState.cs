using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingState : EnemyBaseState
{
    public EnemyPatrollingState(EnemyStateMachine stateMachine) : base(stateMachine){    }

    public override void Enter()
    {
    _stateMachine.NavMeshAgent.destination = _stateMachine.PatrolPoints[_stateMachine.CurrentPatrolPoint].position;
    
    }

    public override void Exit(){}
    public override void Tick(float deltaTime)
    {
        if(HasReachedPatrolPoint())
        {
            _stateMachine.CurrentPatrolPoint = (_stateMachine.CurrentPatrolPoint + 1) % _stateMachine.PatrolPoints.Count;
            _stateMachine.SwitchState(new EnemyIdleState(_stateMachine));
            return;
        }
        if(IsInChaseRange())
        {
            _stateMachine.SwitchState(new EnemyChasingState(_stateMachine));
            return;
        }
        MoveTowardsPatrolPoint(deltaTime);
        FacePatrolPoint();
        

    }

    // Start is called before the first frame update
    void Start() {  }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveTowardsPatrolPoint(float deltaTime)
    {
        if(_stateMachine.PatrolPoints.Count == 0) {return;}
        if(_stateMachine.NavMeshAgent.isOnNavMesh)
        {
            _stateMachine.NavMeshAgent.destination = _stateMachine.PatrolPoints[_stateMachine.CurrentPatrolPoint].position;
            Move(_stateMachine.NavMeshAgent.desiredVelocity.normalized * _stateMachine.MovementSpeed, deltaTime);
            _stateMachine.NavMeshAgent.velocity = _stateMachine.CharacterController.velocity;
        }
    }
    protected void FacePatrolPoint()
    {
        if(_stateMachine.PatrolPoints.Count == 0) {return ;}
        Vector3 lookPosition = _stateMachine.PatrolPoints[_stateMachine.CurrentPatrolPoint].position - _stateMachine.transform.position;
        lookPosition.y = 0.0f;//gamers dont look up.
        _stateMachine.transform.rotation = Quaternion.LookRotation(lookPosition);
    }
    protected bool HasReachedPatrolPoint()
    {
        if(_stateMachine.PatrolPoints.Count == 0){ return false;}
        float distanceToPatrolpoint = 
        (_stateMachine.PatrolPoints[_stateMachine.CurrentPatrolPoint].position - _stateMachine.transform.position).sqrMagnitude; 
        if(distanceToPatrolpoint <= _stateMachine.PatrolPointRange * _stateMachine.PatrolPointRange)
        {
            return true;
        } else {
            return false;
        }
   
    }
}
