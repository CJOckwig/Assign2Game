using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine)    {    }

    public override void Enter()
    {
    FacePlayer();
    _stateMachine.Weapon.SetAttackData(_stateMachine.AttackDamage, _stateMachine.AttackKnockback);
        }

    public override void Exit()    {    }

    public override void Tick(float deltaTime)
    {
        if(GetNormalizedTime(_stateMachine.Animator)>= 1.0f)
        {
            _stateMachine.SwitchState(new EnemyChasingState(_stateMachine));
            return;
        }

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
