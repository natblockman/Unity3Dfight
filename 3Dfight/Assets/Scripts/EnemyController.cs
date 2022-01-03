using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState{
    CHASE,
    ATTACK

}
public class EnemyController : MonoBehaviour
{
    private CharacterAnimation enemyAnim;
    private NavMeshAgent navMeshAgent;

    private Transform playerTarget;
    public Transform LookAtTarget;

    public float moveSpeed = 3.5f;
    public float attackDistance = 1f;
    public float chaseAfterAttackDistance = 1f;

    public float waitBeforeAttackTime = 1.5f;
    private float attackTimer;

    private EnemyState enemyState;

    public GameObject attackPoint;

    private CharacterSoundFX SoundFX;

    // Start is called before the first frame update
    void Awake()
    {
        enemyAnim = GetComponent<CharacterAnimation>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        SoundFX = GetComponentInChildren<CharacterSoundFX>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void Start()
    {
        enemyState = EnemyState.CHASE;

        attackTimer = waitBeforeAttackTime;
    }
    void Update()
    {
        if(enemyState== EnemyState.CHASE)
        {
            ChasePlayer();
        }
        if(enemyState== EnemyState.ATTACK)
        {
            transform.LookAt(LookAtTarget);
            AttackPlayer();
        }
    }
    void ChasePlayer()
    {
        navMeshAgent.SetDestination(playerTarget.position);
        navMeshAgent.speed = moveSpeed;

        if (navMeshAgent.velocity.sqrMagnitude == 0)
        {
            enemyAnim.Walk(false);
        }
        else
        {
            enemyAnim.Walk(true);
        }

        if(Vector3.Distance(transform.position,playerTarget.position) <= attackDistance)
        {
            enemyState = EnemyState.ATTACK;
        }
    }
    void AttackPlayer()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;

        enemyAnim.Walk(false);

        attackTimer+=Time.deltaTime;

        if (attackTimer > waitBeforeAttackTime)
        {
            if (Random.Range(0, 2) > 0)
            {
                enemyAnim.Attack0();
                SoundFX.Attack_Sound1();
            }
            else
            {
                enemyAnim.Attack1();
                SoundFX.Attack_Sound2();
            }

            attackTimer=0;
        }
        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chaseAfterAttackDistance)
        {
            navMeshAgent.isStopped=false;
            enemyState = EnemyState.CHASE;
        }
    }
    void Active_AttackPoint()
    {
        attackPoint.SetActive(true);
    }
    void Deactive_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
