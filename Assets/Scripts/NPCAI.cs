using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] Transform playerPoint;
    public LayerMask ground, playerLayer;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkRange;

    [SerializeField] float timeBetweenAttacks = 2.0f;
    bool alreadyAttacked;
    public GameObject sphere;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    Animator animator;

    [SerializeField] private float _minDamage = 5f;
    [SerializeField] private float _maxDamage = 15f;

    Health damage;

    public AudioSource enemyAttackVoice;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        damage = GetComponent<Health>();
    }


    void Update()
    {

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if (!playerInSightRange && !playerInAttackRange)
        {

            patroling();
            animator.SetBool("isWalking", true);
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            playerPoint = playerPoint.transform;
            chasePlayer();
            animator.SetBool("isWalking", true);
        }

        if (playerInSightRange && playerInAttackRange)
        {
            if (playerInSightRange && playerInAttackRange)
            {
                if (playerPoint.GetComponent<Health>().currentHealth <= 0) // Check player's health before attacking
                {
                    return;  // Exit the function if player is dead
                }

                attackPlayer();  // Obje fırlatılmasını başlat
            }
        }
    }

    void patroling()
    {
        if (!walkPointSet)
        {

            searchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1.0f)
        {

            walkPointSet = false;
        }

    }
    void searchWalkPoint()
    {
        float randomX = UnityEngine.Random.Range(-walkRange, walkRange);
        float randomZ = UnityEngine.Random.Range(-walkRange, walkRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2.0f, ground))
        {

            walkPointSet = true;
        }
    }
    void chasePlayer()
    {
        agent.SetDestination(playerPoint.position);
    }

    void attackPlayer()
    {


        agent.SetDestination(transform.position);
        transform.LookAt(playerPoint);
        if (!alreadyAttacked)
        {
            // Obje fırlat
            // Rigidbody rb = Instantiate(sphere, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            // rb.AddForce(transform.forward * 25f, ForceMode.Impulse);
            // rb.AddForce(transform.up * 7f, ForceMode.Impulse);

            // Player'a hasar ver
            float damage = Random.Range(_minDamage, _maxDamage);
            playerPoint.GetComponent<Health>().TakeDamage(damage);

            alreadyAttacked = true;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }
    void resetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NotaMermi"))
        {
            damage.TakeDamage(30);
        }
    }

}
