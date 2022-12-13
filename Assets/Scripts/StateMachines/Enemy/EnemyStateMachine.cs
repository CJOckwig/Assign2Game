using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    // Start is called before the first frame update
    [field: SerializeField] public float MovementSpeed {get; set; } = 5.0f;
    [field: SerializeField] public float PlayerChaseRange {get;set;} = 7.0f;
    [field:SerializeField] public float PlayerAttackRange {get; set;} = 1.5f;
    [field: SerializeField] public int AttackDamage {get; set;}
    [field: SerializeField] public float AttackKnockback {get;set;} = 10.0f;
    [field: SerializeField] public Animator Animator {get; set;}
    [field: SerializeField] public WeaponDamage Weapon {get; set;}
    [field: SerializeField] public NavMeshAgent NavMeshAgent {get; set;}
    [field: SerializeField] public CharacterController CharacterController {get; set;}
    [field: SerializeField] public Health Health {get;set;}
    public List<Transform> PatrolPoints = new List<Transform>();
    public int CurrentPatrolPoint {get; set;} = 0;
    public float PatrolPointRange {get;set;} = 1.0f;
    public GameObject Player {get;set;}

    void Awake() {
        foreach(var go in GameObject.FindGameObjectsWithTag("Patrolpoint"))
        {
            PatrolPoints.Add(go.GetComponent<Transform>());
        }
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        NavMeshAgent.updatePosition = false;
        NavMeshAgent.updateRotation = false;
        //SwitchState(new EnemyIdleState(this));
    }

    // Update is called once per frame
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerChaseRange);
        
    }
    void OnEnable() {
        Health.DamageEvent += OnDamage;
        Health.DeathEvent += OnDeath;
    }
    void OnDisable() {
        Health.DamageEvent -= OnDamage;
        Health.DeathEvent -= OnDeath;
    }
    
    void OnDamage()
    {
        SwitchState(new EnemyImpactState(this));
    }
    void OnDeath()
    {
        SwitchState(new EnemyDeathState(this));
    }

}
