using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;
    public int staminaGain;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float patrolSpeed;
    public float chaseSpeed;

    //Attacking
    public float timeBetweenAttacks;
    public float timeWhenHitsPlayer;
    bool alreadyAttacked;
    public bool meleeEnemy;
    public GameObject projectile;
    public float meleePower;
    public int meleeDamage;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator anim;
    public float deathAnimLength;
    private bool isAlive = true;

    private void Awake()
    {
        player = GameObject.Find("Character").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        Collider[] hitplayersight  = Physics.OverlapSphere(transform.position, sightRange, whatIsPlayer);
        Collider[] hitplayerattack = Physics.OverlapSphere(transform.position, attackRange, whatIsPlayer);

        playerInSightRange = hitplayersight.Length > 0;
        playerInAttackRange = hitplayerattack.Length > 0;

        if (isAlive)
        {
            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }
    }

    private void Patroling()
    {
        agent.speed = patrolSpeed;
        anim.SetFloat("Speed", agent.speed);
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.speed = chaseSpeed;
        anim.SetFloat("Speed", agent.speed);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        if (!meleeEnemy)
            transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            anim.ResetTrigger("isAttacking");
            anim.SetTrigger("isAttacking");

            if (!meleeEnemy)
                Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody>();
            else
            {
                StartCoroutine(HitPlayer());
            }
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    IEnumerator HitPlayer()
    {
        yield return new WaitForSecondsRealtime(timeWhenHitsPlayer);

        player.GetComponent<Rigidbody>().AddForce(transform.forward * meleePower, ForceMode.Impulse);
        player.GetComponent<CharacterHealthAndStamina>().removeHealth(meleeDamage);
    }
    
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            isAlive = false;
            anim.SetTrigger("isDying");
            Invoke(nameof(DestroyEnemy), deathAnimLength);
            player.GetComponent<CharacterHealthAndStamina>().addStamina(staminaGain);
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
